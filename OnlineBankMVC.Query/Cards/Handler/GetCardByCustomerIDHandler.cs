using MediatR;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Repositories;
using OnlineBankMVC.Query.Cards.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineBankMVC.Query.Cards.Handler
{
    internal class GetCardByCustomerIDHandler: IRequestHandler<GetCardByCustomerIDQuery, List<Card>>
    {
        private readonly CardRepository repoistory;

        public GetCardByCustomerIDHandler(CardRepository repoistory)
        {
            this.repoistory = repoistory;
        }

        public async Task<List<Card>> Handle(GetCardByCustomerIDQuery request, CancellationToken cancellationToken)
        {
            var response = await repoistory.GetByCustomerID(c => c.CustomerId == request.card.CustomerId);
            return response ?? null;
        }
    }
}
