using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEmpleados
{
    internal class Empleado : Usuario
    {
        public List<Actividad> Actividades = new List<Actividad>();

        public Empleado(string _nombre, DateTime _fechaIngreso, string _contrasenia) : base(_nombre, _fechaIngreso, _contrasenia) 
        {
            Id = controlId++;
            NivelAcceso = 1;
        }

        public void AgregarActividad(int _horas, string _descripcion)
        {
            Actividad nueva = new Actividad(_horas, _descripcion);
            Actividades.Add(nueva);
        }
    }
}
