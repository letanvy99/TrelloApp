using System;
using System.Net;

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
