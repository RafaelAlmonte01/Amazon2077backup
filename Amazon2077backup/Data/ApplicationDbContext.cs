﻿using Amazon2077backup.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon2077backup.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Aqui declaro las tablas que voy a utilizar en mi base de datos

        public DbSet<ProductosEN> Productos { get; set; }

        public DbSet<Carrito> Carrito { get; set; }

        



    }


}