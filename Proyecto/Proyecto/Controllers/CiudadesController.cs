using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Logica;
using Modelos;
using Repositorio;

namespace Proyecto.Controllers
{
   [Authorize(Roles = "Usuario")]

    public class CiudadesController : Controller
    {
        private JaverianaNETEntities db = new JaverianaNETEntities();

        // GET: Ciudades
        public ActionResult Index()
        {
            var logica = new CiudadLogica();
            var listado = logica.GetListadoCiudades();
            return View(listado);
        }

        // GET: Ciudades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CiudadModelo ciudadModelo = new CiudadLogica().GetCiudad(id);
            if (ciudadModelo == null)
            {
                return HttpNotFound();
            }
            return View(ciudadModelo);
        }

        // GET: Ciudades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ciudades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreCiudad,DepartamentoId")] CiudadModelo ciudadModelo)
        {
            if (ModelState.IsValid)
            {
                new CiudadLogica().CrearCiudad(ciudadModelo);
                return RedirectToAction("Index");
            }

            return View(ciudadModelo);
        }

        // GET: Ciudades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CiudadModelo ciudadModelo = new CiudadLogica().EditarCiudad(id);
            if (ciudadModelo == null)
            {
                return HttpNotFound();
            }
            return View(ciudadModelo);
        }

        // POST: Ciudades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreCiudad,DepartamentoId")] CiudadModelo ciudadModelo)
        {
            if (ModelState.IsValid)
            {
                CiudadLogica cl = new CiudadLogica();
                cl.EditarCiudad(ciudadModelo);
                //db.Entry(ciudadModelo).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ciudadModelo);
        }

        // GET: Ciudades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CiudadModelo ciudadModelo = new CiudadLogica().GetCiudad(id);
            if (ciudadModelo == null)
            {
                return HttpNotFound();
            }
            return View(ciudadModelo);
        }

        // POST: Ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CiudadLogica cl = new CiudadLogica();
            cl.EliminarCiudad(id);
            //db.CiudadModeloes.Remove(ciudadModelo);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
