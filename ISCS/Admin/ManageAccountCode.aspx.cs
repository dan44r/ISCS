using BusinessLogicLayer;
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class ManageAccountCode : System.Web.UI.Page
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
                ViewState["SortOrder"] = "AccountName desc";
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataSet ds;
            if (drpSearchCol.SelectedIndex > 0)
            {
                ds = AccountCodesBL.FetchAllAccountCodes(ViewState["SearchKey"].ToString(), drpSearchCol.SelectedItem.Value);
            }
            else
            {
                ds = AccountCodesBL.FetchAllAccountCodes();
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
            int stat = AccountCodesBL.DeleteAccountCodes(Convert.ToInt32(btnSender.CommandArgument));
            if (stat > 0)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "The Account Code has been deleted Successfully.";
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
            hidFAccountid.Value = btnSender.CommandArgument;
        }

        protected void gridUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridUsers.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortAccountName")
            {
                if (ViewState["SortOrder"].ToString() == "AccountName desc")
                {
                    ViewState["SortOrder"] = "AccountName asc";
                }
                else
                {
                    ViewState["SortOrder"] = "AccountName desc";
                }
                BindGrid();
            }
            if (e.CommandName == "sortAccountCode")
            {
                if (ViewState["SortOrder"].ToString() == "AccountCode desc")
                {
                    ViewState["SortOrder"] = "AccountCode asc";
                }
                else
                {
                    ViewState["SortOrder"] = "AccountCode desc";
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
