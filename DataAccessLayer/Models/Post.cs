using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccessLayer.Models
{
    public partial class Post
    {
        public Post()
        {
            Comment = new HashSet<Comment>();
            Like = new HashSet<Like>();
        }

        public int PostId { get; set; }
        public int UserId { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? Likes { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Like> Like { get; set; }
    }
}
