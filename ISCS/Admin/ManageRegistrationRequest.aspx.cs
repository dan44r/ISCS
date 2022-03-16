using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace ISCS.Admin
{
    public partial class ManageRegistrationRequest : System.Web.UI.Page
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
                ViewState["SortOrder"] = "Name asc";
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataSet ds;
            if (drpSearchCol.SelectedIndex > 0)
            {
                ds = RegistrationRequestBL.FetchAllRegistrationRequest(ViewState["SearchKey"].ToString(), drpSearchCol.SelectedItem.Value);
            }
            else
            {
                ds = RegistrationRequestBL.FetchAllRegistrationRequest("", "");
            }
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.Sort = ViewState["SortOrder"].ToString();
            gridRegistrationRequest.DataSource = dv;
            gridRegistrationRequest.DataBind();
        }

        protected void btnDeleteRegistrationRequest_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            Boolean stat = RegistrationRequestBL.DeleteRegistrationRequest(Convert.ToInt32(btnSender.CommandArgument));
            if (stat == true)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "The registration request has been deleted successfully.";
                BindGrid();
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Sorry, please try again later.";
            }
        }

        protected void gridRegistrationRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridRegistrationRequest.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridRegistrationRequest_Sorting(object sender, GridViewSortEventArgs e)
        {

        }



        protected void gridRegistrationRequest_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortName")
            {
                if (ViewState["SortOrder"].ToString() == "Name desc")
                {
                    ViewState["SortOrder"] = "Name asc";
                }
                else
                {
                    ViewState["SortOrder"] = "Name desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortClientRefNum")
            {

                if (ViewState["SortOrder"].ToString() == "ClientRefNum desc")
                {
                    ViewState["SortOrder"] = "ClientRefNum asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ClientRefNum desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortPhone")
            {

                if (ViewState["SortOrder"].ToString() == "Phone desc")
                {
                    ViewState["SortOrder"] = "Phone asc";
                }
                else
                {
                    ViewState["SortOrder"] = "Phone desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortEmail")
            {

                if (ViewState["SortOrder"].ToString() == "EmailAddress desc")
                {
                    ViewState["SortOrder"] = "EmailAddress asc";
                }
                else
                {
                    ViewState["SortOrder"] = "EmailAddress desc";
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
