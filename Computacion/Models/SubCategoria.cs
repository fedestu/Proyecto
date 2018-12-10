using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Computacion.Models
{
    [Table("SubCategorias")]
    public class SubCategoria
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name ="Categoría")]
        public int IdCategoria { get; set; }

        MiBaseDatos miConn = new MiBaseDatos();
        public virtual string DescripcionCategoria
        {
            get
            {
                var ret = miConn.Categorias.Where(x => x.Id == IdCategoria).Select(x => x.Descripcion).FirstOrDefault();
                return ret;
            }
        }

    }
}