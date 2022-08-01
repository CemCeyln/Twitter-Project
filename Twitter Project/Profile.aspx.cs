using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter;
using Twitter.Messages;
using Twitter.UserOperations;
using static Twitter.Messages.UpdateUserMessages;

namespace Twitter_Project
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LanguageControl();
            GetUserInfoMessages user = GetUserInfo.Execute((int)Session["Language"]);
            Email.Text = user.Email;
            Name.Text = user.Name;
        }

        void LanguageControl()
        {
            if ((int)Session["Language"] == 1) //English
            {                          
                NameLabel.Text = General.Labels.NameLabelEnglish;
                ProfilePictureLabel.Text = General.Labels.ProfilePictureLabelEnglish;
            }
            else if ((int)Session["Language"] == 2) //Turkish
            {             
                NameLabel.Text = General.Labels.NameLabelTurkish;
                ProfilePictureLabel.Text = General.Labels.NameLabelTurkish;
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string imagePath = "";
            string extension = ".jpg";
            if(ProfilePictureUpload.HasFile)
            {

                string savePath = Server.MapPath("/File/");
                string fileName = System.Guid.NewGuid().ToString();
                imagePath = savePath + fileName + extension;

                ProfilePictureUpload.SaveAs(imagePath);
                UpdateUserRequest request = new UpdateUserRequest();
                request.Name = Name.Text;
                request.Email = Email.Text;
                request.Image = fileName + extension;
                UpdateUserResponse response = UpdateUserTransaction.Execute(request);
                if(response.Success)
                {
                    ErrorMessageLabel.ForeColor = System.Drawing.Color.Green;
                    ErrorMessageLabel.Text = response.Message;
                }
                else
                {
                    ErrorMessageLabel.Text = response.Message;
                }
               
            }

        }

    }
}