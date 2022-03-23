using System;
using System.IO;
using System.Net;
using System.Xml;

namespace ISCS
{
    public partial class PostToQB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRetuen_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx.aspx");
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            GetFileContent();
        }
        #region public static string VendorADD(int CarrierID)
        public string VendorADD(string strContent, string strFName)
        {
            string requestUrl = null;
            string Results = "";
            string vendoeAdd = "";
            string strStatusCode = "";
            string strToday = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
            requestUrl = "https://apps.quickbooks.com/j/AppGateway";

            HttpWebRequest WebRequestObject = null;
            StreamReader sr = null;
            HttpWebResponse WebResponseObject = null;
            StreamWriter swr = null;

            try
            {
                WebRequestObject = (HttpWebRequest)WebRequest.Create(requestUrl);
                WebRequestObject.Method = "POST";
                WebRequestObject.ContentType = "application/x-qbxml";
                WebRequestObject.AllowAutoRedirect = false;
                strContent = @"<?xml version=""1.0"" encoding=""utf-8"" ?>  
                  <?qbxml version=""6.0""?>  
                <QBXML> 
                 <SignonMsgsRq> 
                 <SignonDesktopRq> 
                 <ClientDateTime>%%CLIENT_DATE_TIME%%</ClientDateTime>
                <ApplicationLogin>int3.3plintegration.com</ApplicationLogin>
                <ConnectionTicket>TGT-181-YVkfJkX6Oxtx3HdlhrdusA</ConnectionTicket>
                <Language>English</Language>
                <AppID>477329740</AppID>
                <AppVer>1</AppVer>
                  </SignonDesktopRq> 
                  </SignonMsgsRq> 
                 <QBXMLMsgsRq onError=""continueOnError""> "
                    + strContent +
                @"</QBXMLMsgsRq> 
                  </QBXML>";

                vendoeAdd = strContent;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(vendoeAdd);
                vendoeAdd = xmlDoc.InnerXml;
                WebRequestObject.ContentLength = vendoeAdd.Length;
                swr = new StreamWriter(WebRequestObject.GetRequestStream());
                swr.Write(vendoeAdd);
                swr.Close();
                WebResponseObject = (HttpWebResponse)WebRequestObject.GetResponse();
                sr = new StreamReader(WebResponseObject.GetResponseStream());
                if (WebResponseObject.StatusCode.ToString().Trim().ToUpper() == "OK")
                { strStatusCode = "OK"; }
                Results = sr.ReadToEnd();
                StreamWriter tw = null;
                tw = new StreamWriter(Server.MapPath("QBFiles/Logs/Log" + strToday + ".txt"), true);
                tw.WriteLine(Results);
                tw.Close();
            }
            finally
            {
                try { sr.Close(); }
                catch { }
                try
                {
                    WebResponseObject.Close();
                    WebRequestObject.Abort();
                }
                catch { }
            }
            return strStatusCode;
        }
        #endregion

        public void GetFileContent()
        {
            lblMsg.Text = "";
            string AllFileData = "";
            string[] x = Directory.GetFiles(Server.MapPath("QBFiles/UnProcessed"));
            foreach (string s in x)
            {
                FileInfo f = new FileInfo(s);
                if (f.Extension == ".txt")
                {
                    StreamReader sr = new StreamReader(s);
                    AllFileData = sr.ReadToEnd();
                    sr.Close();


                    if (f.Name.Trim().ToLower().IndexOf("qbxml") != -1)
                    {
                        string strRes1 = VendorADD(AllFileData, f.Name.ToString().Trim());
                        if (strRes1.Trim() == "OK")
                        {
                            f.MoveTo(Server.MapPath("QBFiles/Processed/" + f.Name));
                            lblMsg.Text = "Data posted successfully.";
                        }
                        else
                        {
                            lblMsg.Text = "Sorry, please try again later.";
                        }
                    }
                }
            }
        }
    }
}
