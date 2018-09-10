using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowAdwords
{
    public static class Mailer
    { 
        /// <summary>
        /// Sends Callfire Report to our PHL Team emails which have been selected
        /// </summary>
        /// <param name="phlTeamEmails">String collection of emails</param>
        /// <param name="authToken">Authentication Token (Username & Password)</param>
        /// <param name="accountNumber">The number of the account that is the report for.</param>
        /// <returns>True for successfull email send / False for failure to send the email</returns>
        public static bool SendCFReportsEmail(string[] selectedPhlTeamEmails, string accountNumber, 
            AuthToken authToken)
        {

            return false;
        }

        public static bool SendChargeEmail(string[] accountantsEmailList, string ammountToLoad, string accountNumberAndName,
            AuthToken authToken)
        {

            return false;
        }

        private static bool SendEmail(string[] emails, string body, string subject, AuthToken authToken)
        {

            return false;
        }
    }
}
