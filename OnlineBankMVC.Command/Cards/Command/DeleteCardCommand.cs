using MediatR;
using OnlineBankMVC.Domain.Models;

namespace OnlineBankMVC.Command.Cards.Command
{
    public class DeleteCardCommand : IRequest<List<Card>>
    {
        public Card card { get; set; } = null!;

        public DeleteCardCommand(int id)
        {
            this.card = new Card();
            card.CardNumber = id;
        }
    }
}
