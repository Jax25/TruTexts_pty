using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruTexts.ClassLibrary
{
    public interface IValidator
    {
        bool Isvalid(User user);
    }
}
