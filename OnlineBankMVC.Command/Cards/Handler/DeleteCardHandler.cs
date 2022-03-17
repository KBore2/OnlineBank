using MediatR;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Repositories;
using OnlineBankMVC.Command.Accounts.Command;
using OnlineBankMVC.Command.Cards.Command;

namespace OnlineBankMVC.Command.Cards.Handler
{
    public class DeleteCardHandler:IRequestHandler<DeleteCardCommand, List<Card>>
    {
        private readonly CardRepository repository;

        public DeleteCardHandler(CardRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Card>> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            var response =  await repository.DeleteAsync(c => c.CardNumber == request.card.CardNumber);
            return response == null ? throw new Exception("Card not found") : response;
        }
    }
}
