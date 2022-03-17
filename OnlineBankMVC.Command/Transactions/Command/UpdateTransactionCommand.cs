using MediatR;
using OnlineBankMVC.Domain.Models;

namespace OnlineBankMVC.Command.Transactions.Command
{
    public class UpdateTransactionCommand : IRequest<Transaction>
    {
        public Transaction transaction { get; set; } = null!;

        public UpdateTransactionCommand(Transaction Transaction)
        {
            this.transaction = Transaction;
        }
    }
}
