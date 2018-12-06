using System.Collections.Generic;
using System.Net.Mail;

namespace EmailTools
{
    public class MailManager : IMailManager
    {
        private SmtpClient _smtpClient;

        public MailManager(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public MailMessage CreateMailMessage(string subject, string from, List<string> toList, string body)
        {
            var mail = new MailMessage()
            {
                From = new MailAddress(from),
                Subject = subject,
                IsBodyHtml = true,
                Body = body               
            };
            
            foreach(var address in toList)
            {
                mail.To.Add(address);
            }

            return mail;
        }

        public void SendMail(MailMessage mail)
        {
            _smtpClient.Send(mail);
        }
    }
}
