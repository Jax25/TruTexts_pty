using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruTexts.ClassLibrary
{
    public class LoginValidator : IValidator
    {
        List<User> AuthenticatedUsers { get; set; }

        DatabaseObject db { get; set; }
        //composition relationship

        public LoginValidator()
        {
            this.db = new DatabaseObject();
            this.db.ReadUsers();

            db.CloseConnection();

            this.AuthenticatedUsers = new List<User>();
            this.AuthenticatedUsers = db.listofusers;
        }
        public bool Isvalid(User user)
        {
            bool response = false;

            foreach (User auth_user in this.AuthenticatedUsers)
            {
                if (auth_user.Equals(user))
                    response = true;
            }

            return response;
        }
    }
}
