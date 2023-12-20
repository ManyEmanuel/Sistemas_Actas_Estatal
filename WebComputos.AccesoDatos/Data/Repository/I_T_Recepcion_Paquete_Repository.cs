using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;
using WebComputos.Models.ViewModels;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Recepcion_Paquete_Repository : IRepositor<T_Recepcion_Paquete>
    {
        IEnumerable<SelectListItem> GetListaRecepcion();

        IEnumerable<ElementosListas> GetListaPaquetesByMun(int mun);
        IEnumerable<T_HistorialModificaciones> GetListaPaquetesModificacion();

        IEnumerable<T_HistorialModificaciones> GetListaPaquetesHistorial();
        IEnumerable<AvancePaquetes> GetAvancePaquetes();
        IEnumerable<DetallePaquete> GetDetallePaquetes(int mun);
        IEnumerable<T_Recepcion_Paquete> GetPaquetes(int mun);

        IEnumerable<ConCausal> ConCausales(int mun, int ele, int tip);

        IEnumerable<SinCausal> SinCausales(int mun, int ele, int tip);

        IEnumerable<SelectListItem> ObtenerCasilla(int seccion, int municipio);

        IEnumerable<T_Acta_Detalle> CapturaCompleta(int mun);

        IEnumerable<SelectListItem> ListaDD(int mun, int ele);

        IEnumerable<T_Acta_Detalle> CapturaCompletaDD(int mun, int ele, int DD);

        void EliminarPaquetes(int casilla);

    }
}
