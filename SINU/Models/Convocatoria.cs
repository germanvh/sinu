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
    
    public partial class Convocatoria
    {
        public int IdPeriodoInscripcion { get; set; }
        public string IdModalidad { get; set; }
        public string IdGrupoCarrOficio { get; set; }
        public int IdConvocatoria { get; set; }
    
        public virtual GrupoCarrOficio GrupoCarrOficio { get; set; }
        public virtual Modalidad Modalidad { get; set; }
        public virtual PeriodosInscripciones PeriodosInscripciones { get; set; }
    }
}
