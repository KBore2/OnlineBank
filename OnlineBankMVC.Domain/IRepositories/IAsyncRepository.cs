using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankMVC.Domain.IRepositories
{
    public interface IAsyncRepository<TEntity> where TEntity : class 
    {

        public Task<List<TEntity>> AddAsync(TEntity entity);

        public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);

        public Task<TEntity?> Update(TEntity entity);

        public Task<List<TEntity>?> DeleteAsync(Expression<Func<TEntity, bool>> expression);

        public Task<List<TEntity>> ListAsync();

        public Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> expression);

    }
}
