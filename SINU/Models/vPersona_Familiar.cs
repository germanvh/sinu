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
    
    public partial class vPersona_Familiar
    {
        public string Email { get; set; }
        public Nullable<int> IdFamiliar { get; set; }
        public int IdPersonaPostulante { get; set; }
        public Nullable<int> IdPersonaFamiliar { get; set; }
        public Nullable<int> idParentesco { get; set; }
        public Nullable<int> IdSexo { get; set; }
        public string IdEstadoCivil { get; set; }
        public string Relacion { get; set; }
        public string Apellido { get; set; }
        public string Nombres { get; set; }
        public string Genero { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public string DNI { get; set; }
        public string EstCivil { get; set; }
    }
}
