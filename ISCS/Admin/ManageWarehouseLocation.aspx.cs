using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace ISCS
{
    public partial class ManageWarehouseLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!IsPostBack)
            {
                ///////////////////////////////////////////////////////////////////////////////////////////
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
                ///////////////////////////////////////////////////////////////////////////////////////////

                ViewState["SearchKey"] = "";
                ViewState["SortOrder"] = "CompanyName desc";
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataSet ds;
            if (drpSearchCol.SelectedIndex > 0)
            {
                ds = WarehouseLocationBL.FetchWarehouseLocation(ViewState["SearchKey"].ToString(), drpSearchCol.SelectedItem.Value);
            }
            else
            {
                ds = WarehouseLocationBL.FetchWarehouseLocation("", "");
            }

            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.Sort = ViewState["SortOrder"].ToString();
            gridWHLocation.DataSource = dv;
            gridWHLocation.DataBind();
            if (dv.Count <= 0)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "No record found";
            }
        }

        protected void gridWHLocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridWHLocation.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridWHLocation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortCompanyName")
            {
                if (ViewState["SortOrder"].ToString() == "CompanyName desc")
                {
                    ViewState["SortOrder"] = "CompanyName asc";
                }
                else
                {
                    ViewState["SortOrder"] = "CompanyName desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortCity")
            {
                if (ViewState["SortOrder"].ToString() == "City desc")
                {
                    ViewState["SortOrder"] = "City asc";
                }
                else
                {
                    ViewState["SortOrder"] = "City desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortStateName")
            {
                if (ViewState["SortOrder"].ToString() == "StateName desc")
                {
                    ViewState["SortOrder"] = "StateName asc";
                }
                else
                {
                    ViewState["SortOrder"] = "StateName desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortContactName")
            {
                if (ViewState["SortOrder"].ToString() == "ContactName desc")
                {
                    ViewState["SortOrder"] = "ContactName asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ContactName desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortContactPhone")
            {
                if (ViewState["SortOrder"].ToString() == "ContactPhone desc")
                {
                    ViewState["SortOrder"] = "ContactPhone asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ContactPhone desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortContactEmail")
            {
                if (ViewState["SortOrder"].ToString() == "ContactEmail desc")
                {
                    ViewState["SortOrder"] = "ContactEmail asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ContactEmail desc";
                }
                BindGrid();
            }           
        }

        protected void gridWHLocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["SearchKey"] = txtSearchKey.Text.ToString().Trim();
            BindGrid();
        }
        protected string TruncateValue(string strValue, int size)
        {
            if (strValue.Length > size)
            {
                strValue = strValue.Substring(0, size - 2) + "..";
            }
            return strValue;
        }
        protected void btnDeleteWHLocations_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            Boolean stat = WarehouseLocationBL.DeleteWarehouseLocation(Convert.ToInt32(btnSender.CommandArgument));
            if (stat == true)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "The warehouse location has been deleted successfully.";
                BindGrid();
            }
        }
        protected void btnEditWHLocation_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            hidWHLocationId.Value = btnSender.CommandArgument;
        }
    }
}
