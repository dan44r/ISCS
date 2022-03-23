using BusinessLogicLayer;
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class ManagePackageTypes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
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
                ViewState["SortOrder"] = "PackageType asc";
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            DataSet ds;
            if (drpSearchCol.SelectedIndex > 0)
            {
                ds = PackageTypeBL.FetchPackageTypes(ViewState["SearchKey"].ToString(), drpSearchCol.SelectedValue);
            }
            else
            {
                ds = PackageTypeBL.FetchPackageTypes("", "");
            }
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.Sort = ViewState["SortOrder"].ToString();
            gridPackageType.DataSource = dv;
            gridPackageType.DataBind();
        }

        protected void gridPackageType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridPackageType.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridPackageType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortPackageType")
            {
                if (ViewState["SortOrder"].ToString() == "PackageType desc")
                {
                    ViewState["SortOrder"] = "PackageType asc";
                }
                else
                {
                    ViewState["SortOrder"] = "PackageType desc";
                }
                BindGrid();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["SearchKey"] = txtSearchKey.Text.ToString().Trim();
            BindGrid();
        }
        protected void btnDeletePType_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            Boolean stat = PackageTypeBL.DeletePackageType(Convert.ToInt32(btnSender.CommandArgument));
            if (stat == true)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "The package type has been deleted successfully.";
                BindGrid();
            }
        }

        protected string TruncateValue(string strValue, int size)
        {
            if (strValue.Length > size)
            {
                strValue = strValue.Substring(0, size - 2) + "..";
            }
            return strValue;
        }

        protected void btnEditPackageType_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            hidPType.Value = btnSender.CommandArgument + "~" + ((Label)btnSender.NamingContainer.FindControl("lblPType")).Text;
        }
    }
}
