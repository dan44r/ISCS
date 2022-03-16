using System;
using System.Web.UI.WebControls;

namespace ISCS
{
    public partial class WebSiteChanges : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HyperLink lnk = new HyperLink();
            lnk = this.Master.FindControl("lnk4") as HyperLink;
            if (lnk != null)
                lnk.Attributes.Add("class", "active");
            if (!IsPostBack)
            {
                FillContent();
            }
        }
        protected void FillContent()
        {
            EntityLayer.PageCms objEl = new EntityLayer.PageCms();
            objEl = BusinessLogicLayer.IscsCms.FetchSingleContent(14);
            this.divContent.InnerHtml = objEl.PageContent;
        }
    }
}
