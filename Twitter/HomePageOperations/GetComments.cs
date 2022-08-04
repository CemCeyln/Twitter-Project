using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Twitter.Messages.CommentMessages;

namespace Twitter.HomePageOperations
{
    public class GetComments
    {
        private static void Validate()
        {

        }

        public static List<GetCommentsResponse> Execute(int postId)
        {
            using(var context = new TwitterDBContext())
            {
                var response = new List<GetCommentsResponse>();
                var comments = context.Comment.Where(x => x.PostId == postId).OrderBy(p => p.Date).ToList();
                if(comments != null)
                {
                    foreach(var comment in comments)
                    {
                        GetCommentsResponse commentResponse = new GetCommentsResponse();
                        var user = context.User.FirstOrDefault(x => x.UserId == comment.UserId);
                        commentResponse.comment = comment;
                        commentResponse.commentUserId = comment.UserId;
                        commentResponse.commentUserName = user.Name;
                        commentResponse.commentProfilePicture = user.Image;                       
                        response.Add(commentResponse);
                    }
                    return response;
                }
                return null;
            }
        }
    }
}
