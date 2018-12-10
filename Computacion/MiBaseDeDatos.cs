using Computacion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Computacion
{
    public class MiBaseDeDatos : DbContext
    {
        public MiBaseDeDatos() : base("DefaultConnection")
        {
            Database.SetInitializer<MiBaseDeDatos>(new DropCreateDatabaseIfModelChanges<MiBaseDeDatos>());
        }

        public DbSet<Articulo> Articulos { get; set; }

    }
}