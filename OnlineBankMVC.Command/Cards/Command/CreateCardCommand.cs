using MediatR;
using OnlineBankMVC.Domain.Models;

namespace OnlineBankMVC.Command.Cards.Command
{
    public class CreateCardCommand: IRequest<List<Card>>
    {
        public Card card { get; set; } = null!;

        public CreateCardCommand(Card card)
        {
            this.card = card;
        }
    }
}
