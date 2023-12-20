using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class T_Tipo_Acta_VM
    {
        public T_Tipo_Acta TipoActa { get; set; }
        public IEnumerable<SelectListItem> LEleccion { get; set; }
    }
}
