// See https://aka.ms/new-console-template for more information
Valle prueba = new Valle();
Console.WriteLine(prueba.cuentaValles());

class Valle
{
    string secuencia = "UDDDUDUU";

    public int cuentaValles()
    {
        int down = 0;
        int resultado = 0;

        for (int i = 0; i < secuencia.Length; i++)
        {
            if (secuencia[i].Equals('U'))
            {
                if (down > 2)
                {
                    resultado++;
                    down = 0;
                }
            }
            else if (secuencia[i].Equals('D'))
            {
                down++;
            }
        }

        return resultado;
    }
}