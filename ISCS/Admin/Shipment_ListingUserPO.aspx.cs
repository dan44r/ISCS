using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace ISCS.Admin
{
    public partial class Shipment_ListingUserPO : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!IsPostBack)
            {
                ViewState["SortOrder"] = "tracking_no desc";
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataSet ds;
            int AccountCodeId = 0;
            string tracking_no = null;
            DateTime strshippeddt = Convert.ToDateTime("1/1/1753 12:00:00 AM");


            if (Session["iTrackingNumber"] != null)
            {
                tracking_no = Convert.ToString(Session["iTrackingNumber"]);
                Session["iTrackingNumber"] = null;
                ViewState["tracking_no"] = tracking_no;
            }
            else if (ViewState["tracking_no"] != null)
            {
                tracking_no = Convert.ToString(ViewState["tracking_no"]);
            }
            if (Session["iAccountCodeId"] != null)
            {
                AccountCodeId = Convert.ToInt32(Session["iAccountCodeId"]);
                Session["iAccountCodeId"] = null;
                ViewState["AccountCodeId"] = AccountCodeId;
            }
            else if (ViewState["AccountCodeId"] != null)
            {
                AccountCodeId = Convert.ToInt32(ViewState["AccountCodeId"]);
            }
            if (Session["iShippedDates"] != null)
            {
                strshippeddt = Convert.ToDateTime(Session["iShippedDates"]);
                Session["iShippedDates"] = null;
                ViewState["strshippeddt"] = strshippeddt;

            }
            else if (ViewState["strshippeddt"] != null)
            {
                strshippeddt = Convert.ToDateTime(ViewState["strshippeddt"]);
            }

            ds = TBillsBL.FetchShipmentByPO(tracking_no, AccountCodeId, strshippeddt);

            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.Sort = ViewState["SortOrder"].ToString();
            gridUsers.DataSource = dv;
            gridUsers.DataBind();
        }

        protected void gridUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridUsers.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortShipDate")
            {
                if (ViewState["SortOrder"].ToString() == "ship_date desc")
                {
                    ViewState["SortOrder"] = "ship_date asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ship_date desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sorttrack")
            {
                if (ViewState["SortOrder"].ToString() == "tracking_no desc")
                {
                    ViewState["SortOrder"] = "tracking_no asc";
                }
                else
                {
                    ViewState["SortOrder"] = "tracking_no desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortStatus")
            {
                if (ViewState["SortOrder"].ToString() == "StatusName desc")
                {
                    ViewState["SortOrder"] = "StatusName asc";
                }
                else
                {
                    ViewState["SortOrder"] = "StatusName desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortcarrier")
            {

                if (ViewState["SortOrder"].ToString() == "GLSCarrierName desc")
                {
                    ViewState["SortOrder"] = "GLSCarrierName asc";
                }
                else
                {
                    ViewState["SortOrder"] = "GLSCarrierName desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortProNo")
            {

                if (ViewState["SortOrder"].ToString() == "ProNumber desc")
                {
                    ViewState["SortOrder"] = "ProNumber asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ProNumber desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortLastUpdated")
            {

                if (ViewState["SortOrder"].ToString() == "DateLastUpdated desc")
                {
                    ViewState["SortOrder"] = "DateLastUpdated asc";
                }
                else
                {
                    ViewState["SortOrder"] = "DateLastUpdated desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortPTno")
            {

                if (ViewState["SortOrder"].ToString() == "ShipToConsigneeRefNumber desc")
                {
                    ViewState["SortOrder"] = "ShipToConsigneeRefNumber asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ShipToConsigneeRefNumber desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortPOno")
            {

                if (ViewState["SortOrder"].ToString() == "ShipFromRefNumber desc")
                {
                    ViewState["SortOrder"] = "ShipFromRefNumber asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ShipFromRefNumber desc";
                }
                BindGrid();

            }
        }

        public string GetProSmall(string _pronumber)
        {
            string rpro = null;
            if (_pronumber.Length > 5)
            {
                rpro = _pronumber.Substring(0, 5);
            }
            else
            {
                rpro = _pronumber;
            }
            return rpro;
        }

        protected void lnktrackclick_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtn = (LinkButton)sender;
            hdnTrackingNumber.Value = lnkbtn.CommandArgument;
        }

        protected void gridUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strShipDate = ((Label)e.Row.FindControl("lblShipDate")).Text;
                if (strShipDate.Trim() != "")
                    ((Label)e.Row.FindControl("lblShipDate")).Text = Convert.ToDateTime(strShipDate).ToString("MM/dd/yyyy");

                string strlastupdated = ((Label)e.Row.FindControl("lbllastupdated")).Text;
                if (strlastupdated.Trim() != "")
                    ((Label)e.Row.FindControl("lbllastupdated")).Text = Convert.ToDateTime(strlastupdated).ToString("MM/dd/yyyy");

                string strAirportCode = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AirportCode"));
                string strStatusName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StatusName"));
                if (strAirportCode.Trim() != "")
                    ((Label)e.Row.FindControl("lblstatus")).Text = strStatusName + " - " + strAirportCode;
            }
        }
    }
}
