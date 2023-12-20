using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Combinacion_Repository :IRepositor<T_Combinacion>
    {
        IEnumerable<SelectListItem> GetListaCombinaciones();

        void Update(T_Combinacion combi);
    }
}
