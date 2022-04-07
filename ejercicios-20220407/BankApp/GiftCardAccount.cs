using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class GiftCardAccount : Account
    {
        public GiftCardAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {

        }

        public void imprimeTransacciones(int month)
        {
            Console.WriteLine($"Movimientos del mes {month}:");
            foreach (Transaction movimiento in TransactionList)
            {
                if (movimiento.Date.Month.Equals(month))
                {
                    Console.WriteLine($"Descripcion: { movimiento.Description} Cantidad: {movimiento.Amount} Fecha: {movimiento.Date}");
                }
            }
        }

        public string GetAccountHistory()
        {
            decimal balance = 0;
            var report = new StringBuilder();
            report.AppendLine("Date\tAmount\tBalance\tDescription\t");

            foreach (var transaction in TransactionList)
            {
                balance += transaction.Amount;
                report.AppendLine($"{transaction.Date.ToShortDateString}\t{transaction.Amount}\t{balance}\t{transaction.Description}");
            }

            return report.ToString();
        }
    }
}
