using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class T_Recepcion_Paquete_VM
    {
        public T_Casilla Casilla { get; set; }
        public string Municipio { get; set; }
        public string NSeccion { get; set; }
        public string Demarcacion { get; set; }
        public string NombreCas { get; set; }
        public string Distrito { get; set; }

        public int Value { get; set; }
        public T_Recepcion_Paquete RecPaquetes { get; set; }

        public T_Seccion Seccion { get; set; }

        public IEnumerable<T_Recepcion_Paquete> LRecepcion { get; set; }
        public IEnumerable<SelectListItem> LSeccion { get; set; }
        public IEnumerable<SelectListItem> LSeccionPaq { get; set; }
        public IEnumerable<SelectListItem> LTipoCasilla { get; set; }
        public IEnumerable<T_Casilla> LCasillaDet { get; set; }
    }
}
