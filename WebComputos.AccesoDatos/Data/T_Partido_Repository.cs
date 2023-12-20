using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class T_Partido_Repository : Repository<T_Partido>, I_T_Partido_Repository
    {
        private ApplicationDbContext _db;
        public T_Partido_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListPartidos()
        {
            return _db.Partidos.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public void Update(T_Partido Partido)
        {
            var Objbd = _db.Partidos.FirstOrDefault(x => x.Id == Partido.Id);
            Objbd.Independiente = Partido.Independiente;
            Objbd.LogoURL = Partido.LogoURL;
            Objbd.Nombre = Partido.Nombre;
            Objbd.PantoneFondo = Partido.PantoneFondo;
            Objbd.PantoneLetra = Partido.PantoneLetra;
            Objbd.Prioridad = Partido.Prioridad;
            Objbd.Siglas = Partido.Siglas;
            
        }
    }
}
