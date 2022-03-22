using Microsoft.EntityFrameworkCore;
using OnlineBankMVC.Domain.IRepositories;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankMVC.Infrastructure.Repositories
{
    public class CardRepository : BaseRepository<Card>
    {
        public CardRepository(OnlineBankDBContext context) : base(context)
        {
        }

        public async Task<List<Card>> GetAll()
        {
            return await dbset.Include(c => c.Customer).ToListAsync();
        }

        public async Task<List<Card>> GetByCustomerID(Expression<Func<Card, bool>> expression)
        {
            return await dbset.Include(c => c.Customer).Where(expression).ToListAsync();
        }


    }
}
