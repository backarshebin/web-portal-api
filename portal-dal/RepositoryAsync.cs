using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using portal_domain.Repository;
using Microsoft.EntityFrameworkCore;
namespace portal_dal
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        protected readonly PortalDbContext _dbContext;
        public RepositoryAsync(PortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<T> Entities => _dbContext.Set<T>();
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }
        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }
        public async Task<List<T>> GetAllAsync(bool noTracking = false)
        {
            var sets = _dbContext
                .Set<T>();
            return noTracking ? await sets.AsNoTracking().ToListAsync() : await sets.ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }
    }
}
