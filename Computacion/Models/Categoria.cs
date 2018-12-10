using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Computacion.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        public int Id { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}