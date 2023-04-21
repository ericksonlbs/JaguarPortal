using JaguarPortal.WebApi.Client.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JaguarPortal.WebApi.Client.ClientConfig;

namespace JaguarPortal.WebApi.Client
{
    public class ClientConfig : IClientConfig
    {
        public ClientConfig(IConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
                        
            string? baseUrl = configuration.GetSection($"JaguarPortalClient:{nameof(BaseUrl)}").Value;
            if (baseUrl != null)
                BaseUrl = new Uri(baseUrl);
            
            string? timeout = configuration.GetSection($"JaguarPortalClient:{nameof(Timeout)}").Value;            
            if (timeout != null && int.TryParse(timeout, out int timeoutInt))
                Timeout = timeoutInt;

        }

        public Uri BaseUrl { get; set; }

        public int Timeout { get; set; }
    }
}
