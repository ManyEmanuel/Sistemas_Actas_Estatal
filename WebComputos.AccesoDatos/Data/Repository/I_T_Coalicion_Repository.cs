using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Coalicion_Repository: IRepositor<T_Coalicion>
    {
        IEnumerable<SelectListItem> GetListaCoalicion();
        void Update(T_Coalicion Coalicion);
    }
}
