using System;
using System.Collections.Generic;

namespace OnlineBankMVC.Domain.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Accounts = new HashSet<Account>();
            Cards = new HashSet<Card>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}
