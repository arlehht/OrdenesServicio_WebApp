//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrdenesServicio_WebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Equipos
    {
        public int IdEquipo { get; set; }
        public string Equipo { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public Nullable<int> Folio { get; set; }
    
        public virtual OrdenesServicio OrdenesServicio { get; set; }
    }
}
