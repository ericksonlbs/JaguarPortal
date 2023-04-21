﻿using Newtonsoft.Json;

namespace JaguarPortal.WebApi.Models.Response
{
    public class UserAuthenticationResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
