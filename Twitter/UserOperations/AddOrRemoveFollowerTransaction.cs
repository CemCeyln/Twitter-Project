using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Twitter.Messages.FollowerMessages;

namespace Twitter.UserOperations
{
    public class AddOrRemoveFollowerTransaction
    {
        public void Validate()
        {

        }
        public static AddOrRemoveFollowerResponse Execute(AddOrRemoveFollowerRequest request)
        {
            int profileId = request.profileId;
            int userId = request.userId;
            var response = new AddOrRemoveFollowerResponse();
            using (var context = new TwitterDBContext())
            {
                using (var dbTran = context.Database.BeginTransaction())
                {
                    bool isFollowing = IsFollowing(request);
                    var followedUser = context.User.FirstOrDefault(x => x.UserId == profileId);
                    if (!isFollowing) //Not following, then follow
                    {
                        try
                        {
                            var newFollower = new Follower();
                            newFollower.UserId = profileId;
                            newFollower.FollowedBy = userId;
                            context.Follower.Add(newFollower);                      
                            followedUser.TotalFollower++;
                            context.SaveChanges();
                            dbTran.Commit();
                            response.Message = "Success";
                            response.Success = true;
                        }
                        catch(Exception ex)
                        {
                            response.Success = false;
                            response.Message = ex.ToString();
                            dbTran.Rollback();
                        }

                    }
                    else //Unfollow
                    {
                        try
                        {
                            var follower = context.Follower.FirstOrDefault(x => x.UserId == request.profileId &&
                                                                                   x.FollowedBy == request.userId);
                            context.Follower.Remove(follower);
                            followedUser.TotalFollower--;
                            context.SaveChanges();
                            dbTran.Commit();
                            response.Success =true;
                            response.Message = "Success";
                        }
                        catch(Exception e)
                        {
                            response.Success = false;
                            response.Message = e.ToString();
                            dbTran.Rollback();
                        }
                    }
                    return response;
                }
            }
        }
        public static bool IsFollowing(AddOrRemoveFollowerRequest request)
        {
            using (var context = new TwitterDBContext())
            {
                var follower = context.Follower.FirstOrDefault(x => x.UserId == request.profileId &&
                                                                                    x.FollowedBy == request.userId);
                if(follower == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
                
    }
}
