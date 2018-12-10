using Computacion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computacion.Controllers
{
    public class ArticuloController : Controller
    {
        MiBaseDatos miConn = new MiBaseDatos();
        // GET: Articulo
        public ActionResult Index()
        {
            var list = miConn.Articulos.ToList();

            return View(list);
        }

        public ActionResult Detailss(int id)
        {
            var list = miConn.Articulos.Where(x => x.Id == id).FirstOrDefault();
            return View(list);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            var articulo = miConn.Articulos.Where(x => x.Id == id).FirstOrDefault();
            var categoria = miConn.Articulos.Where(x => x.IdSubCategoria == id).Select(x => x.IdSubCategoria).FirstOrDefault();
            ViewBag.SubCategoria = categoria;
            return View(articulo);
        }

        public ActionResult ListaArticulos(int id)
        {
            var articulos = miConn.Articulos.Where(x => x.IdSubCategoria == id && x.FechaBaja == null).ToList();
            var categoria = miConn.Articulos.Where(x => x.IdSubCategoria == id).Select(x => x.IdCategoria).FirstOrDefault();
            ViewBag.Categoria = categoria;

            return View(articulos);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            CargarCombos();
            return View();
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(Articulo articulo)
        {
            try
            {
                // TODO: Add insert logic here
                
                miConn.Articulos.Add(articulo);
                miConn.SaveChanges();

                return RedirectToAction("Detailss", new { id = articulo.Id});
            }
            catch
            {
                CargarCombos();
                return View();
            }
        }

        // GET: Articulo/Edit/5
        public ActionResult Edit(int id)
        {
            var articulos = miConn.Articulos.Where(a => a.Id == id).FirstOrDefault();
            return View(articulos);
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(Articulo articulo)
        {
            try
            {

                              
                miConn.Entry(articulo).State = EntityState.Modified;
                miConn.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("Detailss", new { id = articulo.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Articulo/Delete/5
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

        private void CargarCombos()
        {
            ViewBag.ListaCategoria = miConn.Categorias.ToList();
            ViewBag.ListaSubCategorias = miConn.SubCategorias.Where(x => x.IdCategoria == 1).ToList();
        }

        public ActionResult GetSubCategoria (int idCategoria)
        {
            //var subCategoria = miConn.SubCategorias.Where(x => x.IdCategoria == idCategoria).ToList();
            //var retorno = Json(subCategoria, JsonRequestBehavior.AllowGet);
            ViewBag.ListaSubCategorias = miConn.SubCategorias.Where(x => x.IdCategoria == idCategoria).ToList();
            return View();
        }

        public ActionResult BuscarArticulos(string articulo)
        {
            var listArticulo = miConn.Articulos.Where(x => x.Descripcion.Contains(articulo)).ToList();

            if (listArticulo == null || listArticulo.Count == 0)
            {
                listArticulo = new List<Articulo>();
            }

            return View(listArticulo);
        }

        public ActionResult BuscarArticulosIndex(string articulo)
        {
            var listArticulo = miConn.Articulos.Where(x => x.Descripcion.Contains(articulo)).ToList();

            if (listArticulo == null || listArticulo.Count == 0)
            {
                listArticulo = new List<Articulo>();
            }

            return View(listArticulo);
        }

        public JsonResult BuscarArticuloPorId(int id)
        {
            try
            {
                var articulo = miConn.Articulos.Where(a => a.Id == id).FirstOrDefault();
                return Json(articulo);
            }
            catch
            {
                return Json(new Articulo());
            }

        }

        public ActionResult DarDeBaja()
        {
            return View();
        }


        [HttpPost]
        public ActionResult DarDeBaja(int id)
        {
            var articulo = miConn.Articulos.Where(x => x.Id == id).FirstOrDefault();
            articulo.FechaBaja = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
            miConn.Entry(articulo).State = System.Data.Entity.EntityState.Modified;
            miConn.SaveChanges();
            return RedirectToAction("Index" , "Home");
        }

        public ActionResult ComprobarStock()
        {
            var listStock = miConn.Articulos.Where(x => x.Stock < 3 && x.FechaBaja != "").ToList();
            return View(listStock);
        }

    }
}
