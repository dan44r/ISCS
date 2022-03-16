using System;
using System.Collections.Generic;
using System.Text;


namespace CF.Web.Security
{
    public class UserFactory
    {
        public static string CreateUserString(IUser user)
        {
            return string.Concat(user.Id, ",", user.Email, ",", user.FirstName, ",", user.Surname, ",", user.Email, ",", user.Roles, ",", user.UserTypeId.ToString());
        }

        public static IUser CreateUser(IUser user)
        {
            return new User(user.Id, user.Email, user.FirstName, user.Surname, user.Email, user.Roles, user.UserTypeId);
        }

       
        public class User : IUser
        {
            public User(int id, string username, string firstName, string surname, string email, string roles,int UserTypeId)
            {
                this.id = id;
                this.username = username;
                this.firstName = firstName;
                this.surname = surname;
                this.email = email;
                this.roles = roles;
                this.UserTypeId = UserTypeId;
                
            }

            int id;
            string email, username, firstName, surname, roles;

            #region IUser Members

            public int Id
            {
                get { return id; }
            }

            public string Name
            {
                get { return string.Concat(FirstName, " ", Surname); }
            }

            public string Username
            {
                get { return username; }
            }

            public string FirstName
            {
                get { return firstName; }
            }

            public string Surname
            {
                get { return surname; }
            }

            public string Email
            {
                get { return email; }
            }

            public string Roles
            {
                get{ return roles; }
                set{ roles = value; }
            }
            public int UserTypeId { get; set; }
            #endregion
        }
    }
}