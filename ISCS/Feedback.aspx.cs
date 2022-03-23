using BusinessLogicLayer;
using System;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Web.UI.HtmlControls;

namespace ISCS
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlAnchor lnk = new HtmlAnchor();

            lnk = this.Master.FindControl("lnkContact") as HtmlAnchor;
            if (lnk != null)
                lnk.Attributes.Add("class", "active");

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strCaptchaText = Session["strRandom"].ToString();
            if (txtCaptchaText.Text.ToString().Trim() == strCaptchaText)
            {
                Boolean stat = false;

                MailMessage objMail = new MailMessage();
                EntityLayer.UserFeedback objEl = new EntityLayer.UserFeedback();
                objEl.Name = txtName.Text.ToString().Trim();
                objEl.Company = txtCompany.Text.ToString().Trim();
                objEl.Email = txtEmail.Text.ToString().Trim();
                objEl.Phone = txtTelephone.Text.ToString().Trim();
                objEl.Fax = txtFax.Text.ToString().Trim();
                objEl.IsPriority = chkArgent.Checked;
                objEl.CommentType = radioList.SelectedValue;
                if (drpAbout.SelectedItem.Text == "(Other)")
                {
                    objEl.CommentOn = txtAboutOther.Text.ToString().Trim();
                }
                else
                {
                    objEl.CommentOn = drpAbout.SelectedItem.Text;
                }

                objEl.Comment = txtareaComments.Value.ToString();
                objEl.IsActive = false;
                objEl.IsDeleted = false;
                objEl.CommentDate = DateTime.Now;
                try
                {
                    stat = BusinessLogicLayer.FeedbackBL.InsertFeedback(objEl);
                }
                catch (Exception ex)
                { }
                StringBuilder sbMailBody = new StringBuilder();
                sbMailBody.Append("<table><tr><td>Comment Type : </td><td>");
                sbMailBody.Append(objEl.CommentType);
                sbMailBody.Append("</td></tr><tr><td>Comment on : </td><td>");
                sbMailBody.Append(objEl.CommentOn);
                sbMailBody.Append("</td></tr><tr><td>Comment : </td><td>");
                sbMailBody.Append(objEl.Comment);
                sbMailBody.Append("</td></tr><tr><td>Name : </td><td>");
                sbMailBody.Append(objEl.Name);
                sbMailBody.Append("</td></tr><tr><td>Company : </td><td>");
                sbMailBody.Append(objEl.Company);
                sbMailBody.Append("</td></tr><tr><td>Email : </td><td>");
                sbMailBody.Append(objEl.Email);
                sbMailBody.Append("</td></tr><tr><td>Telephone : </td><td>");
                sbMailBody.Append(objEl.Phone);
                sbMailBody.Append("</td></tr><tr><td>Fax : </td><td>");
                sbMailBody.Append(objEl.Fax);
                sbMailBody.Append("</td></tr><tr><td>Priority : </td><td>");
                if (objEl.IsPriority == true)
                {
                    sbMailBody.Append("Yes");
                }
                else
                {
                    sbMailBody.Append("No");
                }

                sbMailBody.Append("</td></tr></table>");

                CommonBL.sendMailInHtmlFormat(objEl.Email, ConfigurationManager.AppSettings["AdminEmail"].Trim(), "ISCS Feedback", sbMailBody.ToString());
                if (stat == true)
                {
                    lblMsg.Text = "Your feedback has been sent succesfully.";
                    hdMsg.Value = "Thank you for submitting your feedback.";
                }
                else
                {
                    lblMsg.Text = "Sorry, please try again later.";
                }
            }
            else
            {
                lblCpatchaMsg.Text = "Please enter security code correctly";
            }
        }
    }
}
