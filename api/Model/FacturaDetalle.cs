using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class FacturaDetalle
    {
        [Key]
        public int DetalleID { get; set; }
        [Required]
        public int  FacturaID { get; set; }
        [Required]
        public int Servicio { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        
        
        
        
    }
}