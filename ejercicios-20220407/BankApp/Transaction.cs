using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Transaction(decimal amount, DateTime date, string description)
        {
            Amount = amount;
            Date = date;
            Description = description;
        }
    }
}
