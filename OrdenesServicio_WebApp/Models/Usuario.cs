using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdenesServicio_WebApp.Models
{
    public class Usuario
    {
        //Mapeo de la BD
        public int IdUsuario { get; set; } 
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public Rol IdRol { get; set; }
        public string ConfirmarPassword { get; set; }
    }
}