using System;
namespace Empleado.WebAPI.Models
{
    public class Empleado:Persona
    {
        public int idEmpleado { get; set; }
        public string RFC { get; set; }
        public string Puesto { get; set; }
        public DateTime FechadeIngreso { get; set; }
        public decimal SalarioDiario { get; set; }
        public int NSS { get; set; }
        public string Horario { get; set; }
        public int TotalFaltas { get; set; }
    }
}