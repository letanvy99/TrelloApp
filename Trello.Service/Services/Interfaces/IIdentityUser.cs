namespace Trello.Service.Services.Interfaces
{
    public interface IIdentityUser
    {
        int UserId { get; set; }
    }
    public class IdentityUser : IIdentityUser
    {
        public IdentityUser() { }
        public int UserId { get; set; }
    }
}
