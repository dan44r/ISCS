using BusinessLogicLayer;
using System;
using System.Configuration;

namespace ISCS
{
    public partial class SendTestMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }


        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string from, to, subject, body;
            from = ConfigurationManager.AppSettings["AdminEmail"].Trim();
            to = txtMailTo.Text.Trim();
            subject = txtMailSub.Text.Trim();
            body = txtMailBody.Text.Trim();
            int i = CommonBL.sendMailInHtmlFormat(from, to, subject, body);
            if (i == 1)
            {
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Mail Sent Successfully";
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Mail Not Sent Successfully";
            }
        }
    }
}
