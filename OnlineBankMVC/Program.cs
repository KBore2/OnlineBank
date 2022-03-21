using MediatR;
using Microsoft.EntityFrameworkCore;
using NLog;
using OnlineBankMVC.Command.Accounts.Command;
using OnlineBankMVC.Command.Cards.Command;
using OnlineBankMVC.Command.Customers.Command;
using OnlineBankMVC.Command.Transactions.Command;
using OnlineBankMVC.Domain.ILogger;
using OnlineBankMVC.Domain.IRepositories;
using OnlineBankMVC.Infrastructure.Data;
using OnlineBankMVC.Infrastructure.LoggerManager;
using OnlineBankMVC.Infrastructure.Repositories;
using OnlineBankMVC.Query.Accounts.Query;
using OnlineBankMVC.Query.Cards.Query;
using OnlineBankMVC.Query.Customers.Query;
using OnlineBankMVC.Query.Transactions.Query;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Services.AddSingleton<ILoggerManager,LoggerManager>();



builder.Services.AddTransient<CustomerRepository>();
builder.Services.AddTransient<AccountRepository>();
builder.Services.AddTransient<CardRepository>();
builder.Services.AddTransient<TransactionRepository>();

builder.Services.AddMediatR(typeof(CreateAccountCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(DeleteAccountCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UpdateAccountCommand).GetTypeInfo().Assembly);

builder.Services.AddMediatR(typeof(CreateCustomerCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(DeleteCustomerCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UpdateCustomerCommand).GetTypeInfo().Assembly);

builder.Services.AddMediatR(typeof(CreateCardCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(DeleteCardCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UpdateCardCommand).GetTypeInfo().Assembly);

builder.Services.AddMediatR(typeof(CreateTransactionCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(DeleteTransactionCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UpdateTransactionCommand).GetTypeInfo().Assembly);

builder.Services.AddMediatR(typeof(GetAccountByIDQuery).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetAllAccountsQuery).GetTypeInfo().Assembly);

builder.Services.AddMediatR(typeof(GetCardByIDQuery).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetAllCardsQuery).GetTypeInfo().Assembly);

builder.Services.AddMediatR(typeof(GetCustomerByIDQuery).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetAllCustomersQuery).GetTypeInfo().Assembly);


builder.Services.AddMediatR(typeof(GetTransactionByIDQuery).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetAllTransactionsQuery).GetTypeInfo().Assembly);

//builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OnlineBankDBContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{customerId?}"
    );

app.Run();
