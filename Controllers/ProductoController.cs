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
    public class ProductoController : Controller
    {

       private readonly ILogger<ProductoController> _logger;
       private readonly InventarioContext _context;


        public ProductoController(ILogger<ProductoController> logger,
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
            var listProductos=_context.Productos.ToList();
            return View(listProductos);
        }
                
        // GET: Contacto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,product,color,tallas,sexo,cantidad,modelo")] Producto producto)
        {
            if (id != producto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                    
                }
                return RedirectToAction(nameof(Listar));
            }
            return View(producto);
        }
        

        // GET: http://localhost:5000/Contacto/Delete/6 MUESTRA Contacto
        public IActionResult Delete(int? id)
        {
            var producto = _context.Productos.Find(id);
            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Enviar(Producto objFormulario)
        {
                objFormulario.Respuesta = "YA ESTAS REGISTRADO EL PRODUCTO " ;
                _context.Add(objFormulario);
                _context.SaveChanges();
                return View("Index", objFormulario);
        }
    }
}