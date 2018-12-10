using Computacion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Computacion
{
    public class MiBaseDatos : DbContext
    {

        public MiBaseDatos() : base("DefaultConnection")
        //public MiBaseDatos() : base("MiPc")
        {
            
            Database.SetInitializer<MiBaseDatos>(new DropCreateDatabaseIfModelChanges<MiBaseDatos>());

        }

        //Le indico a entity Framework que La Clase/Modelo Persona quiero que sea una tabla en la base de datos

        public DbSet<Articulo> Articulos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<SubCategoria> SubCategorias { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Compra> Compras { get; set; }

        public DbSet<Venta> VentasMaster { get; set; }

        public DbSet<VentaDetalle> VentasDetalle { get; set; }
    }
}