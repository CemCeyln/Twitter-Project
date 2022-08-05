using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.HomePageOperations
{
    public class AddPost
    {
        public class AddPostRequest
        {
            public int UserId { get; set; } 
            public string FilePath { get; set; }
            public string Description { get; set; }

        }

        public class AddPostResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }    
        }
    }
}
