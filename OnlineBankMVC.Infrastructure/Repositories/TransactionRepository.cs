using OnlineBankMVC.Domain.IRepositories;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankMVC.Infrastructure.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>
    {
        public TransactionRepository(OnlineBankDBContext context) : base(context)
        {
        }
    }
}
