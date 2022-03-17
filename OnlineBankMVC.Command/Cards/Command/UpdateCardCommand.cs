using MediatR;
using OnlineBankMVC.Domain.Models;

namespace OnlineBankMVC.Command.Cards.Command
{
    public class UpdateCardCommand : IRequest<Card>
    {
        public Card card { get; set; } = null!;

        public UpdateCardCommand(Card Card)
        {
            this.card = card;
        }
    }
}
