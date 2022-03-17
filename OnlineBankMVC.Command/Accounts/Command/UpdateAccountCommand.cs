using MediatR;
using OnlineBankMVC.Domain.Models;

namespace OnlineBankMVC.Command.Accounts.Command
{
    public class UpdateAccountCommand : IRequest<Account>
    {
        public Account account { get; set; } = null!;

        public UpdateAccountCommand(Account Account)
        {
            this.account = Account;
        }
    }
}
