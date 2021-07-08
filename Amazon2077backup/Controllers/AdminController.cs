using Amazon2077backup.Data;
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
        public IActionResult CrearRole()
        {
            return View();
        }

       
    }
}
