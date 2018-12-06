using BinanceExchange.API.Websockets;
using System;

namespace TradingTools
{
    public class UserDataWebSocketSubscriber : IUserDataWebSocketSubscriber
    {
        private readonly IBinanceWebSocketClient _webSocketClient;
        private Guid _guid;

        public UserDataWebSocketSubscriber(IBinanceWebSocketClient webSocketClient)
        {
            _webSocketClient = webSocketClient ?? throw new ArgumentNullException("webSocketClient");
        }

        public async void Subscribe(UserDataWebSocketMessages messages)
        {
            if(_webSocketClient != null)
            {
                _guid = await _webSocketClient.ConnectToUserDataWebSocket(messages);
            }
        }

        public void UnSubscribe()
        {
            if (_webSocketClient != null)
            {
                _webSocketClient.CloseWebSocketInstance(_guid);
            }
        }
    }
}