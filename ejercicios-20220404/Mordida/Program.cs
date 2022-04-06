// See https://aka.ms/new-console-template for more information
Mordidas prueba = new Mordidas();

prueba.cuentaMovimientos("12345");
prueba.cuentaMovimientos("12534");
prueba.cuentaMovimientos("21534");
//prueba.cuentaMovimientos("25134");

class Mordidas
{

    public int cuentaMovimientos(string desorden)
    {
        int resultado = 0;

        for (int i = 0; i < desorden.Length; i++)
        {
            if ((Int32.Parse(desorden.ElementAt(i).ToString()) - 1) > i)
            {
                int movimientos = (Int32.Parse(desorden.ElementAt(i).ToString()) - 1) - i;

                if (movimientos < 3)
                {
                    resultado += movimientos;
                }
                else
                {
                    resultado = -1;
                    break;
                }
            }
        }

        if (resultado < 0)
        {
            Console.WriteLine("Too Chaotic");
        }
        else
        {
            Console.WriteLine("movimientos: " + resultado);
        }

        return resultado;
    }
}