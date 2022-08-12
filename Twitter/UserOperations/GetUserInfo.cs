using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Messages;

namespace Twitter.UserOperations
{
    public class GetUserInfo
    {
        private static void Validate()
        {

        }
        public static GetUserInfoMessages Execute(int userId)
        {
            using (var context = new TwitterDBContext())
            {
                var user = context.User.FirstOrDefault(x=> x.UserId == userId);
                if (user != null)
                {
                    GetUserInfoMessages response = new GetUserInfoMessages();
                    response.Name = user.Name;
                    response.Email = user.Email;
                    response.ProfilePicture = user.Image;
                    response.TotalFollowers = user.TotalFollower;
                    response.TotalPost = user.TotalPost;
                    return response;
                }
            }
            return null;
        }
    }
}
