using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter;
using Twitter.HomePageOperations;
using Twitter.Messages;
using Twitter.UserOperations;
using static Twitter.Messages.CommentMessages;
using static Twitter.Messages.FollowerMessages;

namespace Twitter_Project
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Language"] = 1;
            var profileId = Convert.ToInt32(Session["ProfileId"]);
            GetUserInfoMessages user = GetUserInfo.Execute(profileId);
            var userId = General.UserIdAndLanguageId.UserId;
            if (profileId == userId)
            {
                postNameLabel.Text = "My Posts";
                followButton.Visible = false;
                messageButton.Visible = false;
            }
            else
            {              
                postNameLabel.Text = user.Name + "'s Posts";
            }
            if (!Page.IsPostBack)
            {   
                var posts = GetPosts.GetSpecificUsersPosts(Convert.ToInt32(profileId));
                if(posts != null)
                {
                    postRepeater.DataSource = posts.OrderByDescending(x => x.post.CreatedDate);
                    postRepeater.DataBind();
                }             
                profilePicture.Src = "File/" + user.ProfilePicture;
                totalFollowers.Text = user.TotalFollowers.ToString();
                totalPosts.Text = user.TotalPost.ToString();
                nameLabel.Text = user.Name;
                emailLabel.Text = user.Email;
                AddOrRemoveFollowerRequest request = new AddOrRemoveFollowerRequest();
                request.profileId = profileId;
                request.userId = userId;
                bool isFollowing = AddOrRemoveFollowerTransaction.IsFollowing(request);
                if (isFollowing)
                {
                    followButton.Text = "Unfollow";
                }
                else
                {
                    followButton.Text = "Follow";
                }
            }           
        }
        protected void SetSession(int userId)
        {
            Session["ProfileId"] = userId;
        }
        protected void PostRepeaterItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Comment")
            {
                TextBox commentBox = e.Item.FindControl("CommentBox") as TextBox;
                if (commentBox.Text != null)
                {
                    Label postIdLabel = e.Item.FindControl("postIdLabel") as Label;
                    var postId = postIdLabel.Text;
                    var userId = General.UserIdAndLanguageId.UserId;
                    var request = new AddCommentRequest();
                    request.userId = userId;
                    request.postId = Int32.Parse(postId);
                    request.commentBody = commentBox.Text;
                    AddCommentTransaction.Execute(request);
                    Response.Redirect("Home");
                }
            }
            else if (e.CommandName == "Profile")
            {
                Label userIdLabel = e.Item.FindControl("userIdLabel") as Label;
                int userId = Convert.ToInt32(userIdLabel.Text);
                SetSession(userId);
                Response.Redirect("Profile");
            }
        }
        protected void PostRepeaterItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater childRepeater = (Repeater)e.Item.FindControl("commentRepeater");
                var postId = ((Label)e.Item.FindControl("postIdLabel")).Text;
                var comments = GetComments.Execute(Int32.Parse(postId));
                childRepeater.DataSource = comments.OrderByDescending(x => x.comment.Date);
                childRepeater.DataBind();
                if (comments.Count > 1)
                {
                    ((Label)e.Item.FindControl("commentCountLabel")).Text = comments.Count.ToString() + " comments";
                }
                else
                {
                    ((Label)e.Item.FindControl("commentCountLabel")).Text = comments.Count.ToString() + " comment";
                }
            }
        }
        protected void CommentRepeaterItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            Label userIdLabel = e.Item.FindControl("commentUserIdLabel") as Label;
            int userId = Convert.ToInt32(userIdLabel.Text);
            SetSession(userId);
            Response.Redirect("Profile");
        }
        protected void FollowUnfollow(object sender, EventArgs e)
        {
            int profileId = Convert.ToInt32(Session["ProfileId"]);
            int userId = General.UserIdAndLanguageId.UserId;
            AddOrRemoveFollowerRequest request = new AddOrRemoveFollowerRequest();
            request.profileId = profileId;
            request.userId = userId;
            AddOrRemoveFollowerResponse response = AddOrRemoveFollowerTransaction.Execute(request);
            Response.Redirect("Profile");
        }
    }
}