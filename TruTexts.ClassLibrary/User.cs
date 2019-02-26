using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruTexts.ClassLibrary
{
    public abstract class User: IEquatable<User>
    {
        public abstract string username { get; set; }
        public abstract string password { get; set; }

        public bool Equals(User other)
        {
            if (this.username == other.username && this.password == other.password)
                return true;
            else
                return false;
        }
    }
}
