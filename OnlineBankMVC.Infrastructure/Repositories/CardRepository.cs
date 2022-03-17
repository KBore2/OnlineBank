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
    public class CardRepository : BaseRepository<Card>
    {
        public CardRepository(OnlineBankDBContext context) : base(context)
        {
        }
    }
}
