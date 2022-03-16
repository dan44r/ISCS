using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;

namespace ISCS.myapp
{
    public partial class OauthGrant : System.Web.UI.Page
    {
        private String consumerSecret, consumerKey, oauthLink, RequestToken, TokenSecret, oauth_callback_url;

        protected void Page_Load(object sender, EventArgs e)
        {
            //oauth_callback_url = Request.Url.GetLeftPart(UriPartial.Authority) + ConfigurationManager.AppSettings["oauth_callback_url"];
            oauth_callback_url = Request.Url.GetLeftPart(UriPartial.Authority) + "/myapp/RequestOAuthToken.aspx";
            //consumerKey = ConfigurationManager.AppSettings["consumerKey"];
            //consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
            //oauthLink = Constants.OauthEndPoints.IdFedOAuthBaseUrl;
            consumerKey = "qyprdjBtLypqvOc9RuXIqczUmLMfz2";
            consumerSecret = "N9iKeesj8OMHddjZTNxlT3QEwD4YvPBn6VfHD9Px";
            oauthLink = "https://oauth.intuit.com/oauth/v1";

            HttpContext.Current.Session["requestToken"] = "lvprdlV7sKjLSNS1KfXS0fHf7hLNI3fptErErpx1aGNLys9B";
            IToken token = (IToken)HttpContext.Current.Session["requestToken"];
            IOAuthSession session = CreateSession();
            IToken requestToken = session.GetRequestToken();
            HttpContext.Current.Session["requestToken"] = requestToken;
            RequestToken = requestToken.Token;
            TokenSecret = requestToken.TokenSecret;
            //oauthLink = Constants.OauthEndPoints.AuthorizeUrl + "?oauth_token=" + RequestToken + "&oauth_callback=" + UriUtility.UrlEncode(oauth_callback_url);
            oauthLink = "https://workplace.intuit.com/Connect/Begin" + "?oauth_token=" + RequestToken + "&oauth_callback=" + UriUtility.UrlEncode(oauth_callback_url);
            Response.Redirect(oauthLink);
        }

        protected IOAuthSession CreateSession()
        {
            OAuthConsumerContext consumerContext = new OAuthConsumerContext
            {
                ConsumerKey = consumerKey,
                ConsumerSecret = consumerSecret,
                SignatureMethod = SignatureMethod.HmacSha1
            };
            //return new OAuthSession(consumerContext,
            //                                Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlRequestToken,
            //                                oauthLink,
            //                                Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlAccessToken);
            return new OAuthSession(consumerContext,
                                            "https://oauth.intuit.com/oauth/v1" + "/get_request_token",
                                            oauthLink,
                                            "https://oauth.intuit.com/oauth/v1" + "/get_access_token");
        }
    }
}
