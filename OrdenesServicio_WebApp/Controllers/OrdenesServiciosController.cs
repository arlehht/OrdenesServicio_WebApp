using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OrdenesServicio_WebApp.Models;
using OrdenesServicio_WebApp.Models.ViewModel;
using OrdenesServicio_WebApp.Controllers;

namespace OrdenesServicio_WebApp.Controllers
{
    public class OrdenesServiciosController : Controller
    {
        private OrdenesServicioEntities db = new OrdenesServicioEntities();

        // GET: OrdenesServicios
        public ActionResult Index()
        {
            return View(db.OrdenesServicio.ToList());
        }

        // GET: OrdenesServicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenesServicio ordenesServicio = db.OrdenesServicio.Find(id);
            if (ordenesServicio == null)
            {
                return HttpNotFound();
            }
            return View(ordenesServicio);
        }

        // GET: OrdenesServicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdenesServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFolio,Fecha,Instalacion,Mantenimiento,Revision,Reparacion,Garantia,Poliza,Configuracion,Capacitacion,Usuario,Empresa,TelefonoCelular,Area,Sucursal,Email,Requerimiento,Acciones")] OrdenesServicio ordenesServicio)
        {
            if (ModelState.IsValid)
            {
                db.OrdenesServicio.Add(ordenesServicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ordenesServicio);
        }

        // GET: OrdenesServicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenesServicio ordenesServicio = db.OrdenesServicio.Find(id);
            if (ordenesServicio == null)
            {
                return HttpNotFound();
            }
            return View(ordenesServicio);
        }

        // POST: OrdenesServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFolio,Fecha,Instalacion,Mantenimiento,Revision,Reparacion,Garantia,Poliza,Configuracion,Capacitacion,Usuario,Empresa,TelefonoCelular,Area,Sucursal,Email,Requerimiento,Acciones")] OrdenesServicio ordenesServicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenesServicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ordenesServicio);
        }

        // GET: OrdenesServicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenesServicio ordenesServicio = db.OrdenesServicio.Find(id);
            if (ordenesServicio == null)
            {
                return HttpNotFound();
            }
            return View(ordenesServicio);
        }

        // POST: OrdenesServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenesServicio ordenesServicio = db.OrdenesServicio.Find(id);
            db.OrdenesServicio.Remove(ordenesServicio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Acceso");
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
