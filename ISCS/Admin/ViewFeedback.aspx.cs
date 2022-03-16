using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace ISCS.Admin
{
    public partial class ViewFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack && PreviousPage.IsPostBack)
            {
                BindValues();
            }
        }
        protected void BindValues()
        {
            ContentPlaceHolder contentPh = (ContentPlaceHolder)Page.PreviousPage.Form.FindControl("ContentPlaceHolder1");
            HiddenField hfFeedbackid = (HiddenField)contentPh.FindControl("hidFFeedbackid");
            int strFeedbackid = Convert.ToInt32(hfFeedbackid.Value);            

            DataTable dtFeedback = FeedbackBL.FetchFeedbackByID(strFeedbackid).Tables[0];
            if (dtFeedback.Rows != null && dtFeedback.Rows.Count > 0)
            {
                lblName.Text = dtFeedback.Rows[0]["Name"].ToString().Trim();
                lblCompany.Text = dtFeedback.Rows[0]["Company"].ToString().Trim();
                lblEmail.Text = dtFeedback.Rows[0]["Email"].ToString().Trim();
                lblPhone.Text = dtFeedback.Rows[0]["Phone"].ToString().Trim();
                lblFax.Text = dtFeedback.Rows[0]["Fax"].ToString().Trim();
                lblCommentType.Text = dtFeedback.Rows[0]["CommentType"].ToString().Trim();
                lblCommentOn.Text = dtFeedback.Rows[0]["CommentOn"].ToString().Trim();
                lblCommentDate.Text = dtFeedback.Rows[0]["CommentDate"].ToString().Trim();
                lblComment.Text = dtFeedback.Rows[0]["Comment"].ToString().Trim();
            }            
        }       

        protected void btnRetuen_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageFeedback.aspx");
        }
        
    }
}
