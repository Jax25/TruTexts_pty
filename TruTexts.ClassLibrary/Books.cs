using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruTexts.ClassLibrary
{
    public class Books 
    {
        public string bookTitle { get; set; }
        public string author { get; set; }
        public string yearPublished { get; set; }
    }
}

//add book.. check list for book. if book is not in list add it. if book is in list increment sales by 1