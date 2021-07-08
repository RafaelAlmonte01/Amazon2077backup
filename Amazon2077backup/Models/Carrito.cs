using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon2077backup.Models
{
    [Table("Carrito")]
    public class Carrito

    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CartID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int PID { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public int PreUNI { get; set; }

    }
}