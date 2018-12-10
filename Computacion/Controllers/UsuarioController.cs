using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Computacion.Models;


namespace Computacion.Controllers
{
    public class UsuarioController : Controller
    {

        MiBaseDatos miConn = new MiBaseDatos();

        // GET: Usuario
        public ActionResult Index()
        {
            var list = miConn.Usuarios.ToList();
            return View(list);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(string id)
        {
            var usuario = miConn.Usuarios.Where(x => x.IdAccount.Contains(id)).FirstOrDefault();
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                // TODO: Add insert logic here
                miConn.Usuarios.Add(usuario);
                miConn.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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

        public ActionResult BuscarUsuario(string usuario)
        {            
            var listUsuario = miConn.Usuarios.Where(x => (x.Nombre.Contains(usuario) || x.Apellido.Contains(usuario) )&& x.Rol != 99).ToList();

            if (listUsuario == null || listUsuario.Count == 0)
            {
                listUsuario = new List<Usuario>();
            }

            return View(listUsuario);
        }

        public ActionResult BuscarUsuarioPorDni(int dni)
        {
            var listUsuario = miConn.Usuarios.Where(x => x.Dni == dni).ToList();

            if (listUsuario == null || listUsuario.Count == 0)
            {
                listUsuario = new List<Usuario>();
            }

            return View(listUsuario);
        }
    }
}
