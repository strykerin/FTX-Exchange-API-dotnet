using System.Threading.Tasks;
using System.Collections.Generic;
using FTX.Api.Entities;

namespace FTX.Api
{
    public interface IFTX
    {
        Task<List<Market>> GetMarketsAsync();
    }
}