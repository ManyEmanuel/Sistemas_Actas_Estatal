using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.Models.ViewModels
{
    public class T_Detalle_Votos_Actas_VM
    {
        public List<T_Votos_Acta> VotosActaGob { get; set; }
        public List<T_Votos_Acta> VotosActaAyu { get; set; }
        public List<T_Votos_Acta> VotosActaDip { get; set; }
        public List<T_Votos_Acta> VotosActaReg { get; set; }
        public List<T_Votos_Acta_RP> VotosActaDipRP { get; set; }
        public List<T_Votos_Acta_RP> VotosActaRegRP { get; set; }
        //-----------------------------------------------------------------------------//
        public List<ElementosCartel> Gobernador { get; set; }
        public List<ElementosCartel> Ayuntamiento { get; set; }
        public List<ElementosCartel> Diputado { get; set; }
        public List<ElementosCartel> Regidor { get; set; }
        public List<T_Detalle_Votos_Acta> RegidorLista { get; set; }
        public List<T_Detalle_Votos_Acta> DiputadoLista { get; set; }
        public List<ElementosCartel> DiputadosRP { get; set; }
        public List<ElementosCartel> RegidoresRP { get; set; }

        //--------------------------------------------------------------------------//
        public List<T_Partido> Partidos { get; set; }
        public List<T_Combinacion> Combinaciones { get; set; }

        //-----------------------------------------------------------------------------//
        public string Municipio { get; set; }
        public int Distrito { get; set; }
        public int CasillasCapturadas { get; set; }
        public int CasillasTotales { get; set; }
        public string HoraFin { get; set; }
        public string DiaFin { get; set; }
        public int TotalDistritos { get; set; }
        public int TotalDemarcaciones { get; set; }

        //--------------------------------------------------------------------------------------------//
        public List<T_Distrito> ListaDistritos { get; set; }
        public List<T_Demarcacion> ListaDemarcacion { get; set; }

    }
}
