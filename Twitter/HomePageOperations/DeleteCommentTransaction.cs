using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Twitter.Messages.CommentMessages;

namespace Twitter.HomePageOperations
{
    public class DeleteCommentTransaction
    {
        private static DeleteCommentResponse Validate(int commentId)
        {
            using (var context = new TwitterDBContext())
            {
                var response = new DeleteCommentResponse();
                if(context.Comment.FirstOrDefault(x => x.CommentId == commentId) != null)
                {
                    response.Success = true;
                    response.Message = "Success";
                }
                else
                {
                    response.Success=false;
                    response.Message = "There is no such comment";
                }
                return response;
            }
        }

        public static DeleteCommentResponse Execute(int commentId)
        {
            DeleteCommentResponse response = Validate(commentId);
            if(response.Success)
            {
                using (var context = new TwitterDBContext())
                {
                    using (var dbTran = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var deletedComment = context.Comment.FirstOrDefault(x => x.CommentId == commentId);
                            context.Comment.Remove(deletedComment);
                            context.SaveChanges();
                            dbTran.Commit();
                        }
                        catch(Exception ex)
                        {
                            response.Success = false;
                            response.Message = ex.Message; 
                            dbTran.Rollback();
                        }
                    }
                }
            }
            return response;
        }
    }
}
