using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class T_Demarcacion_Repository: Repository<T_Demarcacion>, I_T_Demarcacion_Repository
    {
        private readonly ApplicationDbContext _db;

        public T_Demarcacion_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaDemarcacion()
        {
            return _db.Demarcaciones.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> DemarcacionMunicipio(int id)
        {
            return _db.Demarcaciones.Where(x=> x.MunicipioId == id).Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public void Update(T_Demarcacion Demarcacion)
        {
            var Objbd = _db.Demarcaciones.FirstOrDefault(s => s.Id == Demarcacion.Id);
            Objbd.Municipio = Demarcacion.Municipio;
            Objbd.No_Demarcacion = Demarcacion.No_Demarcacion;
            Objbd.Nombre = Demarcacion.Nombre;
            _db.SaveChanges();
        }
    }
}
