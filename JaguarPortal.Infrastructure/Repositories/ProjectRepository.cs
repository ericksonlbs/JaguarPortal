using JaguarPortal.Core;
using JaguarPortal.Core.Context;
using JaguarPortal.Core.Interfaces;
using JaguarPortal.Core.Models;

namespace JaguarPortal.Infrastructure.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(JaguarDbContext dbContext) : base(dbContext)
        {

        }
    }
}
