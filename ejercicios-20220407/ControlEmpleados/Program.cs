// See https://aka.ms/new-console-template for more information
using ControlEmpleados;
Sistema prueba = new Sistema();
prueba.ejecutar();

class Sistema
{
    List<Usuario> usuariosSistema = new List<Usuario>();
    public Sistema()
    {
        usuariosSistema.Add(new Supervisor("Supervisor", new DateTime(2000, 04, 07), "12345"));
        usuariosSistema.Add(new Empleado("Empleado1", new DateTime(2000, 04, 07), "12345"));
        usuariosSistema.Add(new Empleado("Empleado2", new DateTime(2000, 04, 07), "12345"));
    }

    public void ejecutar()
    {
        do
        {
            Usuario user = inicioSesion();

            if (user != null)
            {
                if (user.nivelAcceso == 1)
                {
                    while(opcionesEmpleado());
                }
                else if (user.nivelAcceso == 2)
                {
                    while(opcionesSupervisor());
                }
            }
        } while (true);
    }

    public Usuario inicioSesion()
    {
        Console.Clear();
        Console.WriteLine("Inicio de sesion.");
        Console.WriteLine("Usuario:");
        var usuario = Console.ReadLine();

        Console.WriteLine("Contrasenia:");
        var contrasenia = Console.ReadLine();

        foreach (Usuario a in usuariosSistema)
        {
            if (a.nombre.Equals(usuario) && a.contrasenia.Equals(contrasenia))
            {
                return a;
            }
        }

        return null;
    }

    public Boolean opcionesEmpleado()
    {
        Console.Clear();
        Console.WriteLine("Ingrese opcion");
        Console.WriteLine("1. Registrar horas.");
        Console.WriteLine("2. Salir.");
        var opcion = Console.ReadLine();

        if (!string.IsNullOrEmpty(opcion) && !"2".Equals(opcion))
        {
            return true;
        }else
        {
            return false;
        }
    }

    public Boolean opcionesSupervisor()
    {
        Console.Clear();
        Console.WriteLine("Ingrese opcion");
        Console.WriteLine("1. Alta empleado.");
        Console.WriteLine("2. Editar empleado.");
        Console.WriteLine("3. Baja empleado.");
        Console.WriteLine("4. Salir.");
        var opcion = Console.ReadLine();

        if (!string.IsNullOrEmpty(opcion) && !"4".Equals(opcion))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void registroHoras()
    {
        Console.Clear();
        Console.WriteLine("Horas de trabajo:");
        var horasTrabajo = Console.ReadLine();
        Console.WriteLine("Descripcion:");
        var descripcion = Console.ReadLine();
    }

    public void menuAltaEmpleado()
    {
        Console.Clear();
        Console.WriteLine("ALTA EMPLEADO");
        Console.WriteLine("Nombre de empleado:");
        var nombreCaptura = Console.ReadLine();
        Console.WriteLine("Fecha de ingreso:");
        var fechaCaptura = Console.ReadLine();
        Console.WriteLine("Contrasenia de empleado:");
        var contraseniaCaptura = Console.ReadLine();
    }

    public void menuEditarEmpleado()
    {
        Console.Clear();
        Console.WriteLine("MODIFICAR DATOS EMPLEADO");
        Console.WriteLine("Nombre Empleado");
        var nombreCaptura = Console.ReadLine();
        Console.WriteLine("Contrasenia:");
        var contraseniaCaptura = Console.ReadLine();
    }

    public void menuBajaEmpleado()
    {
        Console.Clear();
        Console.WriteLine("BAJA EMPLEADO");
        Console.WriteLine("Ingrese id de empleado:");
        var idCaptura = Console.ReadLine();
    }
}