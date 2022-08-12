using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Messages
{
    public class FollowerMessages
    {
        public class AddOrRemoveFollowerRequest
        {
            public int profileId { get; set; }
            public int userId { get; set; }
        }
        public class AddOrRemoveFollowerResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
        }
    }
}
