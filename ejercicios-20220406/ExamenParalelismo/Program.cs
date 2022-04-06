// See https://aka.ms/new-console-template for more information
using System.Diagnostics;


Console.WriteLine("Listo para responder examen? (s/n):");
var opcion = Console.ReadLine();

if (!string.IsNullOrEmpty(opcion) && opcion.Equals("s"))
{
    var timeElapsed = await Parallelism.reloj();
    Console.WriteLine($"Tiempo de examen: {timeElapsed / 1000m} seconds");
}
else
{
    return;
}

class Examen
{
    List<Pregunta> listaPreguntas = new List<Pregunta>();

    public Examen()
    {
        listaPreguntas.Add(new Pregunta("Rey:", "a) Skywalker", "b) Kenobi", "c) Palpatine", "a"));
        listaPreguntas.Add(new Pregunta("Arroz: ", "a) Con salsa", "b) Con leche", "c) Con frijol", "c"));
        listaPreguntas.Add(new Pregunta("Pizza: ", "a) Hawaiiana", "b) Mexicana", "c) Peperoni", "b"));
    }

    public void ejecuta()
    {
        int correctas = 0;

        for (int i = 0; i < listaPreguntas.Count; i++)
        {
            string pregunta = listaPreguntas.ElementAt(i).pregunta;
            string opcion1 = listaPreguntas.ElementAt(i).opcion1;
            string opcion2 = listaPreguntas.ElementAt(i).opcion2;
            string opcion3 = listaPreguntas.ElementAt(i).opcion3;

            Console.WriteLine(pregunta);
            Console.WriteLine(opcion1);
            Console.WriteLine(opcion2);
            Console.WriteLine(opcion3);

            var respuesta = Console.ReadLine();

            if (!string.IsNullOrEmpty(respuesta))
            {
                if (respuesta.ToString().Equals(listaPreguntas.ElementAt(i).respuesta))
                {
                    //listaPreguntas.ElementAt(i).evaluacion = true;
                    correctas++;
                }
            }

            var tiempoExamen = Parallelism.stopwatch.ElapsedMilliseconds;
            if ((tiempoExamen/1000m) >= 15)
            {
                Console.WriteLine(i = listaPreguntas.Count);
            }
        }

        Console.WriteLine($"Resultado: {correctas}/{listaPreguntas.Count}");
    }
}

public class Parallelism
{
    public static Stopwatch stopwatch = new Stopwatch();

    public static async Task<long> reloj()
    {
        stopwatch.Start();

        await Process1();

        stopwatch.Stop();

        return stopwatch.ElapsedMilliseconds;
    }

    public static async Task Process1()
    {
        //await Task.Run(() =>
        //{
        //    Thread.Sleep(4000);
        //});
        Examen prueba = new Examen();
        prueba.ejecuta();
    }
}

class Pregunta
{
    public string pregunta { get; set; }
    public string opcion1 { get; set; }
    public string opcion2 { get; set; }
    public string opcion3 { get; set; }
    public string respuesta { get; set; }
    public Boolean evaluacion { get; set; }

    public Pregunta(string txtPregunta, string txtOpcion1, string txtOpcion2, string txtOpcion3, string txtRespuesta)
    {
        pregunta = txtPregunta;
        opcion1 = txtOpcion1;
        opcion2 = txtOpcion2;
        opcion3 = txtOpcion3;
        respuesta = txtRespuesta;

        evaluacion = false;
    }
}