using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Estatus_Acta_Repository : IRepositor<T_Estatus_Acta>
    {
        IEnumerable<SelectListItem> GetEstatusActa();
    }
}
