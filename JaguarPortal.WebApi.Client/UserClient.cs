using JaguarPortal.WebApi.Client.Interfaces;
using JaguarPortal.WebApi.Models.Request;
using JaguarPortal.WebApi.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace JaguarPortal.WebApi.Client
{
    public class UserClient : IUserClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UserClient> logger;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserClient(HttpClient httpClient, ILogger<UserClient> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            this.logger = logger;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task Register(UserInsertRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("/Users", request);
            result.EnsureSuccessStatusCode();

        }

        public async Task<UserAuthenticationResponse> Authenticate(UserAuthenticationRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("/Authenticate", request);
            result.EnsureSuccessStatusCode();

            var response = await result.Content.ReadFromJsonAsync<UserAuthenticationResponse>();

            return response;
        }

        public async Task<UserResponse> GetByLogin(string login, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            var result = await _httpClient.GetFromJsonAsync<UserResponse>($"/Users/ByLogin/{login}");

            return result;
        }
    }
}