using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccessLayer.Model
{
    public partial class Resource
    {
        public int ResourceId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }

        public virtual Language Language { get; set; }
    }
}
