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
        public Nullable<int> Fk_Folio { get; set; }
    
        public virtual OrdenesServicio OrdenesServicio { get; set; }
    }
}
