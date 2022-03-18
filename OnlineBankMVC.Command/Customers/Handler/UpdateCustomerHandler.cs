using MediatR;
using OnlineBankMVC.Command.Customers.Command;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Repositories;

namespace OnlineBankMVC.Command.Customers.Handler
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly CustomerRepository repository;

        public UpdateCustomerHandler(CustomerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = await repository.Update(request.customer);
            return response ?? null;
        }
    }
}
