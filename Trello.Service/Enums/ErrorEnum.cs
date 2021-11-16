using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Service.Enums
{
    public enum ErrorEnum
    {
        [Description("INCORRECT_USERNAME_OR_PASSWORD")]
        LoginFail,

        [Description("EXPIRED_TOKEN")]
        ExpiredToken,

        [Description("NOTFOUND_LIST")]
        NotFoundList
    }
}
