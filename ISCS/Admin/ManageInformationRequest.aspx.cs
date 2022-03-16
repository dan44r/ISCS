using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace ISCS.Admin
{
    public partial class ManageInformationRequest : System.Web.UI.Page
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
            divReply.Visible = false;
        }

        protected void BindGrid()
        {
            DataSet ds;
            if (drpSearchCol.SelectedIndex > 0)
            {
                ds = InformationRequestBL.FetchAllInfoRequest(ViewState["SearchKey"].ToString(), drpSearchCol.SelectedItem.Value);
            }
            else
            {
                ds = InformationRequestBL.FetchAllInfoRequest("", "");
            }
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.Sort = ViewState["SortOrder"].ToString();
            gridInfoReq.DataSource = dv;
            gridInfoReq.DataBind();
        }
        protected void gridInfoReq_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string isActive = ((Label)e.Row.FindControl("lblReply")).Text;
                if (isActive == "True")
                {
                    ((Label)e.Row.FindControl("lblReplyStat")).Text = "Yes";
                }
                else
                {
                    ((Label)e.Row.FindControl("lblReplyStat")).Text = "No";
                }
            }
        }

        protected void btnDeleteInfoReq_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            Boolean stat = InformationRequestBL.DeleteInfoRequest(Convert.ToInt32(btnSender.CommandArgument));
            if (stat == true)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "The information request has been deleted successfully.";
                BindGrid();
            }
        }

        protected void gridInfoReq_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridInfoReq.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridInfoReq_RowCommand(object sender, GridViewCommandEventArgs e)
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
            else if (e.CommandName == "sortAddress")
            {

                if (ViewState["SortOrder"].ToString() == "Address desc")
                {
                    ViewState["SortOrder"] = "Address asc";
                }
                else
                {
                    ViewState["SortOrder"] = "Address desc";
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
        protected void btnReply_Click(object sender, EventArgs e)
        {
            divReply.Visible = true;
            Button btnSender = (Button)sender;
            lblToMailId.Text = ((Label)btnSender.NamingContainer.FindControl("lblEmail")).ToolTip;
            ViewState["InfoRequestId"] = ((Label)btnSender.NamingContainer.FindControl("lblId")).Text;

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            int mailsent = CommonBL.sendMailInHtmlFormat("ops@3plintegration.com", lblToMailId.Text, txtSubject.Text.ToString().Trim(), txtareaMailBody.Value.ToString().Trim());

            if (mailsent == 1)
            {
                BusinessLogicLayer.InformationRequestBL.SetRepliedInfoRequest(Convert.ToInt32(ViewState["InfoRequestId"]));
                lblMsg.Visible = true;
                lblMsg.Text = "Your reply has been sent successfully";
                BindGrid();
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Sorry, please try again later.";
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
            hidFInfoReqid.Value = btnSender.CommandArgument;
        }
    }
}
