using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebComputos.Models.ViewModels
{
    public class T_Acta_Detalle_VM
    {
        public T_Acta_Detalle DetallesActas { get; set; }
        public IEnumerable<SelectListItem> LdetalleActa { get; set; }

    }
}
