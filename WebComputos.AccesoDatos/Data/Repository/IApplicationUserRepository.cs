using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface IApplicationUserRepository : IRepositor<T_Usuario>
    {
        IEnumerable<SelectListItem> GetListaUsuarios();
        void Update(T_Usuario user);
    }
}
