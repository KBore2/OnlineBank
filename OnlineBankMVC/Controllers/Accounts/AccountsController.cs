#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBankMVC.Command.Accounts.Command;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Data;
using OnlineBankMVC.Query.Accounts.Query;

namespace OnlineBankMVC.Controllers.AddAccountControllerr
{
    public class AccountsController : Controller
    {
        private readonly IMediator mediator;

        public AccountsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            return View(await mediator.Send(new GetAllAccountsQuery()));
        }

        // GET: Accounts/2
        [Route("Accounts/{id}")]
        public async Task<IActionResult> AccountsByCustomer(int id)
        {
            return View(await mediator.Send(new GetAccountByCustomerIDQuery(id)));
        }

        // GET: Accounts/2/Details/2
        [Route("Accounts/{customerId}/Details/{AccountNumber}")]
        public async Task<IActionResult> Details(int customerId, int AccountNumber)
        {

            var Account = await mediator.Send(new GetAccountByIDQuery(customerId, AccountNumber));
            return Account == null ? NotFound() : View(Account);
        }

        // GET: Accounts/Create
        [Route("Accounts/{customerId}/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Accounts/{customerId}/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int customerId, [Bind("Balance,BankName")] Account Account)
        {
            ModelState.Remove("Customer");
            if (ModelState.IsValid)
            {
                Account.CustomerId = customerId;
                await mediator.Send(new CreateAccountCommand(Account));
                return RedirectToAction(nameof(Index));
            }
            return View(Account);
        }

        // GET: Accounts/2/Edit/5
        [Route("Accounts/{customerId}/Edit/{AccountNumber}")]
        public async Task<IActionResult> Edit(int customerId, int AccountNumber)
        {
            var Account = await mediator.Send(new GetAccountByIDQuery(customerId, AccountNumber));
            return Account == null ? NotFound() : View(Account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Accounts/{customerId}/Edit/{AccountNumber}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int customerId, int AccountNumber, [Bind("Balance,BankName")] Account Account)
        {
            ModelState.Remove("Customer");
            if (ModelState.IsValid)
            {

                Account.AccountNumber = AccountNumber;
                Account.CustomerId = customerId;
                await mediator.Send(new UpdateAccountCommand(Account));
                return RedirectToAction(nameof(Index));
            }

            return View(Account);
        }

        // GET: Accounts/2/Delete/5
        [Route("Accounts/{customerId}/Delete/{AccountNumber}")]
        public async Task<IActionResult> Delete(int customerId, int AccountNumber)
        {
            var Account = await mediator.Send(new GetAccountByIDQuery(customerId, AccountNumber));
            return Account == null ? NotFound() : View(Account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("Accounts/{customerId}/Delete/{AccountNumber}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int customerId, int AccountNumber)
        {
            await mediator.Send(new DeleteAccountCommand(AccountNumber));
            return RedirectToAction(nameof(Index));
        }
    }
}
