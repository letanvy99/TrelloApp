using System.ComponentModel;

namespace Trello.Service.Enums
{
    public enum ErrorEnum
    {
        [Description("INCORRECT_USERNAME_OR_PASSWORD")]
        LoginFail,

        [Description("EXPIRED_TOKEN")]
        ExpiredToken,

        [Description("NOTFOUND_LIST")]
        NotFoundList,

        [Description("NOTFOUND_CARD")]
        NotFoundCard,

        [Description("NOTFOUND_CHECK_LIST")]
        NotFoundCheckList,

        [Description("NOTFOUND_ITEM")]
        NotFoundItem
    }
}
