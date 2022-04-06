// See https://aka.ms/new-console-template for more information
Lista prueba = new Lista();

prueba.imprimeArreglo();
prueba.rotarArreglo(1);
prueba.imprimeArreglo();
prueba.rotarArreglo(2);
prueba.imprimeArreglo();

class Lista
{
    List<int> arreglo = new List<int>() { 1, 2, 3, 4, 5 };

    public void imprimeArreglo()
    {
        //foreach(int i in arreglo)
        //{
        //    Console.WriteLine(i);
        //}

        Console.WriteLine(String.Join(",", arreglo));
    }

    public void rotarArreglo(int numero)
    {
        for (int i = 0; i < numero; i++)
        {
            var temporal = arreglo.ElementAt(arreglo.Count - 1);
            arreglo.RemoveAt(arreglo.Count - 1);
            arreglo.Insert(0, temporal);
        }
    }
}