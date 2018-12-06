using BinanceExchange.API.Websockets;

namespace TradingTools
{
    public interface IUserDataWebSocketSubscriber
    {
        void Subscribe(UserDataWebSocketMessages messages);

        void UnSubscribe();
    }
}