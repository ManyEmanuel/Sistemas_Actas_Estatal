using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Actas_Repository : IRepositor<T_Acta>
    {
        IEnumerable<SelectListItem> GetListaActas();
        IEnumerable<SelectListItem> ListaSeccionInfoComByMunicipioGob(int Municipio);
        IEnumerable<SelectListItem> ListaSeccionInfoComByMunicipioPys(int Municipio);
        IEnumerable<SelectListItem> ListaSeccionInfoComByMunicipioDip(int Municipio, int Distrito);
        IEnumerable<SelectListItem> ListaSeccionInfoComByMunicipioReg(int Municipio, int Demarcacion);
        IEnumerable<SelectListItem> ComprobarDipRP(int Municipio);
        IEnumerable<SelectListItem> ComprobarRegRP(int Municipio);

        IEnumerable<SelectListItem> ListaSeccionInfoComByMunicipioDipRP(int Municipio);
        IEnumerable<SelectListItem> ListaSeccionInfoComByMunicipioRegRP(int Municipio);
        IEnumerable<AvancePaquetes> GetPorcentajeDocumentos(int Municipio);
        IEnumerable<AvanceEstatal> ListaAvanceEstatal();
        IEnumerable<T_Acta_Detalle> RegistroCausal(int id, int estatus);
        IEnumerable<T_Acta_Detalle> RegistroCausalRP(int id, int estatus);
        IEnumerable<T_Acta_Detalle> CargarCombo(int id, int mun, int ele);
        IEnumerable<T_Acta_Detalle_RP> CargarComboRP(int id, int mun, int ele);
        IEnumerable<T_Acta> CargarTabla(int Mun,int Ele,int DD);

        IEnumerable<T_Acta> CargarTablaComplementaria(int Ele);
        IEnumerable<SelectListItem> ListaSeccion(int Municipio, int Eleccion, int DR);
        IEnumerable<SelectListItem> ListaSeccionRP(int Municipio, int Eleccion);
        IEnumerable<ElementosListas> CargarTablasElecciones(int Municipio, int Eleccion, int DR);
        IEnumerable<ElementosListas> CargarTablasEleccionesRP(int Municipio, int Eleccion);
        IEnumerable<SelectListItem> ListaCasilla(int Seccion, int Eleccion);
        IEnumerable<SelectListItem> ListaCasillaRP(int Seccion, int Eleccion);

        IEnumerable<DocumentosEntregados> ListaDocumentosEntregados(int id);
        void EliminarComplementaria(int CasillaDetalle, int Eleccion);
        IEnumerable<T_HistorialModificaciones> GetListaComplementariaModificacion();

        IEnumerable<T_HistorialModificaciones> GetListaComplementariaHistorial();
        IEnumerable<T_HistorialModificaciones> GetListaVotosModificacion();

        IEnumerable<T_HistorialModificaciones> GetListaVotosHistorial();



    }
}
