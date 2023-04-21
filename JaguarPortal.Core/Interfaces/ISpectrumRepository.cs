using JaguarPortal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPortal.Core.Interfaces
{
    public interface ISpectrumRepository : IGenericRepository<Spectrum>
    {
        Task<IEnumerable<Spectrum>> GetByAnalysis(long analysisId);
    }
}
