using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccessLayer.Models
{
    public partial class Comment
    {
        public Comment()
        {
            CommentLike = new HashSet<CommentLike>();
        }

        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Comment1 { get; set; }
        public DateTime Date { get; set; }
        public int? LikeCount { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CommentLike> CommentLike { get; set; }
    }
}
