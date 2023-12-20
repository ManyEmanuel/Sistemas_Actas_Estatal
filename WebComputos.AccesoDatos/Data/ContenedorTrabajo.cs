using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.AccesoDatos.Migrations;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Acta = new T_Actas_Repository(_db);
            Distrito = new T_Distrito_Repository(_db);
            Municipio = new T_Municipio_Repository(_db);
            Demarcacion = new T_Demarcacion_Repository(_db);
            Seccion = new T_Seccion_Repository(_db);
            TipoEleccion = new T_Tipo_Eleccion_Repository(_db);
            TipoCasilla = new T_Tipo_Casilla_Repository(_db);
            TipoActa = new T_Tipo_Acta_Repository(_db);
            Casilla = new T_Casilla_Repository(_db);
            Coalicion = new T_Coalicion_Repository(_db);
            Partido = new T_Partido_Repository(_db);
            Coalicion_Detalle = new T_Detalle_Coalicion(_db);
            Candidato = new T_Candidato_Repository(_db);
            Recepcion = new T_Recepcion_Paquete_Repository(_db);
            Resultados_Actas = new ResultadosActasRepository(_db);
            Combinacion = new T_Combinacion_Repository(_db);
            Combinacion_Detalle = new T_Detalle_Combinacion_Repository(_db);
            //RecepcionDetalle = new RecepcionDetalleRepository(_db);
            EstatusActa = new T_Estatus_Acta_Repository(_db);
            Causales = new T_Causal_Repository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            Oficina = new T_Oficina_Repository(_db);
            ActasDetalles = new T_Acta_Detalle_Repository(_db);
            Votos_Actas = new T_Votos_Acta_Repository(_db);
            Detalle_Votos_Acta = new T_Detalle_Votos_Acta_Repository(_db);
            Detalle_Votos_Acta_Actor = new T_Detalle_Votos_Acta_Actor_Repository(_db);
            //EstatusEntrega = new EstatusEntregaRepository(_db);
            Puntos_Recuento = new T_Puntos_Recuento_Repository(_db);
            Detalle_Votos_Acta_Partido = new T_Detalle_Votos_Acta_Partido_Repository(_db);
            UbicaCasilla = new UbicaCasillaRepository(_db);
            Detalle_Acta_Computo = new T_Detalle_Acta_Computo_Repository(_db);
            Actas_RP = new T_Actas_RP_Repository(_db);
            Actas_Detalle_RP = new T_Acta_RP_Detalle_Repository(_db);
            Detalle_Votos_Acta_RP = new T_Detalle_Votos_Acta_RP_Repository(_db);
            Votos_Actas_RP = new T_Votos_Acta_RP_Repository(_db);
            Detalle_Acta_Computo_RP = new T_Detalle_Acta_Computo_RP_Repository(_db);
            Acta_Extranjero = new T_Acta_Extranjero_Repository(_db);
            Votos_Acta_Ext = new T_Votos_Actas_Ext_Repository(_db);
            Detalle_Votos_Ext = new T_Detalle_Votos_Ext_Repository(_db);
            HistorialSubsanar = new T_HistorialSubsanar_Repository(_db);
            HistoricoRestablecer = new T_HistoricoRestablecer_Repository(_db);
            HistorialModificacion = new T_HistorialModificacion_Repository(_db);



        }
        public I_T_Actas_Repository Acta { get; private set; }
        public I_T_Distrito_Repository Distrito { get; private set; }
        public I_T_Municipio_Repository Municipio { get; private set; }
        public I_T_Demarcacion_Repository Demarcacion { get; private set; }
        public I_T_Seccion_Repository Seccion { get; private set; }
        public I_T_Tipo_Eleccion_Repository TipoEleccion { get; private set; }
        public I_T_Tipo_Casilla_Repository TipoCasilla { get; private set; }
        public I_T_Tipo_Acta_Repository TipoActa { get; private set; }
        public I_T_Casilla_Repository Casilla { get; private set; }
        public I_T_Coalicion_Repository Coalicion { get; private set; }
        public I_T_Partido_Repository Partido { get; private set; }
        public I_T_Detalle_Coalicion Coalicion_Detalle { get; private set; }
        public I_T_Candidato_Repository Candidato { get; private set; }
        public I_T_Recepcion_Paquete_Repository Recepcion { get; private set; }
        public IResultadosActasRepository Resultados_Actas { get; private set; }

        public I_T_Oficina_Repository Oficina { get; private set; }
        
        public I_T_Detalle_Combinacion_Repository Combinacion_Detalle { get; private set; }

        public I_T_Combinacion_Repository Combinacion { get; private set; }
        //public IRecepcionDetalleRepository RecepcionDetalle { get; private set; }
        public I_T_Estatus_Acta_Repository EstatusActa { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }
        public I_T_Causal_Repository Causales { get; private set; }
        public I_T_Acta_Detalle_Repository ActasDetalles { get; private set; }
        public I_T_Votos_Acta_Repository Votos_Actas { get; private set; }
        public I_T_Detalle_Votos_Acta_Repository Detalle_Votos_Acta { get; private set; }
        public I_T_Detalle_Votos_Acta_Actor_Repository Detalle_Votos_Acta_Actor { get; private set; }
        //public IEstatusEntregaRepository EstatusEntrega { get; private set; }
        public I_T_Puntos_Recuento_Repository Puntos_Recuento { get; private set; }
        public I_T_Detalle_Votos_Acta_Partido_Repository Detalle_Votos_Acta_Partido { get; private set; }

        public IUbicaCasillaRepository UbicaCasilla { get; private set; }
        public I_T_Detalle_Acta_Computo_Repository Detalle_Acta_Computo { get; private set; }

        public I_T_Actas_RP_Repository Actas_RP { get; private set; }
        public I_T_Acta_Detalle_RP_Repository Actas_Detalle_RP { get; private set; }
        public I_T_Detalle_Votos_Acta_RP_Repository Detalle_Votos_Acta_RP { get; private set; }
        public I_T_Votos_Acta_RP_Repository Votos_Actas_RP { get; private set; }
        public I_T_Detalle_Acta_Computo_RP_Repository Detalle_Acta_Computo_RP { get; private set; }

        public I_T_Acta_Extranjero_Repository Acta_Extranjero { get; private set; }

        public I_T_Votos_Acta_Ext_Repository Votos_Acta_Ext { get; private set; }

        public I_T_Detalle_Votos_Ext_Repository Detalle_Votos_Ext { get; private set; }
        public I_T_HistorialSubsanar_Repository HistorialSubsanar { get; private set; }
        public I_T_HistoricoRestablecer_Repository HistoricoRestablecer { get; private set; }
        public I_T_HistorialModificacion_Repository HistorialModificacion { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
