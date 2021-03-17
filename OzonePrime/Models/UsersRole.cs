using System;
using System.Collections.Generic;

#nullable disable

namespace OzonePrime.Models
{
    public partial class UsersRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
