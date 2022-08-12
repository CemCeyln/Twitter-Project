using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Messages
{
    public class ChatMessages
    {
        public class GetChatsRequest
        {

        }

        public class GetChatsResponse
        {
            public Chat chat { get; set; }
            public string chatPersonName { get; set; }
            public int chatPersonId { get; set; }
            public string chatPersonProfilePicture { get; set; }

        }
    }
}
