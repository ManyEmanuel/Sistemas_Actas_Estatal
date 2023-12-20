using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class T_Candidato_VM
    {
        public T_Candidato Candidato { get; set; }
        public IEnumerable<SelectListItem> LTipoEleccion { get; set; }
        public IEnumerable<SelectListItem> Lmunicipio { get; set; }
        public IEnumerable<SelectListItem> LDistrito { get; set; }
        public IEnumerable<SelectListItem> LDemarcacion { get; set; }
        public IEnumerable<SelectListItem> LCoalicion { get; set; }
        public IEnumerable<SelectListItem> LPartido { get; set; }
    }
}
