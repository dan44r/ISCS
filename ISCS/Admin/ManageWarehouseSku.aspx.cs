using BusinessLogicLayer;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class ManageWarehouseSku : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["SortOrder"] = "PartNumber_WI desc";
            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack && PreviousPage.IsPostBack)
            {
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            int strSkuid = 0;
            if (Page.PreviousPage != null)
            {
                ContentPlaceHolder contentPh = (ContentPlaceHolder)Page.PreviousPage.Form.FindControl("ContentPlaceHolder1");
                HiddenField hfskuid = (HiddenField)contentPh.FindControl("hidFSkuid");
                strSkuid = Convert.ToInt32(hfskuid.Value);
                ViewState["strSkuid"] = strSkuid;
            }
            else
            {
                strSkuid = Convert.ToInt32(ViewState["strSkuid"]);
            }

            DataSet ds;
            ds = WarehouseShipmentItemsBL.FetchAllWarehouseShipmentItemsBySkuId(strSkuid);

            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.Sort = ViewState["SortOrder"].ToString();
            gridUsers.DataSource = dv;
            gridUsers.DataBind();
        }

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            hidFInventoryid.Value = btnSender.CommandArgument;
        }

        protected void gridUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridUsers.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortmaskedskid")
            {
                if (ViewState["SortOrder"].ToString() == "maskedskid desc")
                {
                    ViewState["SortOrder"] = "maskedskid asc";
                }
                else
                {
                    ViewState["SortOrder"] = "maskedskid desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortPartNumber")
            {
                if (ViewState["SortOrder"].ToString() == "PartNumber_WI desc")
                {
                    ViewState["SortOrder"] = "PartNumber_WI asc";
                }
                else
                {
                    ViewState["SortOrder"] = "PartNumber_WI desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortLotNumber")
            {
                if (ViewState["SortOrder"].ToString() == "LotNumber_WI desc")
                {
                    ViewState["SortOrder"] = "LotNumber_WI asc";
                }
                else
                {
                    ViewState["SortOrder"] = "LotNumber_WI desc";
                }
                BindGrid();
            }
        }
    }
}
