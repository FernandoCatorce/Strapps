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

        [HttpPut]
        public async Task<ActionResult<Models.Alumnos>> Actualizar(Models.Alumnos alumno)
        {
            Models.Alumnos alumnoModificar = null;
            List<Models.Alumnos> listAl = listAlumnos;
            foreach (Models.Alumnos IdEstudiante in listAlumnos)
            {
                if(IdEstudiante.IdEstudiante == alumno.IdEstudiante)
                {
                    alumnoModificar = IdEstudiante;
                    break;
                }
            }
                if (alumnoModificar == null )
                {
                    return NotFound();
                }
                else 
                {
                    alumnoModificar.Nombre = alumno.Nombre;
                    alumnoModificar.ApellidoPaterno = alumno.ApellidoPaterno;
                    alumnoModificar.ApellidoMaterno = alumno.ApellidoMaterno;
                }
            return alumnoModificar;
        } 
    [HttpGet("{IdEstudiante}")]
    public async Task<ActionResult<Models.Alumnos>> obtenerID(int IdEstudiante)
    {
        Models.Alumnos alumnoEcontrado = null;
        List<Models.Alumnos> lista = listAlumnos;

        foreach (Models.Alumnos iEstudiante in lista )
        {
            if (iEstudiante.IdEstudiante == IdEstudiante)
            {
                alumnoEcontrado = iEstudiante;
            }
        }
    
        if(alumnoEcontrado == null)
        {
            return NotFound();
        }
    
            else 
            {
                return alumnoEcontrado;
            }
    }
    }
}