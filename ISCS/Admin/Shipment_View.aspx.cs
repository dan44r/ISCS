using BusinessLogicLayer;
using CF.Web.Security;
using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class Shipment_View : System.Web.UI.Page
    {
        public int transportationmode = 0;
        public string PickupRequestID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack && PreviousPage.IsPostBack)
            {
                BindValues();
            }
        }
        protected void BindValues()
        {
            DataTable dtSI = null;
            int strtrackingbillid = 0;
            string strtrackingbillno = null;
            ContentPlaceHolder contentPh = (ContentPlaceHolder)Page.PreviousPage.Form.FindControl("ContentPlaceHolder1");
            HiddenField hftrackingbillid = (HiddenField)contentPh.FindControl("hdnTrackingBillId");
            HiddenField hftrackingbillno = (HiddenField)contentPh.FindControl("hdnTrackingNumber");
            if (hftrackingbillid != null)
            {
                if (hftrackingbillid.Value != null && hftrackingbillid.Value != "")
                {
                    strtrackingbillid = Convert.ToInt32(hftrackingbillid.Value);
                }
            }

            if (hftrackingbillno != null)
            {
                if (hftrackingbillno.Value != null && hftrackingbillno.Value != "")
                {
                    strtrackingbillno = hftrackingbillno.Value;
                }
            }

            if (strtrackingbillid > 0)
            {
                dtSI = TBillsBL.FetchByTrackingBillId(strtrackingbillid).Tables[0];
            }
            else
            {
                dtSI = TBillsBL.FetchByTrackingBillNo(strtrackingbillno).Tables[0];
            }

            if (dtSI.Rows.Count > 0)
            {
                pnltrack.Visible = true;
                pnlnorecord.Visible = false;
                hdtrackingbillid.Value = dtSI.Rows[0]["TrackingBillId"].ToString();
                hdairportid.Value = dtSI.Rows[0]["Airport_Id"].ToString();
                hdDimWeight.Value = dtSI.Rows[0]["dim_weight"].ToString();
                lblDimWeight.Text = dtSI.Rows[0]["dim_weight"].ToString();
                hdshipfromcompany.Value = dtSI.Rows[0]["ShipFromCompany"].ToString();
                hdshiptocompany.Value = dtSI.Rows[0]["ShipToCompany"].ToString();

                lbltrackingno.Text = dtSI.Rows[0]["tracking_no"].ToString();
                lblshipdate.Text = dtSI.Rows[0]["Ship_Date"].ToString();

                lblstatus.Text = dtSI.Rows[0]["StatusName"].ToString();
                DateTime dtime = Convert.ToDateTime(dtSI.Rows[0]["Status_Date"]);
                string month = string.Format("{0:d}", dtime).Split('/')[0];
                string day = string.Format("{0:d}", dtime).Split('/')[1];
                string year = string.Format("{0:d}", dtime).Split('/')[2];
                string hour = string.Format("{0:h hh H HH}", dtime).Split(' ')[0];
                string min = string.Format("{0:m mm}", dtime).Split(' ')[0];

                lblStatusDate.Text = dtSI.Rows[0]["status_date_new"].ToString();
                lblStatusHr.Text = hour.ToString() + ":" + min.ToString();

                lblpieces.Text = dtSI.Rows[0]["Pieces"].ToString();

                lblactualweight.Text = dtSI.Rows[0]["Actual_Weight"].ToString();

                lblnotes.Text = dtSI.Rows[0]["Notes"].ToString();

                StringBuilder sbshipper = new StringBuilder();
                sbshipper.Append(dtSI.Rows[0]["ShipFromCompany"] + ",<br />");
                sbshipper.Append(dtSI.Rows[0]["ShipFromAddress"] + ",<br />");
                sbshipper.Append(dtSI.Rows[0]["ShipFromCity"]);
                sbshipper.Append((dtSI.Rows[0]["ShipFromState"].ToString() != "") ? "," + dtSI.Rows[0]["ShipFromState"] : "");
                sbshipper.Append("<br />");
                sbshipper.Append((dtSI.Rows[0]["ShipFromPostalCode"].ToString() != "") ? " " + dtSI.Rows[0]["ShipFromPostalCode"] : "");

                lblshipper.Text = sbshipper.ToString();

                StringBuilder sbconsignee = new StringBuilder();
                sbconsignee.Append(dtSI.Rows[0]["ShipToCompany"] + ",<br />");
                sbconsignee.Append(dtSI.Rows[0]["ShipToAddress"] + ",<br />");
                sbconsignee.Append(dtSI.Rows[0]["ShipToCity"]);
                sbconsignee.Append((dtSI.Rows[0]["ShipToState"].ToString() != "") ? "," + dtSI.Rows[0]["ShipToState"] : "");
                sbconsignee.Append("<br />");
                sbconsignee.Append((dtSI.Rows[0]["ShipToPostalCode"].ToString() != "") ? " " + dtSI.Rows[0]["ShipToPostalCode"] : "");

                lblconsignee.Text = sbconsignee.ToString();

                if (dtSI.Rows[0].IsNull("TransMode") == false)
                {
                    lbltransmode.Text = dtSI.Rows[0]["TransMode"].ToString();
                    transportationmode = Convert.ToInt32(dtSI.Rows[0]["TransMode"]);
                }
                lblshipperrefno.Text = dtSI.Rows[0]["ShipFromRefNumber"].ToString();
                lblconsigneerefno.Text = dtSI.Rows[0]["ShipToConsigneeRefNumber"].ToString();
                hdPickupRequestId.Value = dtSI.Rows[0]["PickupRequestId"].ToString();
                string strReqIDEncode = SecurityUtils.UrlEncode(Convert.ToString(dtSI.Rows[0]["PickupRequestId"].ToString()));
                PickupRequestID = strReqIDEncode;
            }
            else
            {
                pnltrack.Visible = false;
                pnlnorecord.Visible = true;
            }
        }

        protected void btnRetuen_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageWarehouse.aspx");
        }

        protected void return_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageShipmentTracking.aspx");
        }
    }
}
