using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEmpleados
{
    internal class Usuario
    {
        protected static int conteoId = 0;
        public int id { get; set; }
        public string nombre { get; set; }
        public DateTime fechaIngreso { get; set; }
        public string contrasenia { get; set; }
        public int nivelAcceso { get; set; }

        public Usuario(string _nombre, DateTime _fechaIngreso, string _contrasenia)
        {
            nombre = _nombre;
            fechaIngreso = _fechaIngreso;
            contrasenia = _contrasenia;
        }

        public void validarSaludoAniversario()
        {
            TimeSpan time = DateTime.Now.Subtract(fechaIngreso);
            if((time.TotalDays % 365 < 1))
            {
                Console.WriteLine($"Felicidades! Hoy es tu {(int)time.TotalDays/365} aniversario en la empresa.");
            }
        }
    }
}
