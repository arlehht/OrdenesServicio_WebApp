using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrdenesServicio_WebApp.Models;
using OrdenesServicio_WebApp.Logica;
using System.Web.Security;

namespace OrdenesServicio_WebApp.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string correo, string clave)
        {
            Usuario ObjUsuario = new LO_Usuario().FindUser(correo,clave);
            if (ObjUsuario.Nombre!=null)
            {
                FormsAuthentication.SetAuthCookie(ObjUsuario.Correo, false);
                Session["Usuario"] = ObjUsuario;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}