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
    
    public partial class ResGrupo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ResGrupo()
        {
            this.GrupoCarrOficio = new HashSet<GrupoCarrOficio>();
        }
    
        public int Edad_Al_AnioSig { get; set; }
        public int Edad_Al_Dia { get; set; }
        public int Edad_Al_Mes { get; set; }
        public int EdadMinCAutoriz { get; set; }
        public int EdadMin { get; set; }
        public int EdadMax { get; set; }
        public string IdEstadoCivil { get; set; }
        public Nullable<System.DateTime> Edad_a_fecha { get; set; }
        public int IdResGrupo { get; set; }
        public Nullable<int> AlturaMinF { get; set; }
        public Nullable<int> AlturaMinM { get; set; }
        public Nullable<int> IMC_min { get; set; }
        public Nullable<int> IMC_max { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrupoCarrOficio> GrupoCarrOficio { get; set; }
    }
}
