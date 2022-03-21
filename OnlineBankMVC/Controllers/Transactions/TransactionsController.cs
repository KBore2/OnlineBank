#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBankMVC.Command.Transactions.Command;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Data;
using OnlineBankMVC.Query.Transactions.Query;

namespace OnlineBankMVC.Controllers.AddTransactionControllerr
{
    public class TransactionsController : Controller
    {
        private readonly IMediator mediator;

        public TransactionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            return View(await mediator.Send(new GetAllTransactionsQuery()));
        }

        // GET: Transactions/2
        [Route("Transactions/{id}")]
        public async Task<IActionResult> TransactionsByCustomer(int id)
        {
            return View(await mediator.Send(new GetTransactionByAccountIDQuery(id)));
        }

        [Route("Transactions/{accountNumber}/{id}")]
        public async Task<IActionResult> Details(int accountNumber,int id)
        {
            return View(await mediator.Send(new GetTransactionByIDQuery(accountNumber,id)));
        }

        /*// GET: Transactions/Create
        [Route("Transactions/{customerId}/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Transactions/{customerId}/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int customerId, [Bind("Balance,BankName")] Transaction Transaction)
        {
            ModelState.Remove("Customer");
            if (ModelState.IsValid)
            {
                Transaction.CustomerId = customerId;
                await mediator.Send(new CreateTransactionCommand(Transaction));
                return RedirectToAction(nameof(Index));
            }
            return View(Transaction);
        }*/
    }
}
