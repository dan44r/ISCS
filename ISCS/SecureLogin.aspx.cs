using BusinessLogicLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Security;


namespace ISCS
{
    public partial class SecureLogin : System.Web.UI.Page
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAuthenticate_Click(object sender, EventArgs e)
        {
            string userName = txtEmail.Text, password = txtPassword.Text.Trim();
            Users objUsers = new Users();
            DataTable dtuser = UserBL.GetUserByUserNamePassword(userName, password);


            if (dtuser.Rows.Count <= 0)
            {
                lblError.Text = "No Such valid user present.";
                return;
            }

            else if (dtuser.Rows.Count > 0)
            {
                objUsers.Email = Convert.ToString(dtuser.Rows[0]["Email"]);
                objUsers.UserId = Convert.ToInt32(dtuser.Rows[0]["UserId"]);
                objUsers.FirstName = Convert.ToString(dtuser.Rows[0]["FirstName"]);
                objUsers.LastName = Convert.ToString(dtuser.Rows[0]["LastName"]);
                objUsers.Password = Convert.ToString(dtuser.Rows[0]["Password"]);
                objUsers.UserTypeId = Convert.ToInt32(dtuser.Rows[0]["UserTypeId"]);

                if (dtuser.Rows[0]["Password"] != null && Convert.ToString(dtuser.Rows[0]["Password"]) != password)
                {

                    lblError.Text = "The username and/or password could not be validated.";
                    return;
                }
            }
            Dictionary<string, string> tags = new Dictionary<string, string>();

            tags.Add("QCUName", Convert.ToString(dtuser.Rows[0]["Email"]));
            tags.Add("QCName", Convert.ToString(dtuser.Rows[0]["FirstName"]) + " " + Convert.ToString(dtuser.Rows[0]["LastName"]));
            tags.Add("QCUserId", Convert.ToString(dtuser.Rows[0]["UserId"]));
            tags.Add("TestCookie", "test");
            FormsAuthenticationTicket tckt = CF.Web.Security.CFFormAuthenticationModule.CreateAuthenticationCookie(objUsers, tags, true, true);
            string[] userData = tckt.UserData.Split(',');
            Session["cacheName"] = dtuser.Rows[0]["FirstName"].ToString() + " " + dtuser.Rows[0]["LastName"].ToString();
            Session["cacheUserId"] = dtuser.Rows[0]["UserId"].ToString();
            Session["cacheUserRole"] = Convert.ToString(dtuser.Rows[0]["UserTypeId"]);
            Session["cacheUserCode"] = dtuser.Rows[0]["UserCode"].ToString();
            Session["userEmail"] = Convert.ToString(dtuser.Rows[0]["Email"]);
            string url = FormsAuthentication.GetRedirectUrl(objUsers.Email, false);
            if (string.IsNullOrEmpty(url) || url == "/")
                url = ResolveUrl("~/Admin/Home.aspx");

            Response.Redirect(url);
        }

        #endregion
    }
}
