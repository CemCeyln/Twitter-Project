using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Messages
{
    public  class PostMessages
    {
        public Post post { get; set; }
        public int userId { get; set; }

        public string userName { get; set; }
    }
}
