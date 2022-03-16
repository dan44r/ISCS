using System;
using BusinessLogicLayer;
using EntityLayer;

namespace ISCS
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string strCaptchaText = Session["strRandom"].ToString();
            if (txtCaptcha.Text.ToString().Trim() == strCaptchaText)
            {
                RegistrationRequest objRegistrationRequest = new RegistrationRequest();
                objRegistrationRequest.Name = txtName.Text.ToString().Trim();
                objRegistrationRequest.ClientRefNum = txtClientRefNum.Text.ToString().Trim();
                objRegistrationRequest.Phone = txtPhone.Text.ToString().Trim();
                objRegistrationRequest.EmailAddress = txtEmail.Text.ToString().Trim();

                bool res = RegistrationRequestBL.InsertRegistrationRequest(objRegistrationRequest);                

                string strBodyUser = null;

                strBodyUser = "<p>Thank you for choosing us, Your request is pending for verification. We will get back to you soon.<br><br>Please find your request details below.</p><br><br>";
                strBodyUser += "<table cellpadding=\"5\" cellspacing=\"0\" align=\"center\" border=\"0\" width=\"70%\">";
                strBodyUser += "<tr><td>Name</td><td>" + txtName.Text.ToString().Trim() + "</td></tr>";
                strBodyUser += "<tr><td>Client Ref.Number</td><td>" + txtClientRefNum.Text.ToString().Trim() + "</td></tr>";
                strBodyUser += "<tr><td>Phone</td><td>" + txtPhone.Text.ToString().Trim() + "</td></tr>";
                strBodyUser += "<tr><td>Email Address</td><td>" + txtEmail.Text.ToString().Trim() + "</td></tr>";
                strBodyUser += "<tr><td>Thank You</td><td>&nbsp;</td></tr>";
                strBodyUser += "</table>";

                CommonBL.sendMailInHtmlFormat("amitm@indusnet.co.in", txtEmail.Text.ToString().Trim(), "Registration Request Sucessfull !!!", strBodyUser);

                string strBodyAdmin = null;

                strBodyAdmin = "<p>A New Registration Request has arrived.<br><br>Please find the request details below.</p><br><br>";
                strBodyAdmin += "<table cellpadding=\"5\" cellspacing=\"0\" align=\"center\" border=\"0\" width=\"70%\">";
                strBodyAdmin += "<tr><td>Name</td><td>" + txtName.Text.ToString().Trim() + "</td></tr>";
                strBodyAdmin += "<tr><td>Client Ref.Number</td><td>" + txtClientRefNum.Text.ToString().Trim() + "</td></tr>";
                strBodyAdmin += "<tr><td>Phone</td><td>" + txtPhone.Text.ToString().Trim() + "</td></tr>";
                strBodyAdmin += "<tr><td>Email Address</td><td>" + txtEmail.Text.ToString().Trim() + "</td></tr>";
                strBodyAdmin += "<tr><td>Thank You</td><td>&nbsp;</td></tr>";
                strBodyAdmin += "</table>";

                CommonBL.sendMailInHtmlFormat(txtEmail.Text.ToString().Trim(), "amitm@indusnet.co.in", "New Registration Request !!!", strBodyAdmin);
            
                lblError.Text = "Your request has been taken, please wait for acceptance";
                
            }
            else
            {

                lblError.Text = "Wrong text provided";
            }
        }
    }
}
