using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class T_Votos_Actas_RP_VM
    {
        public T_Votos_Acta_RP Votos_Acta { get; set; }
        //public TActas Actas { get; set; }
        public T_Partido Partidos { get; set; }
        public T_Coalicion coalicion { get; set; }
        public T_Combinacion combinaciones { get; set; }
        public IEnumerable<SelectListItem> LActa { get; set; }
        public IEnumerable<SelectListItem> LSeccionGob { get; set; }
        public IEnumerable<SelectListItem> LSeccionPys { get; set; }
        public IEnumerable<SelectListItem> LSeccionDip { get; set; }
        public IEnumerable<SelectListItem> LSeccionReg { get; set; }
        public IList<T_Detalle_Votos_Acta_RP> DetalleVotosActasRPList { get; set; }
        public T_Acta_Detalle_RP DetallesActas { get; set; }
        public T_Detalle_Votos_Acta_RP DetalleVotosActaRP { get; set; }
    }
}
