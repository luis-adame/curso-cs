using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class GiftCardAccount : Account
    {
        public GiftCardAccount(string name, decimal initialBalance) : base(name, initialBalance) { }
    }
}
