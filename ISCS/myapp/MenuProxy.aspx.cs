using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;
using System.Net;
using System.IO;

namespace ISCS.myapp
{
    public partial class MenuProxy : System.Web.UI.Page
    {
        private String txtServiceResponse = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            GetBlueDotMenu();
        }

        protected void GetBlueDotMenu()
        {
            //HttpContext.Current.Session["serviceEndPoint"] = Constants.PlatformApiEndpoints.BlueDotAppMenuUrl;
            HttpContext.Current.Session["serviceEndPoint"] = "https://workplace.intuit.com/api/v1/Account/AppMenu";
            OAuthConsumerContext consumerContext = new OAuthConsumerContext
            {
                //ConsumerKey = ConfigurationManager.AppSettings["consumerKey"].ToString(),
                ConsumerKey = "qyprdjBtLypqvOc9RuXIqczUmLMfz2",
                SignatureMethod = SignatureMethod.HmacSha1,
                //ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"].ToString()
                ConsumerSecret = "N9iKeesj8OMHddjZTNxlT3QEwD4YvPBn6VfHD9Px"
            };

            //OAuthSession oSession = new OAuthSession(consumerContext, Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlRequestToken,
            //                      Constants.OauthEndPoints.AuthorizeUrl,
            //                      Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlAccessToken);
            OAuthSession oSession = new OAuthSession(consumerContext, "https://oauth.intuit.com/oauth/v1" + "/get_request_token",
                                  "https://workplace.intuit.com/Connect/Begin",
                                  "https://oauth.intuit.com/oauth/v1" + "/get_access_token");

            oSession.ConsumerContext.UseHeaderForOAuthParameters = true;

            oSession.AccessToken = new TokenBase
            {
                //Token = Session["accessToken"].ToString(),
                //ConsumerKey = ConfigurationManager.AppSettings["consumerKey"].ToString(),
                //TokenSecret = Session["accessTokenSecret"].ToString()
                Token = "lvprdYVYhK3VRLOWJrw9UQLfhVPvBFtynj0VyqcXuhPUS6cM",
                ConsumerKey = "qyprdjBtLypqvOc9RuXIqczUmLMfz2",
                TokenSecret = "VnA80uQcYbvWjOZb2k7Rmz9VnbZJMeiAA6H7EVFn"
            };

            IConsumerRequest conReq = oSession.Request();
            conReq = conReq.Get();
            conReq = conReq.ForUrl(HttpContext.Current.Session["serviceEndPoint"].ToString());
            try
            {
                conReq = conReq.SignWithToken();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string header = conReq.Context.GenerateOAuthParametersForHeader();
            try
            {
                txtServiceResponse = conReq.ReadBody();
                Response.Write(txtServiceResponse);
            }
            catch (WebException we)
            {
                HttpWebResponse rsp = (HttpWebResponse)we.Response;
                if (rsp != null)
                {
                    try
                    {
                        using (StreamReader reader = new StreamReader(rsp.GetResponseStream()))
                        {
                            txtServiceResponse = txtServiceResponse + rsp.StatusCode + " | " + reader.ReadToEnd();
                        }
                    }
                    catch (Exception)
                    {
                        txtServiceResponse = txtServiceResponse + "Status code: " + rsp.StatusCode;
                    }
                }
                else
                {
                    txtServiceResponse = txtServiceResponse + "Error Communicating with App Menu Platform API" + we.Message;
                }
            }
        }
    }
}
