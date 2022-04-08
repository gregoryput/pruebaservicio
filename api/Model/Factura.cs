using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Factura
    {
        [Key]
        public int FacturaID { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public int ClienteID { get; set; }
    }
}