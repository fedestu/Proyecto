using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Computacion.Models
{
    [Table("VentaMaster")]
    public class Venta
    {
        public int Id { get; set; }

        public string Fecha { get; set; }

        public string IdAccount { get; set; }

        MiBaseDatos miConn = new MiBaseDatos();

        public Usuario usuario { get { return miConn.Usuarios.Where(p => p.IdAccount == IdAccount).FirstOrDefault(); } }

        public string NombreApellidoUsuario { get { return usuario.Apellido + ", " + usuario.Nombre; } }

    }
}