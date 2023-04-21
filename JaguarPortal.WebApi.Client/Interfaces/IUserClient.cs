using JaguarPortal.WebApi.Models.Request;
using JaguarPortal.WebApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPortal.WebApi.Client.Interfaces
{
    public interface IUserClient
    {
        public Task Register(Models.Request.UserInsertRequest request);
        public Task<UserResponse> GetByLogin(string login, string accesstoken);
        public Task<UserAuthenticationResponse> Authenticate(UserAuthenticationRequest request);
    }
}
