using System.Net;
using System.Net.Mail;

namespace EmailTools
{
    public interface ISmtpClientFactory
    {
        SmtpClient CreateSmtpClient(string host, int port, ICredentialsByHost credential);
    }
}
