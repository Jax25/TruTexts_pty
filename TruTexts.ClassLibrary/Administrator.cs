using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruTexts.ClassLibrary
{
    public class Administrator : User
    {
        public override string username { get; set; }
        public override string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

    }
}
