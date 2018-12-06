using BinanceExchange.API.Client.Interfaces;
using BinanceExchange.API.Websockets;

namespace TradingTools
{
    public class WebSocketClientFactory : IWebSocketClientFactory
    {
        public IBinanceWebSocketClient CreateInstanceBinanceWebSocketClient(IBinanceClient client)
        {
            return new InstanceBinanceWebSocketClient(client);
        }

        public IBinanceWebSocketClient CreateDisposableBinanceWebSocketClient(IBinanceClient client)
        {
            return new DisposableBinanceWebSocketClient(client);
        }
    }
}
