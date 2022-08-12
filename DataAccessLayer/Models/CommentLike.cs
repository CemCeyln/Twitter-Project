using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccessLayer.Models
{
    public partial class CommentLike
    {
        public int CommentLikeId { get; set; }
        public int CommentId { get; set; }
        public int LikedBy { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual User LikedByNavigation { get; set; }
    }
}
