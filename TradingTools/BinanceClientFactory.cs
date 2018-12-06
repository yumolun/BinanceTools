using BinanceExchange.API.Client;
using BinanceExchange.API.Client.Interfaces;

namespace OrderTools
{
    public class BinanceClientFactory : IBinanceClientFactory
    {
        public IBinanceClient CreateBinanceClient(string apiKey, string secretKey)
        {
            var clientConfiguration = new ClientConfiguration()
            {
                ApiKey = apiKey,
                SecretKey = secretKey
            };

            return new BinanceClient(clientConfiguration);
        }
    }
}
