﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SINUEntities : DbContext
    {
        public SINUEntities()
            : base("name=SINUEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ActividadMilitar> ActividadMilitar { get; set; }
        public virtual DbSet<Baja> Baja { get; set; }
        public virtual DbSet<Configuracion> Configuracion { get; set; }
        public virtual DbSet<DocPresentado> DocPresentado { get; set; }
        public virtual DbSet<Domicilio> Domicilio { get; set; }
        public virtual DbSet<EstablecimientoRindeExamen> EstablecimientoRindeExamen { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<EstadoOcupacional> EstadoOcupacional { get; set; }
        public virtual DbSet<Estudio> Estudio { get; set; }
        public virtual DbSet<Etapa> Etapa { get; set; }
        public virtual DbSet<Familiares> Familiares { get; set; }
        public virtual DbSet<Fuerza> Fuerza { get; set; }
        public virtual DbSet<Inscripcion> Inscripcion { get; set; }
        public virtual DbSet<Institucion> Institucion { get; set; }
        public virtual DbSet<Institutos> Institutos { get; set; }
        public virtual DbSet<NiveldEstudio> NiveldEstudio { get; set; }
        public virtual DbSet<NivelIdioma> NivelIdioma { get; set; }
        public virtual DbSet<OficinasYDelegaciones> OficinasYDelegaciones { get; set; }
        public virtual DbSet<PeriodosInscripciones> PeriodosInscripciones { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<PersonaIdioma> PersonaIdioma { get; set; }
        public virtual DbSet<Postulante> Postulante { get; set; }
        public virtual DbSet<PostulanteViaje> PostulanteViaje { get; set; }
        public virtual DbSet<Preferencia> Preferencia { get; set; }
        public virtual DbSet<Secuencia_EtapaEstado> Secuencia_EtapaEstado { get; set; }
        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<SituacionOcupacional> SituacionOcupacional { get; set; }
        public virtual DbSet<SituacionRevista> SituacionRevista { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipoDocPresentado> TipoDocPresentado { get; set; }
        public virtual DbSet<TipoNacionalidad> TipoNacionalidad { get; set; }
        public virtual DbSet<InscripcionEtapaEstado> InscripcionEtapaEstado { get; set; }
        public virtual DbSet<vEstCivil> vEstCivil { get; set; }
        public virtual DbSet<vLOCALIDAD> vLOCALIDAD { get; set; }
        public virtual DbSet<vParentesco> vParentesco { get; set; }
        public virtual DbSet<vPeriodosInscrip> vPeriodosInscrip { get; set; }
        public virtual DbSet<vProvincia_Depto_Localidad> vProvincia_Depto_Localidad { get; set; }
        public virtual DbSet<vRELIGION> vRELIGION { get; set; }
        public virtual DbSet<vSecuencia_EtapaEstado> vSecuencia_EtapaEstado { get; set; }
        public virtual DbSet<vSeguridad_Grupos> vSeguridad_Grupos { get; set; }
        public virtual DbSet<vSeguridad_Grupos_Usuarios> vSeguridad_Grupos_Usuarios { get; set; }
        public virtual DbSet<vSeguridad_Usuarios> vSeguridad_Usuarios { get; set; }
        public virtual DbSet<vPersona_DatosBasicos> vPersona_DatosBasicos { get; set; }
        public virtual DbSet<vEntrevistaLugarFecha> vEntrevistaLugarFecha { get; set; }
        public virtual DbSet<vInscripcionEtapaEstadoUltimoEstado> vInscripcionEtapaEstadoUltimoEstado { get; set; }
        public virtual DbSet<ConfiguracionAdmin> ConfiguracionAdmin { get; set; }
        public virtual DbSet<vConfiguracionAdmin> vConfiguracionAdmin { get; set; }
        public virtual DbSet<vPersona_DatosPer> vPersona_DatosPer { get; set; }
        public virtual DbSet<vPersona_Domicilio> vPersona_Domicilio { get; set; }
        public virtual DbSet<VPersona_Estudio> VPersona_Estudio { get; set; }
        public virtual DbSet<vPersona_Idioma> vPersona_Idioma { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int spIngresaASeguridad(string uSUARIO, string grupo, string mr, string grado, string destino, string nombre, string apellido)
        {
            var uSUARIOParameter = uSUARIO != null ?
                new ObjectParameter("USUARIO", uSUARIO) :
                new ObjectParameter("USUARIO", typeof(string));
    
            var grupoParameter = grupo != null ?
                new ObjectParameter("Grupo", grupo) :
                new ObjectParameter("Grupo", typeof(string));
    
            var mrParameter = mr != null ?
                new ObjectParameter("mr", mr) :
                new ObjectParameter("mr", typeof(string));
    
            var gradoParameter = grado != null ?
                new ObjectParameter("Grado", grado) :
                new ObjectParameter("Grado", typeof(string));
    
            var destinoParameter = destino != null ?
                new ObjectParameter("Destino", destino) :
                new ObjectParameter("Destino", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spIngresaASeguridad", uSUARIOParameter, grupoParameter, mrParameter, gradoParameter, destinoParameter, nombreParameter, apellidoParameter);
        }
    
        public virtual ObjectResult<spPrueba_Result> spPrueba(string uSUARIO, string funcion)
        {
            var uSUARIOParameter = uSUARIO != null ?
                new ObjectParameter("USUARIO", uSUARIO) :
                new ObjectParameter("USUARIO", typeof(string));
    
            var funcionParameter = funcion != null ?
                new ObjectParameter("Funcion", funcion) :
                new ObjectParameter("Funcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spPrueba_Result>("spPrueba", uSUARIOParameter, funcionParameter);
        }
    
        public virtual ObjectResult<spValidarUsuario_Result> spValidarUsuario(string uSUARIO, string funcion)
        {
            var uSUARIOParameter = uSUARIO != null ?
                new ObjectParameter("USUARIO", uSUARIO) :
                new ObjectParameter("USUARIO", typeof(string));
    
            var funcionParameter = funcion != null ?
                new ObjectParameter("Funcion", funcion) :
                new ObjectParameter("Funcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spValidarUsuario_Result>("spValidarUsuario", uSUARIOParameter, funcionParameter);
        }
    
        public virtual int tablasnuevas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tablasnuevas");
        }
    
        public virtual int VaciarASPNETUser(string correoregistrado, Nullable<int> eliminar)
        {
            var correoregistradoParameter = correoregistrado != null ?
                new ObjectParameter("correoregistrado", correoregistrado) :
                new ObjectParameter("correoregistrado", typeof(string));
    
            var eliminarParameter = eliminar.HasValue ?
                new ObjectParameter("eliminar", eliminar) :
                new ObjectParameter("eliminar", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("VaciarASPNETUser", correoregistradoParameter, eliminarParameter);
        }
    
        public virtual int spCreaPostulante(string apellido, string nombre, string dNI, string email, Nullable<int> idPreferenciaInstituto, Nullable<int> idDelegacionOficinaIngresoInscribio)
        {
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var dNIParameter = dNI != null ?
                new ObjectParameter("DNI", dNI) :
                new ObjectParameter("DNI", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var idPreferenciaInstitutoParameter = idPreferenciaInstituto.HasValue ?
                new ObjectParameter("IdPreferenciaInstituto", idPreferenciaInstituto) :
                new ObjectParameter("IdPreferenciaInstituto", typeof(int));
    
            var idDelegacionOficinaIngresoInscribioParameter = idDelegacionOficinaIngresoInscribio.HasValue ?
                new ObjectParameter("IdDelegacionOficinaIngresoInscribio", idDelegacionOficinaIngresoInscribio) :
                new ObjectParameter("IdDelegacionOficinaIngresoInscribio", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spCreaPostulante", apellidoParameter, nombreParameter, dNIParameter, emailParameter, idPreferenciaInstitutoParameter, idDelegacionOficinaIngresoInscribioParameter);
        }
    
        public virtual ObjectResult<string> Vaciar(string valoremail, Nullable<int> eliminandotabla)
        {
            var valoremailParameter = valoremail != null ?
                new ObjectParameter("valoremail", valoremail) :
                new ObjectParameter("valoremail", typeof(string));
    
            var eliminandotablaParameter = eliminandotabla.HasValue ?
                new ObjectParameter("eliminandotabla", eliminandotabla) :
                new ObjectParameter("eliminandotabla", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("Vaciar", valoremailParameter, eliminandotablaParameter);
        }
    
        public virtual int spDatosBasicosUpdate(string apellido, string nombres, Nullable<int> idSexo, string dNI, string telefono, string celular, string email, Nullable<int> idDelegacionOficinaIngresoInscribio, string comoSeEntero, Nullable<int> idPreferencia, Nullable<int> idPersona, Nullable<int> idPostulante)
        {
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var nombresParameter = nombres != null ?
                new ObjectParameter("Nombres", nombres) :
                new ObjectParameter("Nombres", typeof(string));
    
            var idSexoParameter = idSexo.HasValue ?
                new ObjectParameter("IdSexo", idSexo) :
                new ObjectParameter("IdSexo", typeof(int));
    
            var dNIParameter = dNI != null ?
                new ObjectParameter("DNI", dNI) :
                new ObjectParameter("DNI", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var celularParameter = celular != null ?
                new ObjectParameter("Celular", celular) :
                new ObjectParameter("Celular", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var idDelegacionOficinaIngresoInscribioParameter = idDelegacionOficinaIngresoInscribio.HasValue ?
                new ObjectParameter("IdDelegacionOficinaIngresoInscribio", idDelegacionOficinaIngresoInscribio) :
                new ObjectParameter("IdDelegacionOficinaIngresoInscribio", typeof(int));
    
            var comoSeEnteroParameter = comoSeEntero != null ?
                new ObjectParameter("ComoSeEntero", comoSeEntero) :
                new ObjectParameter("ComoSeEntero", typeof(string));
    
            var idPreferenciaParameter = idPreferencia.HasValue ?
                new ObjectParameter("IdPreferencia", idPreferencia) :
                new ObjectParameter("IdPreferencia", typeof(int));
    
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("IdPersona", idPersona) :
                new ObjectParameter("IdPersona", typeof(int));
    
            var idPostulanteParameter = idPostulante.HasValue ?
                new ObjectParameter("IdPostulante", idPostulante) :
                new ObjectParameter("IdPostulante", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spDatosBasicosUpdate", apellidoParameter, nombresParameter, idSexoParameter, dNIParameter, telefonoParameter, celularParameter, emailParameter, idDelegacionOficinaIngresoInscribioParameter, comoSeEnteroParameter, idPreferenciaParameter, idPersonaParameter, idPostulanteParameter);
        }
    
        public virtual int spDatosPersonalesUpdate(Nullable<int> idPersona, string cUIL, Nullable<System.DateTime> fechaNacimiento, string idEstadoCivil, string idReligion, Nullable<int> idTipoNacionalidad)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("IdPersona", idPersona) :
                new ObjectParameter("IdPersona", typeof(int));
    
            var cUILParameter = cUIL != null ?
                new ObjectParameter("CUIL", cUIL) :
                new ObjectParameter("CUIL", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var idEstadoCivilParameter = idEstadoCivil != null ?
                new ObjectParameter("IdEstadoCivil", idEstadoCivil) :
                new ObjectParameter("IdEstadoCivil", typeof(string));
    
            var idReligionParameter = idReligion != null ?
                new ObjectParameter("IdReligion", idReligion) :
                new ObjectParameter("IdReligion", typeof(string));
    
            var idTipoNacionalidadParameter = idTipoNacionalidad.HasValue ?
                new ObjectParameter("idTipoNacionalidad", idTipoNacionalidad) :
                new ObjectParameter("idTipoNacionalidad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spDatosPersonalesUpdate", idPersonaParameter, cUILParameter, fechaNacimientoParameter, idEstadoCivilParameter, idReligionParameter, idTipoNacionalidadParameter);
        }
    }
}
