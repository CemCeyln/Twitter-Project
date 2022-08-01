using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter
{
    public class General
    {
        public enum Language
        {
            English = 1,
            Turkish = 2,
            
        }

        public static class UserIdAndLanguageId
        {
            public static int UserId { get; set; }
            public static int LanguageId { get; set; }
        }

        public static class Buttons
        {
            public static string LoginButtonEnglish = "Log in";
            public static string LoginButtonTurkish = "Giriş yap";
            public static string RegisterButtonEnglish = "Register";
            public static string RegisterButtonTurkish = "Kayıt ol";
        }

        public static class Labels
        {
            public static string PasswordLabelEnglish = "Password";
            public static string PasswordLabelTurkish = "Şifre";
            public static string ChangeLanguageLabelEnglish = "Change Language";
            public static string ChangeLanguageLabelTurkish = "Dili değiştir";
            public static string PasswordAgainLabelEnglish = "Password Again";
            public static string PasswordAgainLabelTurkish = "Şifre (Tekrar)";
            public static string NameLabelEnglish = "Name Surname";
            public static string NameLabelTurkish = "İsim Soyisim";
            public static string ProfilePictureLabelEnglish = "Profile Picture";
            public static string ProfilePictureLabelTurkish = "Profil Fotoğrafı";

        }

    }
}
