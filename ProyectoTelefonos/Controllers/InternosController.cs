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
    public class InternosController : Controller
    {
        private ModelDB db = new ModelDB();

        // GET: Internos
        public ActionResult Index()
        {
            return View(db.Interno.ToList());
        }

        // GET: Internos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Interno interno = db.Interno.Find(id);

            if (interno == null)
            {
                return HttpNotFound();
            }

            return View(interno);
        }

        // GET: Internos/Create
        public ActionResult Create()
        {
            ViewBag.DDLTipos = new List<SelectListItem> {   new SelectListItem { Text = "Analogico", Value = "analogico" },
                                                            new SelectListItem { Text = "Digital", Value = "digital"}
                                                        };

            ViewBag.DDLEstados = new List<SelectListItem>   {   new SelectListItem { Text = "Usado", Value = "usado" },
                                                                new SelectListItem { Text = "Libre", Value = "libre" },
                                                                new SelectListItem { Text = "Chequear", Value = "chequear"},
                                                                new SelectListItem { Text = "No Funciona", Value = "nofunciona"}
                                                            };

            ViewBag.DDLSubareas = db.SubArea.ToList();

            return View();
        }

        // POST: Internos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Numero,Tipo,Tn,Estado,Mostrar,Observacion")] Interno interno)
        {
            if (ModelState.IsValid)
            {
                db.Interno.Add(interno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(interno);
        }

        // GET: Internos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interno interno = db.Interno.Find(id);
            if (interno == null)
            {
                return HttpNotFound();
            }
            return View(interno);
        }

        // POST: Internos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Numero,Tipo,Estado,Observacion")] Interno interno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(interno);
        }

        // GET: Internos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interno interno = db.Interno.Find(id);
            if (interno == null)
            {
                return HttpNotFound();
            }
            return View(interno);
        }

        // POST: Internos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Interno interno = db.Interno.Find(id);
            db.Interno.Remove(interno);
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
