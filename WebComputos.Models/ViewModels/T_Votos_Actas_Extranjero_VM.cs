using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class T_Votos_Actas_Extranjero_VM
    {
        public T_Votos_Acta_Ext Votos_Ext {get;set;}
        public IList<T_Detalle_Votos_Ext> DetalleVotosExt { get; set; }
    }
}
