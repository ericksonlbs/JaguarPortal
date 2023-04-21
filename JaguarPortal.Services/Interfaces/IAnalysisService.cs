using JaguarPortal.Core.Models;

namespace JaguarPortal.Services.Interfaces
{
    public interface IAnalysisService
    {
        Task<IEnumerable<Analysis>> GetList();
        Task<Analysis> GetById(long id);
        Task Insert(Analysis obj);
        Task Delete(long id);
    }
}
