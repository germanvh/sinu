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
    
    public partial class DocumentosNecesariosDelInscripto_Result
    {
        public Nullable<int> Orden { get; set; }
        public string IdModalidad { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public bool Obligatorio { get; set; }
        public Nullable<bool> Presentado { get; set; }
        public string PathAlmacenamiento { get; set; }
        public Nullable<int> IdInscripcion { get; set; }
        public Nullable<int> IdPostulantePersona { get; set; }
    }
}
