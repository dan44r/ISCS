using System;

namespace ISCS.Admin
{
    public partial class PostToQBV3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRetuen_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                localhost.WebService1 oWebService1 = new localhost.WebService1();
                oWebService1.GetFileContent();
            }
            catch (Exception ex) { lblMsg.Text = "Sorry, please try again."; }
        }
    }
}
