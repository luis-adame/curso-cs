// See https://aka.ms/new-console-template for more information
Console.WriteLine("Seleccione Busqueda:");
Console.WriteLine(" 1. ID\n 2. Nombre\n 3. Puesto\n 4. Fecha inicio\n 5. Estatus(a/i)\n");
var opcion = Console.ReadLine();
Console.Clear();
var input = "";
switch (opcion)
{
    case "1":
        Console.WriteLine("Ingrese id:");
        input = Console.ReadLine();
        searcher(input);
        break;
    case "2":
        Console.WriteLine("Ingrese nombre");
        input = Console.ReadLine();
        searcher(input);
        break;
    case "3":
        Console.WriteLine("Ingrese puesto");
        input = Console.ReadLine();
        searcher(input);
        break;
    case "4":
        Console.WriteLine("Ingrese rango de fechas de Inicio");
        Console.WriteLine("Ingrese fecha1:");
        var fecha1 = Console.ReadLine();
        Console.WriteLine("Ingrese fecha2:");
        var fecha2 = Console.ReadLine();
        input = fecha1 + ":" + fecha2;
        searcher(input);
        break;
    case "5":
        Console.WriteLine("Ingrese estatus");
        break;
    default:
        Console.WriteLine("Opcion no válida.");
        break;
}

static void searcher(string input)
{
    User.Input = input;

    Predicate<Empleado> predicateById = new Predicate<Empleado>(Empleado.getById);
    Predicate<Empleado> predicateByNombre = new Predicate<Empleado>(Empleado.getByNombre);
    Predicate<Empleado> predicateByPuesto = new Predicate<Empleado>(Empleado.getByPuesto);
    Predicate<Empleado> predicateByFechaInicio = new Predicate<Empleado>(Empleado.getByFechaInicio);

    List<Empleado> people = new List<Empleado>()
    {
        new Empleado() { id = 0, nombre = "Jorge",  puesto = "programador", fechaInicio = new DateTime(1992, 05, 17), estatus=false},
        new Empleado() { id = 1, nombre = "Alberto",  puesto = "programador", fechaInicio = new DateTime(1993, 06, 18), estatus=true},
        new Empleado() { id = 2, nombre = "Adriana",  puesto = "programador", fechaInicio = new DateTime(1994, 07, 19), estatus=true},
        new Empleado() { id = 3, nombre = "Karla",  puesto = "programador", fechaInicio = new DateTime(1995, 08, 20), estatus=true},
        new Empleado() { id = 4, nombre = "Gerardo",  puesto = "programador", fechaInicio = new DateTime(1996, 09, 21), estatus=true},
        new Empleado() { id = 5, nombre = "Esmeralda",  puesto = "analista", fechaInicio = new DateTime(2002, 05, 17), estatus=false},
        new Empleado() { id = 6, nombre = "Ivonne",  puesto = "analista", fechaInicio = new DateTime(2003, 06, 18), estatus=true},
        new Empleado() { id = 7, nombre = "Ramiro",  puesto = "documentador", fechaInicio = new DateTime(2004, 07, 19), estatus=true},
        new Empleado() { id = 8, nombre = "Andres",  puesto = "documentador", fechaInicio = new DateTime(2005, 08, 20), estatus=true},
        new Empleado() { id = 9, nombre = "Jose",  puesto = "programador", fechaInicio = new DateTime(2006, 09, 21), estatus=true}
    };

    var result = people.FindAll(predicateById);

    if (result.Any())
    {
        imprimeLista(result);
    }
    else
    {
        result = people.FindAll(predicateByNombre);
        if (result.Any())
        {
            imprimeLista(result);
        }
        else
        {
            result = people.FindAll(predicateByPuesto);

            if (result.Any())
            {
                imprimeLista(result);
            }
            else
            {
                result = people.FindAll(predicateByFechaInicio);
                if (result.Any())
                {
                    imprimeLista(result);
                }
            }
        }
    }
}

static void imprimeLista(List<Empleado> listaEmpleados)
{
    Console.WriteLine("Lista de empleados:");

    foreach (var empleado in listaEmpleados)
    {
        Console.WriteLine("id: " + empleado.id + "; nombre: " + empleado.nombre + "; puesto:" + empleado.puesto + "; fecha de inicio:" + empleado.fechaInicio);
    }
}

class Empleado
{
    public int id { get; set; }
    public string nombre { get; set; }
    public string puesto { get; set; }
    public DateTime fechaInicio { get; set; }
    public Boolean estatus { get; set; }

    public static bool getById(Empleado a)
    {
        var isNumber = Int32.TryParse(User.Input, out int idtmp);

        if (isNumber)
        {
            return a.id.Equals(idtmp);
        }
        else
        {
            return false;
        }
    }
    public static bool getByNombre(Empleado a)
    {
        return a.nombre.Equals(User.Input);
    }
    public static bool getByPuesto(Empleado a)
    {
        return a.puesto.Equals(User.Input);
    }
    public static bool getByFechaInicio(Empleado a)
    {
        string fecha1 = User.Input.Substring(0, User.Input.IndexOf(":"));
        string fecha2 = User.Input.Substring(User.Input.IndexOf(":") + 1);

        DateTime.TryParse(fecha1, out DateTime fechaI);
        DateTime.TryParse(fecha2, out DateTime fechaF);

        if (DateTime.Compare(a.fechaInicio, fechaI) >= 0
            && DateTime.Compare(a.fechaInicio, fechaF) <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

class User
{
    public static string Input { get; set; }
}