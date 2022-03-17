using MediatR;
using OnlineBankMVC.Command.Accounts.Command;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Repositories;

namespace OnlineBankMVC.Command.Accounts.Handler
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, List<Account>>
    {
        private readonly AccountRepository repository;

        public CreateAccountHandler(AccountRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Account>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            return await repository.AddAsync(request.account);
        }
    }
}
