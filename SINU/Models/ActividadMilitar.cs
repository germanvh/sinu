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
    
    public partial class ActividadMilitar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActividadMilitar()
        {
            this.Persona = new HashSet<Persona>();
        }
    
        public Nullable<bool> Ingreso { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<System.DateTime> FechaBaja { get; set; }
        public string CausaMotivoNoingreso { get; set; }
        public string MotivoBaja { get; set; }
        public string Jerarquia { get; set; }
        public string Cargo { get; set; }
        public string Destino { get; set; }
        public int IdSituacionRevista { get; set; }
        public int IdFuerza { get; set; }
        public int IdBaja { get; set; }
        public int IdActividadMilitar { get; set; }
    
        public virtual Fuerza Fuerza { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Persona> Persona { get; set; }
    }
}
