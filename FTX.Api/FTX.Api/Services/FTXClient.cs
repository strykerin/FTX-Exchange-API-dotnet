using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace FTX.Api.Services
{
    public class FTXClient
    {
        private const string _ftxKey = "FTX-KEY";
        private const string _ftxTS = "FTX-TS";
        private const string _ftxSignature = "FTX-SIGN";

        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public FTXClient(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<T> GetAsync<T>(string path)
        {
            this.AddAuthentication(HttpMethod.Get.ToString(), path);
            return await _httpClient.GetFromJsonAsync<T>(path);
        }

        private void AddAuthentication(string httpVerb, string path)
        {
            string signature;
            long nonce;
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_apiKey)))
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
