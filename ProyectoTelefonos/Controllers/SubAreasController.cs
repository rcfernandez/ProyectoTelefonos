using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoTelefonos;

namespace ProyectoTelefonos.Controllers
{
    public class SubAreasController : Controller
    {
        private ModelDB db = new ModelDB();

        // GET: SubAreas
        public ActionResult Index()
        {
            return View(db.SubArea.ToList());
        }

        // GET: SubAreas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubArea subArea = db.SubArea.Find(id);
            if (subArea == null)
            {
                return HttpNotFound();
            }
            return View(subArea);
        }

        // GET: SubAreas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Referente")] SubArea subArea)
        {
            if (ModelState.IsValid)
            {
                db.SubArea.Add(subArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subArea);
        }

        // GET: SubAreas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubArea subArea = db.SubArea.Find(id);
            if (subArea == null)
            {
                return HttpNotFound();
            }
            return View(subArea);
        }

        // POST: SubAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Referente")] SubArea subArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subArea);
        }

        // GET: SubAreas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubArea subArea = db.SubArea.Find(id);
            if (subArea == null)
            {
                return HttpNotFound();
            }
            return View(subArea);
        }

        // POST: SubAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            SubArea subArea = db.SubArea.Find(id);
            db.SubArea.Remove(subArea);
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
