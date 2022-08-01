using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Messages;

namespace Twitter.HomePageOperations
{
    public class GetPosts
    {
        private static void Validate()
        {

        }

        public static List<PostMessages> Execute(int userId)
        {
            using (var context = new TwitterDBContext())
            {
                List<int> followedPeopleIdList = context.Follower.Where(x => x.FollowedBy == userId).Select(k => k.UserId).ToList();
                List <User> followedPeople= context.User.Where(p => followedPeopleIdList.Contains(p.UserId)).ToList();
                var allPosts = context.Post.Where(p=> followedPeopleIdList.Contains(p.UserId)).ToList();
                List<PostMessages> postMessages = new List<PostMessages>();
                
                if(allPosts.Any() && followedPeople.Any())
                {
                    foreach (var followedPerson in followedPeople)
                    {
                        
                        List<Post> posts = new List<Post>();
                        posts.AddRange(allPosts.Where(x => x.UserId == followedPerson.UserId).OrderByDescending(z => z.CreatedDate).ToList());
                        foreach (var post in posts)
                        {
                            PostMessages postMessage = new PostMessages();
                            postMessage.userId = followedPerson.UserId;
                            postMessage.userName = followedPerson.Name;
                            postMessage.profilePicture = followedPerson.Image;
                            postMessage.post = post;
                            postMessages.Add(postMessage);
                        }
                    }
                    return postMessages;
                }
                return null;
            }
        }
    }
}
