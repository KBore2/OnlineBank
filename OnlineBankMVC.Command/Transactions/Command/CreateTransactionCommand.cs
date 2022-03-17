using MediatR;
using OnlineBankMVC.Domain.Models;

namespace OnlineBankMVC.Command.Transactions.Command
{
    public class CreateTransactionCommand: IRequest<List<Transaction>>
    {
        public Transaction transaction { get; set; } = null!;
    }
}
