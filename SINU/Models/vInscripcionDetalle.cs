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
    
    public partial class vInscripcionDetalle
    {
        public System.DateTime FechaRegistro { get; set; }
        public string Apellido { get; set; }
        public string Nombres { get; set; }
        public string Genero { get; set; }
        public string DNI { get; set; }
        public string Celular { get; set; }
        public string OpcionSeEnteroPOR { get; set; }
        public string ComoSeEntero { get; set; }
        public string Preferencia { get; set; }
        public string Modalidad { get; set; }
        public Nullable<int> IdCarreraOficio { get; set; }
        public string CarreraRelacionada { get; set; }
        public string Rinde_En { get; set; }
        public string Inscripto_En { get; set; }
        public string Inscripto_En_descrip { get; set; }
        public Nullable<System.DateTime> FechaEntrevista { get; set; }
        public Nullable<System.DateTime> FechaRindeExamen { get; set; }
        public string Numero { get; set; }
        public int IdPersona { get; set; }
        public int IdInscripcion { get; set; }
        public int IdOficinasYDelegaciones { get; set; }
    }
}
