using System;

namespace Alumno.WebAPI.Models
{
    public class Alumnos:Persona
    {
        public int IdEstudiante { get; set; }
        public string RFC { get; set; }
        public string Carrera { get; set; }
        public DateTime FechadeIngreso { get; set; }
        public int NSS { get; set; }
        public string Horario { get; set; }
        public int TotalFaltas { get; set; }
        public bool Activo {get; set;}
    }
} 
