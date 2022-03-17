using MediatR;
using OnlineBankMVC.Domain.Models;

namespace OnlineBankMVC.Command.Customers.Command
{
    public class UpdateCustomerCommand : IRequest<Customer>
    {
        public Customer customer { get; set; } = null!;

        public UpdateCustomerCommand(Customer customer)
        {
            this.customer = customer;
        }
    }
}
