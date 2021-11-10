using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Alumnos.MVC.Models;

namespace Alumnos.MVC.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly ILogger<AlumnosController> _logger;

        public AlumnosController(ILogger<AlumnosController> logger)
        {
            _logger = logger;
        }

        public IActionResult lista()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View("Alumnado");
        }

         public IActionResult Editar()
        {
            return View("Alumnado");
        }

          public IActionResult Consultar()
        {
            return View("Alumnado");
        }
    }
}
