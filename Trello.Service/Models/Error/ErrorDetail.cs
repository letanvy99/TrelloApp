using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Service.Enums;
using Trello.Service.Helpers;

namespace Trello.Service.Models.Error
{
    public class ErrorDetail
    {
        public string ErrorCode { get; set; }

        public string Message { get; set; }

        public ErrorDetail() { }

        public ErrorDetail(ErrorEnum error)
        {
            ErrorCode = EnumHelper.GetEnumDescription(error);
        }
    }
}
