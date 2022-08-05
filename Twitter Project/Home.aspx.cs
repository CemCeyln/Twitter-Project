using DataAccessLayer.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Twitter;
using Twitter.HomePageOperations;
using static Twitter.Messages.CommentMessages;

namespace Twitter_Project
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                General.UserIdAndLanguageId.UserId = 2;
                var posts = GetPosts.Execute(General.UserIdAndLanguageId.UserId);
                postRepeater.DataSource = posts.OrderByDescending(x => x.post.CreatedDate);
                postRepeater.DataBind();
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
                if(comments.Count > 1)
                {
                    ((Label)e.Item.FindControl("commentCountLabel")).Text = comments.Count.ToString() + " comments";
                }
                else
                {
                    ((Label)e.Item.FindControl("commentCountLabel")).Text = comments.Count.ToString() + " comment";
                }
            }
        }
        protected void PostRepeaterItemCommand(object sender, RepeaterCommandEventArgs e)
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
                Response.Redirect("Home");            }
        }
    }
}