// See https://aka.ms/new-console-template for more information
using ControlEmpleados;
Sistema prueba = new Sistema();
prueba.ejecutar();

class Sistema
{
    List<Usuario> usuariosSistema = new List<Usuario>();
    public Sistema()
    {
        usuariosSistema.Add(new Supervisor("Supervisor", new DateTime(2010, 12, 07), "12345"));
        usuariosSistema.Add(new Empleado("Empleado1", new DateTime(2020, 04, 08), "12345"));
        usuariosSistema.Add(new Empleado("Empleado2", new DateTime(2021, 06, 21), "12345"));
        usuariosSistema.Add(new Empleado("Empleado3", new DateTime(2022, 01, 13), "12345"));
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
                    while(opcionesEmpleado(user));
                }
                else if (user.nivelAcceso == 2)
                {
                    while(opcionesSupervisor(user));
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

    private Boolean opcionesEmpleado(Usuario _usuario)
    {
        Console.Clear();
        _usuario.validarSaludoAniversario();
        Console.WriteLine("Ingrese opcion");
        Console.WriteLine("1. Registrar horas.");
        Console.WriteLine("2. Salir.");
        var captura = Console.ReadLine();
        int opcionmenu;

        if (!string.IsNullOrEmpty(captura) && int.TryParse(captura, out opcionmenu))
        {
            switch (opcionmenu)
            {
                case 1: while (registroHoras(_usuario)); return true;
                case 2: return false;
                default: return true;
            }
        }
        else
        {
            return true;
        }
    }

    private Boolean opcionesSupervisor(Usuario _usuario)
    {
        Console.Clear();
        _usuario.validarSaludoAniversario();
        Console.WriteLine("Ingrese opcion");
        Console.WriteLine("1. Validar horas.");
        Console.WriteLine("2. Alta empleado.");
        Console.WriteLine("3. Editar empleado.");
        Console.WriteLine("4. Baja empleado.");
        Console.WriteLine("5. Salir.");
        var captura = Console.ReadLine();
        int opcionmenu;

        if (!string.IsNullOrEmpty(captura) && int.TryParse(captura, out opcionmenu))
        {
            switch (opcionmenu)
            {
                case 1: validarHoras(); return true;
                case 2: while (altaEmpleado()); return true;
                case 3: editarEmpleado1();  return true;
                case 4: bajaEmpleado();  return true;
                case 5: return false;
                default: return true;
            }
        }
        else
        {
            return true;
        }
    }

    private Boolean registroHoras(Usuario _usuario)
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
            //var result = from r in usuariosSistema where r.id == _usuario.id select r;
            //((Empleado)result.First()).agregarActividad(horasTrabajo, descripcionCaptura);
            ((Empleado)_usuario).agregarActividad(horasTrabajo, descripcionCaptura);
            return false;
        }
        else if (!string.IsNullOrEmpty(horasCaptura)
            || !string.IsNullOrEmpty(descripcionCaptura))
        {
            return true;
        }

        return false;
    }

    private void validarHoras()
    {
        Console.Clear();
        Console.WriteLine("VALIDAR HORAS");

        Usuario seleccion = seleccionaEmpleado();

        Console.Clear();
        Console.WriteLine("VALIDAR HORAS");
        Console.WriteLine($"Horas trabajadas de usuario:{seleccion.nombre} \n");
        var _empleado = (Empleado)seleccion;

        foreach(var actividad in _empleado.actividades)
        {
            if (!actividad.validacion){
                Console.WriteLine($"Fecha: {actividad.fechaAlta};\tTiempo: {actividad.horas} horas;\tDescripcion: {actividad.descripcion}");
            }
        }

        Console.WriteLine("Validar horas de empleado (s/n)?");
        var opcion = Console.ReadLine();

        if (!string.IsNullOrEmpty(opcion)) {
            if (opcion.Equals("s"))
            {
                foreach (var actividad in _empleado.actividades)
                {
                    actividad.validacion = true;
                }
            } else if (opcion.Equals("n"))
            {
                for (int i =0; i < _empleado.actividades.Count; i++)
                {
                    if (!_empleado.actividades.ElementAt(i).validacion)
                    {
                        _empleado.actividades.Remove(_empleado.actividades.ElementAt(i--));
                    }
                }
            }
        }
    }

    private Boolean altaEmpleado()
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
            usuariosSistema.Add(new Empleado(nombreCaptura, fecha, contraseniaCaptura));
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

    private void editarEmpleado1()
    {
        Console.Clear();
        Console.WriteLine("MODIFICAR DATOS EMPLEADO");

        Usuario seleccion = seleccionaEmpleado();

        while (editarEmpleado2(seleccion));
    }

    private Boolean editarEmpleado2(Usuario _usuario)
    {
        Console.Clear();
        Console.WriteLine("MODIFICAR DATOS EMPLEADO");
        Console.WriteLine($"Seleccionado usuario id:{_usuario.id} nombre:{_usuario.nombre}");
        Console.WriteLine("Nuevo nombre empleado");
        var nombreCaptura = Console.ReadLine();
        Console.WriteLine("Nueva contrasenia:");
        var contraseniaCaptura = Console.ReadLine();

        if (!string.IsNullOrEmpty(nombreCaptura) && !string.IsNullOrEmpty(contraseniaCaptura))
        {
            //var result = from r in usuariosSistema where r.id == _usuario.id select r;
            //result.First().nombre = nombreCaptura;
            //result.First().contrasenia = contraseniaCaptura;
            _usuario.nombre = nombreCaptura;
            _usuario.contrasenia = contraseniaCaptura;
            return false;
        }
        else if(!string.IsNullOrEmpty(nombreCaptura) || !string.IsNullOrEmpty(contraseniaCaptura))
        {
            return true;
        }

        return false;
    }

    private void bajaEmpleado()
    {
        Console.Clear();
        Console.WriteLine("BAJA EMPLEADO");

        Usuario seleccion = seleccionaEmpleado();

        if (seleccion != null)
        {
            usuariosSistema.Remove(seleccion);
        }
    }

    private Usuario seleccionaEmpleado()
    {
        foreach (Usuario a in usuariosSistema)
        {
            if (a.nivelAcceso == 1)
            {
                Console.WriteLine($"{a.id}\t{a.nombre}\t{a.fechaIngreso}");
            }
        }

        Console.WriteLine("Ingrese id de empleado:");
        var idCaptura = Console.ReadLine();
        int numeroid;

        if (!string.IsNullOrEmpty(idCaptura) && int.TryParse(idCaptura, out numeroid))
        {
            for (int i = 0; i < usuariosSistema.Count; i++)
            {
                if (usuariosSistema.ElementAt(i).id.Equals(numeroid))
                {
                    return usuariosSistema.ElementAt(i);
                }
            }
        }
        
        return null;
    }
}