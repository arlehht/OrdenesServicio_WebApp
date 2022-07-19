using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrdenesServicio_WebApp.Models;
using OrdenesServicio_WebApp.Models.ViewModel;

namespace OrdenesServicio_WebApp.Controllers
{
    public class EquiposController : Controller
    {
        private OrdenesServicioEntities db = new OrdenesServicioEntities();

        // GET: Equipos
        public ActionResult Index()
        {
            var equipos = db.Equipos.Include(e => e.OrdenesServicio);
            return View(equipos.ToList());
        }

        // GET: Equipos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipos equipos = db.Equipos.Find(id);
            if (equipos == null)
            {
                return HttpNotFound();
            }
            return View(equipos);
        }

        // GET: Equipos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEquipo,Equipo,Modelo,Serie,Fk_Folio")] Equipos equipos)
        {
            List<OrdenesViewModel> lst;
            using (Models.OrdenesServicioEntities db = new Models.OrdenesServicioEntities())
            {
                lst = (from d in db.OrdenesServicio
                       select new OrdenesViewModel
                       {
                           Id = d.IdFolio
                       }).ToList();
            }
            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Id.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });
            ViewBag.Items = items;

            if (ModelState.IsValid)
            {
                db.Equipos.Add(equipos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fk_Folio = new SelectList(db.OrdenesServicio, "IdFolio", "Usuario", equipos.Fk_Folio);
            
            return View(equipos);
        }

        // GET: Equipos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipos equipos = db.Equipos.Find(id);
            if (equipos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fk_Folio = new SelectList(db.OrdenesServicio, "IdFolio", "Usuario", equipos.Fk_Folio);
            return View(equipos);
        }

        // POST: Equipos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEquipo,Equipo,Modelo,Serie,Fk_Folio")] Equipos equipos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fk_Folio = new SelectList(db.OrdenesServicio, "IdFolio", "Usuario", equipos.Fk_Folio);
            return View(equipos);
        }

        // GET: Equipos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipos equipos = db.Equipos.Find(id);
            if (equipos == null)
            {
                return HttpNotFound();
            }
            return View(equipos);
        }

        // POST: Equipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipos equipos = db.Equipos.Find(id);
            db.Equipos.Remove(equipos);
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
