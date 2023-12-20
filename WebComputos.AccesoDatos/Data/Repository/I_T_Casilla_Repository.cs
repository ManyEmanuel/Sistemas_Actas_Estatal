using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Casilla_Repository: IRepositor<T_Casilla>
    {
        IEnumerable<SelectListItem> GetListaTipoCasilla();

        IEnumerable<T_Casilla> GetListaCasillaMunicipio(int mun);


        void Update(T_Casilla CasillaDet);
    }
}
