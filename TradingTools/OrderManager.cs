using BinanceExchange.API.Client.Interfaces;
using BinanceExchange.API.Enums;
using BinanceExchange.API.Models.Request;
using BinanceExchange.API.Models.Response;
using BinanceExchange.API.Models.Response.Abstract;
using System.Threading.Tasks;

namespace TradingTools
{
    public class OrderManager : IOrderManager
    {
        private IBinanceClient _client;

        public OrderManager(IBinanceClient client)
        {
            _client = client;
        }

        public async Task<BaseCreateOrderResponse> CreateOrderAsync(string symbol, decimal price, decimal quantity, OrderSide orderSide, OrderType orderType, decimal icebergQuantity)
        {
            // Create an order with varying options
            var response = await _client.CreateOrder(new CreateOrderRequest()
            {
                IcebergQuantity = 100,
                Price = 230,
                Quantity = 0.6m,
                Side = OrderSide.Buy,
                Symbol = "ETHBTC",
                Type = OrderType.Market,
            });

            return response;
        }

        public async Task<CancelOrderResponse> CancelOrderAsync(long id, string symbol)
        {
            // Cancel an order
            var response = await _client.CancelOrder(new CancelOrderRequest()
            {
                NewClientOrderId = "123456",
                OrderId = 523531,
                OriginalClientOrderId = "789",
                Symbol = "ETHBTC",
            });

            return response;
        }
    }
}
