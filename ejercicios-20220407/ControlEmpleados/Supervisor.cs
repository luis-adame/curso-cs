using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEmpleados
{
    internal class Supervisor : Usuario
    {
        public Supervisor(string _nombre, DateTime _fechaIngreso, string _contrasenia) : base(_nombre, _fechaIngreso, _contrasenia) 
        {
            Id = conteoId++;
            NivelAcceso = 2;
        }

    }
}
