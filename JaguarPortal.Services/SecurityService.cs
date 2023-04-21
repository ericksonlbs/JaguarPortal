using JaguarPortal.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPortal.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IConfiguration configuration;
        private readonly byte[] salt;

        public SecurityService(IConfiguration configuration)
        {
            this.configuration = configuration;

            salt = GetSaltPassword();
        }

        public byte[] GetSaltPassword()
        {
            return Convert.FromBase64String(configuration.GetValue<string>("Security:Password:Salt"));
        }

        public string GenerateRandomHexadecimal(int bytesCount)
        {
            using RandomNumberGenerator cryptoProvider = RandomNumberGenerator.Create();
            byte[] bytes = new byte[bytesCount];
            cryptoProvider.GetBytes(bytes);

            string secureRandomString = Convert.ToBase64String(bytes);
            return secureRandomString;
        }

        public string GenerateHash(string pass)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pass,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
