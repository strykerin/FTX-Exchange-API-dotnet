using FTX.Api.Parameters;
using FTX.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

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
            services.AddScoped<>

        }
    }
}
