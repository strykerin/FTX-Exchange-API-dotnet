using FTX.Api.Entities;
using System.Threading.Tasks;

namespace FTX.Api.Services
{
    public interface IFTXClient
    {
        Task<Response<T>> GetAsync<T>(string path);
        Task<Response<T>> GetAuthenticatedAsync<T>(string path);
    }
}
