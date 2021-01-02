using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Http;
using System;
using System.Text;
using System.Security.Cryptography;
using FTX.Entities;

namespace FTX.Services
{
    public class FTXClient : IFTXClient
    {
        private const string _ftxKey = "FTX-KEY";
        private const string _ftxTS = "FTX-TS";
        private const string _ftxSignature = "FTX-SIGN";

        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _apiSecret;

        public FTXClient(HttpClient httpClient, string apiKey, string apiSecret)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
            _apiSecret = apiSecret;
        }

        public async Task<Response<T>> GetAsync<T>(string path)
        {
            return await _httpClient.GetFromJsonAsync<Response<T>>(path);
        }

        public async Task<Response<T>> GetAuthenticatedAsync<T>(string path)
        {
            this.AddAuthentication(HttpMethod.Get.ToString(), path);
            return await _httpClient.GetFromJsonAsync<Response<T>>(path);
        }

        private void AddAuthentication(string httpVerb, string path)
        {
            string signature;
            long nonce;
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_apiSecret)))
            {
                nonce = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                string signaturePayload = $"{nonce}{httpVerb.ToUpper()}{path}";
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(signaturePayload));
                string hashString = BitConverter.ToString(hash).Replace("-", string.Empty);
                signature = hashString.ToLower();
            }

            _httpClient.DefaultRequestHeaders.Add(_ftxKey, _apiKey);
            _httpClient.DefaultRequestHeaders.Add(_ftxSignature, signature);
            _httpClient.DefaultRequestHeaders.Add(_ftxTS, nonce.ToString());
        }
    }
}
