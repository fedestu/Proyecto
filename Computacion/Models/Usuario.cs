using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Computacion.Models;


namespace Computacion.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }

        
        public string Apellido { get; set; }

        
        [Display(Name ="DNI")]
        public int Dni { get; set; }

        
        public string Provincia { get; set; }

        
        public string Localidad { get; set; }

        
        [Display(Name ="Dirección")]
        public string Direccion { get; set; }

        
        public DateTime FechaNacimiento { get; set; }

        
        public string Sexo { get; set; }

        public string Email { get; set; }

        [Display(Name = "Código Postal")]
        public int CodigoPostal { get; set; }

        public int Rol { get; set; }

        public string IdAccount { get; set; }

        public string NombreApellidoPersona { get { return Apellido + ", " + Nombre; } }
    }
}