using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

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
        /// <param name="callType">If Its [since last refil] or [since the begining]</param>
        /// <returns>True for successfull email send / False for failure to send the email</returns>
     
        public static string SendCFReportsEmail(string[] selectedPhlTeamEmails, string accountNumber, 
            AuthToken authToken, string attachmentPath, bool callType)
        {

            return SendEmail(selectedPhlTeamEmails,"",
                $"[AdWords] {accountNumber} {((callType)?"Since last refil":"Since The Begining")}",
                authToken,attachmentPath);        
        }

        /// <summary>
        /// Sends a charge AdWords Account Email
        /// </summary>
        /// <param name="accountantsEmailList">The accountant emails to send the email</param>
        /// <param name="ammountToLoad">how much to load into the account</param>
        /// <param name="accountNumberAndName">!IMPORTANT format - ACCNUMBER_ACCNAME</param>
        /// <param name="authToken">Authentication Token (Username & Password)</param>
        /// <returns>True for successfull email send / False for failure to send the email</returns>
        public static string SendChargeEmail(string[] accountantsEmailList, string ammountToLoad, string accountNumberAndName,
            AuthToken authToken)
        {
            string body = $"Здравейте,\n\nМоля заредете ${ammountToLoad} на  {accountNumberAndName}.";
            return SendEmail(accountantsEmailList,body + "\n\nBest Regards From The PPC Team!", 
                $"[AdWords] {accountNumberAndName.Split('_')[0]} Зареждане на пари",
                authToken);
        }

        private static string SendEmail(string[] emails, string body, string subject, 
            AuthToken authToken, string attachmentPath = "")
        {
            string result = "nope";
            MailAddress Address = new MailAddress(authToken.Username);
           
            try
            {
                foreach (string s in emails)
                {
                    var toAddress = new MailAddress(s);
                    Attachment attachment = null;
                    if (attachmentPath != "")
                        attachment = new Attachment(attachmentPath);



                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(Address.Address, authToken.Password)
                    };

                    using (var message = new MailMessage(Address, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        if(attachment != null)
                        message.Attachments.Add(attachment);

                        smtp.Send(message);
                        result = "";
                    }
                    if (result != "" )
                        break;
                }
            }
            catch(Exception ex)
            {          
                return ex.ToString();
            }
            return "";
        }
    }
}
