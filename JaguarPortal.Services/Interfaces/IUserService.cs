using JaguarPortal.Core.Models;

namespace JaguarPortal.Services.Interfaces
{
    public interface IUserService : IServiceRepository<User, long>
    {
        Task<string> RegenerateClientSecret(long id);

        Task<bool> ValidateSecret(string clientId, string clientSecret);
        Task<bool> ValidateLogin(string login, string password);
        Task<User> GetByLogin(string login);
    }
}
