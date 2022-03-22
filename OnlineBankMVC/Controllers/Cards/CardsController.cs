#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBankMVC.Command.Cards.Command;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Data;
using OnlineBankMVC.Query.Cards.Query;

namespace OnlineBankMVC.Controllers.AddCardControllerr
{
    public class CardsController : Controller
    {
        private readonly IMediator mediator;

        public CardsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: Cards
        public async Task<IActionResult> Index()
        {
            return View(await mediator.Send(new GetAllCardsQuery()));
        }

        // GET: Cards/2
        [Route("Cards/{id}")]
        public async Task<IActionResult> CardsByCustomer(int id)
        {
            //return View(await mediator.Send(new GetCardByCustomerIDQuery(id)));
            TempData["customerId"] = id;
            var card = await mediator.Send(new GetCardByCustomerIDQuery(id));
            return View(card);
        }

        // GET: Cards/2/Details/2
        [Route("Cards/{customerId}/Details/{cardNumber}")]
        public async Task<IActionResult> Details(int customerId,int cardNumber)
        {

            var Card = await mediator.Send(new GetCardByIDQuery(customerId, cardNumber));
            return Card == null? NotFound(): View(Card);
        }

        // GET: Cards/Create
        [Route("Cards/{customerId}/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Cards/{customerId}/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int customerId,[Bind("ExpiryDate,Ccv")] Card Card)
        {
            ModelState.Remove("Customer");
            if (ModelState.IsValid)
            {
                Card.CustomerId = customerId;
                await mediator.Send(new CreateCardCommand(Card));
                return RedirectToAction(nameof(Index));
            }
            return View(Card);
        }

        // GET: Cards/2/Edit/5
        [Route("Cards/{customerId}/Edit/{cardNumber}")]
        public async Task<IActionResult> Edit(int customerId, int cardNumber)
        {
            var Card = await mediator.Send(new GetCardByIDQuery(customerId, cardNumber));
            return Card == null ? NotFound() : View(Card);
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Cards/{customerId}/Edit/{cardNumber}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int customerId,int cardNumber, [Bind("ExpiryDate,Ccv")] Card Card)
        {
            ModelState.Remove("Customer");
            if (ModelState.IsValid)
            {
                
                Card.CardNumber = cardNumber;
                Card.CustomerId = customerId;
                await mediator.Send(new UpdateCardCommand(Card));
                return RedirectToAction(nameof(Index));
            }
            
            return View(Card);
        }

        // GET: Cards/2/Delete/5
        [Route("Cards/{customerId}/Delete/{cardNumber}")]
        public async Task<IActionResult> Delete(int customerId, int cardNumber)
        {
            var Card = await mediator.Send(new GetCardByIDQuery(customerId,cardNumber));
            return Card == null ? NotFound() : View(Card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("Cards/{customerId}/Delete/{cardNumber}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int customerId, int cardNumber)
        {
            await mediator.Send(new DeleteCardCommand(cardNumber));
            return RedirectToAction(nameof(Index));
        }
    }
}
