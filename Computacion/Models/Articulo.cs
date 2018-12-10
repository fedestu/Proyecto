using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Computacion.Models
{

    [Table("Articulos")]
    public class Articulo
    {
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name ="Precio de Compra")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public decimal PrecioCompra { get; set; }

        [Required]
        [Display(Name = "Precio de Venta")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public decimal PrecioVenta { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        [Display(Name ="Categoría")]
        public int IdCategoria { get; set; }

        [Required]
        [Display(Name = "Sub Categoría")]
        public int IdSubCategoria { get; set; }

        public string FechaBaja { get; set; }

        MiBaseDatos miConn = new MiBaseDatos();

        public virtual string DescripcionCategoria
        {
            get
            {
                var ret = miConn.Categorias.Where(x => x.Id == IdCategoria).Select(x => x.Descripcion).FirstOrDefault();
                return ret;
            }
        }

        public virtual string DescripcionSubCategoria
        {
            get
            {
                var ret = miConn.SubCategorias.Where(x => x.Id == IdSubCategoria).Select(x => x.Descripcion).FirstOrDefault();
                return ret;
            }
        }
    }
}