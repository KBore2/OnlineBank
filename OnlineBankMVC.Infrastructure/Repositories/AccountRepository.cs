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
    public class AccountRepository : BaseRepository<Account>
    {
        public AccountRepository(OnlineBankDBContext context) : base(context)
        {
        }
    }
}
