// See https://aka.ms/new-console-template for more information
using BankApp;

//var account = new Account("Luis", 1000, 0);
//var giftCard = new GiftCardAccount("Felipe", 5000);
//Console.WriteLine($"Se creo cuenta con numero {account.Number} con saldo {account.Balance} por el cliente {account.Owner}");
//Console.WriteLine($"Se creo cuenta con numero {giftCard.Number} con saldo {giftCard.Balance} por el cliente {giftCard.Owner}");


//giftCard.Deposit(200, DateTime.Now.Date.AddDays(-4), "Para los tacos");
//giftCard.Deposit(500, DateTime.Now.Date.AddDays(-2), "Para la gasolina");
//giftCard.Deposit(200, DateTime.Now.Date.AddDays(0), "Para las caguas");

//var credito = new CreditAccount("Luis Felipe", 0, -3000);

//credito.Withdraw(750, DateTime.Now.Date.AddDays(-5), "gasto1");
//credito.Withdraw(750, DateTime.Now.Date.AddDays(-4), "gasto2");

//Console.WriteLine(credito.GetAccountHistory());

var inversion = new Inversiones("Luis Felipe", 0, 0);

inversion.Deposit(1000, DateTime.Now.Date.AddDays(-5), "deposito1");
inversion.PerformEndMonthTransaction();
Console.WriteLine(inversion.GetAccountHistory());