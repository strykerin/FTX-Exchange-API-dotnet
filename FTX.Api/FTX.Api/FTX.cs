using System.Threading.Tasks;
using System.Collections.Generic;
using FTX.Api.Entities;
using FTX.Api.Services;
using System;
using FTX.Api.Exceptions;

namespace FTX.Api
{
    public class FTX : IFTX
    {
        private readonly IFTXClient _ftxClient;
        public FTX(IFTXClient ftxClient)
        {
            _ftxClient = ftxClient;
        }

        public async Task<Response<List<Market>>> GetMarketsAsync()
        {
            try
            {
                string path = "/api/markets";
                return await _ftxClient.GetAsync<List<Market>>(path);
            }
            catch (Exception ex)
            {
                throw new FTXException("Your message here", ex);
            }
        }

        public async Task<Response<Market>> GetMarketAsync(string marketName)
        {
            try
            {
                string path = $"/api/markets/{marketName}";
                return await _ftxClient.GetAsync<Market>(path);
            }
            catch (Exception ex)
            {
                throw new FTXException(ex.Message, ex);
            }
        }

        public async Task<Response<OrderBook>> GetOrderBookAsync(string marketName, int depth = 20)
        {
            try
            {
                if (depth > 100)
                {
                    throw new FTXException($"{nameof(depth)} cannot be greater than 100");
                }

                string path = $"/api/markets/{marketName}/orderbook?depth={depth}";
                return await _ftxClient.GetAsync<OrderBook>(path);
            }
            catch (Exception ex)
            {
                throw new FTXException(ex.Message, ex);
            }
        }
    }
}
