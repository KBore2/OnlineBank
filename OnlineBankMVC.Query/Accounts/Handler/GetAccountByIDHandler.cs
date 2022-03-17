using MediatR;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Repositories;
using OnlineBankMVC.Query.Accounts.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankMVC.Query.Accounts.Handler
{
    internal class GetAccountByIDHandler: IRequestHandler<GetAccountByIDQuery,Account>
    {
        private readonly AccountRepository repoistory;

        public GetAccountByIDHandler(AccountRepository repoistory)
        {
            this.repoistory = repoistory;
        }

        public async Task<Account> Handle(GetAccountByIDQuery request, CancellationToken cancellationToken)
        {
            var response = await repoistory.GetAsync(c => c.AccountNumber == request.account.AccountNumber);
            return response == null ? throw new Exception("Account not found") : response;
        }
    }
}
