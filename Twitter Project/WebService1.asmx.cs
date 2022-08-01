using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Twitter;

namespace Twitter_Project
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public void IncrementLikes(int postId)
        {
            using( var context = new TwitterDBContext())
            {
                using (var dbTran = context.Database.BeginTransaction())
                {
                    try
                    {
                        Post post = context.Post.FirstOrDefault(x => x.PostId == postId);
                        post.Likes = post.Likes + 1;
                        Like newLike = new Like();
                        newLike.PostId = postId;
                        newLike.LikedBy = General.UserIdAndLanguageId.UserId;
                        context.Like.Add(newLike);
                        context.SaveChanges();
                        dbTran.Commit();
                    }
                    catch
                    {
                        dbTran.Rollback();
                    }
                }
                 
            }
        }

        [WebMethod]
        public void DecrementLikes(int postId)
        {
            using (var context = new TwitterDBContext())
            {
                using (var dbTran = context.Database.BeginTransaction())
                {
                    Post post = context.Post.FirstOrDefault(x => x.PostId == postId);
                    if (post.Likes != 0)
                    {
                        try
                        {
                            post.Likes = post.Likes - 1;
                            var user = context.User.FirstOrDefault(x => x.UserId == General.UserIdAndLanguageId.UserId);
                            var like = context.Like.FirstOrDefault(x => x.PostId == postId && x.LikedBy == user.UserId);
                            if (like != null)
                            {
                                context.Like.Remove(like);
                            }
                            context.SaveChanges();
                            dbTran.Commit();
                        }
                        catch
                        {
                            dbTran.Rollback();
                        }
                       
                    }
                }                 
            }
        }
    }
}
