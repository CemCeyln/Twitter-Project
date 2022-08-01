using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Messages
{
    public class UpdateUserMessages
    {

        public class UpdateUserRequest
        {
            public string Email { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
        }

        public class UpdateUserResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
        }
    }
       
}
