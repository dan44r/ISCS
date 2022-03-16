using System;
using System.Web.UI.HtmlControls;

namespace ISCS
{
    public partial class WorldEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlAnchor lnk = new HtmlAnchor();

            lnk = this.Master.FindControl("lnkWorldEvent") as HtmlAnchor;
            if (lnk != null)
                lnk.Attributes.Add("class", "active");
            if (!IsPostBack)
            {
                populateFeedOne();
                populateFeedTwo();
                populateFeedThree();

            }
        }

        protected void populateFeedOne()
        {
            dlFeedOne.DataSource = XmlDataSourceFeedOne;
            dlFeedOne.DataBind();
        }

        protected void populateFeedTwo()
        {

        }

        protected void populateFeedThree()
        {
            dlFeedThree.DataSource = XmlDataSourceFeedThree;
            dlFeedThree.DataBind();
        }
    }

}
