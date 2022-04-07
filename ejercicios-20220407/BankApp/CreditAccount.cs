using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class CreditAccount : Account
    {
        public CreditAccount(string name, decimal initialBalance, int minimumBalance) : base(name, initialBalance, minimumBalance){ }

        public void PerformEndMonthTransaction()
        {
            if (Balance < 0)
            {
                var interest = -Balance * 0.07m;
                Withdraw(interest, DateTime.Now, "Cargo de interes mensual");
            }
        }

        protected override Transaction CheckWithdrawalLimit(bool isOvercharged) => isOvercharged ? new Transaction(-20, DateTime.Now, "Cargo adicional por sobregiro") : default;
    }
}
