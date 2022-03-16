using System;
using System.Data;
using BusinessLogicLayer;
using CF.Web.Security;

namespace ISCS
{
    public partial class Shipment_viewNS : System.Web.UI.Page
    {
        public int transportationmode = 0;
        public string PickupRequestID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["tno"] != null)
                {
                    BindValue(Request.QueryString["tno"].ToString());
                }

            }
        }

        protected void BindValue(string trackingno)
        {
            if (trackingno != "")
            {
                string strTrackingNo = Request.QueryString["tno"].ToString();
                DataSet ds = TBillsBL.SelectTrackingBillByTackingNo(strTrackingNo);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    lblTrackingNo.Text = ds.Tables[0].Rows[0]["tracking_no"].ToString();
                    lblShipperRefNo.Text = ds.Tables[0].Rows[0]["ShipFromRefNumber"].ToString();
                    lblShipDate.Text = ds.Tables[0].Rows[0]["Ship_Date"].ToString();
                    lblConsigneeRef.Text = ds.Tables[0].Rows[0]["ShipToConsigneeRefNumber"].ToString();
                    lblStatus.Text = ds.Tables[0].Rows[0]["StatusDescription"].ToString();
                    lblServiceLevel.Text = ds.Tables[0].Rows[0]["TransModeService1"].ToString();
                    string strMonthName = (Convert.ToDateTime(ds.Tables[0].Rows[0]["Status_Date"])).ToString("MMMM");

                    lblDate.Text = (Convert.ToDateTime(ds.Tables[0].Rows[0]["Status_Date"])).ToString("MMMM") + " " + (Convert.ToDateTime(ds.Tables[0].Rows[0]["Status_Date"])).Day + " " + (Convert.ToDateTime(ds.Tables[0].Rows[0]["Status_Date"])).Year;
                    lblTime.Text = (Convert.ToDateTime(ds.Tables[0].Rows[0]["Status_Date"])).Hour.ToString() + ":" + (Convert.ToDateTime(ds.Tables[0].Rows[0]["Status_Date"])).ToString("HH:mm");

                    string strFromText = "";
                    string strToText = "";
                    strFromText = ds.Tables[0].Rows[0]["ShipFromCompany"].ToString() + "<br />" + ds.Tables[0].Rows[0]["ShipFromAddress"].ToString() + "<br />" + ds.Tables[0].Rows[0]["ShipFromCity"].ToString();
                    if (ds.Tables[0].Rows[0].IsNull("ShipFromState") == false && ds.Tables[0].Rows[0]["ShipFromState"].ToString() != "")
                    {
                        strFromText = strFromText + ", " + ds.Tables[0].Rows[0]["ShipFromState"].ToString() + "<br />";
                    }
                    if (ds.Tables[0].Rows[0].IsNull("ShipFromPostalCode") == false && ds.Tables[0].Rows[0]["ShipFromPostalCode"].ToString() != "")
                    {
                        strFromText = strFromText + " " + ds.Tables[0].Rows[0]["ShipFromPostalCode"].ToString();
                    }
                    spanShipFrom.InnerHtml = strFromText;
                    strToText = ds.Tables[0].Rows[0]["ShipToCompany"].ToString() + "<br />" + ds.Tables[0].Rows[0]["ShipToAddress"].ToString() + "<br />" + ds.Tables[0].Rows[0]["ShipToCity"].ToString();
                    if (ds.Tables[0].Rows[0].IsNull("ShipToState") == false && ds.Tables[0].Rows[0]["ShipToState"].ToString() != "")
                    {
                        strToText = strToText + ", " + ds.Tables[0].Rows[0]["ShipToState"].ToString() + "<br />";
                    }
                    if (ds.Tables[0].Rows[0].IsNull("ShipToPostalCode") == false && ds.Tables[0].Rows[0]["ShipToPostalCode"].ToString() != "")
                    {
                        strToText = strToText + " " + ds.Tables[0].Rows[0]["ShipToPostalCode"].ToString();
                    }
                    spanShipTo.InnerHtml = strToText;
                    lblPieces.Text = ds.Tables[0].Rows[0]["Pieces"].ToString();
                    lblActualWeight.Text = ds.Tables[0].Rows[0]["Actual_Weight"].ToString();
                    lblDimWeight.Text = ds.Tables[0].Rows[0]["Dim_Weight"].ToString();
                    lblNotes.Text = ds.Tables[0].Rows[0]["Notes"].ToString();
                    if (ds.Tables[0].Rows[0].IsNull("TransMode") == false)
                    { transportationmode = Convert.ToInt32(ds.Tables[0].Rows[0]["TransMode"]); }
                    string strReqIDEncode = SecurityUtils.UrlEncode(Convert.ToString(ds.Tables[0].Rows[0]["PickupRequestId"].ToString()));
                    PickupRequestID = strReqIDEncode;
                }
                else
                {
                    pnlData.Visible = false;
                    lblError.Text = "No records found.";
                }
            }
        }
    }
}
