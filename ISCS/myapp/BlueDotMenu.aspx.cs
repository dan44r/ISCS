using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;

namespace ISCS.myapp
{
    public partial class BlueDotMenu : System.Web.UI.Page
    {
        private String txtServiceResponse = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //GetBlueDotMenu();
        }

        //protected void GetBlueDotMenu()
        //{
        //    HttpContext.Current.Session["serviceEndPoint"] = Constants.PlatformApiEndpoints.BlueDotAppMenuUrl;
        //    OAuthConsumerContext consumerContext = new OAuthConsumerContext
        //    {
        //        ConsumerKey = ConfigurationManager.AppSettings["consumerKey"].ToString(),
        //        SignatureMethod = SignatureMethod.HmacSha1,
        //        ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"].ToString()
        //    };

        //    OAuthSession oSession = new OAuthSession(consumerContext, Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlRequestToken,
        //                          Constants.OauthEndPoints.AuthorizeUrl,
        //                          Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlAccessToken);

        //    oSession.ConsumerContext.UseHeaderForOAuthParameters = true;

        //    oSession.AccessToken = new TokenBase
        //    {
        //        Token = Session["accessToken"].ToString(),
        //        ConsumerKey = ConfigurationManager.AppSettings["consumerKey"].ToString(),
        //        TokenSecret = Session["accessTokenSecret"].ToString()
        //    };

        //    IConsumerRequest conReq = oSession.Request();
        //    conReq = conReq.Get();
        //    conReq = conReq.ForUrl(HttpContext.Current.Session["serviceEndPoint"].ToString());
        //    try
        //    {
        //        conReq = conReq.SignWithToken();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    string header = conReq.Context.GenerateOAuthParametersForHeader();
        //    try
        //    {
        //        txtServiceResponse = conReq.ReadBody();
        //        Response.Write(txtServiceResponse);
        //    }
        //    catch (WebException we)
        //    {
        //        HttpWebResponse rsp = (HttpWebResponse)we.Response;
        //        if (rsp != null)
        //        {
        //            try
        //            {
        //                using (StreamReader reader = new StreamReader(rsp.GetResponseStream()))
        //                {
        //                    txtServiceResponse = txtServiceResponse + rsp.StatusCode + " | " + reader.ReadToEnd();
        //                }
        //            }
        //            catch (Exception)
        //            {
        //                txtServiceResponse = txtServiceResponse + "Status code: " + rsp.StatusCode;
        //            }
        //        }
        //        else
        //        {
        //            txtServiceResponse = txtServiceResponse + "Error Communicating with App Menu Platform API" + we.Message;
        //        }
        //    }
        //}
    }
}
