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
    
    public partial class vPersona_ActividadMilitar
    {
        public string Email { get; set; }
        public int IdPersona { get; set; }
        public int IdActividadMilitar { get; set; }
        public int IdFuerza { get; set; }
        public string Fuerza { get; set; }
        public string Jerarquia { get; set; }
        public string Cargo { get; set; }
        public string Destino { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<System.DateTime> FechaBaja { get; set; }
    }
}
