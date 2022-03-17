using MediatR;
using OnlineBankMVC.Command.Accounts.Command;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Repositories;

namespace OnlineBankMVC.Command.Accounts.Handler
{
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, Account>
    {
        private readonly AccountRepository repository;

        public UpdateAccountHandler(AccountRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Account> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var response = await repository.Update(request.account);
            return response == null ? throw new Exception("Account not found") : response;
        }
    }
}
