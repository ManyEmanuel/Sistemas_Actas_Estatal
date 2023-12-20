using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Distrito_Repository: IRepositor<T_Distrito>
    {
        IEnumerable<SelectListItem> GetListaDistrito();

        void Update(T_Distrito distrito);

        List<int?> DistritoBySeccion(int idmun);


    }
}
