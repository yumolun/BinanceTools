using BinanceExchange.API.Client;
using BinanceExchange.API.Client.Interfaces;
using BinanceExchange.API.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TradingTools
{
    public class UserStreamManager : IUserStreamManager
    {
        private IBinanceClient _client;

        public UserStreamManager(IBinanceClient client)
        {
            _client = client;
        }
        
        public async Task<UserDataStreamResponse> StartUserDataStream()
        {
            return await _client.StartUserDataStream();
        }

        public async Task<UserDataStreamResponse> KeepAliveUserDataStream(string userDataListenKey)
        {
            return await _client.KeepAliveUserDataStream(userDataListenKey);
        }

        public async Task<UserDataStreamResponse> StopUserDataStream(string userDataListenKey)
        {
            return await _client.CloseUserDataStream(userDataListenKey);
        }
    }
}
