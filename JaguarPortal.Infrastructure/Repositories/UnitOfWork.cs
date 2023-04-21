using JaguarPortal.Core;
using JaguarPortal.Core.Interfaces;

namespace JaguarPortal.Infrastructure.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JaguarDbContext _dbContext;

        public IProjectRepository Projects { get; }
        public IUserRepository Users { get; }
        public IAnalysisRepository Analyses { get; }
        public ISpectrumRepository Spectrums { get; }

        public UnitOfWork(JaguarDbContext dbContext,
                            IProjectRepository projectRepository,
                            IUserRepository userRepository,
                            IAnalysisRepository analysisRepository,
                            ISpectrumRepository spectrumRepository)
        {
            _dbContext = dbContext;
            Projects = projectRepository;
            Users = userRepository;
            Analyses = analysisRepository;
            Spectrums = spectrumRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
