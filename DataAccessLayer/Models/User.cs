using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccessLayer.Models
{
    public partial class User
    {
        public User()
        {
            ChatMessagesReceiverNavigation = new HashSet<ChatMessages>();
            ChatMessagesSenderNavigation = new HashSet<ChatMessages>();
            ChatUser1Navigation = new HashSet<Chat>();
            ChatUser2Navigation = new HashSet<Chat>();
            Comment = new HashSet<Comment>();
            CommentLike = new HashSet<CommentLike>();
            FollowerFollowedByNavigation = new HashSet<Follower>();
            FollowerUser = new HashSet<Follower>();
            Like = new HashSet<Like>();
            Post = new HashSet<Post>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int TotalFollower { get; set; }
        public int TotalPost { get; set; }

        public virtual ICollection<ChatMessages> ChatMessagesReceiverNavigation { get; set; }
        public virtual ICollection<ChatMessages> ChatMessagesSenderNavigation { get; set; }
        public virtual ICollection<Chat> ChatUser1Navigation { get; set; }
        public virtual ICollection<Chat> ChatUser2Navigation { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<CommentLike> CommentLike { get; set; }
        public virtual ICollection<Follower> FollowerFollowedByNavigation { get; set; }
        public virtual ICollection<Follower> FollowerUser { get; set; }
        public virtual ICollection<Like> Like { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
