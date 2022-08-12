using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Messages
{
    public class CommentMessages
    {
        public class GetCommentsRequest
        {

        }

        public class GetCommentsResponse
        {
            public Comment comment { get; set; }
            public int commentUserId { get; set; }
            public string commentUserName { get; set; }
            public string commentProfilePicture { get; set; }
        }

        public class AddCommentRequest
        {
            public int postId { get; set; }
            public int userId { get; set; }
            public string commentBody { get; set; }

        }

        public class AddCommentResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
        }

        public class DeleteCommentResponse
        {
            public bool Success { get; set; }

            public string Message { get; set; }
        }
    }
}
