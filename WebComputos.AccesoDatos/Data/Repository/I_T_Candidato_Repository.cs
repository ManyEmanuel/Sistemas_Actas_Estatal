using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Candidato_Repository : IRepositor<T_Candidato>
    {
       // IEnumerable<SelectListItem> GetListaCandidato();
        void Update(T_Candidato Candidato);
    }
}
