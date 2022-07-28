using DataAccessLayer.Models;
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
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            General.UserIdAndLanguageId.UserId = 1;
            var posts = GetPosts.Execute(General.UserIdAndLanguageId.UserId);
            postRepeater.DataSource = posts.OrderByDescending(x => x.post.CreatedDate);
            postRepeater.DataBind();
        }
    }
}