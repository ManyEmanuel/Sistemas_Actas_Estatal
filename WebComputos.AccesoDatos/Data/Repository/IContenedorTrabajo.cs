using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface IContenedorTrabajo : IDisposable
    {
        I_T_Distrito_Repository Distrito { get; }
        I_T_Municipio_Repository Municipio { get; }
        I_T_Demarcacion_Repository Demarcacion { get; }
        I_T_Seccion_Repository Seccion { get; }
        I_T_Tipo_Eleccion_Repository TipoEleccion { get; }
        I_T_Tipo_Casilla_Repository TipoCasilla { get; }
        I_T_Tipo_Acta_Repository TipoActa { get; }
        I_T_Casilla_Repository Casilla { get; }
        I_T_Coalicion_Repository Coalicion { get; }
        I_T_Partido_Repository Partido { get; }
        I_T_Detalle_Coalicion Coalicion_Detalle { get; }
        I_T_Candidato_Repository Candidato { get; }
        I_T_Recepcion_Paquete_Repository Recepcion { get; }
        I_T_Actas_Repository Acta { get; }   
        IApplicationUserRepository  ApplicationUser { get; }
        IResultadosActasRepository Resultados_Actas { get; }
        I_T_Combinacion_Repository Combinacion { get; }
        I_T_Detalle_Combinacion_Repository Combinacion_Detalle { get; }
        I_T_Estatus_Acta_Repository EstatusActa { get; }
        I_T_Causal_Repository Causales { get; }
        I_T_Oficina_Repository Oficina { get; }
        I_T_Acta_Detalle_Repository ActasDetalles { get; }
        I_T_Votos_Acta_Repository Votos_Actas { get; }
        I_T_Detalle_Votos_Acta_Repository Detalle_Votos_Acta { get; }
        I_T_Detalle_Votos_Acta_Actor_Repository Detalle_Votos_Acta_Actor{ get; }
        I_T_Puntos_Recuento_Repository Puntos_Recuento { get; }
        I_T_Detalle_Votos_Acta_Partido_Repository Detalle_Votos_Acta_Partido { get; }
        IUbicaCasillaRepository UbicaCasilla { get; }
        I_T_Detalle_Acta_Computo_Repository Detalle_Acta_Computo { get; }
        I_T_Actas_RP_Repository Actas_RP { get;}
        I_T_Acta_Detalle_RP_Repository Actas_Detalle_RP { get; }
        I_T_Detalle_Votos_Acta_RP_Repository Detalle_Votos_Acta_RP { get;}
        I_T_Votos_Acta_RP_Repository Votos_Actas_RP { get;}
        I_T_Detalle_Acta_Computo_RP_Repository Detalle_Acta_Computo_RP { get;}

        I_T_Acta_Extranjero_Repository Acta_Extranjero { get; }

        I_T_Votos_Acta_Ext_Repository Votos_Acta_Ext { get; }

        I_T_Detalle_Votos_Ext_Repository Detalle_Votos_Ext { get; }
        I_T_HistorialSubsanar_Repository HistorialSubsanar { get; }
        I_T_HistoricoRestablecer_Repository HistoricoRestablecer { get; }
        I_T_HistorialModificacion_Repository HistorialModificacion { get;}
        void Save();
    }
}
