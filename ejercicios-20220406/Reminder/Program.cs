// See https://aka.ms/new-console-template for more information

Console.WriteLine("Nombre evento:");
var nombre = Console.ReadLine();

Console.WriteLine("Fecha evento (mm/dd/aaaa):");
var fecha1 = Console.ReadLine();
if (InputUsuario.validarInputFecha(fecha1))
{
	Console.WriteLine("Fecha actual (mm/dd/aaaa):");
	var fecha2 = Console.ReadLine();

    if (InputUsuario.validarInputFecha(fecha2))
    {
        if (InputUsuario.validarOrdenFechas(fecha2, fecha1))
        {
			Console.Clear();
			await Evento.ProgramarEvento(nombre, fecha1, fecha2);
        }
        else
        {
			Console.WriteLine("La fecha del evento debe ser mayor a la fecha actual.");
        }
    }
    else
    {
		Console.WriteLine("Formato de fecha no valido.");
    }
}
else
{
	Console.WriteLine("Formato de fecha no valido.");
}

public class Evento
{
	public static string nombreEvento { get; set; }
	public static DateTime fechaEvento { get; set; }
	public static DateTime fechaActual { get; set; }

	public static async Task ProgramarEvento(string nombre, string fecha1, string fecha2)
    {
		nombreEvento = nombre;
		fechaEvento = DateTime.Parse(fecha1);
		fechaActual = DateTime.Parse(fecha2);

		double diasParaEvento = (fechaEvento-fechaActual).TotalDays;
		
        for (int i= Convert.ToInt32(diasParaEvento-1); i>0; i--)
        {
			fechaActual = fechaActual.AddDays(1);
			await delayDia(i);
		}

		Console.WriteLine($"El evento: {nombreEvento} es Hoy!");
    }

	public static async Task delayDia(int dato)
	{
		await Task.Delay(TimeSpan.FromSeconds(1));
		Console.WriteLine(fechaActual.ToShortDateString() + " Faltan " + dato +" dias para el evento: " + nombreEvento);
	}
}

public class InputUsuario
{
	public static Boolean validarInputFecha(string dato)
	{
		return DateTime.TryParse(dato, out DateTime fecha);	
	}

	public static Boolean validarOrdenFechas(string dato1, string dato2)
    {
		DateTime fecha1 = DateTime.Parse(dato1);
		DateTime fecha2 = DateTime.Parse(dato2);

        if (DateTime.Compare(fecha1, fecha2) < 0)
        {
			return true;
        }
        else
        {
			return false;
        }
    }
}
