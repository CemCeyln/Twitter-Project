using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DataAccessLayer.Models;
using System.Data;
using System.Data.Entity;
using Twitter.Response;
using Twitter.Resources;

namespace Twitter.UserOperations
{
    public class AddUserTransaction
    {
        private static ResponseMessage Validate(AddUserRequest request)
        {
            using (var context = new TwitterDBContext())
            {
                ResponseMessage response = new ResponseMessage();
                int languageId = General.UserIdAndLanguageId.LanguageId;
                if (request.Email == "" || request.Password1 == "" || request.Password2 == "" || request.Name == "")
                {
                    response.Success = false;
                    response.Message = context.Resource.FirstOrDefault(x => x.Name == "EmptyFieldError" &&
                    x.LanguageId == languageId).Message;
                }
                else if (request.Password1 != request.Password2)
                {
                    response.Success = false;
                    response.Message = context.Resource.FirstOrDefault(x => x.Name == "PasswordMatchError" &&
                    x.LanguageId == languageId).Message;
                }
                else
                {
                    response.Success = true;
                    response.Message = "Succes";
                }
                return response;
            }
        }

        public static ResponseMessage Execute(AddUserRequest request)
        {
            ResponseMessage response = Validate(request);
            if(!response.Success)
            {
                return response;
            }
            using (var context = new TwitterDBContext()) {
                var dbTran = context.Database.BeginTransaction();
                try
                {
                    User newUser = new User();
                    newUser.Email = request.Email;
                    newUser.Name = request.Name;
                    newUser.Password = request.Password1;
                    context.User.Add(newUser);
                    context.SaveChanges();
                    dbTran.Commit();
                    dbTran.Dispose();
                    response.Success = true;
                    response.Message = "Succes";                
                    return response;
                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    response.Message = ResourcesTransaction.GetLoginError().Message;
                    response.Success = false;
                }            
                return response;
            }

        }
    }
}
