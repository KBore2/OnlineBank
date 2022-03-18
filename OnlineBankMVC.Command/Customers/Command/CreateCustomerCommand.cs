using MediatR;
using OnlineBankMVC.Domain.Models;

namespace OnlineBankMVC.Command.Customers.Command
{
    public class CreateCustomerCommand: IRequest<List<Customer>>
    {
        public Customer customer { get; set; } = null!;

        public CreateCustomerCommand(Customer customer)
        {
            this.customer = customer;
        }
    }
}
