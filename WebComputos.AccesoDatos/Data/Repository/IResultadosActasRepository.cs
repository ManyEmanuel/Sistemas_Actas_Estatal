using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface IResultadosActasRepository : IRepositor<T_Votos_Acta>
    {
       

        IEnumerable<ElementosListas> SegundoLugarEleccion(int Municipio, int eleccion, int DR);

        IEnumerable<T_Votos_Acta> ResultadosExcel(int Eleccion);

        IEnumerable<T_Detalle_Votos_Acta> VotosExcel(int Eleccion);

        IEnumerable<T_Causal_Recuento> Causales (int Eleccion);

        IEnumerable<T_Acta> Complementaria(int Eleccion);

        IEnumerable<T_Acta> ComplementariaMunicipal(int Eleccion, int Municipio);


        IEnumerable<T_Votos_Acta> ResultadosExcelMunicipal(int Eleccion, int Municipio);

        IEnumerable<T_Detalle_Votos_Acta> VotosExcelMunicipal(int Eleccion, int Municipio);

        IEnumerable<T_Causal_Recuento> CausalesMunicipal(int Eleccion, int Municipio);

        IEnumerable<T_Recepcion_Paquete> Paquetes();

        IEnumerable<T_Recepcion_Paquete> PaquetesINE();
        IEnumerable<T_Recepcion_Paquete> PaquetesMunicipal(int Municipio);

        IEnumerable<T_HistorialModificaciones> GetListaVotosModificacion();

        IEnumerable<T_HistorialModificaciones> GetListaVotosHistorial();

    }
}
