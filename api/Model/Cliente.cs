using System.Net.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }
        [Required]
        public string? NombreCompleto { get; set; }
        [Required]
        public string? RNC { get; set; }
        [Required]
        public string? Direccion { get; set; }
        [Required]
        public string? Sector { get; set; }
        [Required]
        public string? Ciudad { get; set; }
        [Required]
        public string? Provincia { get; set; }

        [Required]
        public string? Telefono { get; set; }
        [Required]
        public string? Correo { get; set; }



    }
}