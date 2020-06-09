﻿using Microsoft.Ajax.Utilities;
using SINU.Models;
using SINU.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SINU.Controllers
{
    [Authorize]
    public class PostulanteController : Controller
    {
        SINUEntities db = new SINUEntities();

        //ESTABLESCO LA VARIABLE MAIL DEL USUARIO QUE ESTA ACTUALMENTE LOGUEADO
        //ESTA CARIABLE ES UTILIZADA PARA BUSCAR EN LAS DISTINTAS VISTAS, UTILIZADAS EN EL CONTROLADOR, PARA  BUSCAR LOS REGISTROS DEL USUARIO LOGUEADO
        //private int ID_persona;
        //=> db.Persona.FirstOrDefault(m => m.Email == HttpContext.User.Identity.Name.ToString()).IdPersona;
        //private int ID_fami;
        //----------------------------------PAGINA PRINCIPAL----------------------------------------------------------------------//

        public ActionResult Index()
        {//error cdo existe uno registrado antes de los cambios de secuencia
            IDPersonaVM pers = new IDPersonaVM
            {
                ID_PER = db.Persona.FirstOrDefault(m => m.Email == HttpContext.User.Identity.Name.ToString()).IdPersona,
            };
            pers.EtapaTabs = db.vPostulanteEtapaEstado.Where(id => id.IdPostulantePersona == pers.ID_PER).DistinctBy(id => id.IdEtapa).Select(id => id.IdEtapa).ToList();
            pers.EtapaTabs.ForEach(m => pers.IDETAPA += m + ",");

            return View(pers);
        }

        //----------------------------------DATOS BASICOS----------------------------------------------------------------------//

        //ver el tema de la fecha de casamiento
        public ActionResult DatosBasicos(int ID_persona)
        {
            try
            {
                //se carga los datos basicos del usuario actual y los utilizados para los dropboxlist
                DatosBasicosVM datosba = new DatosBasicosVM()
                {
                    SexoVM = db.Sexo.Where(m=>m.IdSexo!=4).ToList(),
                    vPeriodosInscripsVM = db.vPeriodosInscrip.ToList(),
                    OficinasYDelegacionesVM = db.OficinasYDelegaciones.ToList(),
                    vPersona_DatosBasicosVM = db.vPersona_DatosBasicos.FirstOrDefault(b => b.IdPersona == ID_persona)
                };

                return PartialView(datosba);
            }
            catch (Exception ex)
            {
                //revisar como mostrar error en la vista
                return PartialView(ex);
            }

        }

        //ACCION QUE GUARDA LOS DATOS INGRESADOS EN LA VISTA "DATOS BASICOS"
        [HttpPost]
        public ActionResult DatosBasicos(DatosBasicosVM Datos)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    //se guarda los datos de las persona devueltos
                    var p = Datos.vPersona_DatosBasicosVM;
                    //se llama el "spDatosBasicosUpdate" para guadar los datos ingresados en la base de datos
                    var result = db.spDatosBasicosUpdate(p.Apellido, p.Nombres, p.IdSexo, p.DNI, p.Telefono, p.Celular, p.Email, p.IdDelegacionOficinaIngresoInscribio, p.ComoSeEntero, p.IdPreferencia,p.FechaNacimiento, p.IdPersona, p.IdPostulante);
                  
                    return Json(new { success = true, msg = "se guardaron los datos correctamente datos basicos", form= "datosbasicos" });
                }
                catch (Exception ex)
                {
                    //envio la error  a la vista
                    string msgerror = ex.Message + " " + ex.InnerException.Message;
                    return Json(new { success = false, msg = msgerror });
                }
            };
            return Json(new { success = false, msg = "Modelo no VALIDO" });
        }


        //DEVUELVE TRUE SI LA EDAD ES COHERENTE Y FALSE SI NO.
        public JsonResult EdadInstituto(int IDinst ,int edad ) {
            if (IDinst == 9 & edad > 22)
            {
                return Json(new { coherencia = false },JsonRequestBehavior.AllowGet);
            } else if (IDinst == 10 & edad > 24) {
                return Json(new { coherencia = false }, JsonRequestBehavior.AllowGet);
            };

            return Json(new { coherencia = true }, JsonRequestBehavior.AllowGet);
        }
        //----------------------------------ENTREVISTA----------------------------------------------------------------------//

        public ActionResult Entrevista(int ID_persona)
        {
            vEntrevistaLugarFecha entrevistafh = new vEntrevistaLugarFecha();
            try
            {
                entrevistafh = db.vEntrevistaLugarFecha.FirstOrDefault(m => m.IdPersona == ID_persona);
                //se carga los texto parametrizados desde la tabla configuracion
                string[] consideraciones = {
                    db.Configuracion.FirstOrDefault(m => m.NombreDato == "ConsideracionEntrevTitulo").ValorDato.ToString(),
                    db.Configuracion.FirstOrDefault(m => m.NombreDato == "ConsideracionEntrevTexto").ValorDato.ToString()
                };
                ViewBag.Considere = consideraciones;

                return PartialView(entrevistafh);
            }
            catch (Exception ex)
            {

                return PartialView(ex);
            }

        }

        //----------------------------------DATOS PERSONALES----------------------------------------------------------------------//

        public ActionResult DatosPersonales(int ID_persona)
        {
            try
            {
                DatosPersonalesVM datosba = new DatosPersonalesVM()
                {
                    vPersona_DatosPerVM = db.vPersona_DatosPer.FirstOrDefault(m => m.IdPersona == ID_persona),
                    TipoNacionalidadVM = db.TipoNacionalidad.ToList(),
                    vEstCivilVM = db.vEstCivil.ToList(),
                    vRELIGIONVM = db.vRELIGION.ToList()
                };
                return PartialView(datosba);
            }
            catch (Exception ex)
            {
                //revisar como mostrar error en la vista
                return PartialView(ex);
            }
        }


        //ACCION QUE GUARDA LOS DATOS INGRESADOS EN LA VISTA "DATOS PERSONALES"
        [HttpPost]
        public ActionResult DatosPersonales(DatosPersonalesVM Datos)
        {
            var fe = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    var p = Datos.vPersona_DatosPerVM;
                    var result = db.spDatosPersonalesUpdate(p.IdPersona, p.CUIL, p.FechaNacimiento, p.IdEstadoCivil, p.IdReligion, p.idTipoNacionalidad);
                    return Json(new { success = true, msg = "se guadaron con exito los DATOS PERSONALES" });
                }
                catch (Exception ex)
                {
                    //envio la error  a la vista
                    string msgerror = ex.Message + " " + ex.InnerException.Message;
                    return Json(new { success = false, msg = msgerror });
                }
            }
            return Json(new { success = false, msg = "Modelo no VALIDO" });
        }

        //----------------------------------Domicilio----------------------------------------------------------------------//

       
        public ActionResult Domicio_API(int ID_persona)
        {

            Domiciolio_API domi = new Domiciolio_API()
            {
                vPersona_Domicilio_API = db.vPersona_Domicilio.FirstOrDefault(m => m.IdPersona == ID_persona),
                Pais_API = db.sp_vPaises("").Select(m => new SelectListItem { Text = m.DESCRIPCION, Value = m.CODIGO }).ToList(),
                Provincia_API = new List<SelectListItem>(),
                Localidad_API= new List<SelectListItem>()

            };
            return View(domi);
        }
               



        public ActionResult Domicilio(int ID_persona)
        {
            try
            {
                DomicilioVM datosdomilio = new DomicilioVM()
                {
                    vPersona_DomicilioVM = db.vPersona_Domicilio.FirstOrDefault(m => m.IdPersona == ID_persona),
                    sp_vPaises_ResultVM = db.sp_vPaises("").OrderBy(m => m.DESCRIPCION).ToList(),
                    provincias = db.vProvincia_Depto_Localidad.Select(m => m.Provincia).Distinct().ToList()
                };

                if (datosdomilio.vPersona_DomicilioVM.IdPais != "AR")
                {
                    string[] domiextR = datosdomilio.vPersona_DomicilioVM.Prov_Loc_CP.Split('-');
                    datosdomilio.vPersona_DomicilioVM.Provincia = domiextR[0];
                    datosdomilio.vPersona_DomicilioVM.Localidad = domiextR[1];
                    datosdomilio.vPersona_DomicilioVM.CODIGO_POSTAL = domiextR[2];
                };

                if (datosdomilio.vPersona_DomicilioVM.EventualIdPais != "AR")
                {
                    string[] domiextE = datosdomilio.vPersona_DomicilioVM.EventualProv_Loc.Split('-');
                    datosdomilio.vPersona_DomicilioVM.EventualProvincia = domiextE[0];
                    datosdomilio.vPersona_DomicilioVM.EventualLocalidad = domiextE[1];
                    datosdomilio.vPersona_DomicilioVM.EventualCodigo_Postal = domiextE[2];
                };

                datosdomilio.vProvincia_Depto_LocalidadREALVM = (datosdomilio.vPersona_DomicilioVM.IdLocalidad != null) ?
                    db.vProvincia_Depto_Localidad.Where(m => m.Provincia == datosdomilio.vPersona_DomicilioVM.Provincia).ToList()
                  : new List<vProvincia_Depto_Localidad>();

                datosdomilio.vProvincia_Depto_LocalidadEVENTUALVM = (datosdomilio.vPersona_DomicilioVM.EventualIdLocalidad != null) ?
                    db.vProvincia_Depto_Localidad.Where(m => m.Provincia == datosdomilio.vPersona_DomicilioVM.EventualProvincia).ToList()
                  : new List<vProvincia_Depto_Localidad>();

                return PartialView(datosdomilio);
            }
            catch (Exception ex)
            {
                //revisar como mostrar error en la vista
                return PartialView(ex);
            }
        }
        //ACCION QUE GUARDA LOS DATOS INGRESADOS EN LA VISTA "DATOS PERSONALES"
        [HttpPost]
        public JsonResult Domicilio(DomicilioVM Datos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var p = Datos.vPersona_DomicilioVM;
                    if (p.IdPais != "AR")
                    {
                        p.IdLocalidad = null;
                        p.Prov_Loc_CP = p.Provincia + "-" + p.Localidad + "-" + p.CODIGO_POSTAL;
                    }
                    else
                    {
                        p.Prov_Loc_CP = null;
                    };

                    if (p.EventualIdPais != "AR")
                    {
                        p.EventualIdLocalidad = null;
                        p.EventualProv_Loc = p.EventualProvincia + "-" + p.EventualLocalidad + "-" + p.EventualCodigo_Postal;
                    }
                    else
                    {
                        p.EventualProv_Loc = null;
                    };

                    db.spDomiciliosU(
                        p.IdDomicilioDNI, p.Calle, p.Numero, p.Piso, p.Unidad, p.IdLocalidad, p.Prov_Loc_CP, p.IdPais,
                        p.IdDomicilioActual, p.EventualCalle, p.EventualNumero, p.EventualPiso, p.EventualUnidad, p.EventualIdLocalidad, p.EventualProv_Loc, p.EventualIdPais
                    );

                    return Json(new { success = true, msg = "Se guardaron con Exito datos de DOMICILIO" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    //envio la error  a la vista
                    string msgerror = ex.Message + " " + ex.InnerException.Message;
                    return Json(new { success = false, msg = msgerror }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new { success = false, msg = "Modelo no VALIDO - " /*+ errors*/ }, JsonRequestBehavior.AllowGet);
        }

        //Cargo el DropBoxList de localidad,segun Provincia Seleccionado o Cp segun Localidad Seleccionada
        public JsonResult DropEnCascadaDomicilio(string? Provincia, int? Localidad)
        {
            if (Provincia!=null)
            {
                var localidades = db.vProvincia_Depto_Localidad
                                .Where(m => m.Provincia == Provincia)
                                .Select(m => new SelectListItem
                                {
                                    Value = m.IdLocalidad.ToString(),
                                    Text = m.Localidad
                                })
                                .OrderBy(m => m.Text)
                                .ToList();
                return Json(localidades, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string Value = db.vProvincia_Depto_Localidad.FirstOrDefault(m => m.IdLocalidad == Localidad).IdLocalidad.ToString();
                string Text = db.vProvincia_Depto_Localidad.FirstOrDefault(m => m.IdLocalidad == Localidad).CODIGO_POSTAL.ToString();

                return Json(new { Value, Text }, JsonRequestBehavior.AllowGet);
            }
        }

//----------------------------------Estudios----------------------------------------------------------------------//
        public ActionResult Estudios(int ID_persona)
        {
            try
            {
                EstudiosVM estudio = new EstudiosVM
                {
                    vPersona_EstudioListVM = db.VPersona_Estudio.Where(m => m.IdPersona == ID_persona).ToList()
                };
                foreach (var item in estudio.vPersona_EstudioListVM)
                {
                    if (item.IdInstitutos == 0)
                    {
                        string[] paisyinst = item.NombreYPaisInstituto.Split('-');
                        item.Jurisdiccion = paisyinst[0];
                        item.Nombre = paisyinst[1];
                    }
                }
                return PartialView(estudio);
            }
            catch (Exception ex)
            {
                //revisar como mostrar error en la vista
                return PartialView(ex);
            }
        }

        public ActionResult EstudiosCUD(int? ID,int ID_persona )
        {
            try
            {
                EstudiosVM estudio = new EstudiosVM()
                {
                    NivelEstudioVM = db.NiveldEstudio.ToList(),
                    //cargo los datos para el combobox de provincia
                    Provincia = db.Institutos
                        .DistinctBy(m => m.Jurisdiccion)
                        .OrderBy(m => m.Jurisdiccion)
                        .Select(m => m.Jurisdiccion)
                        .ToList()
                };
                //verifico si envio un ID 
                //SI reciobio ID cargo los datos correspondiente
                //caso contrario envio un nuevo registro de Estudio
                if (ID != null)
                {
                    estudio.vPersona_EstudioIdVM = db.VPersona_Estudio.FirstOrDefault(m => m.IdEstudio == ID);

                    //Si IdInstituto existe se carga los datos relacionados con el, provincia localidad y nombre de institutos
                    //de NO existir se carga datos del campo "NombreYPaisInstituto"
                    if (estudio.vPersona_EstudioIdVM.IdInstitutos != 0)
                        {
                            estudio.Localidad = db.Institutos
                                .Where(m => m.Jurisdiccion == estudio.vPersona_EstudioIdVM.Jurisdiccion)
                                .DistinctBy(m => m.Localidad)
                                .OrderBy(m => m.Localidad)
                                .Select(m => m.Localidad)
                                .ToList();
                            estudio.InstitutoVM = db.Institutos
                                .Where(m => m.Localidad == estudio.vPersona_EstudioIdVM.Localidad)
                                .OrderBy(m => m.Nombre)
                                .Select(m => new SelectListItem
                                {
                                    Value = m.Id.ToString(),
                                    Text = m.Nombre
                                })
                                .ToList();
                            estudio.vPersona_EstudioIdVM.Nombre = "";
                    }
                    else
                    {
                            string[] paisinst = estudio.vPersona_EstudioIdVM.NombreYPaisInstituto.Split('-');
                            estudio.vPersona_EstudioIdVM.Jurisdiccion = paisinst[0];
                            estudio.vPersona_EstudioIdVM.Nombre = paisinst[1];
                            estudio.Localidad = new List<string>();
                            estudio.InstitutoVM = new List<SelectListItem>();
                    }
                }
                else
                {
                    VPersona_Estudio nuevoestu = new VPersona_Estudio()
                    {
                        
                        IdInstitutos = 0,
                        IdEstudio = 0,
                        NombreYPaisInstituto = "-"
                    };
                    nuevoestu.IdPersona = ID_persona;
                    estudio.vPersona_EstudioIdVM = nuevoestu;
                    estudio.Localidad = new List<string>();
                    estudio.InstitutoVM = new List<SelectListItem>();
                };
                return PartialView(estudio);

            }
            catch (Exception ex)
            {
                //revisar como mostrar error en la vista
                return PartialView(ex);
            }
        }

        [HttpPost]
        public ActionResult EstudiosCUD(EstudiosVM Datos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var e = Datos.vPersona_EstudioIdVM;
                    if (e.IdInstitutos != 0)
                    {
                        e.NombreYPaisInstituto = null;
                    }
                    else
                    {
                        //e.IdInstitutos = 0;
                        e.NombreYPaisInstituto = e.Jurisdiccion + "-" + e.Nombre;
                    }

                    db.spEstudiosIU(e.IdEstudio, e.IdPersona, e.Titulo, e.Completo, e.IdNiveldEstudio, e.IdInstitutos, e.Promedio, e.CantidadMateriaAdeudadas, e.ultimoAnioCursado, e.NombreYPaisInstituto);

                    return Json(new { success = true, msg = "Se Inserto correctamente el  ESTUDIOS" });
                }
                catch (Exception ex)
                {
                    //revisar como mostrar error en la vista
                    return Json(new { success = false, msg = ex.InnerException.Message });
                }
            }
            return Json(new { success = false, msg = "Error en el Modelo Recibido" });

        }


        public JsonResult EliminaEST(int ID)
        {
            try
            {
                var estu = db.Estudio.Find(ID);
                if (estu != null)
                {
                    db.spEstudiosEliminar(ID);
                    return Json(new { success = true, msg = "Se elimno correctamente el EStudio seleccionado" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { success = false, msg = "Error: no existe el estudio con el id enviado", JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, msg = ex.InnerException.Message, JsonRequestBehavior.AllowGet });
            }
        }


        public JsonResult DropCascadaEST(int opc, string val)
        {
            if (opc == 0)
            {
                var result = db.Institutos
                                 .Where(m => m.Jurisdiccion == val)
                                 .DistinctBy(m => m.Localidad)
                                 .Select(m => new SelectListItem
                                 {
                                     Value = m.Localidad,
                                     Text = m.Localidad
                                 })
                                 .OrderBy(m => m.Text)
                                 .ToList();


                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //recibo 2 parametroe en val uno pára privincia y otro es localidad
                string[] valpro = val.Split('-');
                string juri = valpro[0];
                string loca = valpro[1];
                var result = db.Institutos
                                 .Where(m => m.Jurisdiccion == juri)
                                 .Where(m => m.Localidad == loca)
                                 .Select(m => new SelectListItem
                                 {
                                     Value = m.Id.ToString(),
                                     Text = m.Nombre
                                 })
                                 .OrderBy(m => m.Text)
                                 .ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

/*--------------------------------------------------------------IDIOMAS-------------------------------------------------------------------------------*/
        public ActionResult Idiomas(int ID_persona)
        {
            try
            {
                List<vPersona_Idioma> idioma;
                idioma = db.vPersona_Idioma.Where(m=>m.IdPersona== ID_persona).ToList();

                return PartialView(idioma);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult IdiomaCUD(int? ID,int? ID_persona)
        {
            try
            {
                IdiomasVM idioma = new IdiomasVM()
                {
                    NivelIdiomaVM = db.NivelIdioma.ToList(),
                    Sp_VIdiomas_VM = db.sp_vIdiomas("").ToList()
                };

                if (ID != null)
                {
                    idioma.VPersona_IdiomaIdVM = db.vPersona_Idioma.FirstOrDefault(m => m.IdPersonaIdioma == ID);
                }
                else
                {
                    idioma.VPersona_IdiomaIdVM = new vPersona_Idioma()
                    {
                        IdPersonaIdioma = 0,
                        IdPersona = ID_persona
                    };
                }

                return PartialView(idioma);

            }
            catch (Exception ex)
            {
                //revisar como mostrar error en la vista
                return PartialView(ex);
            }
        }

        [HttpPost]
        public JsonResult IdiomaCUD(IdiomasVM datos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    vPersona_Idioma i = datos.VPersona_IdiomaIdVM;
                    db.spIdiomasIU(i.IdPersonaIdioma, i.IdPersona, i.CodIdioma, i.Habla, i.Lee, i.Escribe);
                    return Json(new { success = true, msg = "Se Inserto correctamente el Idioma nuevo o s emodifico IDIOMA" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {

                    return Json(new { success = true, msg = ex.InnerException.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = true, msg = "El modelo recibido NO ES VALIDO"}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminaIDIO(int ID)
        {
            try
            {
                var regidioma = db.PersonaIdioma.FirstOrDefault(m=>m.IdPersonaIdioma==ID);
                db.PersonaIdioma.Remove(regidioma);
                db.SaveChanges();
                return Json(new { success = true, msg = "Se le elimino correctamente el idioma seleccionado" });
            }
            catch (Exception ex)
            { 

                return Json(new { success = false, msg =  ex.InnerException.Message});
            }
        }

/*--------------------------------------------------------------ACTIVIDAD MILITAR-------------------------------------------------------------------------------*/
        public ActionResult ActMilitar(int ID_persona)
        {
            try
            {
                List<vPersona_ActividadMilitar> LISTactividad;
                LISTactividad = db.vPersona_ActividadMilitar.Where(m => m.IdPersona == ID_persona).ToList();

                return PartialView(LISTactividad);
            }
            catch (Exception )
            {
                throw;
            }
        }

        public ActionResult ActMilitarCUD(int? ID,int ID_persona)
        {
            try
            {
                ActividadMIlitarVM actividad = new ActividadMIlitarVM() {
                    FuerzasVM = db.Fuerza.ToList(),
                    IDPErsona = ID_persona,
                    BajaVM = db.Baja.ToList(),
                    SituacionRevistaVM = db.SituacionRevista.ToList()
                 };
                if (ID!= null)
                {
                    actividad.ACTMilitarIDVM = db.ActividadMilitar.FirstOrDefault(m => m.IdActividadMilitar == ID);
                }
                else
                {
                    actividad.ACTMilitarIDVM = new ActividadMilitar()
                    {
                        IdActividadMilitar = 0,
                    };
                }
                return PartialView(actividad);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public JsonResult ActMilitarCUD(ActividadMIlitarVM datos)
        {

            try
            {
                var a = datos.ACTMilitarIDVM;
                if (a.Ingreso == true)
                {
                    a.CausaMotivoNoingreso=null;
                }
                else
                {
                    a.FechaBaja = null;
                    a.FechaIngreso = null;
                    a.MotivoBaja = null;
                    a.Jerarquia = null;
                    a.Cargo = null;
                    a.Destino = null;
                    a.IdSituacionRevista = 0;
                    a.IdBaja = 0;
                }

                db.spActividadMilitarIU(a.IdActividadMilitar, datos.IDPErsona, a.Ingreso, a.FechaIngreso, a.FechaBaja, a.CausaMotivoNoingreso, a.MotivoBaja, a.Jerarquia, a.Cargo, a.Destino, a.IdSituacionRevista, a.IdFuerza, a.IdBaja);
                return Json(new { success = true  , msg = "Se inserto o actulaizo correctamente ACTMilitar" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.InnerException.Message }, JsonRequestBehavior.AllowGet);
            }
            
        }

        public JsonResult EliminaACT(int ID)
        {
            try
            {
                db.spActividadMilitarEliminar(ID);
                return Json(new { success = false, msg = "se elimino correctamente el registro"}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = true, msg = ex.InnerException.Message }, JsonRequestBehavior.AllowGet);
            }
        }

 /*--------------------------------------------------------------SITUACION OCUPACIONAL-------------------------------------------------------------------------------*/
        public ActionResult SituOcupacional(int ID_persona)
        {
            try
            {

                SituacionOcupacionalVM SituOcu = new SituacionOcupacionalVM
                {
                    EstadoDescripcionVM = new SelectList(db.EstadoOcupacional.ToList(), "Id", "Descripcion", "EstadoOcupacional1", 1)
                };

                List<string> InteresesSeleccionados = db.Persona.Find(ID_persona).Interes.Select(m => m.DescInteres).ToList();
                SituOcu.InteresesVM = db.Interes.Select(c => new SelectListItem { Text = c.DescInteres, Value = c.IdInteres.ToString(), Selected = InteresesSeleccionados.Contains(c.DescInteres) ? true : false }).ToList();

                var situ = db.vPersona_SituacionOcupacional.FirstOrDefault(m => m.IdPersona == ID_persona);
                if (situ == null)
                {
                    SituOcu.VPersona_SituacionOcupacionalVM = new vPersona_SituacionOcupacional()
                    {
                        IdSituacionOcupacional = 0,
                        IdPersona = ID_persona,   
                    };
                }
                else
                {
                    SituOcu.VPersona_SituacionOcupacionalVM = situ;
                };

                return PartialView(SituOcu);
            }
            catch (Exception ex)
            {
                return PartialView(ex);
            }
        }

        [HttpPost]
        public ActionResult SituOcupacional(SituacionOcupacionalVM situ)
        {
            try
            {
                var s = situ.VPersona_SituacionOcupacionalVM;
                db.spSituacionOcupacionalIU(s.IdSituacionOcupacional, s.IdPersona, s.IdEstadoOcupacional, s.OcupacionActual, s.Oficio, s.AniosTrabajados, s.DomicilioLaboral);

                Interes ins = new Interes();
                var per = db.Persona.Find(s.IdPersona).Interes;
                per.Clear();
                if (situ.IdInteres != null)
                {
                    foreach (var item in situ.IdInteres)
                    {
                        ins = db.Interes.Find(Double.Parse(item));
                        per.Add(ins);
                    };
                };
                db.SaveChanges();
                return Json(new { success = true, msg = "exito en guardar la situacion ocupacional" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.InnerException.Message });
            }
        }

        /*--------------------------------------------------------------Antropometria------------------------------------------------------------------------------*/
        public ActionResult Antropometria(int ID_persona)
        {
            vPersona_Antropometria antropo = db.vPersona_Antropometria.FirstOrDefault(m=>m.IdPersona == ID_persona);
            return PartialView(antropo);
        }
        [HttpPost]
        public ActionResult Antropometria(vPersona_Antropometria a)
        {
            try
            {
                db.spAntropometriaIU(a.IdPersona, a.Altura, a.Peso, a.IMC, a.PerimCabeza, a.PerimTorax, a.PerimCintura, a.PerimCaderas, a.LargoPantalon, a.LargoEntrep, a.LargoFalda, a.Cuello, a.Calzado);
                return Json(new { success = true, msg = "exito en guardar la situacion ocupacional" });
            }
            catch (Exception ex )
            {
                return Json(new { success = false, msg = ex.InnerException.Message});
            }

        }

        /*--------------------------------------------------------------FAMILIA------------------------------------------------------------------------------*/
        public ActionResult Familia(int ID_persona)
        {
            try
            {
                List<vPersona_Familiar> FAMI ;
                FAMI = db.vPersona_Familiar.Where(m => m.IdPersonaPostulante == ID_persona).ToList();
                return PartialView(FAMI);
            }
            catch (Exception )
            {
                return View();
            }
        }

        //recibo el idFamilia, si es 0 creo  una personaFamilia y su relacion.
        public ActionResult FamiliaCUD(int idPersonaFamilia)
        { 
            //viewmodel creado para la creacion de un familiar
            //cargo los datos necesarios para los combobox
            PersonaFamiliaVM pers = new PersonaFamiliaVM
            {
                vParentecoVM = db.vParentesco.Select(m => new SelectListItem { Value = m.idParentesco.ToString(), Text = m.Relacion }).ToList(),
                SexoVM = db.Sexo.Select(m => new SelectListItem { Value = m.IdSexo.ToString(), Text = m.Descripcion }).Where(m => m.Value != "4").ToList(),
                vEstCivilVM = db.vEstCivil.Select(m => new SelectListItem { Value = m.Codigo_n, Text = m.Descripcion }).ToList(),
                ReligionVM = db.vRELIGION.Select(m => new SelectListItem { Value = m.CODIGO, Text = m.DESCRIPCION }).ToList(),
                TipoDeNacionalidadVm = db.TipoNacionalidad.Select(m => new SelectListItem { Value = m.IdTipoNacionalidad.ToString(), Text = m.Descripcion }).ToList()
            };
            if (idPersonaFamilia != 0  )
            {
                pers.ID_PER = idPersonaFamilia;
                pers.vPersona_FamiliarVM = db.vPersona_Familiar.FirstOrDefault(m => m.IdPersonaFamiliar == idPersonaFamilia);
            }
            else
            {
                pers.ID_PER = idPersonaFamilia;
                var IdAspUser = db.AspNetUsers.FirstOrDefault(e => e.Email == User.Identity.Name).Id;
                pers.vPersona_FamiliarVM = new vPersona_Familiar();
                pers.vPersona_FamiliarVM.IdPersonaPostulante = db.Postulante.FirstOrDefault(e => e.IdAspNetUser == IdAspUser).IdPersona;
                pers.vPersona_FamiliarVM.IdFamiliar = 0;
                pers.vPersona_FamiliarVM.IdPersonaFamiliar = 0;
            }
            return View(pers);
        }

        [HttpPost]
        public JsonResult FamiliaCUD(SINU.ViewModels.PersonaFamiliaVM fami)
        {
            if (ModelState.IsValid)
            {
                var datos = fami.vPersona_FamiliarVM;
                int? idpersonafamiliar = 0;
                try
                {
                    db.spPERSONAFamiliarIU(datos.IdPersonaFamiliar, datos.IdPersonaPostulante, datos.Email, datos.Apellido, datos.Nombres, datos.IdSexo, datos.FechaNacimiento, datos.DNI, datos.CUIL,
                    datos.IdReligion, datos.IdEstadoCivil, datos.FechaCasamiento, datos.Telefono, datos.Celular, datos.Mail, datos.idTipoNacionalidad, 0, datos.idParentesco, datos.Vive, datos.ConVive);
                    if (datos.IdPersonaFamiliar==0)
                    {
                        idpersonafamiliar = db.vPersona_Familiar.FirstOrDefault(d => d.DNI == datos.DNI).IdPersonaFamiliar;
                    }
                    return Json(new { success = true, msg = "Creacion/Modificacion del Familiar Exitoso!!!",accion= idpersonafamiliar });
                }
                catch (Exception ex)
                {
                    return Json(new {success= false, msg = ex.InnerException.Message});
                    
                }
            }
            return Json(new {success= false, msg= "MOdelono valido" });
        }
  
        /*--------------------------------------------------------------POSTULANTE------------------------------------------------------------------------------*/

        public JsonResult SolicitudEntrevista(int ID_persona)
        {
            try
            {
                int secu = db.vInscripcionEtapaEstadoUltimoEstado.FirstOrDefault(m => m.IdPersona == ID_persona).IdSecuencia;
                //Verificar como realizar la validadcion sobre la edad con respecto  a la institucion a inscribirse
                //if (true)
                //{
                //    //asumo que cumple con el requisito con respecto a la edad y lo coloco en la secuencia 7= DATOS BASICOS/ VALIDADO
                //    db.spProximaSecuenciaEtapaEstadov2(p.IdPostulante, 0, 7);
                //};
             
                //    db.spProximaSecuenciaEtapaEstado(ID_persona, 0);
                //    return Json(new { success = true, msg = "Exitoso el cambio de Secuecia" });
                //}
                return Json(new { success = false, msg = "Numero de secuencia diferente al esperado, se esperaba secuencia 6" });
            }
            catch (Exception ex )
            {

                return Json(new { success = false, msg = ex.InnerException.Message });
            }
        }
    }
}
