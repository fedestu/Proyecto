namespace Computacion.Migrations
{
    using Computacion.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Computacion.MiBaseDatos>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Computacion.MiBaseDatos";
        }

        protected override void Seed(Computacion.MiBaseDatos context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //Agregar Categorías
            var categoria1 = new Categoria { Descripcion = "Componentes de PC" };
            var categoria2 = new Categoria { Descripcion = "Periféricos y Accesorios" };
            var categoria3 = new Categoria { Descripcion = "Impresoras e Insumos" };

            context.Categorias.AddOrUpdate(pr => pr.Descripcion, categoria1, categoria2, categoria3);


            //Agregar Sub Categorías
            var subCategoria1 = new SubCategoria { Descripcion = "SSD", IdCategoria = 1 };
            var subCategoria2 = new SubCategoria { Descripcion = "Procesadores", IdCategoria = 1 };
            var subCategoria5 = new SubCategoria { Descripcion = "Memorias Ram", IdCategoria = 1 };
            var subCategoria3 = new SubCategoria { Descripcion = "Mouse", IdCategoria = 2 };
            var subCategoria4 = new SubCategoria { Descripcion = "Teclado", IdCategoria = 2 };
            var subCategoria6 = new SubCategoria { Descripcion = "Motherboard", IdCategoria = 1 };
            var subCategoria7 = new SubCategoria { Descripcion = "Impresoras", IdCategoria = 3 };
            var subCategoria8 = new SubCategoria { Descripcion = "Cartuchos", IdCategoria = 3 };

            context.SubCategorias.AddOrUpdate(sc => new { sc.Descripcion, sc.IdCategoria },
                subCategoria1, subCategoria2, subCategoria3, subCategoria4, subCategoria5, subCategoria6, subCategoria7, subCategoria8
                );


            //Agregar Artículos
            context.Articulos.AddOrUpdate(p => p.Descripcion,
                new Articulo { Descripcion = "WD 120GB M.2 Green", IdCategoria = 1, IdSubCategoria = 1, PrecioCompra = 1100, PrecioVenta = 1342, Stock = 15 , FechaBaja = null},
                new Articulo { Descripcion = "WD Green 240GB", IdCategoria = 1, IdSubCategoria = 1, PrecioCompra = 1549, PrecioVenta = 1999, Stock = 8, FechaBaja = null },
                new Articulo { Descripcion = "Crucial BX500 120GB", IdCategoria = 1, IdSubCategoria = 1, PrecioCompra = 1240, PrecioVenta = 1440, Stock = 5, FechaBaja = null },
                new Articulo { Descripcion = "Intel Core i3 8100 (1151)", IdCategoria = 1, IdSubCategoria = 2, PrecioCompra = 5000, PrecioVenta = 5956, Stock = 5, FechaBaja = null },
                new Articulo { Descripcion = "AMD Ryzen 5 2600X (AM4)", IdCategoria = 1, IdSubCategoria = 2, PrecioCompra = 12477, PrecioVenta = 14878, Stock = 5, FechaBaja = null },
                new Articulo { Descripcion = "Intel Core i5 8400 (1151)", IdCategoria = 1, IdSubCategoria = 2, PrecioCompra = 8250, PrecioVenta = 9999, Stock = 5, FechaBaja = null },
                new Articulo { Descripcion = "AMD Ryzen 5 2600 (AM4)", IdCategoria = 1, IdSubCategoria = 2, PrecioCompra = 10785, PrecioVenta = 12095, Stock = 5, FechaBaja = null },
                new Articulo { Descripcion = "AMD Ryzen 5 1500X (AM4)", IdCategoria = 1, IdSubCategoria = 2, PrecioCompra = 8350, PrecioVenta = 9331, Stock = 2, FechaBaja = null },
                new Articulo { Descripcion = "Intel Core i7 8700 (1151)", IdCategoria = 1, IdSubCategoria = 2, PrecioCompra = 14978, PrecioVenta = 18323, Stock = 1, FechaBaja = null },
                new Articulo { Descripcion = "AMD Ryzen 7 1700X (AM4)", IdCategoria = 1, IdSubCategoria = 2, PrecioCompra = 16459, PrecioVenta = 18375, Stock = 5, FechaBaja = null },
                new Articulo { Descripcion = "Redragon M711 Cobra FPS", IdCategoria = 2, IdSubCategoria = 3, PrecioCompra = 1000, PrecioVenta = 1274, Stock = 12, FechaBaja = null },
                new Articulo { Descripcion = "Logitech G600 Gaming negro", IdCategoria = 2, IdSubCategoria = 3, PrecioCompra = 1989, PrecioVenta = 2374, Stock = 9, FechaBaja = null },
                new Articulo { Descripcion = "Redragon K556 Devarajas", IdCategoria = 2, IdSubCategoria = 4, PrecioCompra = 2877, PrecioVenta = 3059, Stock = 9, FechaBaja = null },
                new Articulo { Descripcion = "Logitech Gaming Keyboard G213", IdCategoria = 2, IdSubCategoria = 4, PrecioCompra = 2450, PrecioVenta = 2989, Stock = 3, FechaBaja = null },
                new Articulo { Descripcion = "Kingston Fury DDR4-2133 4GB", IdCategoria = 1, IdSubCategoria = 5, PrecioCompra = 1899, PrecioVenta = 2546, Stock = 8, FechaBaja = null },
                new Articulo { Descripcion = "Crucial BaSpLT DDR4 - 2400 8GB", IdCategoria = 1, IdSubCategoria = 5, PrecioCompra = 3750, PrecioVenta = 4199, Stock = 7, FechaBaja = null },
                new Articulo { Descripcion = "(1151) Gigabyte GA-B360M AO G3", IdCategoria = 1, IdSubCategoria = 6, PrecioCompra = 5105, PrecioVenta = 5674, Stock = 4, FechaBaja = null },
                new Articulo { Descripcion = "(1151) Asus B360-H ROG STRIX G", IdCategoria = 1, IdSubCategoria = 6, PrecioCompra = 6204, PrecioVenta = 6699, Stock = 3, FechaBaja = null },
                new Articulo { Descripcion = "C(AM4) Asus B350M-Plus TUF Gaming", IdCategoria = 1, IdSubCategoria = 6, PrecioCompra = 4999, PrecioVenta = 5550, Stock = 5, FechaBaja = null },
                new Articulo { Descripcion = "HP Deskjet Ink Advantage 4729", IdCategoria = 3, IdSubCategoria = 7, PrecioCompra = 5800, PrecioVenta = 6550, Stock = 5, FechaBaja = null },
                new Articulo { Descripcion = "Brother DCP-1617NW Multifunción", IdCategoria = 3, IdSubCategoria = 7, PrecioCompra = 13500, PrecioVenta = 14600, Stock = 4, FechaBaja = null },
                new Articulo { Descripcion = "Brother TN-1060", IdCategoria = 3, IdSubCategoria = 8, PrecioCompra = 1150, PrecioVenta = 1600, Stock = 8, FechaBaja = null },
                new Articulo { Descripcion = "HP 662 Tricolor", IdCategoria = 3, IdSubCategoria = 8, PrecioCompra = 500, PrecioVenta = 591, Stock = 9, FechaBaja = null },
                new Articulo { Descripcion = "HP 662 Negro", IdCategoria = 3, IdSubCategoria = 8, PrecioCompra = 500, PrecioVenta = 594, Stock = 6, FechaBaja = null }
                );


        }
    }
}
