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

         public IActionResult Login()
        {
            return View();
        }
        public IActionResult Listar()
        {
            var listUsu=_context.Registrar.ToList();
            return View(listUsu);
        }
         public IActionResult Delete(int? id)
        {
            var usuario = _context.Registrar.Find(id);
            _context.Registrar.Remove(usuario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Listar));
        }


          public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Registrar.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DNI,Nombre,Apellido,Correo,Cargo,Contraseña")] Registrar usuario)
        {
            if (id != usuario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                    
                }
                return RedirectToAction(nameof(Listar));
            }
            return View(usuario);
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
            return View("Login",objRegistrar);
        }
    
    }
}
