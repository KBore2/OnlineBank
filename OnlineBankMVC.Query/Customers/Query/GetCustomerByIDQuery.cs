using MediatR;
using OnlineBankMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankMVC.Query.Customers.Query
{
    public class GetCustomerByIDQuery : IRequest<Customer>
    {
        public Customer customer { get; set; } = null!;

        public GetCustomerByIDQuery(int id)
        {
            customer = new Customer();
            customer.CustomerId = id;
        }
    }
}
