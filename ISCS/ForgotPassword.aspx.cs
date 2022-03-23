using BusinessLogicLayer;
using System;

namespace ISCS
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSendPass_Click(object sender, EventArgs e)
        {
            string strBodyUser = null;

            strBodyUser = "<p>Thank you, Your request is pending for verification. We will get back to you soon.<br><br>Please find your request details below.</p><br><br>";
            strBodyUser += "<table cellpadding=\"5\" cellspacing=\"0\" align=\"center\" border=\"0\" width=\"70%\">";
            strBodyUser += String.Format("<tr><td>Name</td><td>{0}</td></tr>", txtName.Text.ToString().Trim());
            strBodyUser += String.Format("<tr><td>Email Address</td><td>{0}</td></tr>", txtEmail.Text.ToString().Trim());
            strBodyUser += "<tr><td>Thank You</td><td>&nbsp;</td></tr>";
            strBodyUser += "</table>";

            CommonBL.sendMailInHtmlFormat("amitm@indusnet.co.in", txtEmail.Text.ToString().Trim(), "Forget Password Request Sucessfull !!!", strBodyUser);

            string strBodyAdmin = null;

            strBodyAdmin = "<p>A New Forget Password Request has arrived.<br><br>Please find the request details below.</p><br><br>";
            strBodyAdmin += "<table cellpadding=\"5\" cellspacing=\"0\" align=\"center\" border=\"0\" width=\"70%\">";
            strBodyAdmin += String.Format("<tr><td>Name</td><td>{0}</td></tr>", txtName.Text.ToString().Trim());
            strBodyAdmin += String.Format("<tr><td>Email Address</td><td>{0}</td></tr>", txtEmail.Text.ToString().Trim());
            strBodyAdmin += "<tr><td>Thank You</td><td>&nbsp;</td></tr>";
            strBodyAdmin += "</table>";

            CommonBL.sendMailInHtmlFormat(txtEmail.Text.ToString().Trim(), "amitm@indusnet.co.in", "New Forget Password Request !!!", strBodyAdmin);
        }
    }
}
