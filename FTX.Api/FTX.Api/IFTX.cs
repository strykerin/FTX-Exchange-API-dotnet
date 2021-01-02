﻿using System.Threading.Tasks;
using System.Collections.Generic;
using FTX.Api.Entities;

namespace FTX.Api
{
    public interface IFTX
    {
        Task<Response<List<Market>>> GetMarketsAsync();
        Task<Response<Market>> GetMarketAsync(string marketName);
        Task<Response<OrderBook>> GetOrderBookAsync(string marketName, int depth = 20);
    }
}