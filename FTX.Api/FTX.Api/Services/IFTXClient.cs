using System.Threading.Tasks;

namespace FTX.Api.Services
{
    public interface IFTXClient
    {
        Task<T> GetAsync<T>(string path);
    }
}
