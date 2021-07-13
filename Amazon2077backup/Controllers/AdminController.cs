using Amazon2077backup.Data;
using Amazon2077backup.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon2077backup.Controllers
{
    public class AdminController : Controller
    {
       
        private readonly ILogger<AdminController> _logger;
        private readonly ApplicationDbContext _db;
       

        public AdminController(ILogger<AdminController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;

        }

        [Authorize(Roles = "Admin")]

        public IActionResult IndexAdmin()
        {

            return View();
        }

        [Authorize(Roles = "Admin")]


        public IActionResult ListaProductosAdmin()
        {
            var productos = _db.Productos;
            return View(productos);
        }

        [Authorize(Roles = "Admin")]
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

                return RedirectToAction("ListaProductosAdmin");
            }
            return View(input);
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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



        [Authorize(Roles = "Admin")]
        public IActionResult CrearRole()
        {
            return View();
        }

       
    }
}
