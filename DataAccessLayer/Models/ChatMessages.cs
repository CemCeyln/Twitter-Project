using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccessLayer.Models
{
    public partial class ChatMessages
    {
        public ChatMessages()
        {
            Chat = new HashSet<Chat>();
        }

        public int MessageId { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }

        public virtual User ReceiverNavigation { get; set; }
        public virtual User SenderNavigation { get; set; }
        public virtual ICollection<Chat> Chat { get; set; }
    }
}
