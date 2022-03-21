using MediatR;
using OnlineBankMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankMVC.Query.Accounts.Query
{
    public class GetAccountByCustomerIDQuery : IRequest<List<Account>>
    {
        public Account Account { get; set; } = null!;

        public GetAccountByCustomerIDQuery(int id)
        {
            Account = new Account();
            Account.CustomerId = id;
        }
    }
}
