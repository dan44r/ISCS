using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ISCS.Admin.UserControls
{
    public partial class AdminHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            Session["cacheUserRole"] = null;
            Session["cacheName"] = null;
            Session["cacheUserId"] = null;
            Session["cacheUserCode"] = null;
            Session["userEmail"] = null;

            //Session["cacheUserRole"] = "";
            //Session["cacheName"] = "";
            //Session["cacheUserId"] = "";
            //Session["cacheUserCode"] = "";
            //Session["userEmail"] = "";

            //Session.Remove("cacheUserRole");
            //Session.Remove("cacheName");
            //Session.Remove("cacheUserId");
            //Session.Remove("cacheUserCode");
            //Session.Remove("userEmail");
            Response.Redirect(ResolveUrl("~/SecureLogin.aspx"));
        }
    }
}