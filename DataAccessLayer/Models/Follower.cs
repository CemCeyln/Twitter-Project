using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccessLayer.Models
{
    public partial class Follower
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FollowedBy { get; set; }

        public virtual User FollowedByNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
