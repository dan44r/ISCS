using System;
using System.Web.UI.WebControls;

namespace ISCS
{
    public partial class SiteMap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HyperLink lnk = new HyperLink();
            lnk = this.Master.FindControl("lnk7") as HyperLink;
            if (lnk != null)
                lnk.Attributes.Add("class", "active");
        }
    }
}
