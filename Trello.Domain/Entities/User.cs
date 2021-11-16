using System;
using System.Collections.Generic;
using Trello.Domain.Base;

#nullable disable

namespace Trello.Domain.Entities
{
    public partial class User : DeleteEntity<int>
    {
        public User()
        {
            CardUsers = new HashSet<CardUser>();
            UserRoles = new HashSet<UserRole>();
            WorkspaceUsers = new HashSet<WorkspaceUser>();
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? Birthday { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<CardUser> CardUsers { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<WorkspaceUser> WorkspaceUsers { get; set; }
    }
}
