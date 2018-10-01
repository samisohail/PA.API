using API.DataAccess.DataContext;
using API.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace API.DataAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        public virtual IPA24Context _dbContext { get; set; }

        public GenericRepository(IPA24Context pA24Context)
        {
            _dbContext = pA24Context;
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            return await this._dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindByConditionAync(Expression<Func<TEntity, bool>> expression)
        {
            return await this._dbContext.Set<TEntity>().Where(expression).ToListAsync();
        }

        public void Add(TEntity entity)
        {
            this._dbContext.Set<TEntity>().Add(entity);
        }

        public Task<int> AddAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().AddAsync(entity);
            return _dbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            this._dbContext.Set<TEntity>().Update(entity);
        }        

        public void Delete(TEntity entity)
        {

            this._dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await this._dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._dbContext?.Dispose();
        }
    }
}
