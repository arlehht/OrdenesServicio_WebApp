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
    
    public partial class OrdenesServicio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrdenesServicio()
        {
            this.Equipos = new HashSet<Equipos>();
        }
    
        public int IdFolio { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public bool Instalacion { get; set; }
        public bool Mantenimiento { get; set; }
        public bool Revision { get; set; }
        public bool Reparacion { get; set; }
        public bool Garantia { get; set; }
        public bool Poliza { get; set; }
        public bool Configuracion { get; set; }
        public bool Capacitacion { get; set; }
        public string Usuario { get; set; }
        public string Empresa { get; set; }
        public string TelefonoCelular { get; set; }
        public string Area { get; set; }
        public string Sucursal { get; set; }
        public string Email { get; set; }
        public string Requerimiento { get; set; }
        public string Acciones { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Equipos> Equipos { get; set; }
    }
}
