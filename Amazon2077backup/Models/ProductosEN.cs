using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon2077backup.Models
{
    [Table("Productos")]
    public class ProductosEN
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Imagen { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public TipoProducto Tipo { get; set; }
    }
}
