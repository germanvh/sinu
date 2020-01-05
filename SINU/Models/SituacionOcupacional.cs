//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SINU.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SituacionOcupacional
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SituacionOcupacional()
        {
            this.Persona = new HashSet<Persona>();
        }
    
        public int Id { get; set; }
        public int IdEstadoOcupacional { get; set; }
        public string OcupacionActual { get; set; }
        public string Oficio { get; set; }
        public Nullable<int> AniosTrabajados { get; set; }
        public string DomicilioLaboral { get; set; }
    
        public virtual EstadoOcupacional EstadoOcupacional { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Persona> Persona { get; set; }
    }
}
