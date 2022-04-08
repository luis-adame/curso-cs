using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEmpleados
{
    internal class Empleado : Usuario
    {
        public List<Actividad> actividades = new List<Actividad>();

        public Empleado(string _nombre, DateTime _fechaIngreso, string _contrasenia) : base(_nombre, _fechaIngreso, _contrasenia) 
        {
            id = conteoId++;
            nivelAcceso = 1;
        }

        public void agregarActividad(int _horas, string _descripcion)
        {
            Actividad nueva = new Actividad(_horas, _descripcion);
            actividades.Add(nueva);
        }
    }
}
