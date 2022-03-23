using System;
using System.IO;
using System.Text;

namespace ISCS.Admin
{
    public partial class PageContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    BindContent(Convert.ToInt32(Request.QueryString["id"]));
                }
            }
        }

        protected void BindContent(int pageId)
        {
            EntityLayer.PageCms objEl = BusinessLogicLayer.IscsCms.FetchSingleContent(pageId);
            FCKeditor1.Value = objEl.PageContent;
            txtPageTitle.Text = objEl.PageTitle;
            txtareaMetaKeywords.Value = objEl.MetaKey;
            txtareaMetaDescription.Value = objEl.MetaDescription;
            lblPages.Text = objEl.PageName;
        }

        private void GetImages()
        {
            StringBuilder objNewBS = new StringBuilder();
            objNewBS = ReadImage();
            string strContent = objNewBS.ToString();
            TextWriter tw = new StreamWriter(Server.MapPath("ContentImageList.js"));
            tw.Write(strContent);
            tw.Close();
        }

        private StringBuilder ReadImage()
        {
            StringBuilder objBS = new StringBuilder();
            DirectoryInfo objinfo = new DirectoryInfo(Server.MapPath("ContentImage"));
            string strCpath = "";
            strCpath = System.Configuration.ConfigurationSettings.AppSettings["cpath"];
            FileInfo[] allFiles = objinfo.GetFiles("*.*");
            objBS.Append("var tinyMCEImageList = new Array(");
            Int64 i = allFiles.LongLength;
            foreach (FileInfo fi in allFiles)
            {
                objBS.Append("['" + fi.Name + "','" + strCpath + "ContentImage/" + fi.Name + "']");
                if ((i > 1))
                {
                    objBS.Append(",");
                }
                i = i - 1;
            }
            objBS.Append(");");
            return objBS;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageList.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            EntityLayer.PageCms objEl = new EntityLayer.PageCms();
            objEl.PageId = Convert.ToInt32(Request.QueryString["id"]);
            objEl.PageContent = FCKeditor1.Value;
            objEl.PageTitle = txtPageTitle.Text.ToString().Trim();
            objEl.MetaKey = txtareaMetaKeywords.Value.ToString().Trim();
            objEl.MetaDescription = txtareaMetaDescription.Value.ToString().Trim();
            bool stat = BusinessLogicLayer.IscsCms.AddPageContent(objEl);
            if (stat == true)
            {
                lblMsg.Text = "Content has been updated successfully.";
            }
            else
            {
                lblMsg.Text = "Sorry, please try again later.";
            }
        }
    }
}
