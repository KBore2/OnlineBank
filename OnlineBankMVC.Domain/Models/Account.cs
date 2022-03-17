using OnlineBankMVC.Domain.Models;
using System;
using System.Collections.Generic;

namespace OnlineBankMVC.Domain.Models
{
    public partial class Account
    {
        public Account()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int AccountNumber { get; set; }
        public int Balance { get; set; }
        public string BankName { get; set; } = null!;
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
