using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class T_Combinacion_Repository : Repository<T_Combinacion>, I_T_Combinacion_Repository
    {
        private readonly ApplicationDbContext _db;
        public T_Combinacion_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaCombinaciones()
        {
            return _db.Combinaciones.Select(i => new SelectListItem()
            {
                Text = i.Combinacion,
                Value = i.Id.ToString()
            });
        }

        public void Update(T_Combinacion combi)
        {
            throw new NotImplementedException();
        }
    }
}
