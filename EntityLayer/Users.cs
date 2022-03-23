using CF.Web.Security;
using System;

namespace EntityLayer
{
    public class Users : CF.Web.Security.IUser
    {
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string PostalCode { get; set; }
        public int CountryId { get; set; }
        public string Fax { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public int AccountCodeId { get; set; }
        public int UserCode { get; set; }
        public string UserType { get; set; }

        #region IUser Members

        int IUser.Id
        {
            get { return UserId; }
        }

        string IUser.FirstName
        {
            get { return FirstName; }
        }

        string IUser.Name
        {
            get { return FirstName + " " + LastName; }
        }

        string IUser.Email
        {
            get { return Email; }
        }

        string IUser.Surname
        {
            get { return LastName; }
        }

        public string Roles
        {
            get;
            set;
        }

        #endregion




    }
}
