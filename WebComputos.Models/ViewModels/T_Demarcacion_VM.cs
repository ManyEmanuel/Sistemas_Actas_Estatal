using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class T_Demarcacion_VM
    {
        public T_Demarcacion Demarcacion { get; set; }
        public IEnumerable<SelectListItem> LMunicipio { get; set; }
    }
}
