using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Comunication.Requests
{
    public class RequestFilterBooksJson
    {
        public int PageNumber { get; set; }
        public string? Title { get; set; }
    }
}
    