using BusinessLogicLayer;
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class PageList : System.Web.UI.Page
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
                ViewState["SortOrder"] = "PageTitle asc";
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            DataSet objDs;
            if (drpSearchCol.SelectedIndex > 0)
            {
                objDs = BusinessLogicLayer.IscsCms.GetPages(ViewState["SearchKey"].ToString(), drpSearchCol.SelectedItem.Text);
            }
            else
            {
                objDs = BusinessLogicLayer.IscsCms.GetPages(ViewState["SearchKey"].ToString(), "");
            }
            DataView dv = new DataView();
            dv.Table = objDs.Tables[0];
            dv.Sort = ViewState["SortOrder"].ToString();
            gridPages.DataSource = dv;
            gridPages.DataBind();
        }

        protected void gridPages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                Response.Redirect("PageContent.aspx?id=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "sortPageTitle")
            {

                if (ViewState["SortOrder"].ToString() == "PageTitle desc")
                {
                    ViewState["SortOrder"] = "PageTitle asc";
                }
                else
                {
                    ViewState["SortOrder"] = "PageTitle desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortPageName")
            {

                if (ViewState["SortOrder"].ToString() == "PageName desc")
                {
                    ViewState["SortOrder"] = "PageName asc";
                }
                else
                {
                    ViewState["SortOrder"] = "PageName desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortMetaKey")
            {

                if (ViewState["SortOrder"].ToString() == "MetaKey desc")
                {
                    ViewState["SortOrder"] = "MetaKey asc";
                }
                else
                {
                    ViewState["SortOrder"] = "MetaKey desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortMetaDescription")
            {

                if (ViewState["SortOrder"].ToString() == "MetaDescription desc")
                {
                    ViewState["SortOrder"] = "MetaDescription asc";
                }
                else
                {
                    ViewState["SortOrder"] = "MetaDescription desc";
                }
                BindGrid();
            }
        }

        protected void gridPages_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strMetaKey = ((Label)e.Row.FindControl("lblMetaKey")).Text;
                if (strMetaKey.Length > 20)
                {
                    ((Label)e.Row.FindControl("lblMetaKey")).Text = strMetaKey.Substring(0, 20) + "..";
                }
                string strMetaDesc = ((Label)e.Row.FindControl("lblMetaDescription")).Text;
                if (strMetaDesc.Length > 20)
                {
                    ((Label)e.Row.FindControl("lblMetaDescription")).Text = strMetaDesc.Substring(0, 20) + "..";
                }
            }
        }

        protected void gridPages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridPages.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["SearchKey"] = txtKeyWords.Text.ToString().Trim();
            BindGrid();
        }
    }
}
