using MediatR;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Repositories;
using OnlineBankMVC.Command.Accounts.Command;

namespace OnlineBankMVC.Command.Accounts.Handler
{
    public class DeleteAccountHandler:IRequestHandler<DeleteAccountCommand, List<Account>>
    {
        private readonly AccountRepository repository;

        public DeleteAccountHandler(AccountRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Account>> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var response =  await repository.DeleteAsync(c => c.AccountNumber == request.account.AccountNumber);
            return response == null ? throw new Exception("Account not found") : response;
        }
    }
}
