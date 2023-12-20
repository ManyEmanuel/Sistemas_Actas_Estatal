using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class T_Casilla_VM
    {
        public T_Casilla CasillaDet { get; set; }
        public IEnumerable<SelectListItem> LSeccion { get; set; }
        public IEnumerable<SelectListItem> LTipoCasilla { get; set; }
    }
}
