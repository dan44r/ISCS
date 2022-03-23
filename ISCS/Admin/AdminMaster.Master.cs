using BusinessLogicLayer;
using System;

namespace ISCS.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["cacheUserRole"] != null)
                {
                    int userTypeId = Convert.ToInt32(Session["cacheUserRole"]);
                    if (userTypeId != 0)
                    {
                        string userName = Convert.ToString(Session["cacheName"]);
                        string strUserType = UserTypesBL.FetchUserTypeById(userTypeId);
                        welcomeAdmin.InnerHtml = userName + " , " + "Role:" + " " + strUserType;
                    }
                    else
                    {
                        Response.Redirect(ResolveUrl("~/SecureLogin.aspx"));
                    }
                }
                else
                {
                    Response.Redirect(ResolveUrl("~/SecureLogin.aspx"));
                }
            }
        }
    }
}
