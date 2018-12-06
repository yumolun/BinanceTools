using EmailTools;
using TradingTools;
using OrderTools;
using BinanceExchange.API.Client.Interfaces;
using System.Net;
using BinanceExchange.API.Websockets;
using System.Threading;

namespace Startup
{
    public class Program
    {
        static ManualResetEvent _quitEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            string apiKey = "";
            string secretKey = "";
            string smtpHost = Parameters.SmtpHost;
            int smtpPort = Parameters.SmtpPort;
            string mailAccountUserName = Parameters.MailAccountUserName;
            string mailAccountPassword = "";

            IBinanceClient binanceClient = new BinanceClientFactory().CreateBinanceClient(apiKey, secretKey);
            IBinanceWebSocketClient binanceWebSocketClient = new WebSocketClientFactory().CreateInstanceBinanceWebSocketClient(binanceClient);

            new TradingMonitor(new MailManager(new SmtpClientFactory().CreateSmtpClient(smtpHost, smtpPort, new NetworkCredential(mailAccountUserName, mailAccountPassword))), 
                new OrderManager(binanceClient), 
                new AccountInfoManager(binanceClient),
                new UserStreamManager(binanceClient),
                binanceWebSocketClient).Start();

            System.Console.WriteLine("Running");

            System.Console.CancelKeyPress += (sender, eArgs) => {
                _quitEvent.Set();
                eArgs.Cancel = true;
            };

            // kick off asynchronous stuff 

            _quitEvent.WaitOne();

        }
    }
}
