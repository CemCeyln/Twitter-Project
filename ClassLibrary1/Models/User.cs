using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
