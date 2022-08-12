using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using static Twitter.HomePageOperations.AddPost;

namespace Twitter.HomePageOperations
{
    public class AddPostTransaction
    {
        public static AddPostResponse Validate(AddPostRequest request)
        {
            AddPostResponse response = new AddPostResponse();
            using (var context = new TwitterDBContext())
            {
                var user = context.User.FirstOrDefault(x => x.UserId == request.UserId);
                if(user != null)
                {
                    response.Success = true;
                    response.Message = "Succes";
                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "User could not found";
                    return response;
                }
            }
                
            
        }

        public static AddPostResponse Execute(AddPostRequest request)
        {
            AddPostResponse response = Validate(request);
            if(response.Success)
            {
                using (var context = new TwitterDBContext())
                {
                    using (var dbTran = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var newPost = new Post();
                            newPost.UserId = request.UserId;
                            newPost.FilePath = request.FilePath;
                            newPost.Description = request.Description;
                            newPost.CreatedDate = DateTime.Now;
                            newPost.Likes = 0;
                            context.Post.Add(newPost);
                            var user = context.User.FirstOrDefault(x => x.UserId == request.UserId);
                            user.TotalPost = user.TotalPost + 1;
                            context.SaveChanges();
                            dbTran.Commit();
                        }
                        catch(Exception e)
                        {
                            dbTran.Rollback();
                            response.Success = false;
                            response.Message = e.Message;
                        }
                        
                    }
                }
            }
            return response;
            
        }
    }
}

