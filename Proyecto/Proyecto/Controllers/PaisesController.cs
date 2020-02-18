using Logica;
using Modelos;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class PaisesController : Controller
    {
        private JaverianaNETEntities db = new JaverianaNETEntities();

      

        // GET: Paises
        public ActionResult Index()
        {
            var logica = new PaisLogica();
            var listado = logica.GetListadoPaises();
            return View(listado);
        }

        // GET: Paises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaisModelo paisModelo = new PaisLogica().GetPais(id);
            if (paisModelo == null)
            {
                return HttpNotFound();
            }
            return View(paisModelo);
        }

        // GET: Paises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paises/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombrePais,PaisId")] PaisModelo paisModelo)
        {
            if (ModelState.IsValid)
            {
                new PaisLogica().CrearPais(paisModelo);

                return RedirectToAction("Index");
            }

            return View(paisModelo);
        }

        // GET: Paises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaisModelo paisModelo = new PaisLogica().EditarPais(id);
            if (paisModelo == null)
            {
                return HttpNotFound();
            }
            return View(paisModelo);
        }

        // POST: Paises/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombrePais,PaisId")] PaisModelo paisModelo)
        {
            if (ModelState.IsValid)
            {
                PaisLogica cl = new PaisLogica();
                cl.EditarPais(paisModelo);
                return RedirectToAction("Index");
            }
            return View(paisModelo);
        }

        // GET: Paises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaisModelo paisModelo = new PaisLogica().GetPais(id);
            if (paisModelo == null)
            {
                return HttpNotFound();
            }
            return View(paisModelo);
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaisLogica cl = new PaisLogica();
            cl.EliminarPais(id);
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