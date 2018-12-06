using BinanceExchange.API.Client.Interfaces;
using BinanceExchange.API.Models.Response;
using System.Threading.Tasks;

namespace TradingTools
{
    public class AccountInfoManager : IAccountInfoManager
    {
        private IBinanceClient _client;

        public AccountInfoManager(IBinanceClient client)
        {
            _client = client;
        }

        public async Task<AccountInformationResponse> GetAccountInformation()
        {
            return await _client.GetAccountInformation();
        }
    }
}
