using Amazon2077backup.Data;
using Amazon2077backup.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon2077backup.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaProductos(ProductosENListaProductosViewModel input)
        {
            IEnumerable<ProductosEN> productos = _db.Productos;

           if (input.TipoProducto == null)
            {
                productos = _db.Productos;
            }
            else
            {
                productos = _db.Productos.Where(a => a.Tipo == input.TipoProducto.Value);
            }
            if (!string.IsNullOrEmpty(input.Nombre))
            {

                productos = productos.Where(a => a.Nombre.ToUpper().Contains(input.Nombre.ToUpper()));
            
            
            }           
            return View(productos);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ListaProductosAdmin()
        {
            var productos = _db.Productos;
            return View(productos);
        }
        

        public IActionResult DetalleProducto()
        {
            var productos = _db.Productos;
            return View(productos);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(ProductosEN input)
        {
            if (ModelState.IsValid)
            {
                _db.Productos.Add(input);
                _db.SaveChanges();

                return RedirectToAction("ListaProductos");
            }
            return View(input);
        }

        public IActionResult Modificar(int id)
        {
            var output = _db.Productos.Find(id);
            return View(output);
        }

        [HttpPost]
        public IActionResult Modificar(ProductosEN input)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(input).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("ListaProductosAdmin");

            }
            return View(input);
        }

        public IActionResult Eliminar(int id)
        {
            var output = _db.Productos.Find(id);
            return View(output);
        }

        [HttpPost]
        public IActionResult Eliminar(ProductosEN input)
        {
            _db.Entry(input).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction("ListaProductosAdmin");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
