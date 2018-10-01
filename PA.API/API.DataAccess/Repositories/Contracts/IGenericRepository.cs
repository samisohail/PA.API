using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace API.DataAccess.Repositories.Contracts
{
    public interface IGenericRepository<TEntity> : IDisposable
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> FindAllAsync();
        Task<IEnumerable<TEntity>> FindByConditionAync(Expression<Func<TEntity, bool>> expression);
        void Add(TEntity entity);
        Task<int> AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task SaveAsync();
    }
}
