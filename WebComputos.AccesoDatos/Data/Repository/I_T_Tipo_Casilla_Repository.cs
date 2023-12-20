using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Tipo_Casilla_Repository : IRepositor<T_Tipo_Casilla> 
    {

        IEnumerable<SelectListItem> GetListaTipoCasilla();

        void Update(T_Tipo_Casilla TipoCasilla);
    }
}
