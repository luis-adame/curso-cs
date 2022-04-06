// See https://aka.ms/new-console-template for more information
Predicate<int> predicado = new Predicate<int>(esPrimo);

List<int> numeros = new List<int>();
numeros.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

List<int> resultado = numeros.FindAll(predicado);
//List<int> resultado = numeros.FindAll(LambdaExpression.GetPairs);

foreach (int numero in resultado)
{
    Console.WriteLine(numero);
}

static bool esPrimo(int numero)
{
    int contador = 0;

    for (int i = 1; i <= numero; i++)
    {
        if ((numero % i) == 0)
        {
            contador++;
        }
    }

    if (contador <= 2)
    {
        return true;
    }
    else
    {
        return false;
    }
}

class LambdaExpression
{
    private static List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    public static List<int> GetPairs()
    {
        return list.FindAll(x => x % 2 == 0);
    }
}

class ActionCalculator
{
    public static void Lambda(double x, double y)
    {
        Action<double, double> addition = (x, y) =>
        {
            Console.WriteLine(x + y);
        };
        addition(x, y);
    }
}