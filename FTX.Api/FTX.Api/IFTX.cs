using System.Threading.Tasks;
using System.Collections.Generic;
using FTX.Api.Entities;

namespace FTX.Api
{
    public interface IFTX
    {
        Task<Response<List<Market>>> GetMarketsAsync();
        Task<Response<Market>> GetMarketAsync(string marketName);
        Task<Response<OrderBook>> GetOrderBookAsync(string marketName, int depth = 20);
        Task<Response<List<Trade>>> GetTradesAsync(string marketName, int limit = 20, long start_time = long.MinValue, long end_time = long.MinValue);
    }
}