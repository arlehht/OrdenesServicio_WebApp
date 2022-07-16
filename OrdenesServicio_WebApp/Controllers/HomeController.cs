using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OrdenesServicio_WebApp.Permisos;
using OrdenesServicio_WebApp.Models;

namespace OrdenesServicio_WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        //Indica que para visualizar la página debe estar autorizado
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [PermisosRol(Rol.Administrador)]
        // Sólo el administrador puede acceder a la página de contacto
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            Session["Usuario"] = null;
            return RedirectToAction("Index","Acceso");
        }
        public ActionResult SinPermiso()
        {
            ViewBag.Message = "Usted no tiene permisos para esta sección";

            return View();
        }
    }
}