using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_HistorialSubsanar_Repository : IRepositor<T_HistorialSubsanar>
    {
        public List<T_HistorialSubsanar> Historial();

        public List<T_HistoricoRestablecer> Historico();

        public List<T_HistoricoRestablecer> HistoricoMunicipal(int id);

        public List<T_HistorialSubsanar> Solicitudes();
        public List<T_HistorialSubsanar> HistorialMunicipio(int id);
        public List<T_Recepcion_Paquete> Recepcion();
    }
}
