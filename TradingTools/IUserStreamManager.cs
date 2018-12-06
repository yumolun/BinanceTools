using BinanceExchange.API.Models.Response;
using System.Threading.Tasks;

namespace TradingTools
{
    public interface IUserStreamManager
    {
        Task<UserDataStreamResponse> StartUserDataStream();

        Task<UserDataStreamResponse> KeepAliveUserDataStream(string userDataListenKey);

        Task<UserDataStreamResponse> StopUserDataStream(string userDataListenKey);
    }
}