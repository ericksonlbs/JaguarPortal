using JaguarPortal.Core;
using JaguarPortal.Core.Context;
using JaguarPortal.Core.Exceptions;
using JaguarPortal.Core.Interfaces;
using JaguarPortal.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace JaguarPortal.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(JaguarDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<User?> GetByLogin(string login)
        {
            return await _dbContext.Users.FirstOrDefaultAsync<User>(x => x.Login == login);
        }
    }
}
