using MediatR;
using OnlineBankMVC.Domain.Models;

namespace OnlineBankMVC.Command.Accounts.Command
{
    public class DeleteAccountCommand : IRequest<List<Account>>
    {
        public Account account { get; set; } = null!;

        public DeleteAccountCommand(int id)
        {
            this.account = new Account();
            account.AccountNumber = id;
        }
    }
}
