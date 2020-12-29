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

        public async Task<IActionResult> Listar(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewBag.CurrentSort = sortOrder;
                var productos = from s in _context.Productos
                    select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    productos = productos.Where(s => s.product.Contains(searchString)
                                || s.color.Contains(searchString)  || s.tallas.Contains(searchString) || s.modelo.Contains(searchString)
                                || s.sexo.Contains(searchString) || s.cantidad.ToString().Contains(searchString));
                }

                if (searchString != null)
                {
                    pageNumber  = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;
                   

                int pageSize = 10;
                    return View(await PaginatedList<Producto>.CreateAsync(productos.AsNoTracking(), pageNumber ?? 1, pageSize));

       
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
                
                TempData["prueba02"] = "prueba02";

                return RedirectToAction(nameof(Listar));

            }
            return View(producto);
        }
        

        public IActionResult Delete(int? id)
        {
            var producto = _context.Productos.Find(id);
            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Enviar(Producto objFormulario)
        {
              if (ModelState.IsValid)
                {
                _context.Add(objFormulario);
                _context.SaveChanges();
                TempData["prueba"] = "prueba01";
                objFormulario.Response = "Gracias. Formulario enviado";
                return RedirectToAction("Listar");  
                }
            return View("index", objFormulario);
        }

        public async Task<IActionResult> EntradaProducto(int? id)
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

        public async Task<IActionResult> SalidaProducto(int? id)
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
        public async Task<IActionResult> EntradaProducto(int id, [Bind("ID,product,color,tallas,sexo,cantidad,modelo")] Producto producto)
        {
            if (id != producto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var listarProductos = _context.Productos.Where(x => x.ID == id).Select(y => y.cantidad).ToList();
                    int listarP = int.Parse(listarProductos.First().ToString());

                    
                    producto.cantidad = producto.cantidad + listarP;
                    _context.Productos.Attach(producto);
                    _context.Entry(producto).Property(x => x.cantidad).IsModified = true;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SalidaProducto(int id, [Bind("ID,product,color,tallas,sexo,cantidad,modelo")] Producto producto)
        {
            if (id != producto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var listarProductos = _context.Productos.Where(x => x.ID == id).Select(y => y.cantidad).ToList();
                    int listarP = int.Parse(listarProductos.First().ToString());

                    
                    producto.cantidad = listarP - producto.cantidad;
                    _context.Productos.Attach(producto);
                    _context.Entry(producto).Property(x => x.cantidad).IsModified = true;
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

    }
}