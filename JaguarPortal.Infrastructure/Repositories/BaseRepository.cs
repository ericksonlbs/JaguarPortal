using JaguarPortal.Core;

namespace JaguarPortal.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        public readonly JaguarDbContext context;
        private bool disposed = false;

        public BaseRepository(JaguarDbContext context)
        {
            this.context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
