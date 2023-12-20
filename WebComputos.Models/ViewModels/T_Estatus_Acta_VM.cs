using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.Models.ViewModels
{
    public class T_Estatus_Acta_VM
    {
        public Models.T_Estatus_Acta EstatuActa { get; set; }
        public IEnumerable<SelectListItem> LestatusActa { get; set; }
    }
}
