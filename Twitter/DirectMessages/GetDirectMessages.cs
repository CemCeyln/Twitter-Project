using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DirectMessages
{
    public class GetDirectMessages
    {
        private void Validate()
        {

        }
        public static void Execute(int userId)
        {
            using (var context = new TwitterDBContext())
            {
                var chats = context.Chat.Where(x => x.User1 == userId || x.User2 == userId);
                if(chats.Any())
                {

                }
            }
        }
    }
}
