using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISCS
{
    public partial class ThankYou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack && PreviousPage.IsPostBack)
            {
                ContentPlaceHolder contentPh = (ContentPlaceHolder)Page.PreviousPage.Form.FindControl("ContentPlaceHolder1");
                HiddenField hfMsg = (HiddenField)contentPh.FindControl("hdMsg");
                lblMsg.Text = hfMsg.Value;
            }
        }
    }
}
