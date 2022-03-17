using MediatR;
using OnlineBankMVC.Domain.Models;

namespace OnlineBankMVC.Command.Transactions.Command
{
    public class DeleteTransactionCommand : IRequest<List<Transaction>>
    {
        public Transaction transaction { get; set; } = null!;

        public DeleteTransactionCommand(int id)
        {
            this.transaction = new Transaction();
            transaction.TransactionNumber = id;
        }
    }
}
