
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Acta_Detalle_RP_Repository : IRepositor<T_Acta_Detalle_RP>
    {
        public IEnumerable<SelectListItem> GetListaDetActa();

    }
}
