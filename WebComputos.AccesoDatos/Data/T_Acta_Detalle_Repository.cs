using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Acta_Detalle_Repository : Repository<T_Acta_Detalle>, I_T_Acta_Detalle_Repository
    {
        private readonly ApplicationDbContext _db;

        public T_Acta_Detalle_Repository (ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<SelectListItem> GetListaDetActa()
        {
            return _db.Actas_Detalle.Select(i => new SelectListItem()
            {
                Text = i.CapturadoVotos.ToString(),
                Value = i.IdActaDetalle.ToString()
            });
        }
    }
}
