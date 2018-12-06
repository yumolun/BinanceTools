using BinanceExchange.API.Models.Response;
using System.Threading.Tasks;

namespace TradingTools
{
    public interface IAccountInfoManager
    {
        Task<AccountInformationResponse> GetAccountInformation();
    }
}