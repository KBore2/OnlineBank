using MediatR;
using OnlineBankMVC.Command.Cards.Command;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Repositories;

namespace OnlineBankMVC.Command.Cards.Handler
{
    public class UpdateCardHandler : IRequestHandler<UpdateCardCommand, Card>
    {
        private readonly CardRepository repository;

        public UpdateCardHandler(CardRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Card> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var response = await repository.Update(request.card);
            return response == null ? throw new Exception("Card not found") : response;
        }
    }
}
