using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.Models.ViewModels
{
    public class T_Causal_Recuento_VM
    {
        public T_Causal_Recuento Causales { get; set; }
        public T_Casilla CasillaDet { get; set; }
        public IEnumerable<SelectListItem> LCasillaDet { get; set; }
        
    }
}
