using JaguarPortal.Core.Exceptions;
using JaguarPortal.Core.Interfaces;
using JaguarPortal.Core.Models;
using JaguarPortal.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace JaguarPortal.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly ISecurityService secService;

        public UserService(ILogger<UserService> logger, IUnitOfWork unitOfWork, ISecurityService secService)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.secService = secService;
        }
        public async Task Delete(long id)
        {
            User user = await this.GetById(id);
            unitOfWork.Users.Delete(user);
            unitOfWork.Save();
            logger.LogInformation("User \"{id}\" deleted", id);
        }

        public async Task<string> RegenerateClientSecret(long id)
        {
            User user = await this.GetById(id);
            string clientSecret = secService.GenerateRandomHexadecimal(64);
            user.ClientSecret = secService.GenerateHash(clientSecret);
            unitOfWork.Users.Update(user);
            unitOfWork.Save();
            return clientSecret;
        }

        public async Task<User> GetById(long id)
        {
            User? proj = await unitOfWork.Users.GetById(id);
            if (proj is null)
                throw new NotFoundObjectException("User not found");

            return proj;
        }
        public async Task<User> GetByLogin(string login)
        {
            User? proj = await unitOfWork.Users.GetByLogin(login);
            if (proj is null)
                throw new NotFoundObjectException("User not found");

            return proj;
        }

        public async Task<IEnumerable<User>> GetList()
        {
            return await unitOfWork.Users.GetAll();
        }

        public async Task Insert(User obj)
        {
            obj.ClientId = secService.GenerateRandomHexadecimal(16);
            obj.ClientSecret = secService.GenerateHash(secService.GenerateRandomHexadecimal(64));

            string pass = obj.Password;
            obj.Password = secService.GenerateHash(pass);

            await unitOfWork.Users.Add(obj);
            unitOfWork.Save();

            logger.LogInformation("User {login} inserted", obj.Login);
        }

        public async Task Update(long id, User obj)
        {
            var user = await unitOfWork.Users.GetById(id);

            if (user is null)
                throw new NotFoundObjectException("User not found");

            user.Name = obj.Name;
            user.Email = obj.Email;
            user.EnabledAPI = obj.EnabledPortal;
            user.EnabledPortal = obj.EnabledPortal;

            unitOfWork.Users.Update(user);
            unitOfWork.Save();

            logger.LogInformation("User \"{id}\" updated", id);
        }

        public async Task<bool> ValidateLogin(string login, string password)
        {
            var user = await unitOfWork.Users.GetByLogin(login);

            return
                user is not null &&
                user.Password == secService.GenerateHash(password);
        }
        public async Task<bool> ValidateSecret(string clientId, string clientSecret)
        {
            var user = await unitOfWork.Users.GetByLogin(clientId);

            if (user is null)
                throw new NotFoundObjectException("User not found");
            return user.ClientSecret == secService.GenerateHash(clientSecret);
        }

    }
}
