// See https://aka.ms/new-console-template for more information
using ControlEmpleados;

Sistema prueba = new ();
prueba.Ejecutar();

class Sistema
{
    BaseDatos Base;
    public Sistema()
    {
        Base = new BaseDatos();
    }

    public void Ejecutar()
    {
        do
        {
            Usuario user = InicioSesion();

            if (user != null)
            {
                if (user.NivelAcceso == 1)
                {
                    while(OpcionesEmpleado(user));
                }
                else if (user.NivelAcceso == 2)
                {
                    while(OpcionesSupervisor(user));
                }
            }
        } while (true);
    }

    public Usuario InicioSesion()
    {
        Console.Clear();
        Console.WriteLine("Inicio de sesion.");
        Console.WriteLine("Usuario:");
        var nombreUsuario = Console.ReadLine();
        if (string.IsNullOrEmpty(nombreUsuario))
        {
            nombreUsuario = "";
        }

        Console.WriteLine("Contrasenia:");
        var contrasenia = Console.ReadLine();
        if (string.IsNullOrEmpty(contrasenia))
        {
            contrasenia = "";
        }

        return Base.BuscarUsuario(nombreUsuario, contrasenia);
    }

    private Boolean OpcionesEmpleado(Usuario _usuario)
    {
        Console.Clear();
        Console.WriteLine(_usuario.ValidarSaludoAniversario());
        Console.WriteLine("Ingrese opcion");
        Console.WriteLine("1. Registrar horas.");
        Console.WriteLine("2. Salir.");
        var captura = Console.ReadLine();

        if (!string.IsNullOrEmpty(captura) && int.TryParse(captura, out int opcionmenu))
        {
            switch (opcionmenu)
            {
                case 1: MenuRegistrarHoras(_usuario); return true;
                case 2: return false;
                default: return true;
            }
        }
        else
        {
            return true;
        }
    }

    private Boolean OpcionesSupervisor(Usuario _usuario)
    {
        Console.Clear();
        Console.WriteLine(_usuario.ValidarSaludoAniversario());
        Console.WriteLine("Ingrese opcion");
        Console.WriteLine("1. Validar horas.");
        Console.WriteLine("2. Alta empleado.");
        Console.WriteLine("3. Editar empleado.");
        Console.WriteLine("4. Baja empleado.");
        Console.WriteLine("5. Salir.");
        var captura = Console.ReadLine();

        if (!string.IsNullOrEmpty(captura) && int.TryParse(captura, out int opcionmenu))
        {
            switch (opcionmenu)
            {
                case 1: MenuValidarHoras(); return true;
                case 2: while (MenuAltaEmpleado()); return true;
                case 3: MenuEditarEmpleado();  return true;
                case 4: MenuBajaEmpleado();  return true;
                case 5: return false;
                default: return true;
            }
        }
        else
        {
            return true;
        }
    }

    private void MenuRegistrarHoras(Usuario _usuario)
    {
        Console.Clear();
        Console.WriteLine("REGISTRO HORAS");

        Proyecto seleccion = MenuSeleccionaProyecto();

        if (seleccion != null)
        {
            while (MenuRegistrarHoras2(_usuario, seleccion.Id)) ;
        }
    }

    private Boolean MenuRegistrarHoras2(Usuario _usuario, int _idProyecto)
    {
        Console.Clear();
        Console.WriteLine("REGISTRO HORAS");
        Console.WriteLine("Horas de trabajo:");
        var horasCaptura = Console.ReadLine();
        Console.WriteLine("Descripcion:");
        var descripcionCaptura = Console.ReadLine();

        if (!string.IsNullOrEmpty(horasCaptura)
            && int.TryParse(horasCaptura, out int horasTrabajo)
            && !string.IsNullOrEmpty(descripcionCaptura))
        {
            Base.AgregarActividad(_usuario, horasTrabajo, descripcionCaptura, _idProyecto);
            return false;
        }
        else if (!string.IsNullOrEmpty(horasCaptura)
            || !string.IsNullOrEmpty(descripcionCaptura))
        {
            return true;
        }

        return false;
    }

    private void MenuValidarHoras()
    {
        Console.Clear();
        Console.WriteLine("VALIDAR HORAS");

        Usuario seleccion = MenuSeleccionaEmpleado();

        Console.Clear();
        Console.WriteLine("VALIDAR HORAS");
        Console.WriteLine($"Horas trabajadas de usuario:{seleccion.Nombre} \n");

        foreach(var actividad in Base.GetActividades(seleccion))
        {
            if (!actividad.Validacion){
                Console.WriteLine($"Fecha: {actividad.FechaAlta};\tTiempo: {actividad.Horas} horas;\tDescripcion: {actividad.Descripcion}");
            }
        }

        Console.WriteLine("Validar horas de empleado (s/n)?");
        var opcion = Console.ReadLine();

        if (!string.IsNullOrEmpty(opcion)) {
            if (opcion.Equals("s"))
            {
                Base.ValidarActividades(seleccion);
            } else if (opcion.Equals("n"))
            {
                Base.BorrarActividades(seleccion);
            }
        }
    }

    private Boolean MenuAltaEmpleado()
    {
        Console.Clear();
        Console.WriteLine("ALTA EMPLEADO");
        Console.WriteLine("Nombre de empleado:");
        var nombreCaptura = Console.ReadLine();
        Console.WriteLine("Fecha de ingreso (MM/DD/AAAA):");
        var fechaCaptura = Console.ReadLine();
        Console.WriteLine("Contrasenia de empleado:");
        var contraseniaCaptura = Console.ReadLine();

        if (!string.IsNullOrEmpty(nombreCaptura) 
            && !string.IsNullOrEmpty(fechaCaptura) 
            && DateTime.TryParse(fechaCaptura, out DateTime fecha)
            && !string.IsNullOrEmpty(contraseniaCaptura))
        {
            Base.AgregarUsuario(nombreCaptura, fecha, contraseniaCaptura);
            return false;
        }else if (!string.IsNullOrEmpty(nombreCaptura)
            || !string.IsNullOrEmpty(fechaCaptura)
            || DateTime.TryParse(fechaCaptura, out fecha)
            || !string.IsNullOrEmpty(contraseniaCaptura))
        {
            return true;
        }

        return false;
    }

    private void MenuEditarEmpleado()
    {
        Console.Clear();
        Console.WriteLine("MODIFICAR DATOS EMPLEADO");

        Usuario seleccion = MenuSeleccionaEmpleado();

        while (MenuEditarEmpleado2(seleccion));
    }

    private Boolean MenuEditarEmpleado2(Usuario _usuario)
    {
        Console.Clear();
        Console.WriteLine("MODIFICAR DATOS EMPLEADO");
        Console.WriteLine($"Seleccionado usuario id:{_usuario.Id} nombre:{_usuario.Nombre}");
        Console.WriteLine("Nuevo nombre empleado");
        var nombreCaptura = Console.ReadLine();
        Console.WriteLine("Nueva contrasenia:");
        var contraseniaCaptura = Console.ReadLine();

        if (!string.IsNullOrEmpty(nombreCaptura) && !string.IsNullOrEmpty(contraseniaCaptura))
        {
            Base.ModificarUsuario(_usuario, nombreCaptura, contraseniaCaptura);
            return false;
        }
        else if(!string.IsNullOrEmpty(nombreCaptura) || !string.IsNullOrEmpty(contraseniaCaptura))
        {
            return true;
        }

        return false;
    }

    private void MenuBajaEmpleado()
    {
        Console.Clear();
        Console.WriteLine("BAJA EMPLEADO");

        Usuario seleccion = MenuSeleccionaEmpleado();

        Base.BorrarUsuario(seleccion);
    }

    private Usuario MenuSeleccionaEmpleado()
    {
        foreach (Usuario a in Base.GetListaUsuarios(1))
        {
            Console.WriteLine($"{a.Id}\t{a.Nombre}\t{a.FechaIngreso}");
        }

        Console.WriteLine("Ingrese id de empleado:");
        var idCaptura = Console.ReadLine();

        if (!string.IsNullOrEmpty(idCaptura) && int.TryParse(idCaptura, out int numeroId))
        {
            return Base.SeleccionarUsuario(numeroId);
        }

        return null;
    }

    private Proyecto MenuSeleccionaProyecto()
    {
        foreach (Proyecto a in Base.GetListaProyectos())
        {
            Console.WriteLine($"{a.Id}\t{a.Nombre}\t{a.Descripcion}");
        }

        Console.WriteLine("Ingrese id de proyecto:");
        var idCaptura = Console.ReadLine();

        if (!string.IsNullOrEmpty(idCaptura) && int.TryParse(idCaptura, out int numeroId))
        {
            return Base.SeleccionarProyecto(numeroId);
        }

        return null;
    }
}