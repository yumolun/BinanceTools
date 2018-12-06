using BinanceExchange.API.Client.Interfaces;

namespace OrderTools
{
    public interface IBinanceClientFactory
    {
        IBinanceClient CreateBinanceClient(string apiKey, string secretKey);
    }
}
