using BinanceExchange.API.Models.WebSocket;
using BinanceExchange.API.Websockets;
using EmailTools;
using System;

namespace TradingTools
{
    public class TradingMonitor : ITradingMonitor
    {
        private readonly IMailManager _mailManager;
        private readonly IOrderManager _orderManager;
        private readonly IUserStreamManager _userStreamManager;
        private readonly IAccountInfoManager _accountInfoManager;
        private readonly IBinanceWebSocketClient _binanceWebSocketClient;
        private IUserDataWebSocketSubscriber _userDataWebSocketSubscriber;

        public TradingMonitor(IMailManager mailManager, IOrderManager orderManager, IAccountInfoManager accountInfoManager, IUserStreamManager userStreamManager, IBinanceWebSocketClient binanceWebSocketClient)
        {
            _mailManager = mailManager;
            _orderManager = orderManager;
            _userStreamManager = userStreamManager;
            _accountInfoManager = accountInfoManager;
            _binanceWebSocketClient = binanceWebSocketClient;
        }

        public void Start()
        {
            SubscribeToUserDataWebSocket();
        }

        private void SubscribeToUserDataWebSocket()
        {
            _userDataWebSocketSubscriber = new UserDataWebSocketSubscriber(_binanceWebSocketClient);

            _userDataWebSocketSubscriber.Subscribe(new UserDataWebSocketMessages()
            {
                AccountUpdateMessageHandler = OnAccountUpdateMessageReceived,
                TradeUpdateMessageHandler = OnTradeUpdateMessageReceived,
                OrderUpdateMessageHandler = OnOrderUpdateMessageReceived,
            }
                );
        }

        private void UnSubscribeFromUserDataWebSocket()
        {
            _userDataWebSocketSubscriber.UnSubscribe();
        }

        private void OnOrderUpdateMessageReceived(BinanceTradeOrderData data)
        {
            Console.WriteLine("Order update recieved");
            Console.WriteLine(data.Symbol);
            Console.WriteLine(data.ExecutionType);
            Console.WriteLine(data.EventType);
            Console.WriteLine(data.Price);
            Console.WriteLine(data.Quantity);
            Console.WriteLine(data.Side);
        }

        private void OnTradeUpdateMessageReceived(BinanceTradeOrderData data)
        {
            Console.WriteLine("Trade update recieved");
        }

        private void OnAccountUpdateMessageReceived(BinanceAccountUpdateData data)
        {
            Console.WriteLine("Account update recieved");
        }

        public void Stop()
        {
            UnSubscribeFromUserDataWebSocket();
        }
    }
}


/* Account
{
  "e": "outboundAccountInfo",   // Event type
  "E": 1499405658849,           // Event time
  "m": 0,                       // Maker commission rate (bips)
  "t": 0,                       // Taker commission rate (bips)
  "b": 0,                       // Buyer commission rate (bips)
  "s": 0,                       // Seller commission rate (bips)
  "T": true,                    // Can trade?
  "W": true,                    // Can withdraw?
  "D": true,                    // Can deposit?
  "u": 1499405658848,           // Time of last account update
  "B": [                        // Balances array
    {
      "a": "LTC",               // Asset
      "f": "17366.18538083",    // Free amount
      "l": "0.00000000"         // Locked amount
    },
    {
      "a": "BTC",
      "f": "10537.85314051",
      "l": "2.19464093"
    },
    {
      "a": "ETH",
      "f": "17902.35190619",
      "l": "0.00000000"
    },
    {
      "a": "BNC",
      "f": "1114503.29769312",
      "l": "0.00000000"
    },
    {
      "a": "NEO",
      "f": "0.00000000",
      "l": "0.00000000"
    }
  ]
}

Order:
{
  "e": "executionReport",        // Event type
  "E": 1499405658658,            // Event time
  "s": "ETHBTC",                 // Symbol
  "c": "mUvoqJxFIILMdfAW5iGSOW", // Client order ID
  "S": "BUY",                    // Side
  "o": "LIMIT",                  // Order type
  "f": "GTC",                    // Time in force
  "q": "1.00000000",             // Order quantity
  "p": "0.10264410",             // Order price
  "P": "0.00000000",             // Stop price
  "F": "0.00000000",             // Iceberg quantity
  "g": -1,                       // Ignore
  "C": "null",                   // Original client order ID; This is the ID of the order being canceled
  "x": "NEW",                    // Current execution type
  "X": "NEW",                    // Current order status
  "r": "NONE",                   // Order reject reason; will be an error code.
  "i": 4293153,                  // Order ID
  "l": "0.00000000",             // Last executed quantity
  "z": "0.00000000",             // Cumulative filled quantity
  "L": "0.00000000",             // Last executed price
  "n": "0",                      // Commission amount
  "N": null,                     // Commission asset
  "T": 1499405658657,            // Transaction time
  "t": -1,                       // Trade ID
  "I": 8641984,                  // Ignore
  "w": true,                     // Is the order working? Stops will have
  "m": false,                    // Is this trade the maker side?
  "M": false,                    // Ignore
  "O": 1499405658657,            // Order creation time
  "Z": "0.00000000",             // Cumulative quote asset transacted quantity
  "Y": "0.00000000"              // Last quote asset transacted quantity (i.e. lastPrice * lastQty)
}
 */
