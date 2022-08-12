using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter;
using Twitter.UserOperations;
using static Twitter.Messages.FollowerMessages;

namespace Twitter_Project
{
    public partial class SearchUserResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string searchWord = Session["SearchWord"].ToString();
            var response = SearchUser.Execute(searchWord);           
            if (response.Success && response.users.Any())
            {
                if (!Page.IsPostBack)
                {
                    profileRepeater.DataSource = response.users;
                    profileRepeater.DataBind();
                }         
            }
        }
        protected void SetSession(int userId)
        {
            Session["ProfileId"] = userId;
        }
        protected void ProfileRepeaterItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "Follow")
            {
                Label profileIdLabel = e.Item.FindControl("profileIdLabel") as Label;
                int profileId = Convert.ToInt32(profileIdLabel.Text);
                int userId = General.UserIdAndLanguageId.UserId;
                AddOrRemoveFollowerRequest request = new AddOrRemoveFollowerRequest();
                request.profileId = profileId;
                request.userId = userId;
                AddOrRemoveFollowerResponse response = AddOrRemoveFollowerTransaction.Execute(request);
                Response.Redirect("SearchUserResults");
            }
            else if (e.CommandName == "Profile")
            {
                Label profileIdLabel = e.Item.FindControl("profileIdLabel") as Label;
                int userId = Convert.ToInt32(profileIdLabel.Text);
                SetSession(userId);
                Response.Redirect("Profile");
            }
        }
        protected void ProfileRepeaterItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int userId = General.UserIdAndLanguageId.UserId;
            var profileId = ((Label)e.Item.FindControl("profileIdLabel")).Text;
            Button followButton = e.Item.FindControl("followButton") as Button;
            AddOrRemoveFollowerRequest request = new AddOrRemoveFollowerRequest();
            request.profileId =Convert.ToInt32(profileId);
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
}