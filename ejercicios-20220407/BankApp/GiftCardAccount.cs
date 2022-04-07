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
    }
}
