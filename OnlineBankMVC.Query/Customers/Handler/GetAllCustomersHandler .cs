using MediatR;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Repositories;
using OnlineBankMVC.Query.Customers.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankMVC.Query.Customers.Handler
{
    internal class GetAllCustomersHandler: IRequestHandler<GetAllCustomersQuery, List<Customer>>
    {
        private readonly CustomerRepository repoistory;

        public GetAllCustomersHandler(CustomerRepository repoistory)
        {
            this.repoistory = repoistory;
        }

        public async Task<List<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await repoistory.ListAsync();
        }
    }
}
