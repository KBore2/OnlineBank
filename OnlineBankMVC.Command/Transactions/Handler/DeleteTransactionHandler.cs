using MediatR;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Repositories;
using OnlineBankMVC.Command.Accounts.Command;
using OnlineBankMVC.Command.Transactions.Command;

namespace OnlineBankMVC.Command.Transactions.Handler
{
    public class DeleteTransactionHandler:IRequestHandler<DeleteTransactionCommand, List<Transaction>>
    {
        private readonly TransactionRepository repository;

        public DeleteTransactionHandler(TransactionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Transaction>> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var response =  await repository.DeleteAsync(c => c.TransactionNumber == request.transaction.TransactionNumber);
            return response == null ? throw new Exception("Transaction not found") : response;
        }
    }
}
