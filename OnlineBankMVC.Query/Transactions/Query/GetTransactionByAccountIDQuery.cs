using MediatR;
using OnlineBankMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankMVC.Query.Transactions.Query
{
    public class GetTransactionByAccountIDQuery : IRequest<Transaction>
    {
        public Transaction transaction { get; set; } = null!;

        public GetTransactionByAccountIDQuery(int id)
        {
            transaction = new Transaction();
            transaction.AccountNumber = id;
        }
    }
}
