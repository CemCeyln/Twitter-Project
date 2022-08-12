using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter;
using Twitter.DirectMessages;
using Twitter.UserOperations;

namespace Twitter_Project
{
    public partial class Messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int userId = General.UserIdAndLanguageId.UserId;
            var chats = GetChats.Execute(userId);
            var user = GetUserInfo.Execute(userId);
            profileImage.Src = "File/" + user.ProfilePicture;
            nameLabel.Text = user.Name;
            if (!Page.IsPostBack)
            {
                chatRepeater.DataSource = chats;
                chatRepeater.DataBind();
            }
        }
    }
}