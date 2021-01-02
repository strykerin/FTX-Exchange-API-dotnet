using System.Net.Http.Headers;
using FTX.Api.Parameters;
using FTX.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace FTX.Api.Extensions
{
    public static class FTXExtension
    {
        public static void AddFTX(this IServiceCollection services, string apiKey, string apiSecret)
        {
            services.AddHttpClient("FTX", c =>
            {
                c.BaseAddress = new Uri(FTXParameters.BaseAddress);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            services.AddScoped<IFTXClient>(ctx =>
            {
                var clientFactory = ctx.GetRequiredService<IHttpClientFactory>();
                var httpClient = clientFactory.CreateClient("FTX");

                return new FTXClient(httpClient, apiKey, apiSecret);
            });
            services.AddScoped<IFTX>(ctx =>
            {
                IFTXClient ftxClient = ctx.GetRequiredService<IFTXClient>();
                return new FTX(ftxClient);
            });
        }
    }
}
