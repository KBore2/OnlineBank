using MediatR;
using OnlineBankMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankMVC.Query.Accounts.Query
{
    public class GetAccountByIDQuery : IRequest<Account>
    {
        public Account account { get; set; } = null!;

        public GetAccountByIDQuery(int customerId, int accountNumber)
        {
            account = new Account();
            account.CustomerId = customerId;
            account.AccountNumber = accountNumber;
        }
    }
}
