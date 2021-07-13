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

        //Metodo para Lista Productos(opciones del buscador, y categoria de producto)
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

            else if (input.Categoria == null)
            {

                productos = _db.Productos;

            }
            else 

            {

                productos = _db.Productos.Where(a => a.Tipo == input.Categoria.Value);

            }




            return View(productos);
        }

        //Metodo para detalle de producto
        public IActionResult DetalleProducto(int id)
        {
            var output = _db.Productos.Find(id);
            return View(output);
        }

        public IActionResult Pago()
        {
          
            return View();
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
