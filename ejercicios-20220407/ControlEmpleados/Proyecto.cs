using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEmpleados
{
    internal class Proyecto
    {
        public static int controlId = 0;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Proyecto(string _nombre, string _descripcion)
        {
            Nombre = _nombre;
            Descripcion = _descripcion;
            Id = controlId++;
        }
    }
}
