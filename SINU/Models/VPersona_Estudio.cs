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
    
    public partial class VPersona_Estudio
    {
        public int IdPersona { get; set; }
        public Nullable<int> IdNiveldEstudio { get; set; }
        public int IdEstudio { get; set; }
        public string Titulo { get; set; }
        public bool Completo { get; set; }
        public int IdInstitutos { get; set; }
        public string Nombre { get; set; }
        public Nullable<double> Promedio { get; set; }
        public Nullable<int> CantidadMateriaAdeudadas { get; set; }
        public Nullable<int> ultimoAnioCursado { get; set; }
        public string Nivel { get; set; }
        public string NombreYPaisInstituto { get; set; }
        public string Jurisdiccion { get; set; }
        public string Localidad { get; set; }
        public bool CursandoUltimoAnio { get; set; }
    }
}
