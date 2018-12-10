using Computacion.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computacion.Controllers
{
    public class CompraController : Controller
    {
        static int idArticuloCompra ;
        MiBaseDatos miConn = new MiBaseDatos();

        static List<Compra> ListaCompraTemporal = new List<Compra>();

        // GET: Compra
        public ActionResult Index()
        {
            var list = miConn.Compras.ToList();
            return View(list);
        }

        // GET: Compra/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Compra/Create
        public ActionResult Create()
        {
            //ApplicationDbContext context = new ApplicationDbContext();
            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());

            //string ID = currentUser.Id;
            //string Email = currentUser.;
            //string Username = currentUser.UserName;
            return View();
        }

        // POST: Compra/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Compra/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Compra/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Compras()
        {
            if (idArticuloCompra > 0)
            {
                ViewBag.idArticuloCompra = idArticuloCompra;

            }
            idArticuloCompra = 0;


            return View();
        }

        [HttpPost]
        public ActionResult Compras (Compra compras)
        {

            try
            {
                compras.Fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
                miConn.Compras.Add(compras);
                miConn.SaveChanges();


                //Aumentar stock

                var articulo = miConn.Articulos.Where(a => a.Id == compras.IdArticulo).FirstOrDefault();
                articulo.Stock = articulo.Stock + compras.Cantidad;
                articulo.PrecioVenta = compras.PrecioVenta;
                articulo.PrecioCompra = compras.PrecioCompra;
                miConn.Entry(articulo).State = System.Data.Entity.EntityState.Modified;

                miConn.SaveChanges();

                return RedirectToAction("Index");
            }        

            catch (Exception e)
            {
                return View();
            }

            //return RedirectToAction("Reporte", new { idventa = ventas.Id});
        }


        public ActionResult ComprasIdArticulo(int id)
        {

            idArticuloCompra = id;
           return RedirectToAction("Compras");
        }




    }
}

