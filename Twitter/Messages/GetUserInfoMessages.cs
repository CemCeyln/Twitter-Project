using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Messages
{
    public class GetUserInfoMessages
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string ProfilePicture { get; set; }
        public int TotalFollowers { get; set; }
        public int TotalPost { get; set; }
    }
}
