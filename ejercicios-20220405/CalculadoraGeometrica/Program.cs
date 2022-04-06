// See https://aka.ms/new-console-template for more information
Console.WriteLine("Seleccione una opcion para calcular.");
Console.WriteLine("1. Cuadrado.");
Console.WriteLine("2. Rectangulo.");
Console.WriteLine("3. Triangulo.");
Console.WriteLine("4. Circulo.");
var opcion = Console.ReadLine();

Console.Clear();

var lado1 = "";
var lado2 = "";

double x;
double y;

switch (opcion)
{
	case "1":
		Console.WriteLine("Escriba base de cuadrado: ");
		lado1 = Console.ReadLine();
		if (Double.TryParse(lado1, out x))
		{
			DelegateCalculator.getSquare(x);
		}
		else
		{
			Console.WriteLine("Inserte numero valido.");
		}

		break;
	case "2":
		Console.WriteLine("Escriba base de rectangulo: ");
		lado1 = Console.ReadLine();
		Console.WriteLine("Escriba altura de rectangulo: ");
		lado2 = Console.ReadLine();

		if (Double.TryParse(lado1, out x)
			&& Double.TryParse(lado2, out y))
		{
			DelegateCalculator.getRectangle(x, y);
		}
		else
		{
			Console.WriteLine("Inserte numeros validos.");
		}

		break;
	case "3":
		Console.WriteLine("Escriba base de triangulo: ");
		lado1 = Console.ReadLine();
		Console.WriteLine("Escriba altura de triangulo: ");
		lado2 = Console.ReadLine();

		if (Double.TryParse(lado1, out x)
			&& Double.TryParse(lado2, out y))
		{
			DelegateCalculator.getTriangle(x, y);
		}
		else
		{
			Console.WriteLine("Inserte numeros validos.");
		}

		break;
	case "4":
		Console.WriteLine("Escriba radio de circulo: ");
		lado1 = Console.ReadLine();

		if (Double.TryParse(lado1, out x))
		{
			DelegateCalculator.getCircle(x);
		}
		else
		{
			Console.WriteLine("Inserte numero valido.");
		}

		break;
	default:
		Console.WriteLine("Opcion no valida.");
		break;
}

class DelegateCalculator
{
	public delegate double squarePerimeter(double x);
	public delegate double squareArea(double x);

	public delegate double rectanglePerimeter(double x, double y);
	public delegate double rectangleArea(double x, double y);

	public delegate double trianglePerimeter(double x);
	public delegate double triangleArea(double x, double y);

	public delegate double circlePerimeter(double x);
	public delegate double circleArea(double x);

	public static void getSquare(double x)
	{
		squarePerimeter squarep = new squarePerimeter(x => x * 4);
		Console.WriteLine($"The square perimeter result is: {squarep(x)}");

		squareArea squarea = new squareArea(x => x * x);
		Console.WriteLine($"The square area result is: {squarea(x)}");
	}

	public static void getRectangle(double x, double y)
	{
		rectanglePerimeter rectanglep = new rectanglePerimeter((x, y) => 2 * x + 2 * y);
		Console.WriteLine($"The rectangle perimeter result is: {rectanglep(x, y)}");

		rectangleArea rectanglea = new rectangleArea((x, y) => x * y);
		Console.WriteLine($"The rectangle area result is: {rectanglea(x, y)}");
	}

	public static void getTriangle(double x, double y)
	{
		trianglePerimeter trianglep = new trianglePerimeter((x) => x * 3);
		Console.WriteLine($"The triangle perimeter result is: {trianglep(x)}");

		triangleArea trianglea = new triangleArea((x, y) => (x * y) / 2);
		Console.WriteLine($"The triangle area result is: {trianglea(x, y)}");
	}

	public static void getCircle(double x)
	{
		circlePerimeter circlep = new circlePerimeter((x) => 2 * x * Math.PI);
		Console.WriteLine($"The circle perimeter result is: {circlep(x)}");

		circleArea circlea = new circleArea((x) => Math.Pow(x, 2) * Math.PI);
		Console.WriteLine($"The circle area result is: {circlea(x)}");
	}
}

class FunctionCalculator
{
	public static void getSquare(double x)
	{
		Func<double, double> squarep = (x) => x * 4;
		Console.WriteLine($"The square perimeter result is: {squarep(x)}");

		Func<double, double> squarea = (x) => x * x;
		Console.WriteLine($"The square area result is: {squarea(x)}");
	}

	public static void getRectangle(double x, double y)
	{
		Func<double, double, double> rectanglep = (x, y) => 2 * x + 2 * y;
		Console.WriteLine($"The rectangle perimeter result is: {rectanglep(x, y)}");

		Func<double, double, double> rectanglea = (x, y) => x * y;
		Console.WriteLine($"The rectangle area result is: {rectanglea(x, y)}");
	}

	public static void getTriangle(double x, double y)
	{
		Func<double, double> trianglep = (x) => 3 * x;
		Console.WriteLine($"The triangle perimeter result is: {trianglep(x)}");

		Func<double, double, double> trianglea = (x, y) => (x * y) / 2;
		Console.WriteLine($"The triangle area result is: {trianglea(x, y)}");
	}

	public static void getCircle(double x)
	{
		Func<double, double> circlep = (x) => 2 * x * Math.PI;
		Console.WriteLine($"The circle perimeter result is: {circlep(x)}");

		Func<double, double> circlea = (x) => Math.Pow(x, 2) * Math.PI;
		Console.WriteLine($"The circle area result is: {circlea(x)}");
	}
}
