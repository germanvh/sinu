﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SINU.Models;

namespace SINU.Controllers.Administrador
{
    public class FuerzasController : Controller
    {
        private SINUEntities db = new SINUEntities();

        // GET: Fuerzas
        public ActionResult Index()
        {
            return View(db.Fuerza.ToList());
        }

        // GET: Fuerzas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuerza fuerza = db.Fuerza.Find(id);
            if (fuerza == null)
            {
                return HttpNotFound();
            }
            return View(fuerza);
        }

        // GET: Fuerzas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fuerzas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fuerza1,IdFuerza")] Fuerza fuerza)
        {
            if (ModelState.IsValid)
            {
                db.Fuerza.Add(fuerza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fuerza);
        }

        // GET: Fuerzas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuerza fuerza = db.Fuerza.Find(id);
            if (fuerza == null)
            {
                return HttpNotFound();
            }
            return View(fuerza);
        }

        // POST: Fuerzas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Fuerza1,IdFuerza")] Fuerza fuerza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fuerza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fuerza);
        }

        // GET: Fuerzas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuerza fuerza = db.Fuerza.Find(id);
            if (fuerza == null)
            {
                return HttpNotFound();
            }
            return View(fuerza);
        }

        // POST: Fuerzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fuerza fuerza = db.Fuerza.Find(id);
            db.Fuerza.Remove(fuerza);
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
