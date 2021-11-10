using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models = Alumno.WebAPI.Models;

namespace Alumno.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlumnosController : ControllerBase
    {
        public static List<Models.Alumnos> listAlumnos = new List<Models.Alumnos>()
        {
            new Models.Alumnos()
            {
                IdEstudiante = 1,
                Nombre = "Saul",
                ApellidoPaterno = "Carretero",
                ApellidoMaterno = "Carretero",
                Sexo = 'M'
            },
            new Models.Alumnos()
            {
                IdEstudiante = 2,
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
        public List<Models.Alumnos> Obtener()
        {
            return listAlumnos;
        }
        [HttpPost]
        public Models.Alumnos Crear(Models.Alumnos alumno)
        {
           
            Models.Alumnos ultimoAlumno = listAlumnos.Last();
           
            alumno.IdEstudiante = ultimoAlumno.IdEstudiante + 1;
           
            listAlumnos.Add(alumno);
           
            return alumno;
        }
    }
}