using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class T_Tipo_Acta_Repository : Repository<T_Tipo_Acta>, I_T_Tipo_Acta_Repository
    {
        private ApplicationDbContext _db;

        public T_Tipo_Acta_Repository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaTipoActa()
        {
            return _db.Tipos_Acta.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public void Update(T_Tipo_Acta TipoActa)
        {
            var Objbd = _db.Tipos_Acta.FirstOrDefault(s => s.Id == TipoActa.Id);
            Objbd.Nombre = TipoActa.Nombre;
            Objbd.TipoEleccion = TipoActa.TipoEleccion;
            _db.SaveChanges();
        }
    }
}
