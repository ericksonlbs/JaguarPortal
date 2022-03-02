using System.Net.Http;
using JaguarWeb.Clients;
using Microsoft.Extensions.Configuration;

namespace JaguarWeb.Services{
    public class JaguarWebAPIService : JaguarWebAPIClient
    {
        public JaguarWebAPIService(IConfiguration config, HttpClient httpClient) : base(config["BaseUrlAPI"], httpClient)
        {
            
        }
    }
}