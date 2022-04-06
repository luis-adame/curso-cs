// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

static void DomainValidation()
{
	var domain = "https://www.something.com";
	Regex regex = new Regex(@"^https?://(www.)?([\w]+)((\.[A-Za-z]{2,3})+)$");
}

static void phoneNumber()
{
	var phoneNumber = "+52 (686) 405 4720";
	Regex regex = new Regex(@"^+[\d]{2}\s\([\d]{3}\)\s[\d]{3}\s[\d]{4}");
	Console.WriteLine(regex.IsMatch(phoneNumber));
}
