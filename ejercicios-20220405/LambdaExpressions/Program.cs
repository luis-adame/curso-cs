// See https://aka.ms/new-console-template for more information
Console.WriteLine("Please insert a number:");
var inputX = Console.ReadLine();
Console.WriteLine("Please insert a second number:");
var inputY = Console.ReadLine();

if (Double.TryParse(inputX, out double x)
	&& Double.TryParse(inputY, out double y))
{
	Console.WriteLine("\nDelegate");
	DelegateCalculator.Operate(x, y);
	Console.WriteLine("\nFunction");
	FunctionCalculator.Lambda(x, y);
}
else
{
	Console.WriteLine("Please insert a valid number.");
}

class DelegateCalculator
{
	public delegate double SelfOperator(double x);
	public delegate double Operator(double x, double y);
	public delegate double multiplicacion(double x, double y);
	public delegate double division(double x, double y);

	public delegate double sin(double x);
	public delegate double cos(double x);

	public static void Operate(double num, double num2)
	{
		SelfOperator square = new SelfOperator(x => x * x);
		Console.WriteLine($"The first square operation result is: {square(num)}\tThe second square operation result is: {square(num2)}");

		Operator addition = new Operator((x, y) => x + y);
		Console.WriteLine($"Addition equals to: {addition(num, num2)}");

		multiplicacion multi = new multiplicacion((x, y) => x * y);
		Console.WriteLine($"Multiplication equals to: {multi(num, num2)}");

		division divi = new division((x, y) => x / y);
		Console.WriteLine($"Division equals to: {divi(num, num2)}");

		sin pruebasin = new sin((x) => Math.Sin(x));
		Console.WriteLine($"The first sin operation result is: {pruebasin(num)}\tThe second square operation result is: {pruebasin(num2)}");

		cos pruebacos = new cos((x) => Math.Cos(x));
		Console.WriteLine($"The first cos operation result is: {pruebacos(num)}\tThe second cos operation result is: {pruebacos(num2)}");
	}
}

class FunctionCalculator
{
	public static void Lambda(double x, double y)
	{
		Func<double, double, double> addition = (x, y) => x + y;
		Console.WriteLine($"Addition equals to: {addition(x, y)}");

		Func<double, double> square = (x) => x * x;
		Console.WriteLine($"The first square operation result is: {square(x)}\tThe second square operation result is: {square(y)}");

		Func<double, double, double> multiplication = (x, y) => x * y;
		Console.WriteLine($"Multiplication equals to: {multiplication(x, y)}");

		Func<double, double, double> division = (x, y) => x / y;
		Console.WriteLine($"Division equals to: {division(x, y)}");

		Func<double, double> sin = (x) => Math.Sin(x);
		Console.WriteLine($"The first sin operation result is: {sin(x)}\tThe second square operation result is: {sin(y)}");

		Func<double, double> cos = (x) => Math.Cos(x);
		Console.WriteLine($"The first cos operation result is: {cos(x)}\tThe second cos operation result is: {cos(y)}");
	}
}
