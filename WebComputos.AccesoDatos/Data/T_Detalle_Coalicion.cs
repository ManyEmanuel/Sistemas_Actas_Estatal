using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class T_Detalle_Coalicion : Repository<Models.T_Detalle_Coalicion>, I_T_Detalle_Coalicion
    {
        private ApplicationDbContext _db;

        public T_Detalle_Coalicion(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaCoalicion()
        {
            return _db.Detalle_Coaliciones.Select(i => new SelectListItem()
            {

            });
        }

        public void Update(Models.T_Detalle_Coalicion coaliciondet)
        {
            var Obj = _db.Detalle_Coaliciones.FirstOrDefault(s => s.Id == coaliciondet.Id);
            Obj.Activo = coaliciondet.Activo;
            Obj.Coalicion = coaliciondet.Coalicion;
            Obj.Partido = coaliciondet.Partido;
            
        }
    }
}
