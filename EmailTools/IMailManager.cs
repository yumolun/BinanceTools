using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace EmailTools
{
    public interface IMailManager
    {
        MailMessage CreateMailMessage(string subject, string from, List<string> toList, string body);

        void SendMail(MailMessage mail);
    }
}
