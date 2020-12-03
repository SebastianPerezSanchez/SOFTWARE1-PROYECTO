using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SOFTWARE1_PROYECTO.Models;
using SOFTWARE1_PROYECTO.Data;

namespace SOFTWARE1_PROYECTO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InventarioContext _context;

        public HomeController(ILogger<HomeController> logger,
            InventarioContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Registrar objRegistrar){
            if(ModelState.IsValid){
                _context.Add(objRegistrar);
                _context.SaveChanges();            
                objRegistrar.Respuesta="Se registro correctamente";
            }
            return View("Index",objRegistrar);
        }
    
    }
}
