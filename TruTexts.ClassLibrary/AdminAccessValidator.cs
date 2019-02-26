using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruTexts.ClassLibrary
{
    public class AdminAccessValidator : IValidator
    {
        List<Administrator> administrators { get; set; }

        DatabaseObject db { get; set; }

        public AdminAccessValidator()
        {
            this.db = new DatabaseObject();
            this.db.ReadAdmin();

            db.CloseConnection();

            this.administrators = new List<Administrator>();
            this.administrators = db.administrators;
        }

        public bool Isvalid(User user)
        {
            bool response = false;
            foreach (User adminUser in this.administrators)
            {
                if (adminUser.Equals(user))
                    response = true;

            }

            return response;
        }
    }
}
