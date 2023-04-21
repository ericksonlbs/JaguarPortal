using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPortal.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectRepository Projects { get; }
        IUserRepository Users { get; }
        IAnalysisRepository Analyses { get; }
        ISpectrumRepository Spectrums { get; }
        int Save();
    }
}
