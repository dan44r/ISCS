using System;
using System.Web.UI.HtmlControls;

namespace ISCS
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlAnchor lnk = new HtmlAnchor();

            lnk = this.Master.FindControl("lnkHome") as HtmlAnchor;
            if (lnk != null)
                lnk.Attributes.Add("class", "active");           

        }       
    }
}
