using BinanceExchange.API.Client.Interfaces;
using BinanceExchange.API.Websockets;

namespace TradingTools
{
    public interface IWebSocketClientFactory
    {
        IBinanceWebSocketClient CreateInstanceBinanceWebSocketClient(IBinanceClient client);

        IBinanceWebSocketClient CreateDisposableBinanceWebSocketClient(IBinanceClient client);
    }
}