using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter;
using Twitter.UserOperations;

namespace Twitter_Project
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void SetSession(object sender, EventArgs e)
        {
            Session["ProfileId"] = General.UserIdAndLanguageId.UserId;
            Response.Redirect("Profile");
        }

        public void SearchUser_Click(object sender, EventArgs e)
        {
            
            string searchWord = searchBox.Text;
            Session["SearchWord"] = searchWord;
            Response.Redirect("SearchUserResults");
            
        }
    }
}