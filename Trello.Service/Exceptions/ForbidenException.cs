using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Service.Exceptions
{
    public class ForbidenException : HttpException
    {
        public ForbidenException(string message)
            : base(HttpStatusCode.Forbidden, message)
        {
        }

        public ForbidenException(string message, Exception innerException)
            : base(HttpStatusCode.Forbidden, message, innerException)
        {
        }
    }
}
