using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPortal.Services.Interfaces
{
    public interface ISecurityService
    {
        string GenerateRandomHexadecimal(int bytesCount);

        string GenerateHash(string text);
        byte[] GetSaltPassword();
    }
}
