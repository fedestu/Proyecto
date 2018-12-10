using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Computacion.Models
{
    [Table("VentaDetalle")]
    public class VentaDetalle
    {
        MiBaseDatos miConn = new MiBaseDatos();

        public int Id { get; set; }

        public int IdArticulo { get; set; }

        public decimal PrecioUnitario { get { return miConn.Articulos.Where(a => a.Id == IdArticulo).Select(p => p.PrecioVenta).FirstOrDefault(); } }

        public int Cantidad { get; set; }

        public int IdVentas { get; set; }

        public string DescripcionArticulo
        {
            get
            {
                var descrip = miConn.Articulos.Where(a => a.Id == IdArticulo).Select(p => p.Descripcion).FirstOrDefault();
                return descrip;

            }
        }

        public decimal Total { get { return PrecioUnitario * Cantidad; } }
    }
}