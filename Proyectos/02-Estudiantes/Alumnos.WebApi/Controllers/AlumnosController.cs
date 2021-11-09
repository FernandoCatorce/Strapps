using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models = Alumnos.WebAPI.Models;

namespace Alumnos.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlumnosController : ControllerBase
    {
        public static List<Models.Alumnos> listAlumno = new List<Models.Alumnos>()
        {
            new Models.Alumno()
            {
                idAlumno = 1,
                Nombre = "Saúl",
                ApellidoPaterno = "Carretero",
                ApellidoMaterno = "Carretero",
                Sexo = 'M'
            },
            new Models.Alumnos()
            {
                idAlumno = 2,
                Nombre = "Mariana",
                ApellidoPaterno = "Cuevas",
                ApellidoMaterno = "Cuevas",
                Sexo = 'F'
            }
        };
        private readonly ILogger<AlumnosController> _logger;

        public AlumnosController(ILogger<AlumnosController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public List<Models.Alumno> Obtener()
        {
            return listAlumno;
        }
        [HttpPost]
        public Models.Alumnos Crear(Models.Alumno alumno)
        {
            // Obtener el ultimo alumno de la lista 
            Models.Alumnos ultimoAlumno = listalumno.Last();
            // Le asignamos el ultimo id
            alumno.idAlumno = ultimoAlumno.idAlumno + 1;
            // Al nuevo Alumno lo agregamos a la lista
            listAlumno.Add(alumno);
            // Retornamos al alumno agregado
            return alumno;
        }
    }
}