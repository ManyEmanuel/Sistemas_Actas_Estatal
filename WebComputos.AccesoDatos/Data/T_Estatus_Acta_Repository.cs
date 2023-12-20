using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
   public class T_Estatus_Acta_Repository  : Repository<T_Estatus_Acta>, I_T_Estatus_Acta_Repository
    {
        private readonly ApplicationDbContext _db;
        public T_Estatus_Acta_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public T_Estatus_Acta Get(object p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem> GetEstatusActa()
        {
            return _db.Estatus_Acta.Select(i => new SelectListItem()
            {
                Text = i.Descripcion,
                Value = i.IdEstatus.ToString()
            });
        }
    }
}
