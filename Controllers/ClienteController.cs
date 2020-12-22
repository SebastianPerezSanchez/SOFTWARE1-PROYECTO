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
    public class ClienteController : Controller
    {

       private readonly ILogger<ClienteController> _logger;
       private readonly InventarioContext _context;


        public ClienteController(ILogger<ClienteController> logger,
            InventarioContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {

            var listProductos=_context.Cliente.OrderBy(y => y.compras).OrderBy(x => x.compras).ToList();
            return View(listProductos);
        }
                
        // GET: Contacto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DNI,Nombre,Apellido,Correo,sexo,distrito,direccion,celular")] Cliente cliente)
        {
            if (id != cliente.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                    
                }
                
                TempData["prueba02"] = "prueba02";

                return RedirectToAction(nameof(Listar));

            }
            return View(cliente);
        }
        

        public IActionResult Delete(int? id)
        {
            var Cliente = _context.Cliente.Find(id);
            _context.Cliente.Remove(Cliente);
            _context.SaveChanges();
            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Enviar(Cliente objFormulario)
        {
              if (ModelState.IsValid)
                {
                _context.Add(objFormulario);
                _context.SaveChanges();
                TempData["prueba"] = "prueba01";
                objFormulario.Respuesta = "Gracias. Formulario enviado";
                return RedirectToAction("Listar");  
                }
            return View("index", objFormulario);
        }
    }
}