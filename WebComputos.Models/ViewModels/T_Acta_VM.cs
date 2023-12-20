﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.Models.ViewModels
{
    public class T_Actas_VM
    {
        public T_Acta Actas { get; set; }
        public T_Recepcion_Paquete RecPaquetes { get; set; }
        public IEnumerable<SelectListItem> LRecepcion { get; set; }
        public IEnumerable<SelectListItem>LEstatusActa { get; set; }
        public Models.T_Estatus_Acta Estacta { get; set; }
        public IEnumerable<SelectListItem> LSeccion { get; set; }
        public IEnumerable<SelectListItem> LSeccionPaq { get; set; }
        public IEnumerable<SelectListItem> LSeccionGob { get; set; }
        public IEnumerable<SelectListItem> LSeccionPys { get; set; }
        public IEnumerable<SelectListItem> LSeccionDip { get; set; }
        public IEnumerable<SelectListItem> LSeccionReg { get; set; }





    }
}
