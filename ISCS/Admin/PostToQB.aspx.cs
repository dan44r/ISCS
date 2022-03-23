using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
namespace ISCS.Admin
{
    public partial class PostToQB : System.Web.UI.Page
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
                //GetFileContent();
                GetWebServiceCall();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Sorry, please try again.";
                QBLog(ex);
            }
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

                //WebRequestObject.KeepAlive = false;
                //WebRequestObject.Timeout = System.Threading.Timeout.Infinite;
                //WebRequestObject.ProtocolVersion = HttpVersion.Version10;
                //WebRequestObject.AllowWriteStreamBuffering = false;

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
                if (vendoeAdd.Contains("–"))
                {
                    vendoeAdd = vendoeAdd.Replace("–", "-");
                }
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
                tw = new StreamWriter(Server.MapPath("../QBFiles/Logs/Log" + strToday + ".txt"), true);
                tw.WriteLine(Results);
                tw.Close();
            }
            catch (Exception ex) { lblMsg.Text = "Sorry, please try again."; }
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

        public void QBLog(Exception ErrorMsg)
        {
            string Value = "========";
            Value += "Date : " + DateTime.Now.ToString();
            Value += "  Error : " + ErrorMsg;
            string filename = ConfigurationManager.AppSettings["QBFilesPath"] + "/" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Second.ToString() + ".doc";
            string Path = (Server.MapPath(filename));
            using (FileStream fs = File.Create(Path))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(Value);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }


            //string FileName = "QBLog.txt";
            //string Filepath = string.Empty;
            ////Filepath = Server.MapPath("~/writereaddata/" + FileName);
            //Filepath = ConfigurationManager.AppSettings["UnProcessedPath"].ToString().Replace("UnProcessed\"", "") + FileName;
            //// Write the string to a file.


            //if (File.Exists(Filepath))
            //{
            //    FileStream aFile = new FileStream(Filepath, FileMode.Append, FileAccess.Write);
            //    System.IO.StreamWriter file = new System.IO.StreamWriter(aFile);
            //    file.WriteLine(Value);
            //    file.Close();

            //}
            //else
            //{
            //    FileStream aFile = new FileStream(Filepath, FileMode.OpenOrCreate, FileAccess.Write);
            //    System.IO.StreamWriter file = new System.IO.StreamWriter(aFile);
            //    file.WriteLine(Value);
            //    file.Close();
            //}



        }

        public void GetFileContent()
        {
            lblMsg.Text = "";
            string AllFileData = "";
            string[] x = Directory.GetFiles(Server.MapPath("../QBFiles/UnProcessed"));
            foreach (string s in x)
            {
                FileInfo f = new FileInfo(s);
                if (f.Extension == ".txt")
                {
                    StreamReader sr = new StreamReader(s);
                    AllFileData = sr.ReadToEnd();
                    sr.Close();

                    //if (f.Name.Trim().ToLower().IndexOf("vendoradd") != -1 || f.Name.Trim().ToLower().IndexOf("vendoramtadd") != -1 || f.Name.Trim().ToLower().IndexOf("customeradd") != -1 || f.Name.Trim().ToLower().IndexOf("customeramtadd") != -1)
                    if (f.Name.Trim().ToLower().IndexOf("qbxml") != -1)
                    {
                        string strRes1 = VendorADD(AllFileData, f.Name.ToString().Trim());
                        if (strRes1.Trim() == "OK")
                        {
                            if (!File.Exists(Server.MapPath("../QBFiles/Processed/" + f.Name)))
                            {
                                f.MoveTo(Server.MapPath("../QBFiles/Processed/" + f.Name));
                            }
                            else if (File.Exists(Server.MapPath("../QBFiles/Processed/" + f.Name)))
                            {
                                f.MoveTo(Server.MapPath("../QBFiles/Processed/" + DateTime.Now.ToString("hhmmss") + "-" + f.Name));
                            }
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

        public void GetWebServiceCall()
        {
            //string Value = txtAppName.Text;

            string pageName = ConfigurationManager.AppSettings["PostQBUrl"].ToString();
            //string pageName = "http://50.28.67.88:9026/Webservice1.asmx";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(pageName);
            req.Timeout = 1000000;
            req.Method = "POST";
            req.ContentType = "text/xml;charset=UTF-8";
            //req.Headers.Add("User_Appname", Value);

            // The parameter values. In a real-world app these would of
            // course be gotten from user input or some other input.
            string input = "";


            // Now for the XML. Just build it by brute force.
            string xmlRequest = String.Concat(
            "<?xml version=\"1.0\" encoding=\"utf-8\"?>",
            "<soap:Envelope",
            " xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"",
            " xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"",
            " xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">",
            " <soap:Body>",
            " <GetFileContent xmlns=\"http://tempuri.org/\">",
            " <input>", "</input>",
            " </GetFileContent>",
            " </soap:Body>",
            "</soap:Envelope>");

            // Pull the XML request into a UTF-8 byte array for two
            // reasons:
            // 1. We need to set the content length to the byte length.
            // 2. The XML will be pushed into the request stream, which
            // handles bytes, not characters.
            byte[] reqBytes = new UTF8Encoding().GetBytes(xmlRequest);

            // Now that the request is encoded to a byte array, we can
            // get its byte length. Set the remaining HTTP header value,
            // which is the content-length:
            req.ContentLength = reqBytes.Length;

            // Write the XML to the request stream.
            // Write the request content (the XML) to the request stream.
            try
            {
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(reqBytes, 0, reqBytes.Length);
                }
            }
            catch (Exception ex)
            {
                // GetRequestStream and Write can throw a variety of
                // exceptions; handling them is outside the scope of
                // this article. A "real" application should log and
                // (when possible) handle these exceptions.
                Console.WriteLine("Exception of type " + ex.GetType().Name);
                throw;
            }

            // At this point, the HTTP headers are set and the XML
            // content is set. It's time to call the service.


            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();


            // We won't parse the response XML quite yet. Instead, just
            // log the raw XML received to show success.
            string xmlResponse = null;
            using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
            {
                xmlResponse = sr.ReadToEnd();
            }
            Console.WriteLine(xmlResponse);
            string res = xmlResponse;

        }
    }
}
