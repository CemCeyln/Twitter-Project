using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Messages;
using static Twitter.Messages.UpdateUserMessages;

namespace Twitter.UserOperations
{
    public class UpdateUserTransaction
    {
        private static UpdateUserResponse Validate(UpdateUserRequest request)
        {
            int languageId = General.UserIdAndLanguageId.LanguageId;
            UpdateUserResponse response = new UpdateUserResponse();
            using (var context = new TwitterDBContext())
            {
                if (request.Email == null || request.Name == null)
                {
                    response.Success = false;
                    response.Message = context.Resource.FirstOrDefault(x => x.Name == "EmailandNameEmptyError" && x.LanguageId == languageId).Message;
                }
                else
                {
                    response.Success = true;
                    response.Message = "Succes";
                }
                    return response;
            }
        }

        public static UpdateUserResponse Execute(UpdateUserRequest request)
        {
            UpdateUserResponse response = Validate(request);
            int userId = General.UserIdAndLanguageId.UserId;
            if (!response.Success)
            {
                return response;
            }
            else
            {
                using (var context = new TwitterDBContext())
                {
                    using (var dbTran = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var user = context.User.FirstOrDefault(x => x.UserId == userId);
                            if(user != null)
                            {
                                user.Email = request.Email;
                                user.Name = request.Name;
                                user.Image = request.Image;
                                context.SaveChanges();
                                dbTran.Commit();
                                response.Success = true;
                                response.Message = "Succes";
                                return response;
                            }
                        }
                        catch(Exception e)
                        {
                            dbTran.Rollback();
                            response.Success = false;
                            response.Message = e.Message;
                            return response;
                        }
                    }
                }
            }
            return null;
        }
    }
}
