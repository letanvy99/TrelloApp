﻿using System;
using System.Net;

namespace Trello.Service.Exceptions
{
    public class BadRequestException : HttpException
    {
        public BadRequestException(string message)
            : base(HttpStatusCode.BadRequest, message)
        {
        }

        public BadRequestException(string message, Exception innerException)
            : base(HttpStatusCode.BadRequest, message, innerException)
        {
        }
    }
}
