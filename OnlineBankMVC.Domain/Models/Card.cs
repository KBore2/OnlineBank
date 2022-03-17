using System;
using System.Collections.Generic;

namespace OnlineBankMVC.Domain.Models
{
    public partial class Card
    {
        public int CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Ccv { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
    }
}
