using System.Net;
using System.Net.Mail;

namespace EmailTools
{
    public class SmtpClientFactory : ISmtpClientFactory
    {
        public SmtpClient CreateSmtpClient(string host, int port, ICredentialsByHost credential)
        {
            return new SmtpClient(host, port)
            {
                Credentials = credential,
                EnableSsl = true
            };
        }
    }
}
