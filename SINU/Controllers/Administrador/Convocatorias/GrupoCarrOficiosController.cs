﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SINU.Models;
using SINU.ViewModels;
using System.Data.Entity.Core.Objects;

namespace SINU.Controllers.Administrador.Convocatorias
{
    public class GrupoCarrOficiosController : Controller
    {
        private SINUEntities db = new SINUEntities();

        // GET: GrupoCarrOficios
        public ActionResult Index()
        {
            return View(db.GrupoCarrOficio.ToList());
        }
        // este es el ORIGINAL
        // GET: GrupoCarrOficios/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    GrupoCarrOficio grupoCarrOficio = db.GrupoCarrOficio.Find(id);
        //    List < CarreraOficio > listado = spCarrerasDelGrupo_Result(id);

        //    if (grupoCarrOficio == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(grupoCarrOficio);
        //}

        // GET: GrupoCarrOficios/Create
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);               
                return View("Error", Func.ConstruyeError("Falta el ID que desea buscar entre los Grupos de Carreras", "GrupoCarrOficios", "Details"));
                //o puedo mandarlo al index devuelta e ignorar el error
                //return RedirectToAction("Index");
            }
            GrupoCarrOficio grupoCarrOficio = db.GrupoCarrOficio.Find(id);
            if (grupoCarrOficio == null)
            {
                //return HttpNotFound();
                return View("Error", Func.ConstruyeError("Ese ID de Grupo no se encontro en la tabla de GrupoCarrOficio", "GrupoCarrOficios", "Details"));
            }
            //ViewBag.Carreras = db.spCarrerasDelGrupo(id).ToList();
            GrupoCarrOficiosvm datosgrupocarroficio = new GrupoCarrOficiosvm()
            {

                IdGrupoCarrOficio = grupoCarrOficio.IdGrupoCarrOficio,
                Descripcion = grupoCarrOficio.Descripcion,
                Personal = grupoCarrOficio.Personal,
                Carreras = db.spCarrerasDelGrupo(id,"").ToList()

            };            
            return View(datosgrupocarroficio);
        }
        public ActionResult Create()
        {
            GrupoCarrOficiosvm prueba = new GrupoCarrOficiosvm { Carreras2 = db.CarreraOficio.ToList() };
                       return View(prueba);
        }

        // POST: GrupoCarrOficios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGrupoCarrOficio,Personal,Descripcion,SelectedIDs")]  GrupoCarrOficiosvm
 grupoCarrOficiovm )
        {
            string stgCarreras = String.Join(",", grupoCarrOficiovm.SelectedIDs);
            ObjectParameter ObjMensaje = new ObjectParameter("Mensaje","");
            if (ModelState.IsValid)
            {
                //03 agosto, graba en grupo carrera oficio
                // aca iria un sp donde le paso todo el listado de carreras y 
                //el id del grupo carrera oficio para asignarle a las mismas.
                //db.GrupoCarrOficio.Add(grupoCarrOficio);
                //db.SaveChanges(); 
                
               db.spGrupoYAgrupacionCarreras(grupoCarrOficiovm.IdGrupoCarrOficio, grupoCarrOficiovm.Personal, grupoCarrOficiovm.Descripcion, stgCarreras, ObjMensaje);
                //aca debo MANIPULAR al MensajeDevuelto.Value.ToString()
                
                switch (ObjMensaje.Value.ToString())
                {
                    case "Exito / Inserciones realizadas correctamente.":
                        return RedirectToAction("Index",ObjMensaje); //write "<div>Custom Value 1</div>"
                        
                    case "s":
                        return View(grupoCarrOficiovm); //write "<span>Custom Value 2</span>"
                     
                }
                 //aca haria un case of segun lo recibido en el mensaje (supongo)
                 //lo mando al index si hay exito o queda en la pantalla de create con el error
                
            }

            return View(grupoCarrOficiovm);
        }

        // GET: GrupoCarrOficios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoCarrOficio grupoCarrOficio = db.GrupoCarrOficio.Find(id);
            if (grupoCarrOficio == null)
            {
                return HttpNotFound();
            }
            return View(grupoCarrOficio);
        }

        // POST: GrupoCarrOficios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGrupoCarrOficio,Descripcion,Personal")] GrupoCarrOficio grupoCarrOficio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoCarrOficio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupoCarrOficio);
        }

        // GET: GrupoCarrOficios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoCarrOficio grupoCarrOficio = db.GrupoCarrOficio.Find(id);
            if (grupoCarrOficio == null)
            {
                return HttpNotFound();
            }
            return View(grupoCarrOficio);
        }

        // POST: GrupoCarrOficios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GrupoCarrOficio grupoCarrOficio = db.GrupoCarrOficio.Find(id);
            db.GrupoCarrOficio.Remove(grupoCarrOficio);
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

        //esto es para usar Json y cargar la lista filtrada

        //	DevolverCarrerasFiltradas TPersonal
        public JsonResult DevolverCArrerasFiltradas(string RegionId)
        {
            using (db = new SINUEntities())
            {
                //	carreras					Tpersonal
                var carreras = db.CarreraOficio.Where(x => x.Personal == RegionId).ToList();
                return Json(carreras, JsonRequestBehavior.AllowGet);
                //carrerasFiltradas
            }
        }

    }
}
