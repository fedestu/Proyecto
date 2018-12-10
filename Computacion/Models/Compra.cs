using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Computacion.Models
{
    [Table("Compras")]
    public class Compra
    {
        public int Id { get; set; }

        [Required]
        public int IdArticulo { get; set; }        

        [Required]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public decimal PrecioCompra { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public decimal PrecioVenta { get; set; }

        [Required]
        public int Cantidad { get; set; }
               
        public string Fecha { get; set; }

        MiBaseDatos miConn = new MiBaseDatos();

        public virtual string DescripcionArticulo
        {
            get
            {
                var ret = miConn.Articulos.Where(x => x.Id == IdArticulo).Select(x => x.Descripcion).FirstOrDefault();
                return ret;
            }
        }
    }
}