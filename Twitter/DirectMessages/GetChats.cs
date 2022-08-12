using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Twitter.Messages.ChatMessages;

namespace Twitter.DirectMessages
{
    public class GetChats
    {
         private void Validate()
        {

        }
        public static List<GetChatsResponse> Execute(int userId)
        {
            using (var context = new TwitterDBContext())
            {
               var chats = context.Chat.Include("ChatMessages").Where(x => x.User1 == userId || x.User2 == userId);
                if(chats.Any())
                {
                    foreach(var chat in chats)
                    {
                        var response = new GetChatsResponse();
                        response.chat = chat;
                        if(chat.User1 == userId)
                        {
                            response.chatPersonId = chat.User2;
                            var chatPerson = context.User.FirstOrDefault(x => x.UserId == chat.User2);
                            response.chatPersonName = chatPerson.Name;
                            response.chatPersonProfilePicture = chatPerson.Image;
                        }
                        
                    }
                }
            }
            return null;
        }
    }
}
