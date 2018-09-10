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
        
    }
}
