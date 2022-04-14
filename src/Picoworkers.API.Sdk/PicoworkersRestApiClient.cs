using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Picoworkers.API.Sdk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picoworkers.API.Sdk
{
    internal class PicoworkersRestApiClient : IPicoworkersRestApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;

        public PicoworkersRestApiClient(IHttpClientFactory httpClientFactory, ILogger<PicoworkersRestApiClient> logger)
        {
            _httpClientFactory = httpClientFactory;
            //_remoteServiceOptions = options.Value;
            _logger = logger ?? NullLogger<PicoworkersRestApiClient>.Instance;
        }

    }
}
