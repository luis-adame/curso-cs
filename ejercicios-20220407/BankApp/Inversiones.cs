using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Inversiones : Account
    {
        public Inversiones(string name, decimal initialBalance, int minimumBalance) : base(name, initialBalance, minimumBalance) { }

        public void PerformEndMonthTransaction()
        {
            if (Balance >= 500)
            {
                var interest = Balance * 0.05m;
                Withdraw(interest, DateTime.Now, "Abono de Inversion");
            }
        }

        //protected override Transaction CheckWithdrawalLimit(bool isOvercharged) => isOvercharged ? new Transaction(-20, DateTime.Now, "Cargo adicional por sobregiro") : default;
    }
}
