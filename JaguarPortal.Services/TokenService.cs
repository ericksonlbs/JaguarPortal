using JaguarPortal.Core.Models;
using JaguarPortal.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JaguarPortal.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUserService userService;
        private readonly ISecurityService securityService;
        private readonly IConfiguration configuration;
        private const string JWTTokenType = "JWT";

        public TokenService(IUserService userService, ISecurityService securityService, IConfiguration configuration)
        {
            this.userService = userService;
            this.securityService = securityService;
            this.configuration = configuration;
        }
        public Token GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String(configuration.GetValue<string>("Security:JWT:Secret"));

            string timeExpires = configuration.GetValue<string>("Security:JWT:Expires");

            if (!double.TryParse(timeExpires, out double time))
                time = 1200;
            DateTime expires = DateTime.UtcNow.AddSeconds(time);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name, user.Login),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.GivenName, user.Name),
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenJwt = tokenHandler.CreateToken(tokenDescriptor);
            string sToken = tokenHandler.WriteToken(tokenJwt);
            double expiresIn = (expires - DateTime.UtcNow).TotalSeconds;

            Token token = new Token()
            {
                AccessToken = sToken,
                TokenType = JWTTokenType,
                ExpiresIn = (int)expiresIn
            };

            return token;
        }
    }
}
