using FTX.Entities;
using System.Threading.Tasks;

namespace FTX.Services
{
    public interface IFTXClient
    {
        Task<Response<T>> GetAsync<T>(string path);
        Task<Response<T>> GetAuthenticatedAsync<T>(string path);
    }
}
