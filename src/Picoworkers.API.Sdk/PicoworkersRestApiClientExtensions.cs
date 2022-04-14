using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Picoworkers.API.Sdk.Interfaces;
using Picoworkers.API.Sdk.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picoworkers.API.Sdk
{
    public static class PicoworkersRestApiClientExtensions
    {
        internal static string HttpClientId = Guid.NewGuid().ToString();
        internal static string HttpAuthClientId = Guid.NewGuid().ToString();
        public static void AddPicoworkersApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RemoteServiceOptions>(configuration);
            services.AddPicoworkersApiClientInternal();
        }

        private static void AddPicoworkersApiClientInternal(this IServiceCollection services)
        {
            services.AddHttpClient(HttpClientId, (serviceProvider, httpClient) =>
            {
                IOptions<RemoteServiceOptions> opt = serviceProvider.GetRequiredService<IOptions<RemoteServiceOptions>>();
                //httpClient.BaseAddress = new Uri(opt.Value.Url);
            });

            services.AddHttpClient(HttpAuthClientId, (serviceProvider, httpClient) =>
            {
                IOptions<RemoteServiceOptions> opt = serviceProvider.GetRequiredService<IOptions<RemoteServiceOptions>>();
                //httpClient.BaseAddress = new Uri(opt.Value.AuthUrl)
            });
            services.AddTransient<IPicoworkersRestApiClient, PicoworkersRestApiClient>();
        }
    }
}
