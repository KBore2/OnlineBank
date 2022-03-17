using MediatR;
using OnlineBankMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankMVC.Query.Customers.Query
{
    public class GetAllCustomersQuery : IRequest<List<Customer>>
    {
        public Customer customer { get; set; } = null!;
    }
}
