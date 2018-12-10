using Computacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computacion.Controllers
{
    public class CategoriaController : Controller
    {

        MiBaseDatos miConn = new MiBaseDatos();
    
        // GET: Categoria
        public ActionResult Index()
        {
            var list = miConn.Categorias.ToList();
            return View(list);
        }

        public ActionResult ListaCategoria()
        {
            var list = miConn.Categorias.ToList();
            return View(list);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                // TODO: Add insert logic here

                miConn.Categorias.Add(categoria);
                miConn.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categoria/Edit/5
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

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categoria/Delete/5
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
