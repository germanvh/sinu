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
    
    public partial class VerificacionPantallasCerradas
    {
        public int IdPantalla { get; set; }
        public int IdPostulantePersona { get; set; }
        public System.DateTime fechaCierre { get; set; }
    
        public virtual Persona Persona { get; set; }
        public virtual VerificacionPantallas VerificacionPantallas { get; set; }
    }
}