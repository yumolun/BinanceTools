using BinanceExchange.API.Enums;
using BinanceExchange.API.Models.Response;
using BinanceExchange.API.Models.Response.Abstract;
using System.Threading.Tasks;

namespace TradingTools
{
    public interface IOrderManager
    {
        Task<BaseCreateOrderResponse> CreateOrderAsync(string symbol, decimal price, decimal quantity, OrderSide orderSide, OrderType orderType, decimal icebergQuantity);

        Task<CancelOrderResponse> CancelOrderAsync(long id, string symbol);
    }
}