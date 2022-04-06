// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

PasswordValidator("kakaroto");
PasswordValidator("kakarotO");
PasswordValidator("Kakarot0");
PasswordValidator("Kak@rot0");
PasswordValidator("Kak@rot007$");
PasswordValidator("Kkr#t0");
PasswordValidator("Kak@rot0.");
PasswordValidator("Kakarot0.");

static void DomainValidation()
{
	var domain = "https://www.something.com";
	Regex regex = new Regex(@"^https?://(www.)?([\w]+)((\.[A-Za-z]{2,3})+)$");
}

static void phoneNumber()
{
	var phoneNumber = "+52 (686) 405 4720";
	Regex regex = new Regex(@"^+[\d]{2}\s\([\d]{3}\)\s[\d]{3}\s[\d]{4}$");
	Console.WriteLine(regex.IsMatch(phoneNumber));
}

static void PasswordValidator(String pass)
{
	//longitud de por lo menos 8 caracteres
	//al menos una mayuscula
	//al menos una minuscula
	//al menos un numero
	//al menos un caracter especial

	Regex passwordRegex = new Regex(@"((?=.*[a-z])(?=.*[A-Z])(?=.*[\d])(?=.*[\!\@\#\$\%\&])).{8}");

	Console.WriteLine(pass+" : "+passwordRegex.IsMatch(pass));
}
