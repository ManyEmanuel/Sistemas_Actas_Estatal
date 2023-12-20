using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Tipo_Eleccion_Repository :IRepositor<T_Tipo_Eleccion>
    {
        IEnumerable<SelectListItem> GetListaTipoEleccion();

        void Update(T_Tipo_Eleccion TipoEleccion);
    }
}
