﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// borre los comentarios anteriores
//cambio2
//cambio 3 desde visul studio
namespace SINU.ViewModels
{
    public class vContacto
    {

        [Display(Name = "Lista De Configuracion")]
        public List<SINU.Models.Configuracion> Configuracion { get; set; }

        [Display(Name = "Lista De Oficinas")]
        public List<SINU.Models.OficinasYDelegaciones> listoficinas { get; set; }
    }
}
