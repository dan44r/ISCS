using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;

namespace CF.Web.Security
{
    public class CFPrincipal : IPrincipal
    {
        public CFPrincipal(IIdentity identity, IUser userInfo, string[] roles)
        {
            this.identity = identity;
            this.userInfo = userInfo;
            this.roles = new List<string>(roles);
        }

        List<string> roles;
        IIdentity identity;
        IUser userInfo;

        public IUser UserInfo
        {
            get { return userInfo; }
        }

        #region IPrincipal Members

        public IIdentity Identity
        {
            get { return identity; }
        }

        public bool IsInRole(string role)
        {
            string[] roleArray = null;
            if (role != null)
            {
                roleArray  = role.Split(',');

                foreach (string r in roleArray)
                    if (roles.Contains(r.Trim()))
                        return true;
            }
            return false;
        }

        #endregion
    }
}
