using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;

namespace CF.Web.Security
{
    public class CFFormAuthenticationModule // : IHttpModule
    {
        static Nullable<TimeSpan> timeout;

        static TimeSpan Timeout
        {
            get
            {
                if (!timeout.HasValue)
                {
                    timeout = AuthenticationSection.Forms.Timeout;
                }

                return timeout.Value;
            }
        }
        static AuthenticationSection AuthenticationSection
        {
            get
            {
                return (AuthenticationSection)ConfigurationManager.GetSection("system.web/authentication");
            }
        }

        public static FormsAuthenticationTicket CreateAuthenticationCookie(IUser user, Dictionary<string, string> tags, bool persist, bool addToResponse)
        {
            string userString = UserFactory.CreateUserString(user);
            string tagString = null;
            if (tags != null && tags.Count > 0)
            {
                string[] tagValues = new string[tags.Count];
                int i = 0;
                foreach (string key in tags.Keys)
                    tagValues[i++] = key + "=" + tags[key];

                tagString = string.Join("||", tagValues);

            }

            DateTime expires = persist ? DateTime.Now.AddYears(1) : DateTime.Now.Add(Timeout);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, expires, persist, userString);

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            if (ticket.IsPersistent)
                cookie.Expires = ticket.Expiration;
            if (!string.IsNullOrEmpty(FormsAuthentication.FormsCookiePath))
                cookie.Path = FormsAuthentication.FormsCookiePath;
            if (!string.IsNullOrEmpty(FormsAuthentication.CookieDomain))
                cookie.Domain = FormsAuthentication.CookieDomain;

            if (addToResponse)
                HttpContext.Current.Response.Cookies.Add(cookie);

            return ticket;
        }


        #region IHttpModule Members

        public void Dispose()
        {

        }

        //public void Init(HttpApplication context)
        //{
        //    if (IsFormsAuthenticationEnabled)
        //        context.AuthenticateRequest += new EventHandler(context_AuthenticateRequest);
        //}

        //protected bool IsFormsAuthenticationEnabled
        //{
        //    get
        //    {
        //        AuthenticationSection config = AuthenticationSection;

        //        return (config.Mode == AuthenticationMode.Forms);
        //    }
        //}

        //void context_AuthenticateRequest(object sender, EventArgs e)
        //{
        //    if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
        //    {
        //        HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
        //        if (authCookie == null)
        //            return;
        //        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
        //        if (ticket == null || ticket.Expired)
        //            return;

        //        if (FormsAuthentication.SlidingExpiration)
        //        {
        //            ticket = FormsAuthentication.RenewTicketIfOld(ticket);
        //            if (ticket.IsPersistent)
        //                authCookie.Expires = ticket.Expiration;
        //            authCookie.Value = FormsAuthentication.Encrypt(ticket);
        //            HttpContext.Current.Response.Cookies.Add(authCookie);
        //        }

        //        string data = ticket.UserData;

        //        if (string.IsNullOrEmpty(data))
        //            return;

        //        string[] tags;
        //        IUser user = UserFactory.CreateUser(data, out tags);
        //        string[] roles = user.Roles.Split('|');

        //        FormsIdentity identity = new FormsIdentity(ticket);
        //        HttpContext.Current.User = new CFPrincipal(identity, user, roles);

        //        if (tags != null)
        //            foreach (string item in tags)
        //            {
        //                string[] pair = item.Split('=');
        //                HttpContext.Current.Items[pair[0]] = pair.Length > 1 ? pair[1] : string.Empty;
        //            }
        //    }
        //}

        #endregion

        #region IHttpModule Members


        #endregion
    }
}
