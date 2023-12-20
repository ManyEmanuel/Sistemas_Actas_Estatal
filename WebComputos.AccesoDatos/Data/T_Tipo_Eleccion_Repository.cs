using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class T_Tipo_Eleccion_Repository: Repository<T_Tipo_Eleccion>, I_T_Tipo_Eleccion_Repository
    {
        private ApplicationDbContext _db;
        public T_Tipo_Eleccion_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaTipoEleccion()
        {
            return _db.Tipos_Eleccion.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public void Update(T_Tipo_Eleccion TipoEleccion)
        {
            var ObjBd = _db.Tipos_Eleccion.FirstOrDefault(s => s.Id == TipoEleccion.Id);
            ObjBd.Nombre = TipoEleccion.Nombre;
            ObjBd.Siglas = TipoEleccion.Siglas;
            _db.SaveChanges();

        }
    }
}
