using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Response;

namespace Twitter.Resources
{
    public class ResourcesTransaction
    {
       
        private static void Validate()
        {

        }

        public static ResponseMessage GetLoginError()
        {
            int languageId = General.UserIdAndLanguageId.LanguageId;
            TwitterDBContext context = new TwitterDBContext();
            ResponseMessage response = new ResponseMessage();
            var LoginError = context.Resource.FirstOrDefault(x => x.LanguageId == languageId && x.Name == "LoginError");

            response.Message = LoginError.Message;
            context.Dispose();
            return response;
        }
    }
}
