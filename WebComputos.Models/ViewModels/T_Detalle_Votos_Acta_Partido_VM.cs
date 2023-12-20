using System;
using System.Collections.Generic;
using System.Text;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.Models.ViewModels
{
    public class T_Detalle_Votos_Acta_Partido_VM
    {
        public T_Detalle_Votos_Acta_Partido DetalleVotosPartidos { get; set; }
        public T_Votos_Acta RegistroVotos { get; set; }
    }
}
