using JaguarPortal.Core;
using JaguarPortal.Core.Context;
using JaguarPortal.Core.Interfaces;
using JaguarPortal.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace JaguarPortal.Infrastructure.Repositories
{
    public class SpectrumRepository : GenericRepository<Spectrum>, ISpectrumRepository
    {
        public SpectrumRepository(JaguarDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Spectrum>> GetByAnalysis(long analysisId)
        {
            return await _dbContext.Set<Spectrum>().Where(x=>x.AnalysisId == analysisId).ToListAsync();            
        }
    }
}
