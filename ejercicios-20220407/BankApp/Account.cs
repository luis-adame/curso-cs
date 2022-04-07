using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Account
    {
		public string Owner { get; set; }
		public string Number { get; set; }
		public decimal Balance {
			get
			{
				decimal balance = 0;
				foreach (var transaction in TransactionList)
				{
					balance += transaction.Amount;
				}
				return balance;
			}

			set { } 
		}

		public List<Transaction> TransactionList = new List<Transaction>();

		private readonly int _minimumBalance;

		private static int accountNumberSeed = 1234567890;

		public Account(string name, decimal initialBalance) : this(name, initialBalance, 0){ } 
		public Account(string name, decimal initialBalance, int minimumBalance)
		{
			Owner = name;
			_minimumBalance = minimumBalance;

			Number = accountNumberSeed.ToString();
			accountNumberSeed++;

			if (initialBalance > 0)
				Deposit(initialBalance, DateTime.Now, "Balance inicial");
		}

		public void Deposit(decimal amount, DateTime date, string description)
		{
			if (amount <= 0)
				Console.WriteLine("No puedes depositar cantidad negativa");

			var deposit = new Transaction(amount, date, description);
			TransactionList.Add(deposit);
		}

		public void Withdraw(decimal amount, DateTime date, string description)
		{
			if (amount <= 0)
				Console.WriteLine("No puedes retirar cantidad negativa.");

			var transaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
			var withdrawal = new Transaction(amount, date, description);
			TransactionList.Add(withdrawal);

			if (transaction != null)
				TransactionList.Add(transaction);
		}

		protected virtual Transaction CheckWithdrawalLimit(bool isOverCharge)
		{
			if (isOverCharge)
			{
				throw new InvalidOperationException("No tienes fondos suficientes.");
			}
			else
			{
				return default;
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
