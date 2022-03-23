using BusinessLogicLayer;
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class ManageWarehouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string strpagename = System.IO.Path.GetFileName(HttpContext.Current.Request.FilePath);
                int userTypeId = Convert.ToInt32(Session["cacheUserRole"]);
                DataTable dtUserTypeSectionXref = UserTypeSectionsXrefBL.GetSectionIdByUserTypeId(userTypeId);
                bool redirectionflg = true;
                foreach (DataRow dr in dtUserTypeSectionXref.Rows)
                {
                    DataTable dtSection = SectionsBL.GetSectionById(Convert.ToInt32(dr["SectionId"]));
                    if (strpagename == dtSection.Rows[0]["SectionUrl"].ToString())
                    {
                        redirectionflg = false;
                    }
                }
                if (redirectionflg)
                {
                    Response.Redirect(ResolveUrl("~/Admin/Error.aspx"));
                }


                ViewState["SearchKey"] = "";
                ViewState["SortOrder"] = "WareHouseName desc";
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            if (Session["cacheUserRole"] != null)
            {
                int userTypeId = Convert.ToInt32(Session["cacheUserRole"]);
                if (userTypeId != 0)
                {
                    DataSet ds;
                    DataTable dtUserType = UserTypesBL.FetchUserTypeAllById(userTypeId);
                    if (drpSearchCol.SelectedIndex > 0)
                    {
                        ds = WarehouseShipmentItemsBL.FetchAllWarehouseShipmentItems(ViewState["SearchKey"].ToString(), drpSearchCol.SelectedItem.Value, Convert.ToInt32(dtUserType.Rows[0]["UserCode"]), Convert.ToInt32(dtUserType.Rows[0]["UserTypeId"]));
                    }
                    else
                    {
                        ds = WarehouseShipmentItemsBL.FetchAllWarehouseShipmentItems(Convert.ToInt32(dtUserType.Rows[0]["UserCode"]), Convert.ToInt32(dtUserType.Rows[0]["UserTypeId"]));
                    }

                    DataView dv = new DataView();
                    dv.Table = ds.Tables[0];
                    dv.Sort = ViewState["SortOrder"].ToString();
                    gridUsers.DataSource = dv;
                    gridUsers.DataBind();
                }
                else
                {
                    Response.Redirect(ResolveUrl("~/SecureLogin.aspx"));
                }
            }
            else
            {
                Response.Redirect(ResolveUrl("~/SecureLogin.aspx"));
            }
        }

        protected void lnkmaskedskidClick_Click(object sender, EventArgs e)
        {
            LinkButton btnSender = (LinkButton)sender;
            hidFSkuid.Value = btnSender.CommandArgument;
        }

        protected void gridUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridUsers.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortWarehouseName")
            {
                if (ViewState["SortOrder"].ToString() == "WareHouseName desc")
                {
                    ViewState["SortOrder"] = "WareHouseName asc";
                }
                else
                {
                    ViewState["SortOrder"] = "WareHouseName desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortmaskedskid")
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
            else if (e.CommandName == "sortavailableqty")
            {

                if (ViewState["SortOrder"].ToString() == "PendingPickQuantity desc")
                {
                    ViewState["SortOrder"] = "PendingPickQuantity asc";
                }
                else
                {
                    ViewState["SortOrder"] = "PendingPickQuantity desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortreceiptdate")
            {

                if (ViewState["SortOrder"].ToString() == "DateAdded_WI desc")
                {
                    ViewState["SortOrder"] = "DateAdded_WI asc";
                }
                else
                {
                    ViewState["SortOrder"] = "DateAdded_WI desc";
                }
                BindGrid();

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["SearchKey"] = txtSearchKey.Text.ToString().Trim();
            BindGrid();
        }
    }
}
