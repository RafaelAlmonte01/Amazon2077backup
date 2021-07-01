using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon2077backup.Models
{
    public class ProductosENListaProductosViewModel 
    {
        public TipoProducto? TipoProducto { get; set; }

        public string Nombre { get; set; }
    }
}
