using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Messages;
using static Twitter.Messages.SearchUserMessages;

namespace Twitter.UserOperations
{
    public class SearchUser
    {
        private static SearchUserResponse Validate(string searchWord)
        {
            SearchUserResponse response = new SearchUserResponse();
            if(searchWord != null)
            {
                response.Success = true;
                response.Message = "Success";
            }
            else
            {
                response.Success = false;
                response.Message = "Search field can not be empty";
            }
            return response;
        }

        public static SearchUserResponse Execute(string searchWord)
        {
            SearchUserResponse response = Validate(searchWord);
            List<GetUserInfoMessages> userInfos = new List<GetUserInfoMessages>();
            if (response.Success)
            {
                using (var context = new TwitterDBContext())
                {
                    var users = context.User.Where(x => x.Name.Contains(searchWord));
                    foreach (var user in users)
                    {
                        GetUserInfoMessages userInfo = new GetUserInfoMessages();
                        userInfo.Name = user.Name;
                        userInfo.TotalFollowers = user.TotalFollower;
                        userInfo.TotalPost = user.TotalPost;
                        userInfo.ProfilePicture = user.Image;
                        userInfo.UserId = user.UserId;
                        userInfo.Email = user.Email;
                        userInfos.Add(userInfo);
                    }
                    response.users = userInfos;
                    return response;
                }
            }
            else
            {
                return response;
            }
        }
    }
}
