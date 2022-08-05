using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Twitter.Messages.CommentMessages;

namespace Twitter.HomePageOperations
{
    public class AddCommentTransaction
    {
        private static AddCommentResponse Validate(int postId)
        {
            var response = new AddCommentResponse();
            using (var context = new TwitterDBContext())
            {
                var post = context.Post.FirstOrDefault(x => x.PostId == postId);
                if(post != null)
                {
                    response.Success = true;
                    response.Message = "Succes";
                    return response;
;                }
                else
                {
                    response.Success = false;
                    response.Message = "There is no such post";
                    return response;
                }
            }
            return null;
        }
        public static AddCommentResponse Execute(AddCommentRequest request)
        {
            var response = Validate(request.postId);
            if(!response.Success)
            {
                return response;
            }
            else
            {
                using (var context = new TwitterDBContext())
                {
                    using (var dbTran = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var newComment = new Comment();
                            newComment.Comment1 = request.commentBody;
                            newComment.Date = DateTime.Now;
                            newComment.UserId = request.userId;
                            newComment.PostId = request.postId;
                            context.Comment.Add(newComment);
                            context.SaveChanges();
                            dbTran.Commit();
                            response.Success = true;
                            response.Message = "Succes";
                            return response;
                        }
                        catch(Exception e)
                        {
                            dbTran.Rollback();
                            response.Success = false;
                            response.Message = e.Message;
                            return response;
                        }
                    }                         
                }
            }
        }
    }
}
