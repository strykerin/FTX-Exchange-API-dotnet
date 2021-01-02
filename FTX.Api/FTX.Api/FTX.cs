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
    }
}
