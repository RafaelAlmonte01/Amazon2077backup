using Amazon2077backup.Data;
using Amazon2077backup.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon2077backup.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ILogger<CarritoController> _logger;
        private readonly ApplicationDbContext _db;


        public CarritoController(ILogger<CarritoController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EliminarProducto(int id)
        {
            var output = _db.Carrito.Find(id);
            return View(output);
        }

        [HttpPost]
        public IActionResult EliminarProducto(Carrito input)

        {
            _db.Entry(input).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction("CarritoProductos");
        }

        public IActionResult CarritoProductos()
        {
            var carritos = _db.Carrito;
            return View(carritos);
        }


        

        public IActionResult AgregarAlCarrito()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AgregarAlCarrito(Carrito input)
        {
                
                var producto = _db.Productos.Find(input.ProductoID);  
                input.ProductName = producto.Nombre;
                input.PreUNI = producto.Precio;
                input.UserName = User.Identity.Name;
                input.Cantidad = 1;

                _db.Carrito.Add(input);
                _db.SaveChanges();

                return Json(new { Result = true });
        }
         
    }
}
