using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowAdwords
{
    public class ConfigData
    {
        public string[] accountantEmails { get; set; }

        public string[] adWordsPHLTeamEmails { get; set; }

        public AuthToken authToken { get; set; }

        public string DownloadPath { get; set; }

        public bool TestForEmptyFields()
        {
            try
            {
                if (accountantEmails.Length == 0) return true;
                if (adWordsPHLTeamEmails.Length == 0) return true;
                if (authToken.IsEmpty()) return true;
                if (DownloadPath == "" || DownloadPath == null) return true;
            }
            catch
            {
                return true;
            }
            

            return false;
        }
        
    }
}
