using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Comunication.Requests;

namespace TechLibrary.Comunication.Responses
{
    public class ResponseBooksJson
    {
        public ResponsePaginationJson Pagination { get; set; } = default!;
        public List<ResponseBookJson> Books { get; set; } = [];
    }
}
