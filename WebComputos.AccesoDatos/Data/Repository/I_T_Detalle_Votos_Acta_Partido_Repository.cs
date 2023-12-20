using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Detalle_Votos_Acta_Partido_Repository : IRepositor<T_Detalle_Votos_Acta_Partido>
    {
        /*Resultados de las cabeceras*/
        IEnumerable<ElementosListas> ResultadosCabecera();
        IEnumerable<ElementosListas> ResultadosCabeceraGobPys(int eleccion, int Municipio);
        IEnumerable<ElementosListas> ResultadosCabeceraDip(int Municipio, int Distrito);
        IEnumerable<ElementosListas> ResultadosCabeceraReg(int Municipio, int Demarcacion);
        IEnumerable<ElementosListas> ResultadosCabeceraGobPysCompleta(int eleccion, int Municipio);
        IEnumerable<ElementosListas> ResultadosCabeceraDipCompleta(int Municipio, int Distrito);
        IEnumerable<ElementosListas> ResultadosCabeceraRegCompleta(int Municipio, int Demarcacion);
        /*Resultados de las actas*/
        IEnumerable<ElementosListas> GobernadorPorMunicipio(int Municipio);
        IEnumerable<ElementosListas> GobernadorEstatal();
        IEnumerable<ElementosListas> PySMunicipio(int Municipio);
        IEnumerable<ElementosListas> DiputadosMunicipioDistrito(int Municipio, int Distrito);
        IEnumerable<ElementosListas> DiputadosDistrito(int Distrito);
      
        IEnumerable<ElementosListas> RegidorMunicipioDemarcacion(int Municipio, int Demarcacion);

        /*Resultados de las actas por actor politico*/

        IEnumerable<ElementosListas> GobernadorPorMunicipioActorPolitico(int Municipio);
        IEnumerable<ElementosListas> GobernadorEstatalActorPolitico();
        IEnumerable<ElementosListas> PySMunicipioActorPolitico(int Municipio);
        IEnumerable<ElementosListas> DiputadosMunicipioDistritoActorPolitico(int Municipio, int Distrito);
        IEnumerable<ElementosListas> DiputadosDistritoActorPolitico(int Distrito);

        IEnumerable<ElementosListas> RegidorMunicipioDemarcacionActorPolitico(int Municipio, int Demarcacion);
    }
}
