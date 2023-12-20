using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Votos_Acta_Repository : IRepositor<T_Votos_Acta>
    {
        public List<T_Votos_Acta> VotosActas(int Municipio);
        public List<T_Votos_Acta_RP> VotosActasRP(int Municipio);
        public List<T_Detalle_Votos_Acta> DetalleVotos(int Municipio);
        public List<T_Detalle_Votos_Acta_RP> DetalleVotosRP(int Municipio);
        public List<ElementosListas> TablasVotos(int Eleccion);
        public void EliminarVotos(int CasillaDetalle, int Eleccion);


    }
}
