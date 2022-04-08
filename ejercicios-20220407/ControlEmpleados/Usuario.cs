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
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Contrasenia { get; set; }
        public int NivelAcceso { get; set; }

        public Usuario(string _nombre, DateTime _fechaIngreso, string _contrasenia)
        {
            Nombre = _nombre;
            FechaIngreso = _fechaIngreso;
            Contrasenia = _contrasenia;
        }

        public string validarSaludoAniversario()
        {
            TimeSpan time = DateTime.Now.Subtract(FechaIngreso);

            StringBuilder sb = new StringBuilder();

            sb.Append($"Bienvenido {Nombre} ");

            if((time.TotalDays % 365 < 1))
            {
                sb.Append($"Felicidades! Hoy es tu {(int)time.TotalDays/365} aniversario en la empresa.");
            }

            return sb.ToString();
        }
    }
}
