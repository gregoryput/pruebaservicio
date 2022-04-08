using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Servicios
    {
        [Key]
        public int ServicioID { get; set; }
        public string? NombreServicio { get; set; }

        [Required]
        public int CategoriaID { get; set; }
        
        
        
        
        
    }
}