using MediatR;
using OnlineBankMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankMVC.Query.Accounts.Query
{
    public class GetAllAccountsQuery : IRequest<List<Account>>
    {
        public Account account { get; set; } = null!;
    }
}
