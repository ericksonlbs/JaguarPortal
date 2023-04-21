using JaguarPortal.Core;
using JaguarPortal.Core.Context;
using JaguarPortal.Core.Interfaces;
using JaguarPortal.Core.Models;

namespace JaguarPortal.Infrastructure.Repositories
{
    public class AnalysisRepository : GenericRepository<Analysis>, IAnalysisRepository
    {
        public AnalysisRepository(JaguarDbContext dbContext) : base(dbContext)
        {

        }
    }
}
