using JaguarPortal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPortal.Services.Interfaces
{
    public interface ISpectrumService 
    {
        Task<IEnumerable<Spectrum>> GetList();
        Task<Spectrum> GetById(long id);
        Task Insert(Spectrum obj);
        Task Delete(long id);
        Task<IEnumerable<Spectrum>> GetByAnalysis(long analysisId);

    }
}
