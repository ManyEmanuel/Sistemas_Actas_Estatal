using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class T_Municipio_Repository : Repository<T_Municipio>, I_T_Municipio_Repository 
    {
        private readonly ApplicationDbContext _db;

        public T_Municipio_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaMunicipio()
        {
            return _db.Municipios.Select(i => new SelectListItem()
            {
                Text = i.Municipio,
                Value = i.Id.ToString()
            });
        }

        public void Update(T_Municipio municipio)
        {
            var ObjBD = _db.Municipios.FirstOrDefault(s => s.Id == municipio.Id);
            ObjBD.NoEstado = municipio.NoEstado;
            ObjBD.Municipio = municipio.Municipio;
            ObjBD.Cabecera_Municipal = municipio.Cabecera_Municipal;
            ObjBD.Estado = municipio.Estado;
            _db.SaveChanges();
        }
    }
}
