using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruTexts.ClassLibrary
{
    public class UnauthenticatedUser : User
    {
        public override string username { get; set; }
        public override string password { get; set; }
    }
}