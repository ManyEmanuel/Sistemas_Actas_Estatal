using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Tipo_Casilla_Repository : Repository<T_Tipo_Casilla> , I_T_Tipo_Casilla_Repository
    {
        private ApplicationDbContext _db;

        public T_Tipo_Casilla_Repository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaTipoCasilla()
        {
            return _db.Tipos_Casilla.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public void Update(T_Tipo_Casilla TipoCasilla)
        {
            var ObjBd = _db.Tipos_Casilla.FirstOrDefault(s => s.Id == TipoCasilla.Id);
            ObjBd.Nombre = TipoCasilla.Nombre;
            ObjBd.Siglas = TipoCasilla.Siglas;
            _db.SaveChanges();
        }
    }
}
