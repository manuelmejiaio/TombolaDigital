using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TombolaDigital.Models;

namespace TombolaDigital.Controllers
{
    public class PremioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Premio
        public ActionResult Index()
        {
            return View(db.Premios.ToList());
        }

        // GET: Premio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PremioModels premioModels = db.Premios.Find(id);
            if (premioModels == null)
            {
                return HttpNotFound();
            }
            return View(premioModels);
        }

        // GET: Premio/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Premio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "premioID,nombrePremio")] PremioModels premioModels)
        {
            if (ModelState.IsValid)
            {
                db.Premios.Add(premioModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(premioModels);
        }

        // GET: Premio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PremioModels premioModels = db.Premios.Find(id);
            if (premioModels == null)
            {
                return HttpNotFound();
            }
            return PartialView(premioModels);
        }

        // POST: Premio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "premioID,nombrePremio")] PremioModels premioModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(premioModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(premioModels);
        }

        // GET: Premio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PremioModels premioModels = db.Premios.Find(id);
            if (premioModels == null)
            {
                return HttpNotFound();
            }
            return PartialView(premioModels);
        }

        // POST: Premio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PremioModels premioModels = db.Premios.Find(id);
            db.Premios.Remove(premioModels);
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
