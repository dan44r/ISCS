using System;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Text;
using System.Web;

namespace ISCS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            QBLog("Error Occured");
        }

        public void QBLog(string ErrorMsg)
        {
            string Value = "========";
            Value += "Date : " + DateTime.Now.ToString();
            Value += "  Error : " + ErrorMsg;
            string filename = ConfigurationManager.AppSettings["QBFilesPath"] + "/" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + ".doc";
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

        #region public static string VendorADD(int CarrierID)
        public string VendorADD(string strContent, string strFName)
        {
            string requestUrl = null;
            string Results = "";
            string vendoeAdd = "";
            string strStatusCode = "";
            string strToday = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
            requestUrl = "https://apps.quickbooks.com/j/AppGateway";






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
            if (vendoeAdd.Contains("–"))
            {
                vendoeAdd = vendoeAdd.Replace("–", "xxx");
            }
            return strStatusCode;
        }
        #endregion

        public void GetFileContent()
        {

            string AllFileData = "";
            string[] x = Directory.GetFiles(Server.MapPath("/QBFiles/UnProcessed"));
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
                            if (!File.Exists(Server.MapPath("../QBFiles/Processed/" + f.Name)))
                            {
                                f.MoveTo(Server.MapPath("../QBFiles/Processed/" + f.Name));
                            }
                            else if (File.Exists(Server.MapPath("../QBFiles/Processed/" + f.Name)))
                            {
                                f.MoveTo(Server.MapPath("../QBFiles/Processed/" + DateTime.Now.ToString("hhmmss") + "-" + f.Name));
                            }

                        }
                        else
                        {

                        }
                    }
                }
            }
        }
    }
}
