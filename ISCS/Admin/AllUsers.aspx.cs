using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace ISCS.Admin
{
    public partial class AllUsers : System.Web.UI.Page
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
                ViewState["SortOrder"] = "FirstName desc";
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataSet ds;
            if (drpSearchCol.SelectedIndex > 0)
            {
                ds = UserBL.FetchAllUsers(ViewState["SearchKey"].ToString(), drpSearchCol.SelectedItem.Value);
            }
            else
            {
                ds = UserBL.FetchAllUsers();
            }
            
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.Sort = ViewState["SortOrder"].ToString();
            gridUsers.DataSource = dv;
            gridUsers.DataBind();
        }
        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;            
            int stat = UserBL.DeleteUsers(Convert.ToInt32(btnSender.CommandArgument));            
            if (stat > 0)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "The user has been deleted Successfully.";
                BindGrid();
            }
            if (stat == -547)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Cannot delete record due to database exception.";
            }
        }
        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            hidFUserid.Value = btnSender.CommandArgument;
        }

        protected void gridUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridUsers.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortFirstName")
            {
                if (ViewState["SortOrder"].ToString() == "FirstName desc")
                {
                    ViewState["SortOrder"] = "FirstName asc";
                }
                else
                {
                    ViewState["SortOrder"] = "FirstName desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortLastName")
            {
                if (ViewState["SortOrder"].ToString() == "LastName desc")
                {
                    ViewState["SortOrder"] = "LastName asc";
                }
                else
                {
                    ViewState["SortOrder"] = "LastName desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortCompanyName")
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
            else if (e.CommandName == "sortLevel")
            {
                if (ViewState["SortOrder"].ToString() == "UserType desc")
                {
                    ViewState["SortOrder"] = "UserType asc";
                }
                else
                {
                    ViewState["SortOrder"] = "UserType desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortActive")
            {
                if (ViewState["SortOrder"].ToString() == "Active desc")
                {
                    ViewState["SortOrder"] = "Active asc";
                }
                else
                {
                    ViewState["SortOrder"] = "Active desc";
                }
                BindGrid();
            }
        }

        protected void gridUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string isActive = ((Label)e.Row.FindControl("lblIsActive")).Text;
                if (isActive == "True")
                {
                    ((Label)e.Row.FindControl("lblActive")).Text = "Yes";
                }
                else
                {
                    ((Label)e.Row.FindControl("lblActive")).Text = "No";
                }
            }
        }        

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["SearchKey"] = txtSearchKey.Text.ToString().Trim();
            BindGrid();
        }
    }
}
