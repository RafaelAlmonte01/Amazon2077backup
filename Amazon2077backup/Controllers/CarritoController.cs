﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon2077backup.Controllers
{
    public class CarritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CarritoProductos()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AgregarAlCarrito(int ProductoId)
        {
            return Json(new { Result = true });
        }
    }
}
