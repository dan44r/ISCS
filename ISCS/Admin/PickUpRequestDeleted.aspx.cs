using BusinessLogicLayer;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class PickUpRequestDeleted : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["SearchKey"] = "";
                ViewState["SortOrder"] = "ShipFromDate desc";
                drpStatus.Items.Add("All");
                drpStatus.Items.Add("Pending");
                drpStatus.Items.Add("NonPending");
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataSet ds;
            if (drpStatus.SelectedIndex == 1)
            {
                ds = PickupRequestBL.FetchAllPickupRequest("pdeleted");
            }
            else if (drpStatus.SelectedIndex == 2)
            {
                ds = PickupRequestBL.FetchAllPickupRequest("npdeleted");
            }
            else
            {
                ds = PickupRequestBL.FetchAllPickupRequest("alldeleted");
            }

            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.Sort = ViewState["SortOrder"].ToString();
            gridDeleted.DataSource = dv;
            gridDeleted.DataBind();
        }

        protected void gridDeleted_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDeleted.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridDeleted_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void gridDeleted_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strShipDate = ((Label)e.Row.FindControl("lblShipDate")).Text;
                ((Label)e.Row.FindControl("lblShipFromDate")).Text = Convert.ToDateTime(strShipDate).ToString("MM/dd/yyyy");
                string strRequestType = ((Label)e.Row.FindControl("lblRequestType")).Text;
                if (strRequestType == "2")
                {
                    e.Row.BackColor = System.Drawing.Color.FromName("#E8FFE9");
                }
                string strTransModeName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TransModeName"));
                string strStatus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Status"));

                if (strTransModeName.Trim() != "")
                { e.Row.ToolTip = strStatus.Trim() + " - " + strTransModeName.Trim(); }
                else if (strTransModeName.Trim() == "")
                { e.Row.ToolTip = strStatus.Trim(); }

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
            BindGrid();
        }
    }
}
