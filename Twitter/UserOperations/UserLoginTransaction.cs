using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Resources;
using Twitter.Response;
using static Twitter.UserOperations.LoginMessages;

namespace Twitter.UserOperations
{
    public class UserLoginTransaction
    {

        private static ResponseMessage Validate(LoginRequest request)
        {
            using (var context = new TwitterDBContext())
            {
                ResponseMessage response = new ResponseMessage();
                if (request.Email == "" || request.Password == "")
                {
                    response.Success = false;
                    response.Message = context.Resource.FirstOrDefault(x => x.Name == "EmptyFieldError" &&
                    x.LanguageId == General.UserIdAndLanguageId.LanguageId).Message;
                }
                else
                {
                    response.Success = true;
                    response.Message = "Success";
                }
                return response;
            }
        }

        public static ResponseMessage Execute(LoginRequest request)
        {
            ResponseMessage response = Validate(request);
            if(!response.Success)
            {
                return response;
            }
            var context = new TwitterDBContext();
            var user = context.User.FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password);
            if(user != null)
            {
                response.Success = true;
                response.Message = "Succes";
                General.UserIdAndLanguageId.UserId = user.UserId;
                return response;
            }
            response.Success = false;
            response.Message = ResourcesTransaction.GetLoginError().Message;
            context.Dispose();
            return response;
        }
    }
}
