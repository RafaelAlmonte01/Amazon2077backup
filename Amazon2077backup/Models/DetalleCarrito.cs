using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon2077backup.Models
{ 
    [Table("Detalle")]
public class Detalle

{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int DetalleID { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string ProductName { get; set; }
    [Required]
    public string ProductoIMG { get; set; }
    [Required]
    public int ProductoID { get; set; }
    [Required]
    public int CantidadB { get; set; }
    [Required]
    public decimal PreUNI { get; set; }

    public decimal Subtotal { get { return PreUNI * CantidadB; } }


       }
}