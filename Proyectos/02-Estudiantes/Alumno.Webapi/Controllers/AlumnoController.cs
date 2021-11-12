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
                Sexo = 'M',
                Activo = true
            },
            new Models.Alumnos()
            {
                IdEstudiante = 2,
                Nombre = "Mariana",
                ApellidoPaterno = "Cuevas",
                ApellidoMaterno = "Cuevas",
                Sexo = 'F',
                Activo = true
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
            List <Models.Alumnos> listAlumnosActivos = new List<Models.Alumnos>();

            List<Models.Alumnos> list = listAlumnos;

            foreach(var alumno in list)
            {
                if (alumno.Activo == true)
                {
                    listAlumnosActivos.Add(alumno);
                }
            }
            return listAlumnosActivos;
        
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
    
        [HttpDelete("{IdEstudiante}")]
        public async Task<ActionResult<Models.Alumnos>> Eliminar(int IdEstudiante)
        {
            Models.Alumnos alumnoEliminar = null;

            List<Models.Alumnos> list = listAlumnos; 
            
            foreach (var alumno in list)
            {
                if(alumno.IdEstudiante == IdEstudiante)
                {
                    alumnoEliminar = alumno;
                    break;
                }

            }

            if (alumnoEliminar == null)
            {
                return NotFound();
            }
            
            if (alumnoEliminar != null)
            {
                alumnoEliminar.Activo = false;      
            }
            
            return alumnoEliminar;

        }
    
    
    }
}