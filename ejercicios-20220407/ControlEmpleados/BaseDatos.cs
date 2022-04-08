using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEmpleados
{
    internal class BaseDatos
    {
        public List<Usuario> UsuariosSistema = new List<Usuario>();

        public BaseDatos()
        {
            UsuariosSistema.Add(new Supervisor("Supervisor", new DateTime(2010, 12, 07), "12345"));
            UsuariosSistema.Add(new Empleado("Empleado1", new DateTime(2020, 04, 08), "12345"));
            UsuariosSistema.Add(new Empleado("Empleado2", new DateTime(2021, 06, 21), "12345"));
            UsuariosSistema.Add(new Empleado("Empleado3", new DateTime(2022, 01, 13), "12345"));
        }

        public Usuario BuscarUsuario(string usuario, string contrasenia)
        {
            foreach (Usuario a in UsuariosSistema)
            {
                if (a.Nombre.Equals(usuario) && a.Contrasenia.Equals(contrasenia))
                {
                    return a;
                }
            }

            return null;
        }

        public List<Actividad> GetActividades(Usuario _usuario)
        {
            var empleado = (Empleado)_usuario;
            return empleado.Actividades;
        }

        public void AgregarActividad(Usuario _usuario, int horasTrabajo, string descripcionCaptura)
        {
            ((Empleado)_usuario).AgregarActividad(horasTrabajo, descripcionCaptura);
        }

        public void ValidarActividades(Usuario _usuario)
        {
            var empleado = (Empleado)_usuario;
            foreach (var actividad in empleado.Actividades)
            {
                actividad.Validacion = true;
            }
        }

        public void BorrarActividades(Usuario _usuario)
        {
            var empleado = (Empleado)_usuario;
            for (int i = 0; i < empleado.Actividades.Count; i++)
            {
                if (!empleado.Actividades.ElementAt(i).Validacion)
                {
                    empleado.Actividades.Remove(empleado.Actividades.ElementAt(i--));
                }
            }
        }

        public void AgregarUsuario(string nombre, DateTime fecha, string contrasenia)
        {
            UsuariosSistema.Add(new Empleado(nombre, fecha, contrasenia));
        }

        public Usuario SeleccionarUsuario(int numeroid)
        {
            for (int i = 0; i < UsuariosSistema.Count; i++)
            {
                if (UsuariosSistema.ElementAt(i).Id.Equals(numeroid))
                {
                    return UsuariosSistema.ElementAt(i);
                }
            }

            return null;
        }

        public void BorrarUsuario(Usuario _usuario)
        {
            if (_usuario != null)
            {
                UsuariosSistema.Remove(_usuario);
            }
        }

        public void ModificarUsuario(Usuario _usuario, string nombre, string contrasenia)
        {

        }

        public List<Usuario> GetListaUsuarios(int tipo)
        {
            List<Usuario> lista = new List<Usuario>();

            foreach (Usuario a in UsuariosSistema)
            {
                if (a.NivelAcceso == tipo)
                {
                    lista.Add(a);
                }
            }

            return lista;
        }
    }
}
