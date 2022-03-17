using MediatR;
using OnlineBankMVC.Command.Transactions.Command;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Repositories;

namespace OnlineBankMVC.Command.Transactions.Handler
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, List<Transaction>>
    {
        private readonly TransactionRepository repository;

        public CreateTransactionHandler(TransactionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Transaction>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            return await repository.AddAsync(request.transaction);
        }
    }
}
