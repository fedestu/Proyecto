using Computacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computacion.Controllers
{
    public class SubCategoriaController : Controller
    {

        MiBaseDatos miConn = new MiBaseDatos();

        // GET: SubCategoria
        public ActionResult Index()
        {
            var list = miConn.SubCategorias.ToList();

            return View(list);
        }

        // GET: SubCategoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult ListaSubCategoria(int id)
        {
            var subCate = miConn.SubCategorias.Where(x => x.IdCategoria == id).ToList();

            return View(subCate);
        }

        // GET: SubCategoria/Create
        public ActionResult Create()
        {
            var listaCategoria = miConn.Categorias.ToList();
            ViewBag.listaCategoria = listaCategoria;
            return View();
        }

        // POST: SubCategoria/Create
        [HttpPost]
        public ActionResult Create(SubCategoria subCategoria)
        {
            try
            {
                // TODO: Add insert logic here
                miConn.SubCategorias.Add(subCategoria);
                miConn.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SubCategoria/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubCategoria/Edit/5
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

        // GET: SubCategoria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubCategoria/Delete/5
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
    }
}
