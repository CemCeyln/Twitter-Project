using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Messages
{
    public class SearchUserMessages
    {
        public class SearchUserRequest
        {
            public string searchWord { get; set; }
        }

        public class SearchUserResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public List<GetUserInfoMessages> users {get; set;}
        }
    }
}
