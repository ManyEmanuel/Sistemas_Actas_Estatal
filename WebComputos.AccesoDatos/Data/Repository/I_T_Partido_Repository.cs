using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Partido_Repository: IRepositor<T_Partido> 
    {
        IEnumerable<SelectListItem> GetListPartidos();
        void Update(T_Partido Partido);
    }
}
