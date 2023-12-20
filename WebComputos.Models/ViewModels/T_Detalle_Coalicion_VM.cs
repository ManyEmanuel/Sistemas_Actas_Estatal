using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class T_Detalle_Coalicion_VM
    {
        public T_Detalle_Coalicion Coalicion { get; set; }
        public IEnumerable<SelectListItem> LCoalicion { get; set; }
        public IEnumerable<SelectListItem> LPartido { get; set; }
    }
}
