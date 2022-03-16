using System;
using System.Web.UI.HtmlControls;

namespace ISCS
{
    public partial class Automotive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                FillContent();
            }
        }
        protected void FillContent()
        {
            EntityLayer.PageCms objEl = new EntityLayer.PageCms();
            objEl = BusinessLogicLayer.IscsCms.FetchSingleContent(32);
            this.divContent.InnerHtml = objEl.PageContent;
            this.Title = objEl.PageTitle;
            HtmlMeta objMeta = new HtmlMeta();
            objMeta.Name = "MetaKey";
            objMeta.Content = objEl.MetaKey;
            Header.Controls.Add(objMeta);
            objMeta = new HtmlMeta();
            objMeta.Name = "MetaDescription";
            objMeta.Content = objEl.MetaDescription;
            Header.Controls.Add(objMeta);
        }
    }
}
