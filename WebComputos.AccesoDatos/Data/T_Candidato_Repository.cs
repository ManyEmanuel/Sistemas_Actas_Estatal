using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Candidato_Repository : Repository<T_Candidato>, I_T_Candidato_Repository
    {
        private ApplicationDbContext _db;
        public T_Candidato_Repository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        //public IEnumerable<SelectListItem> GetListaCandidato()
        //{
        //    return _db.TCandidato.Select(i => new SelectListItem()
        //    {
        //        Text = (i.Nombres + " " + i.ApellidoPat).ToString(),
        //        Value = i.IdCandidato.ToString()
        //    });
        //}

        public void Update(T_Candidato Candidato)
        {
            var Objbd = _db.Candidatos.FirstOrDefault(s => s.Id == Candidato.Id);
            Objbd.Activo = Candidato.Activo;

            Objbd.Coalicion = Candidato.Coalicion;
            Objbd.Demarcacion = Candidato.Demarcacion;
            Objbd.Distrito = Candidato.Distrito;
            Objbd.IsCoalicion = Candidato.IsCoalicion;
            Objbd.Estado = Candidato.Estado;
         Objbd.Municipio = Candidato.Municipio;

            Objbd.Orden = Candidato.Orden;
            Objbd.Partido = Candidato.Partido;
            Objbd.Tipo_Eleccion = Candidato.Tipo_Eleccion;
        }
    }
}
