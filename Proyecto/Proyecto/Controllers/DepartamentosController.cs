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

    public class DepartamentosController : Controller
    {
        private JaverianaNETEntities db = new JaverianaNETEntities();

        // GET: Departamentos
        public ActionResult Index()
        {
            var logica = new DepartamentoLogica();
            var listado = logica.GetListadoDepartamentos();
            return View(listado);
        }

        // GET: Departamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartamentoModelo departamentoModelo = new DepartamentoLogica().GetDepartamento(id);
            if (departamentoModelo == null)
            {
                return HttpNotFound();
            }
            return View(departamentoModelo);
        }

        // GET: Departamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreDepartamento,PaisId")] DepartamentoModelo departamentoModelo)
        {
            if (ModelState.IsValid)
            {
                new DepartamentoLogica().CrearDepartamento(departamentoModelo);

                return RedirectToAction("Index");
            }

            return View(departamentoModelo);
        }

        // GET: Departamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartamentoModelo departamentoModelo = new DepartamentoLogica().EditarDepartamento(id);
            if (departamentoModelo == null)
            {
                return HttpNotFound();
            }
            return View(departamentoModelo);
        }

        // POST: Departamentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreDepartamento,PaisId")] DepartamentoModelo departamentoModelo)
        {
            if (ModelState.IsValid)
            {
                DepartamentoLogica cl = new DepartamentoLogica();
                cl.EditarDepartamento(departamentoModelo);
                return RedirectToAction("Index");
            }
            return View(departamentoModelo);
        }

        // GET: Departamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartamentoModelo departamentoModelo = new DepartamentoLogica().GetDepartamento(id);
            if (departamentoModelo == null)
            {
                return HttpNotFound();
            }
            return View(departamentoModelo);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartamentoLogica cl = new DepartamentoLogica();
            cl.EliminarDepartamento(id);
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
