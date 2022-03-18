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
    internal class GetCustomerByIDHandler: IRequestHandler<GetCustomerByIDQuery,Customer>
    {
        private readonly CustomerRepository repoistory;

        public GetCustomerByIDHandler(CustomerRepository repoistory)
        {
            this.repoistory = repoistory;
        }

        public async Task<Customer> Handle(GetCustomerByIDQuery request, CancellationToken cancellationToken)
        {
            var response = await repoistory.GetAsync(c => c.CustomerId == request.customer.CustomerId);
            return response ?? null;
        }
    }
}
