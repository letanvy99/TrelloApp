using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Service.Exceptions
{
    public class InternalErrorException : HttpException
    {
        public InternalErrorException(string message)
            : base(HttpStatusCode.InternalServerError, message)
        {
        }

        public InternalErrorException(string message, Exception innerException)
            : base(HttpStatusCode.InternalServerError, message, innerException)
        {
        }
    }
}
