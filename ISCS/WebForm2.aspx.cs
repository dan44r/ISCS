using CF.Web.Security;
using System;

namespace ISCS
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = "1";
            for (int i = 0; i < 100; i++)
            {
                string aa = SecurityUtils.UrlEncode(Convert.ToString(i));
                Response.Write(aa);
                Response.Write(": " + SecurityUtils.UrlDecode(Convert.ToString(aa)) + "<br/><br/>");
            }

        }
    }
}
