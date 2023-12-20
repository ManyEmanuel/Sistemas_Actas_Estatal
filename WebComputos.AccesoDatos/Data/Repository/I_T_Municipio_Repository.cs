using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Municipio_Repository: IRepositor<T_Municipio> 
    {
        IEnumerable<SelectListItem> GetListaMunicipio();

        void Update(T_Municipio municipio);

    }
}
