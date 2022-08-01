using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Response;

namespace Twitter.LanguageOperations
{
    public class LanguageRequest
    {
        
    }

    public class LanguageResponse:ResponseMessage
    {
        public List<Language> LanguageData { get; set; }

    }
}
