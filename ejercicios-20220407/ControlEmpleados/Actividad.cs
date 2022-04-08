using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEmpleados
{
    internal class Actividad
    {
        public int horas { get; set; }
        public string descripcion { get; set; }

        public Actividad(int _horas, string _descripcion)
        {
            horas = _horas;
            descripcion = _descripcion;
        }
    }
}
