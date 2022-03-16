using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace BusinessLogicLayer
{
    public class CommonBL
    {
        public static int sendMailInHtmlFormat(string sendMailForm, string sendMailTo, string mailSubject, string mailBody)
        {
            try
            {
                //MailMessage message = new MailMessage(sendMailForm, sendMailTo);
                MailMessage message = new MailMessage();
                if (ConfigurationSettings.AppSettings["MailDisplayNameFlag"].Trim() == "Yes")
                {
                    message.From = new MailAddress(ConfigurationSettings.AppSettings["AdminEmail"].Trim(), ConfigurationSettings.AppSettings["MailDisplayName"].Trim());
                }
                else
                {
                    message.From = new MailAddress(ConfigurationSettings.AppSettings["AdminEmail"].Trim());
                }
                message.To.Add(sendMailTo);
                SmtpClient mailClient = new SmtpClient();
                message.Body = mailBody;
                message.Subject = mailSubject;
                message.IsBodyHtml = true;                
                string strCCEmail1 = ConfigurationSettings.AppSettings["CCEmail1"].Trim();
                string strCCEmail2 = ConfigurationSettings.AppSettings["CCEmail2"].Trim();
                string strCCEmail3 = ConfigurationSettings.AppSettings["CCEmail3"].Trim();
                //message.CC.Add(strCCEmail1 + "," + strCCEmail2 + "," + strCCEmail3);                
                //mailClient.Host = "smtp.gmail.com";
                //mailClient.Host = "relay-hosting.secureserver.net";
                mailClient.Host = ConfigurationSettings.AppSettings["SMTPHost"].Trim(); //"smtpout.secureserver.net";
                //mailClient.Host = "127.0.0.1";
                mailClient.Port = Int32.Parse(ConfigurationSettings.AppSettings["SMTPPort"].Trim()); //25;                
                //mailClient.UseDefaultCredentials = true;
                //mailClient.Credentials = new NetworkCredential("ops@3plintegration.com", "kickass3");                
                mailClient.Credentials = new NetworkCredential(ConfigurationSettings.AppSettings["AdminEmail"].Trim(), ConfigurationSettings.AppSettings["AdminEmailPwd"].Trim());
                //mailClient.Credentials = CredentialCache.DefaultNetworkCredentials;
                //mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                mailClient.EnableSsl = bool.Parse(ConfigurationSettings.AppSettings["SMTPEnableSsl"].Trim());                
                if (ConfigurationSettings.AppSettings["SendMailFlag"].Trim() == "Yes")
                {
                
                        mailClient.Send(message);
           
                }
                message.Dispose();
                return 1;
            }

            catch (Exception ex) { return 0; }
        }

        public static int sendMailInHtmlFormat(string sendMailForm, string sendMailTo,string strCCSemiColon, string mailSubject, string mailBody)
        {
            try
            {
                //MailMessage message = new MailMessage(sendMailForm, sendMailTo);
                MailMessage message = new MailMessage();
                if (ConfigurationSettings.AppSettings["MailDisplayNameFlag"].Trim() == "Yes")
                {
                    message.From = new MailAddress(ConfigurationSettings.AppSettings["AdminEmail"].Trim(), ConfigurationSettings.AppSettings["MailDisplayName"].Trim());
                }
                else
                {
                    message.From = new MailAddress(ConfigurationSettings.AppSettings["AdminEmail"].Trim());
                }
                message.To.Add(sendMailTo);
                SmtpClient mailClient = new SmtpClient();
                message.Body = mailBody;
                message.Subject = mailSubject;
                message.IsBodyHtml = true;
                string strCCEmail1 = ConfigurationSettings.AppSettings["CCEmail1"].Trim();
                string strCCEmail2 = ConfigurationSettings.AppSettings["CCEmail2"].Trim();
                string strCCEmail3 = ConfigurationSettings.AppSettings["CCEmail3"].Trim();
                
                if (strCCSemiColon.Trim() != "" && strCCSemiColon.IndexOf(";") != -1)
                {
                    strCCSemiColon = strCCSemiColon.Trim().Replace(" ", "").Replace(";", ",");
                }
                if (strCCSemiColon.Trim() != "")
                {
                    if (sendMailTo.Trim() != "")
                    {
                        strCCSemiColon = strCCSemiColon.Trim().Replace(sendMailTo, "");
                    }
                }
                //message.CC.Add(strCCEmail1 + "," + strCCEmail2 + "," + strCCEmail3 + "," + strCCSemiColon);
                message.CC.Add(strCCSemiColon);
                //mailClient.Host = "relay-hosting.secureserver.net";
                //mailClient.Host = "smtpout.secureserver.net";
                mailClient.Host = ConfigurationSettings.AppSettings["SMTPHost"].Trim();
                //mailClient.Port = 25;  
                mailClient.Port = Int32.Parse(ConfigurationSettings.AppSettings["SMTPPort"].Trim());
                //mailClient.UseDefaultCredentials = true;
                //mailClient.Credentials = CredentialCache.DefaultNetworkCredentials;
                //mailClient.Credentials = new NetworkCredential("ops@3plintegration.com", "kickass3");
                mailClient.Credentials = new NetworkCredential(ConfigurationSettings.AppSettings["AdminEmail"].Trim(), ConfigurationSettings.AppSettings["AdminEmailPwd"].Trim());
                //mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                mailClient.EnableSsl = bool.Parse(ConfigurationSettings.AppSettings["SMTPEnableSsl"].Trim());
                if (ConfigurationSettings.AppSettings["SendMailFlag"].Trim() == "Yes")
                {
                    mailClient.Send(message);
                }
                message.Dispose();
                return 1;
            }
            catch (Exception ex) { return 0; }
        }

        public static int sendMailWithAttch(string sendMailForm, string sendMailTo, string mailSubject, string mailBody, string strAttachPath)
        {
            try
            {
                //MailMessage message = new MailMessage(sendMailForm, sendMailTo);
                MailMessage message = new MailMessage();
                if (ConfigurationSettings.AppSettings["MailDisplayNameFlag"].Trim() == "Yes")
                {
                    message.From = new MailAddress(ConfigurationSettings.AppSettings["AdminEmail"].Trim(), ConfigurationSettings.AppSettings["MailDisplayName"].Trim());
                }
                else
                {
                    message.From = new MailAddress(ConfigurationSettings.AppSettings["AdminEmail"].Trim());
                }
                message.To.Add(sendMailTo);
                SmtpClient mailClient = new SmtpClient();
                message.Body = mailBody;
                message.Subject = mailSubject;
                message.IsBodyHtml = true;
                message.Attachments.Add(new Attachment(strAttachPath));
                string strCCEmail1 = ConfigurationSettings.AppSettings["CCEmail1"].Trim();
                string strCCEmail2 = ConfigurationSettings.AppSettings["CCEmail2"].Trim();
                string strCCEmail3 = ConfigurationSettings.AppSettings["CCEmail3"].Trim();
                //message.CC.Add(strCCEmail1 + "," + strCCEmail2 + "," + strCCEmail3);                
                //mailClient.Host = "smtp.gmail.com";
                //mailClient.Host = "relay-hosting.secureserver.net";
                mailClient.Host = ConfigurationSettings.AppSettings["SMTPHost"].Trim();
                //mailClient.Port = 25;  
                mailClient.Port = Int32.Parse(ConfigurationSettings.AppSettings["SMTPPort"].Trim());
                //mailClient.Host = "127.0.0.1";
                //mailClient.Port = 25;
                //mailClient.UseDefaultCredentials = true;
                //mailClient.Credentials = new NetworkCredential("ops@3plintegration.com", "kickass3");                
                //mailClient.Credentials = new NetworkCredential("ops@3plintegration.com", "kickass3");
                mailClient.Credentials = new NetworkCredential(ConfigurationSettings.AppSettings["AdminEmail"].Trim(), ConfigurationSettings.AppSettings["AdminEmailPwd"].Trim());
                //mailClient.Credentials = CredentialCache.DefaultNetworkCredentials;
                //mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                //mailClient.EnableSsl = true;    
                mailClient.EnableSsl = bool.Parse(ConfigurationSettings.AppSettings["SMTPEnableSsl"].Trim());
                if (ConfigurationSettings.AppSettings["SendMailFlag"].Trim() == "Yes")
                {
                    mailClient.Send(message);
                }
                message.Dispose();
                return 1;
            }

            catch (Exception ex) { return 0; }
        }

        public static int sendMail(string sendMailForm, string sendMailTo, string mailSubject, string mailBody)
        {
            try
            {
                MailMessage message = new MailMessage(sendMailForm, sendMailTo);
                SmtpClient mailClient = new SmtpClient("127.0.0.1", 25);
                message.Body = mailBody;
                message.Subject = mailSubject;

                //mailClient.Host = "mail.gmail.com";
                mailClient.UseDefaultCredentials = false;
                if (ConfigurationSettings.AppSettings["SendMailFlag"].Trim() == "Yes")
                {
                    mailClient.Send(message);
                }
                message.Dispose();
                return 1;
            }

            catch (Exception ex) { return 0; }
        }
        public static bool isDate(string date)
        {
            DateTime dt=new DateTime();
            return DateTime.TryParse(date,out dt);
        }        
    }
}