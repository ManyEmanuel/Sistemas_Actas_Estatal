using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Detalle_Coalicion : IRepositor<Models.T_Detalle_Coalicion>
    {
        IEnumerable<SelectListItem> GetListaCoalicion();
        void Update(Models.T_Detalle_Coalicion coaliciondet);
    }
}
