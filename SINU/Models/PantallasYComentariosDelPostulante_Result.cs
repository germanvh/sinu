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
    
    public partial class PantallasYComentariosDelPostulante_Result
    {
        public Nullable<long> ID { get; set; }
        public string Pantalla { get; set; }
        public Nullable<bool> Abierta { get; set; }
        public Nullable<System.DateTime> fechaCierre { get; set; }
        public string Comentario { get; set; }
        public int IdPantalla { get; set; }
        public Nullable<int> IdPostulantePersona { get; set; }
        public Nullable<int> IdDataProblema { get; set; }
    }
}