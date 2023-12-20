using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Oficina_Repository : IRepositor<T_Oficina>
    {
        IEnumerable<SelectListItem> GetListaOficina();
        void Update(T_Oficina Oficina);
    }
}