using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccessLayer.Models
{
    public partial class Chat
    {
        public int ChatId { get; set; }
        public int User1 { get; set; }
        public int User2 { get; set; }
        public DateTime LastUpdate { get; set; }
        public int LastMessage { get; set; }

        public virtual ChatMessages LastMessageNavigation { get; set; }
        public virtual User User1Navigation { get; set; }
        public virtual User User2Navigation { get; set; }
    }
}
