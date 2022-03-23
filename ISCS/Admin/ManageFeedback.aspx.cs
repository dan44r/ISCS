using BusinessLogicLayer;
using EntityLayer;
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class ManageFeedback : System.Web.UI.Page
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
                ViewState["SortOrder"] = "Name desc";
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataSet ds;
            if (drpSearchCol.SelectedIndex > 0)
            {
                ds = FeedbackBL.FetchAllFeedback(ViewState["SearchKey"].ToString(), drpSearchCol.SelectedItem.Value);
            }
            else
            {
                ds = FeedbackBL.FetchAllFeedback("", "");
            }

            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.Sort = ViewState["SortOrder"].ToString();
            gridFeedback.DataSource = dv;
            gridFeedback.DataBind();
            if (dv.Count <= 0)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "No record found";
            }
        }

        protected void drpIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList drpActivate = (DropDownList)sender;
            EntityLayer.UserFeedback objEl = new UserFeedback();
            objEl.IsActive = Convert.ToBoolean(drpActivate.SelectedValue);
            objEl.Id = Convert.ToInt32(((ImageButton)drpActivate.NamingContainer.FindControl("btnDeleteFeedback")).CommandArgument);
            Boolean stat = FeedbackBL.SetActivation(objEl);
            if (stat == true)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Activation status has been changed successfully.";
            }
        }

        protected void btnDeleteFeedback_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            Boolean stat = FeedbackBL.DeleteFeedback(Convert.ToInt32(btnSender.CommandArgument));
            if (stat == true)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "The feedback has been deleted successfully.";
                BindGrid();
            }
        }

        protected void gridFeedback_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string isActive = ((Label)e.Row.FindControl("lblActive")).Text;
                ((DropDownList)e.Row.FindControl("drpActive")).Items.FindByValue(isActive).Selected = true;
                string isPriority = ((Label)e.Row.FindControl("lblIsPriority")).Text;
                if (isPriority == "True")
                {
                    ((Label)e.Row.FindControl("lblPriority")).Text = "Yes";
                }
                else
                {
                    ((Label)e.Row.FindControl("lblPriority")).Text = "No";
                }
            }
        }

        protected void gridFeedback_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridFeedback.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridFeedback_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortCommentType")
            {
                if (ViewState["SortOrder"].ToString() == "CommentType desc")
                {
                    ViewState["SortOrder"] = "CommentType asc";
                }
                else
                {
                    ViewState["SortOrder"] = "CommentType desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortCommentOn")
            {

                if (ViewState["SortOrder"].ToString() == "CommentOn desc")
                {
                    ViewState["SortOrder"] = "CommentOn asc";
                }
                else
                {
                    ViewState["SortOrder"] = "CommentOn desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortComment")
            {
                if (ViewState["SortOrder"].ToString() == "Comment desc")
                {
                    ViewState["SortOrder"] = "Comment asc";
                }
                else
                {
                    ViewState["SortOrder"] = "Comment desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortName")
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
            else if (e.CommandName == "sortEmail")
            {
                if (ViewState["SortOrder"].ToString() == "Email desc")
                {
                    ViewState["SortOrder"] = "Email asc";
                }
                else
                {
                    ViewState["SortOrder"] = "Email desc";
                }
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["SearchKey"] = txtSearchKey.Text.ToString().Trim();
            BindGrid();
        }

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            hidFFeedbackid.Value = btnSender.CommandArgument;
        }
    }
}
