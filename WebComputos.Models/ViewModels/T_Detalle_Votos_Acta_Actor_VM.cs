using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.Models.ViewModels
{
    public class T_Detalle_Votos_Acta_Actor_VM
    {
        public T_Detalle_Votos_Acta_Actor DetalleVotosActorPol { get; set; }
        public T_Acta_Detalle DetallesActas { get; set; }
    }
}
