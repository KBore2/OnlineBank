using MediatR;
using OnlineBankMVC.Command.Transactions.Command;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Repositories;

namespace OnlineBankMVC.Command.Transactions.Handler
{
    public class UpdateTransactionHandler : IRequestHandler<UpdateTransactionCommand, Transaction>
    {
        private readonly TransactionRepository repository;

        public UpdateTransactionHandler(TransactionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Transaction> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = await repository.Update(request.transaction);
            return response == null ? throw new Exception("Transaction not found") : response;
        }
    }
}
