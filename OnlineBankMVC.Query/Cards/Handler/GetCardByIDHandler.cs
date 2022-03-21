using MediatR;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Repositories;
using OnlineBankMVC.Query.Cards.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankMVC.Query.Cards.Handler
{
    internal class GetCardByIDHandler: IRequestHandler<GetCardByIDQuery,Card>
    {
        private readonly CardRepository repoistory;

        public GetCardByIDHandler(CardRepository repoistory)
        {
            this.repoistory = repoistory;
        }

        public async Task<Card> Handle(GetCardByIDQuery request, CancellationToken cancellationToken)
        {
            var response = await repoistory.GetAsync(c => c.CardNumber == request.card.CardNumber && c.CustomerId == request.card.CustomerId);
            return response == null ? throw new Exception("Card not found") : response;
        }
    }
}
