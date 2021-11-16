using System;
using System.Net;

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
