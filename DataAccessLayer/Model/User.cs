﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccessLayer.Model
{
    public partial class User
    {
        public User()
        {
            FollowerFollowedByNavigation = new HashSet<Follower>();
            FollowerUser = new HashSet<Follower>();
            Post = new HashSet<Post>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Follower> FollowerFollowedByNavigation { get; set; }
        public virtual ICollection<Follower> FollowerUser { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}