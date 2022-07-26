using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrdenesServicio_WebApp.Models;

namespace OrdenesServicio_WebApp.Controllers
{
    public class OrdenesController : Controller
    {
        OrdenesServicioEntities context = new OrdenesServicioEntities();

        public ActionResult ListadoDeOrdenes() 
        {
            //Estamos mandando los datos para ser mostrados
            List<OrdenesServicio> ordenes = context.OrdenesServicio.ToList();
            ViewBag.data = ordenes;
            
            return View();
        }

        // GET: Ordenes
        public ActionResult Ordenes()
        {
            if (TempData["msj"] != null)
            {
                ViewBag.msj = TempData["msj"];
            }

            List<OrdenesServicio> ordenes = context.OrdenesServicio.ToList();
            ViewBag.data = ordenes;
            return View();
        }
        [HttpPost]
        public ActionResult Ordenes(OrdenesServicio ord)
        {
            string accion = Request.Form["boton"].ToString();
            //string eliminacion = Request.Form["eliminacion"].ToString();
            //string modificacion = Request.Form["modificacion"].ToString();

            switch (accion) 
            {
                case "Guardar":
                    context.OrdenesServicio.Add(ord);
                    context.SaveChanges();
                    TempData["msj"] = "Guardado";
                    
                    break;

                //case "Modificar":
                //    //Editar
                //    if (modificacion.Equals("si"))
                //    {
                //        OrdenesServicio temp = context.OrdenesServicio.FirstOrDefault(x => x.Folio == ord.Folio);
                //        temp.Fecha = ord.Fecha;
                //        temp.Usuario = ord.Usuario;
                //        temp.Empresa = ord.Empresa;
                //        temp.TelCel = ord.TelCel;
                //        temp.Area = ord.Area;
                //        temp.Sucursal = ord.Sucursal;
                //        temp.Email = ord.Email;
                //        temp.Requerimiento = ord.Requerimiento;
                //        temp.Acciones = ord.Acciones;
                //        TempData["msj"] = "Modificado";
                //        context.SaveChanges();
                //    }
                //    break;

                //case "Eliminar":
                //    if (eliminacion.Equals("si"))
                //    {
                //        context.OrdenesServicio.Remove(context.OrdenesServicio.FirstOrDefault(x => x.Folio == ord.Folio));
                //        context.SaveChanges();
                //        TempData["msj"] = "Eliminado";
                //    }
                //    break;

            }
            return RedirectToAction("Ordenes");
        }
    }
}