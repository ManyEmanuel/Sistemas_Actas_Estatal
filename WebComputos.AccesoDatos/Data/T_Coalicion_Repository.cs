using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Coalicion_Repository : Repository<T_Coalicion>, I_T_Coalicion_Repository
    {
        private ApplicationDbContext _db;
        public T_Coalicion_Repository(ApplicationDbContext db):base (db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaCoalicion()
        {
            return _db.Coaliciones.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public void Update(T_Coalicion Coalicion)
        {
            var Objbd = _db.Coaliciones.FirstOrDefault(x => x.Id == Coalicion.Id);
            Objbd.Nombre = Coalicion.Nombre;
            Objbd.Siglas = Coalicion.Siglas;
            Objbd.LogoURL = Coalicion.LogoURL;
        }
    }
}
