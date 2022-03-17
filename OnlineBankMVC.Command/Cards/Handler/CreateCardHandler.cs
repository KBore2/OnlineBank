using MediatR;
using OnlineBankMVC.Command.Cards.Command;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Repositories;

namespace OnlineBankMVC.Command.Cards.Handler
{
    public class CreateCardHandler : IRequestHandler<CreateCardCommand, List<Card>>
    {
        private readonly CardRepository repository;

        public CreateCardHandler(CardRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Card>> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            return await repository.AddAsync(request.card);
        }
    }
}
