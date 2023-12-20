using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class T_Distrito_Repository : Repository<T_Distrito>, I_T_Distrito_Repository
    {

        private readonly ApplicationDbContext _db;

        public T_Distrito_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public List<int?> DistritoBySeccion(int idmun)
        {
            var distrito = _db.Secciones.Where(x => x.MunicipioId == idmun).OrderBy(x=> x.DistritoId).Select(x=> x.DistritoId).Distinct().ToList();
          
            return distrito;
        }

        public IEnumerable<SelectListItem> GetListaDistrito()
        {
            return _db.Distritos.Select(i => new SelectListItem()
            {
                Text = "Distrito "+i.NoDistrito.ToString(),
                Value = i.Id.ToString()
            });
        }

        public void Update(T_Distrito distrito)
        {
            var ObjBd = _db.Distritos.FirstOrDefault(s => s.Id == distrito.Id);
            ObjBd.Nombre = distrito.Nombre;
            _db.SaveChanges();
        }
    }
}
