using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEmpleados
{
    internal class Actividad
    {
        public int Horas { get; set; }
        public string Descripcion { get; set; }

        public DateTime FechaAlta;
        public Boolean Validacion { get; set; }

        public Actividad(int _horas, string _descripcion)
        {
            Horas = _horas;
            Descripcion = _descripcion;
            Validacion = false;

            FechaAlta = DateTime.Now;
        }
    }
}
