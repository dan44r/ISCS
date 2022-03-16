using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace ISCS.Admin
{
    public partial class NonPendingList : System.Web.UI.Page
    {
        protected string strHeading = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["SearchKey"] = "";
                ViewState["SortOrder"] = "ShipFromDate desc";
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataSet ds;
            if (Request.QueryString["RequestType"] != null && Request.QueryString["RequestType"].ToUpper() == "ALL")
            {
                ds = PickupRequestBL.FetchAllPickupRequest("All");
                strHeading = "All Pickup Requests List";
            }
            else if (Request.QueryString["RequestType"] != null && Request.QueryString["RequestType"].ToUpper() == "PENDING")
            {
                ds = PickupRequestBL.FetchAllPickupRequest("Pending");
                strHeading = "Pending Pickup Requests List";
            }
            else
            {
                ds = PickupRequestBL.FetchAllPickupRequest("NonPending");
                strHeading = "Non Pending Pickup Requests List";
            }
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.Sort = ViewState["SortOrder"].ToString();
            gridNonPending.DataSource = dv;
            gridNonPending.DataBind();
        }
        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            int stat = PickupRequestBL.DeletePickupRequest(Convert.ToInt32(btnSender.CommandArgument));
            if (stat > 0)
            {
                lblMsg.Text = "The user has been deleted Successfully.";
                BindGrid();
            }
            if (stat == -547)
            {
                lblMsg.Text = "Cannot delete record due to database exception.";
            }
        }
        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            hidFUserid.Value = btnSender.CommandArgument;
        }

        protected void gridNonPending_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridNonPending.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridNonPending_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortShipFromDate")
            {
                if (ViewState["SortOrder"].ToString() == "ShipFromDate desc")
                {
                    ViewState["SortOrder"] = "ShipFromDate asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ShipFromDate desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortGLSTrackingNumber")
            {

                if (ViewState["SortOrder"].ToString() == "GLSTrackingNumber desc")
                {
                    ViewState["SortOrder"] = "GLSTrackingNumber asc";
                }
                else
                {
                    ViewState["SortOrder"] = "GLSTrackingNumber desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortFromContact")
            {

                if (ViewState["SortOrder"].ToString() == "FromContact desc")
                {
                    ViewState["SortOrder"] = "FromContact asc";
                }
                else
                {
                    ViewState["SortOrder"] = "FromContact desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortToContact")
            {

                if (ViewState["SortOrder"].ToString() == "ToContact desc")
                {
                    ViewState["SortOrder"] = "ToContact asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ToContact desc";
                }
                BindGrid();

            }

        }

        protected void gridNonPending_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strShipDate = ((Label)e.Row.FindControl("lblShipDate")).Text;
                ((Label)e.Row.FindControl("lblShipFromDate")).Text = Convert.ToDateTime(strShipDate).ToString("MM/dd/yyyy");

                string WarehouseTypeFlag = ((Label)e.Row.FindControl("lblWarehouseTypeFlag")).Text;

                if (WarehouseTypeFlag == "0")
                    ((Label)e.Row.FindControl("lblWarehouseType")).Text = " N/A &nbsp;";
                else if (WarehouseTypeFlag == "1")
                    ((Label)e.Row.FindControl("lblWarehouseType")).Text = " To Warehouse &nbsp;";
                else if (WarehouseTypeFlag == "2")
                    ((Label)e.Row.FindControl("lblWarehouseType")).Text = "From Warehouse &nbsp;";
                else if (WarehouseTypeFlag == "3")
                    ((Label)e.Row.FindControl("lblWarehouseType")).Text = "From Warehouse To Warehouse &nbsp;";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["SearchKey"] = txtSearchKey.Text.ToString().Trim();
            BindGrid();
        }
    }
}
