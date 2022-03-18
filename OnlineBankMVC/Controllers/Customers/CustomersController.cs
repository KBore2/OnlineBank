#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBankMVC.Command.Customers.Command;
using OnlineBankMVC.Domain.Models;
using OnlineBankMVC.Infrastructure.Data;
using OnlineBankMVC.Query.Customers.Query;

namespace OnlineBankMVC.Controllers.AddCustomerControllerr
{
    public class CustomersController : Controller
    {
        private readonly OnlineBankDBContext _context;
        private readonly IMediator mediator;

        public CustomersController(IMediator mediator, OnlineBankDBContext _context)
        {
            this.mediator = mediator;
            this._context = _context;
    }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await mediator.Send(new GetAllCustomersQuery()));
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var customer = await mediator.Send(new GetCustomerByIDQuery(id));
            return customer == null? NotFound(): View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await mediator.Send(new CreateCustomerCommand(customer));
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await mediator.Send(new GetCustomerByIDQuery(id));
            return customer == null ? NotFound() : View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.CustomerId = id;
                await mediator.Send(new UpdateCustomerCommand(customer));
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await mediator.Send(new GetCustomerByIDQuery(id));
            return customer == null ? NotFound() : View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            await mediator.Send(new DeleteCustomerCommand(id));
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
