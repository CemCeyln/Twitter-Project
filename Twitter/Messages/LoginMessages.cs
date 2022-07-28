using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.UserOperations
{
    public class LoginMessages
    {
        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }    
        }
    }
}
