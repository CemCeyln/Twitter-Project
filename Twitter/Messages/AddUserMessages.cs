using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.UserOperations
{
    public class AddUserRequest
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
        public string Name { get; set; }
    }

    public class AddUserResponse 
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
