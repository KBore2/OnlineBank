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
    internal class GetAllAccountsHandler: IRequestHandler<GetAllAccountsQuery, List<Account>>
    {
        private readonly AccountRepository repoistory;

        public GetAllAccountsHandler(AccountRepository repoistory)
        {
            this.repoistory = repoistory;
        }

        public async Task<List<Account>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var response = await repoistory.ListAsync();
            return response == null ? throw new Exception("Account not found") : response;
        }
    }
}
