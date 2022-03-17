using MediatR;
using OnlineBankMVC.Command.Customers.Command;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Data;
using OnlineBankMVC.Infrastructure.Repositories;

namespace OnlineBankMVC.Command.Customers.Handler
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, List<Customer>>
    {
        private readonly CustomerRepository repository;

        public CreateCustomerHandler(CustomerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await repository.AddAsync(request.customer);
        }
    }
}
