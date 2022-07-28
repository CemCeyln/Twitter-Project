using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter;
using Twitter.LanguageOperations;
using Twitter.Response;
using Twitter.UserOperations;

namespace Twitter_Project
{
    public partial class Register : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                LanguageResponse response = GetLanguageData.Execute();
                LanguageDropDownList.DataTextField = "Language1";
                LanguageDropDownList.DataValueField = "LanguageId";
                LanguageDropDownList.DataSource = response.LanguageData;
                LanguageDropDownList.DataBind();
            }
            LanguageControl();
           
        }

        void LanguageControl()
        {
            if ((int)Session["Language"] == 1) //English
            {
                LoginButton.Text = General.Buttons.LoginButtonEnglish;
                RegisterButton.Text = General.Buttons.RegisterButtonEnglish;
                PasswordLabel1.Text = General.Labels.PasswordLabelEnglish;
                PasswordLabel2.Text = General.Labels.PasswordAgainLabelEnglish;
                NameLabel.Text = General.Labels.NameLabelEnglish;
                LanguageLabel.Text = General.Labels.ChangeLanguageLabelEnglish;
                OrLabel.Text = "Already have an account? Sign in";
                RegisterLabel.Text = "Register Now!";
            }
            else if ((int)Session["Language"] == 2) //Turkish
            {
                LoginButton.Text = General.Buttons.LoginButtonTurkish;
                RegisterButton.Text = General.Buttons.RegisterButtonTurkish;
                PasswordLabel1.Text = General.Labels.PasswordLabelTurkish;
                PasswordLabel2.Text= General.Labels.PasswordAgainLabelTurkish;
                NameLabel.Text = General.Labels.NameLabelTurkish;
                LanguageLabel.Text = General.Labels.ChangeLanguageLabelTurkish;
                OrLabel.Text = "Zaten hesabınız var mı? Giriş yapın.";
                RegisterLabel.Text = "Hemen Kayıt Ol!";
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {

            AddUserRequest addUserRequest = new AddUserRequest();
            addUserRequest.Email = Email.Text;
            addUserRequest.Name = Name.Text;
            addUserRequest.Password1 = Password1.Text;
            addUserRequest.Password2 = Password2.Text;

            ResponseMessage response = AddUserTransaction.Execute(addUserRequest);
            if(response.Success)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                ErrorMessageLabel.Text = response.Message;
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Language"] = int.Parse(LanguageDropDownList.SelectedValue);
            int languageId = Convert.ToInt32(Session["Language"]);
            General.UserIdAndLanguageId.LanguageId = languageId;
            LanguageControl();
        }
    }
}