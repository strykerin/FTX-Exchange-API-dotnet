using FTX.Api.Parameters;
using FTX.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace FTX.Api.Extensions
{
    public static class FTXExtension
    {
        public static void AddFTX(this IServiceCollection services, string apiKey)
        {
            services.AddHttpClient("FTX", c => c.BaseAddress = new Uri(FTXParameters.BaseAddress));
            services.AddScoped<IFTXClient>(ctx =>
            {
                var clientFactory = ctx.GetRequiredService<IHttpClientFactory>();
                var httpClient = clientFactory.CreateClient("FTX");

                return new FTXClient(httpClient, apiKey);
            });
            services.AddScoped<IFTX>(ctx =>
            {
                IFTXClient ftxClient = ctx.GetRequiredService<IFTXClient>();
                return new FTX(ftxClient);
            });
        }
    }
}
