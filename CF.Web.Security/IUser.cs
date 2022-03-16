using System;
using System.Collections.Generic;
using System.Text;

namespace CF.Web.Security
{
    public interface IUser
    {
        int Id
        {
            get;
        }

        string Name
        {
            get;
        }

       

        string FirstName
        {
            get;
        }

        string Surname
        {
            get;
        }

        string Email
        {
            get;
        }

        int UserTypeId
        {
            get;
        }

        /// <summary>
        /// Should return a pipe delimited "|" list of roles.
        /// </summary>
        string Roles
        {
            get;
        }
    }
}