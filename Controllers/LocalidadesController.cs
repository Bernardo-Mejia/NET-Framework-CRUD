using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ADONETStoredProcedures.Models;

namespace ADONETStoredProcedures.Controllers
{
    public class LocalidadesController : Controller
    {
        private ADO_Stored_ProceduresEntities db = new ADO_Stored_ProceduresEntities();

        // GET: Localidades
        public ActionResult Index()
        {
            return View(db.Localidad.ToList());
        }

        // GET: Localidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidad localidad = db.Localidad.Find(id);
            if (localidad == null)
            {
                return HttpNotFound();
            }
            return View(localidad);
        }

        // GET: Localidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Localidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion")] Localidad localidad)
        {
            if (ModelState.IsValid)
            {
                db.Localidad.Add(localidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(localidad);
        }

        // GET: Localidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidad localidad = db.Localidad.Find(id);
            if (localidad == null)
            {
                return HttpNotFound();
            }
            return View(localidad);
        }

        // POST: Localidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] Localidad localidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(localidad);
        }

        // GET: Localidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidad localidad = db.Localidad.Find(id);
            if (localidad == null)
            {
                return HttpNotFound();
            }
            return View(localidad);
        }

        // POST: Localidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Localidad localidad = db.Localidad.Find(id);
            db.Localidad.Remove(localidad);
            db.SaveChanges();
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
