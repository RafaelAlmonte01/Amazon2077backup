using Amazon2077backup.Data;
using Amazon2077backup.Models;
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
           
            return Json(new { Result = true });
        }
    }
}
