using JaguarPortal.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JaguarPortal.Core.Context
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly JaguarDbContext _dbContext;

        protected GenericRepository(JaguarDbContext context)
        {
            _dbContext = context;
        }

        public async Task<T?> GetById(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
