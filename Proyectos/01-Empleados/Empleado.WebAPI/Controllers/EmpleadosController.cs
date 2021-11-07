using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models = Empleado.WebAPI.Models;

namespace Empleado.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
        public static List<Models.Empleado> listEmpleado = new List<Models.Empleado>()
        {
            new Models.Empleado()
            {
                idEmpleado = 1,
                Nombre = "Juanito",
                ApellidoPaterno = "Perez",
                ApellidoMaterno = "Perez",
                Sexo = 'M'
            },
            new Models.Empleado()
            {
                idEmpleado = 2,
                Nombre = "Maria",
                ApellidoPaterno = "Hernandez",
                ApellidoMaterno = "Hernandez",
                Sexo = 'F'
            }
        };
        private readonly ILogger<EmpleadosController> _logger;

        public EmpleadosController(ILogger<EmpleadosController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public List<Models.Empleado> Obtener()
        {
            return listEmpleado;
        }
        [HttpPost]
        public Models.Empleado Crear(Models.Empleado empleado)
        {
            // Obtener el ultimo empleado de la lista 
            Models.Empleado ultimoEmpleado = listEmpleado.Last();
            // Le asignamos el ultimo id
            empleado.idEmpleado = ultimoEmpleado.idEmpleado + 1;
            // Al nuevo empleado lo agregamos a la lista
            listEmpleado.Add(empleado);
            // Retornamos al empleado agregado
            return empleado;
        }
    }
}