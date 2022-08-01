using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DataAccessLayer.Models;
namespace Twitter.LanguageOperations
{
    public class GetLanguageData
    {
        private TwitterDBContext dBContext;

        private GetLanguageData()
        {
            dBContext = new TwitterDBContext();
        }

        public void Validate()
        {

        }
        
        public static LanguageResponse Execute()
        {
            
            var context = new TwitterDBContext();
            using (TransactionScope ts = new TransactionScope())
            {
                LanguageResponse response = new LanguageResponse();
                try
                {
                    //response.LanguageData = context.Language.ToList();
                    response.LanguageData = context.Language.ToList();
                    return response;
                    ts.Complete();
                    //dbTran.Commit();
                }
                catch (Exception ex)
                {
                   // dbTran.Rollback();
                    return null;
                }
            }
        }
    }
}
