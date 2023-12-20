using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Actas_RP_Repository: IRepositor<T_Acta_RP>
    {
        IEnumerable<T_Acta_RP> CargarTablaRP(int Mun, int Ele);

    }
}
