using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class MenuDinamicoVM
    {
        
            public IEnumerable<T_Demarcacion> LDemarcaciones;
            public IEnumerable<T_Seccion> Lsecciones;
            public IEnumerable<T_Acta_Detalle_RP> LActaRP; 
            public List<int?> LDistrito;
        
    }
}
