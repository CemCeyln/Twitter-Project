using System;
using System.Web.UI;
using Twitter;
using Twitter.LanguageOperations;
using Twitter.Response;
using Twitter.UserOperations;
using static Twitter.UserOperations.LoginMessages;

namespace Twitter_Project
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {          
            if (!Page.IsPostBack)
            {
                if (Session["Language"] == null)
                {
                    Session["Language"] = (int)General.Language.English;
                    int languageId = Convert.ToInt32(Session["Language"]);
                    General.UserIdAndLanguageId.LanguageId = languageId;
                }            
                LanguageControl();
                LanguageResponse response = GetLanguageData.Execute();
                LanguageDropDownList.DataTextField = "Language1";
                LanguageDropDownList.DataValueField = "LanguageId";
                LanguageDropDownList.DataSource = response.LanguageData;
                LanguageDropDownList.DataBind();
            }
        }

        void LanguageControl() {
            if ((int)Session["Language"] == 1) //English
            {
                LoginButton.Text = General.Buttons.LoginButtonEnglish;
                RegisterButton.Text = General.Buttons.RegisterButtonEnglish;
                PasswordLabel.Text = General.Labels.PasswordLabelEnglish;
                LanguageLabel.Text = General.Labels.ChangeLanguageLabelEnglish;
                WelcomeLabel.Text = "Welcome!";
                OrLabel.Text = "Or";
            }
            else if ((int)Session["Language"] == 2) //Turkish
            {
                LoginButton.Text = General.Buttons.LoginButtonTurkish;
                RegisterButton.Text = General.Buttons.RegisterButtonTurkish;
                PasswordLabel.Text = General.Labels.PasswordLabelTurkish;
                LanguageLabel.Text = General.Labels.ChangeLanguageLabelTurkish;
                WelcomeLabel.Text = "Hoş geldiniz!";
                OrLabel.Text = "Veya";
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
           
            LoginRequest newRequest = new LoginRequest();
            newRequest.Email = Email.Text;
            newRequest.Password = Password.Text;
            ResponseMessage response = UserLoginTransaction.Execute(newRequest);
            if (response.Success)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {             
                ErrorMessageLabel.Text = response.Message;
            }

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
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