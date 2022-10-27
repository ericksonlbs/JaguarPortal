using System.Net.Http;
using JaguarWeb.Clients;
using Microsoft.Extensions.Configuration;

namespace JaguarWeb.Services
{
    public class JaguarWebAPIService
    {
        private readonly JaguarWebAPIClient _client;

        public JaguarWebAPIService(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            HttpClient httpClient = httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add($"X-API-Key", $"{config["Security:APIKey"]}");
            _client = new JaguarWebAPIClient(config["BaseUrlAPI"], httpClient);
            //base(config["BaseUrlAPI"], httpClientFactory.CreateClient())
        }
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<AnalysisControlFlowModel>> AnalysisControlFlowAllAsync()
        {
            return await _client.AnalysisControlFlowAllAsync();
        }

        public async System.Threading.Tasks.Task<AnalysisControlFlowModel> AnalysisControlFlowGETAsync(string id)
        {
            return await _client.AnalysisControlFlowGETAsync(id);
        }

        public async System.Threading.Tasks.Task AnalysisControlFlowPOSTAsync(AnalysisControlFlowNewModel body)
        {
            await _client.AnalysisControlFlowPOSTAsync(body);
        }
    }
}