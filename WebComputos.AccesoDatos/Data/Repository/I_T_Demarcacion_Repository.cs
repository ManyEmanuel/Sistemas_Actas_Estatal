using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Demarcacion_Repository: IRepositor<T_Demarcacion>
    {
        IEnumerable<SelectListItem> GetListaDemarcacion();
        IEnumerable<SelectListItem> DemarcacionMunicipio(int id);

        void Update(T_Demarcacion Demarcacion);
    }
}
