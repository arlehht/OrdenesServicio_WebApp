using OrdenesServicio_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrdenesServicio_WebApp.Permisos
{
    public class PermisosRolAttribute : ActionFilterAttribute
    {
        private Rol IdRol;
        public PermisosRolAttribute(Rol _idRol)
        {
            IdRol = _idRol;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Usuario"] != null)
            {
                Usuario user = HttpContext.Current.Session["Usuario"] as Usuario;

                if (user.IdRol !=IdRol)
                {
                    filterContext.Result = new RedirectResult("~/Home/SinPermiso");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}