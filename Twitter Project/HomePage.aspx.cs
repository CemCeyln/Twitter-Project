using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter;
using Twitter.HomePageOperations;

namespace Twitter_Project
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                General.UserIdAndLanguageId.UserId = 1;
                var posts = GetPosts.Execute(General.UserIdAndLanguageId.UserId);
                //postRepeater.DataSource = posts.OrderByDescending(x => x.post.CreatedDate);
                //postRepeater.DataBind();
            }

        }

        protected void CommentLoad(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater childRepeater = (Repeater)args.Item.FindControl("commentRepeater");
                Repeater parentRepeater = (Repeater)args.Item.FindControl("postRepeater");
                //var comments = GetComments.Execute(Int32.Parse(postId.Value));
                // childRepeater.DataSource = comments;
                childRepeater.DataBind();
            }
        }

        protected void AddComment(object sender, EventArgs e)
        {

        }
    }
}