using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter;
using Twitter.HomePageOperations;
using static Twitter.HomePageOperations.AddPost;

namespace Twitter_Project
{
    public partial class AddPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void ShareButton_Click(object sender, EventArgs e)
        {
            var request = new AddPostRequest();
            if (ProfilePictureUpload.HasFile)
            {
                string imagePath = "";
                string extension = ".jpg";
                string savePath = Server.MapPath("/File/");
                string fileName = System.Guid.NewGuid().ToString();
                imagePath = savePath + fileName + extension;

                ProfilePictureUpload.SaveAs(imagePath);

                request.FilePath = fileName + extension;

            }
            request.Description = DescriptionTextBox.Text;
            request.UserId = General.UserIdAndLanguageId.UserId;
            AddPostResponse response = AddPostTransaction.Execute(request);
        }
    }
}