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
    public class ParticipanteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Participante
        public ActionResult Index()
        {
            return View(db.Participantes.ToList());
        }

        // GET: Participante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParticipanteModels participanteModels = db.Participantes.Find(id);
            if (participanteModels == null)
            {
                return HttpNotFound();
            }
            return View(participanteModels);
        }

        // GET: Participante/Create
        public ActionResult Create()
        {
            ViewBag.ubicacionID = new SelectList(db.Ubicaciones, "ubicacionID", "nombreUbicacion");
            return PartialView();
        }

        // POST: Participante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "participanteID,cedula,nombreParticipante,ubicacionID")] ParticipanteModels participanteModels)
        {
            if (ModelState.IsValid)
            {
                db.Participantes.Add(participanteModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ubicacionID = new SelectList(db.Ubicaciones, "ubicacionID", "nombreUbicacion", participanteModels.ubicacionID);
            return View(participanteModels);
        }

        // GET: Participante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParticipanteModels participanteModels = db.Participantes.Find(id);
            if (participanteModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.ubicacionID = new SelectList(db.Ubicaciones, "ubicacionID", "nombreUbicacion");
            return PartialView(participanteModels);
        }

        // POST: Participante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "participanteID,cedula,nombreParticipante,ubicacionID")] ParticipanteModels participanteModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participanteModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ubicacionID = new SelectList(db.Ubicaciones, "ubicacionID", "nombreUbicacion", participanteModels.ubicacionID);
            return View(participanteModels);
        }

        // GET: Participante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParticipanteModels participanteModels = db.Participantes.Find(id);
            if (participanteModels == null)
            {
                return HttpNotFound();
            }
            return PartialView(participanteModels);
        }

        // POST: Participante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParticipanteModels participanteModels = db.Participantes.Find(id);
            db.Participantes.Remove(participanteModels);
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
