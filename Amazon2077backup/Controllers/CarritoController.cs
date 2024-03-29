﻿using Amazon2077backup.Data;
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
            var carrito = _db.Carrito.Find(id);
            return View(carrito);
        }

        [HttpPost]
        public IActionResult EliminarProducto(Carrito input)
        {
            _db.Entry(input).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction("Carrito");
        }

        [Authorize]
        public IActionResult CarritoProductos()
        {
            var carritos = _db.Carrito;
            return View(carritos);
        }



        //Metodo Agregar al carrito

        [Authorize]
        public IActionResult AgregarAlCarrito()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AgregarAlCarrito(Carrito input)
        {
            
                var producto = _db.Productos.Find(input.ProductoID);
                var productoCarrito = _db.Carrito.FirstOrDefault(a => a.UserName == User.Identity.Name && a.ProductoID == input.ProductoID);

            if (productoCarrito == null)
            {
                input.ProductName = producto.Nombre;
                input.PreUNI = producto.Precio;
                input.UserName = User.Identity.Name;
                input.Cantidad = 1;

                _db.Carrito.Add(input);


            }
            else 
            {


                productoCarrito.Cantidad += 1;
                _db.Entry(productoCarrito).State = Microsoft.EntityFrameworkCore.EntityState.Modified;



            }
                
                _db.SaveChanges();

                return Json(new { Result = true });
        }
         
    }
}
