using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models.ViewModels;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface IUbicaCasillaRepository : IRepositor<UbicaCasillaVM>
    {
        IEnumerable<ReporteUbica> GetListaUbica(int tipo, int id);



    }
}
