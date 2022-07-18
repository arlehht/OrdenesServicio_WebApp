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
        public System.DateTime Fecha { get; set; }
        public Nullable<bool> Instalacion { get; set; }
        public Nullable<bool> Mantenimiento { get; set; }
        public Nullable<bool> Revision { get; set; }
        public Nullable<bool> Reparacion { get; set; }
        public Nullable<bool> Garantia { get; set; }
        public Nullable<bool> Poliza { get; set; }
        public Nullable<bool> Configuracion { get; set; }
        public Nullable<bool> Capacitacion { get; set; }
        public string Usuario { get; set; }
        public string Empresa { get; set; }
        public string TelCel { get; set; }
        public string Area { get; set; }
        public string Sucursal { get; set; }
        public string Email { get; set; }
        public string Requerimiento { get; set; }
        public string Acciones { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Equipos> Equipos { get; set; }
    }
}
