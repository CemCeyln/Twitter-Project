using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccessLayer.Models
{
    public partial class Language
    {
        public Language()
        {
            Resource = new HashSet<Resource>();
        }

        public int LanguageId { get; set; }
        public string Language1 { get; set; }

        public virtual ICollection<Resource> Resource { get; set; }
    }
}
