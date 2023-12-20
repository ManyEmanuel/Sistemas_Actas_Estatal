using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Causal_Repository : IRepositor<T_Causal_Recuento>
    {

        IEnumerable<ElementosListas> GetListaCausales(int mun, int ele, int rd);
        IEnumerable<T_Acta_Detalle> CausalesCompletas(int Municipio, int Eleccion, int DD);
        IEnumerable<T_Acta_Detalle> CausalesComplemento(int Municipio, int Eleccion, int DD);

        List<T_Detalle_Votos_Acta> SegundoLugar(int Registro);
        List<T_Detalle_Votos_Acta> SegundoLugarCausal(int Municipio, int Eleccion, int DR);

        void CarmbiarCausal();

    }
}
