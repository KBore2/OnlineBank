using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineBankMVC.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankMVC.Domain.IRepositories
{
    public class BaseRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> dbset;
        protected readonly OnlineBankDBContext context;
        public BaseRepository(OnlineBankDBContext context)
        {
            this.context = context;
            dbset = context.Set<TEntity>();

        }

        public async Task<List<TEntity>> AddAsync(TEntity entity)
        {
            await dbset.AddAsync(entity);
            context.SaveChanges();
            return await dbset.ToListAsync();
        }

        public async Task<List<TEntity>?> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            var respone = await dbset.Where(expression).FirstAsync();
            if (respone == null)
                return null;
            
            dbset.Remove(respone);
            context.SaveChanges();
            return await dbset.ToListAsync();

        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
        { 
            var respone = await dbset.Where(expression).FirstOrDefaultAsync();
            return respone == null ? null : respone;
        }

        public async Task<List<TEntity>> ListAsync()
        {
            var response = await dbset.ToListAsync();
            return response;
        }

        public async Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> expression)
        {
            var response = await dbset.Where(expression).ToListAsync();
            return response;
        }

        public async Task<TEntity?> Update(TEntity entity)
        {
            var respone = dbset.Update(entity);
            if (respone == null)
                return null;

           
            context.SaveChanges();
            return  await Task.FromResult(entity);
        }
    }
}
