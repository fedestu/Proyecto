using Computacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Computacion.Controllers
{
    public class VentaMasterController : Controller
    {

        MiBaseDatos miConn = new MiBaseDatos();

        static List<VentaDetalle> ListDetalleTemporal = new List<VentaDetalle>();

        // GET: VentaMaster        
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            var listaVenta = miConn.VentasMaster.Where(x => x.IdAccount.Contains(user)).ToList();
            return View(listaVenta);
        }

        public ActionResult ListaVentas()
        {
            var listaVenta = miConn.VentasMaster.ToList();
            return View(listaVenta);
        }

        public ActionResult ListaVentasUsuario(string id)
        {
            var listaVenta = miConn.VentasMaster.Where(x => x.IdAccount.Contains(id)).ToList();
            return View(listaVenta);
        }

        public ActionResult ListaVentasUsuarioBack(int id)
        {
            var venta = miConn.VentasDetalle.Where(x => x.IdVentas == id).Select(x => x.IdVentas).FirstOrDefault();
            var account = miConn.VentasMaster.Where(x => x.Id == venta).Select(x => x.IdAccount).FirstOrDefault();
            var listaVenta = miConn.VentasMaster.Where(x => x.IdAccount.Contains(account)).ToList();
            return View(listaVenta);
        }

        public ActionResult Details(int id)
        {
            var lista = miConn.VentasDetalle.Where(x => x.IdVentas == id).ToList();
            decimal total = lista.Sum(x => x.Total);
            ViewBag.Total = total;
            
            return View(lista);
        }

        [HttpGet]        
        public ActionResult Ventas()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Ventas(Venta ventas)
        {
            try
            {
                var usuario = User.Identity.GetUserName();
                if (usuario == null || usuario == "")
                {
                    return RedirectToAction("Register", "Account");
                }

                foreach (var item in ListDetalleTemporal)
                {
                    var articulo = miConn.Articulos.Where(a => a.Id == item.IdArticulo).FirstOrDefault();
                    if (articulo.Stock - item.Cantidad < 0)
                    {
                        ViewBag.MensajeError = "El Articulo " + item.DescripcionArticulo + "  Sobrepasa el stock en " + (item.Cantidad - articulo.Stock);
                        return View();
                    }
                }

                //var algo = miConn.Usuarios.Where(x => x.IdAccount == User.Identity.GetUserId()).FirstOrDefault();

                ventas.Fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
                ventas.IdAccount = User.Identity.GetUserId();
                //DateTime otraFecha = DateTime.ParseExact(fecha, "dd/MM/yyyy a las HH:mm tt", null);                           
                miConn.VentasMaster.Add(ventas);
                miConn.SaveChanges();
               
                

                foreach (var item in ListDetalleTemporal)
                {
                    item.IdVentas = ventas.Id;

                    miConn.VentasDetalle.Add(item);

                    //Descontar stock
                    var articulo = miConn.Articulos.Where(a => a.Id == item.IdArticulo).FirstOrDefault();
                    articulo.Stock = articulo.Stock - item.Cantidad;
                    miConn.Entry(articulo).State = System.Data.Entity.EntityState.Modified;
                }
                miConn.SaveChanges();
                ListDetalleTemporal.Clear();
            }
            catch (Exception e)
            {
                return View(e);
            }
            
            return RedirectToAction("Index");
            //return RedirectToAction("Reporte", new { idventa = ventas.Id });
        }

        
        public ActionResult VentaDetalle()
        {
            decimal total = ListDetalleTemporal.Sum(x => x.Total);
            ViewBag.Total = total;

            return View(ListDetalleTemporal);
        }

        //public ActionResult VentaDetalle(Venta ventas)
        //{
        //    try
        //    {
        //        foreach (var item in ListDetalleTemporal)
        //        {
        //            var articulo = miConn.Articulos.Where(a => a.Id == item.IdArticulo).FirstOrDefault();
        //            if (articulo.Stock - item.Cantidad < 0)
        //            {
        //                ViewBag.MensajeError = "El Articulo " + item.DescripcionArticulo + "  Sobrepasa el stock en " + (item.Cantidad - articulo.Stock);
        //                return View();
        //            }
        //        }

        //        var algo = miConn.Usuarios.Where(x => x.IdAccount == User.Identity.GetUserId()).FirstOrDefault();
        //        if (algo == null)
        //        {
        //            //No se encontraron datos del usuario
        //            return RedirectToAction("Create", "UsuarioController");
        //        }
        //        else
        //        {
        //            ventas.IdUsuario = algo.Id;
        //            ventas.Fecha = DateTime.Now.Date;
        //            miConn.VentasMaster.Add(ventas);
        //            miConn.SaveChanges();
        //        }


        //        foreach (var item in ListDetalleTemporal)
        //        {
        //            item.IdVentas = ventas.Id;

        //            miConn.VentasDetalle.Add(item);

        //            //Descontar stock
        //            var articulo = miConn.Articulos.Where(a => a.Id == item.IdArticulo).FirstOrDefault();
        //            articulo.Stock = articulo.Stock - item.Cantidad;
        //            miConn.Entry(articulo).State = System.Data.Entity.EntityState.Modified;
        //        }
        //        miConn.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        return View();
        //    }
        //    return RedirectToAction("Index");
        //    //return RedirectToAction("Reporte", new { idventa = ventas.Id });
        //}

        public ActionResult CargarDetalle()
        {
            return View();
        }

        public void AgregarArticulo(int IdArticulo, int cantidad)
        {
            var Detalle = new VentaDetalle();

            Detalle.IdArticulo = IdArticulo;
            Detalle.Cantidad = cantidad;

            foreach (var item in ListDetalleTemporal)
            {
                if (item.IdArticulo == IdArticulo)
                {
                    // item.Cantidad = item.Cantidad + cantidad;
                    item.Cantidad += cantidad;
                    return;
                }
            }
            ListDetalleTemporal.Add(Detalle); return;

        }

        public void QuitarArticulo(int IdArticulo)
        {
            var Detalle = new VentaDetalle();

            Detalle.IdArticulo = IdArticulo;            

            foreach (var item in ListDetalleTemporal)
            {
                if (item.IdArticulo == IdArticulo)
                {
                    ListDetalleTemporal.Remove(item);           
                    return;
                }
            }
            ListDetalleTemporal.Add(Detalle); return;

        }

        public void ModificarCantidad(int IdArticulo, int cantidad)
        {
            var Detalle = new VentaDetalle();

            Detalle.IdArticulo = IdArticulo;
            Detalle.Cantidad = cantidad;

            foreach (var item in ListDetalleTemporal)
            {
                if (item.IdArticulo == IdArticulo)
                {
                    item.Cantidad = cantidad;
                    return;
                }
            }
            ListDetalleTemporal.Add(Detalle); return;

        }

        public JsonResult VerificarStock(int idArticulo, int cantidad)
        {
            var articulo = miConn.Articulos.Where(a => a.Id == idArticulo).FirstOrDefault();

            return Json(articulo);
        }

        public ActionResult Reporte(int idVenta)
        {
            ListDetalleTemporal = miConn.VentasDetalle.Where(v => v.IdVentas == idVenta).ToList();
            var venta = miConn.VentasMaster.Where(v => v.Id == idVenta).FirstOrDefault();

            return View(venta);
        }

        public ActionResult ClearList()
        {
            //Se acciona al logOff             
            ListDetalleTemporal.Clear();
            return RedirectToAction("Index", "Home");
        }



    }      
}
