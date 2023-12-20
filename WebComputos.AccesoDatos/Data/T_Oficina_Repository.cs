using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class T_Oficina_Repository : Repository<T_Oficina>, I_T_Oficina_Repository
    {
        private ApplicationDbContext _db;

        public T_Oficina_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaOficina()
        {
            return _db.Oficinas.Select(i => new SelectListItem()
            {
                Text = (i.Nombre),
                Value = i.Id.ToString()
            });
        }

        public void Update(T_Oficina Oficina)
        {
            var Objbd = _db.Oficinas.FirstOrDefault(s => s.Id == Oficina.Id);
            Objbd.Calle = Oficina.Calle;
            Objbd.CodigoPostal = Oficina.CodigoPostal;
            Objbd.Colonia = Oficina.Colonia;
            Objbd.Municipio = Oficina.Municipio;
            Objbd.NoExterior = Oficina.NoExterior;
            Objbd.NoInterior = Oficina.NoInterior;
            Objbd.Nombre = Oficina.Nombre;
            Objbd.Siglas = Oficina.Siglas;
            Objbd.Telefono1 = Oficina.Telefono1;
            Objbd.Telefono2 = Oficina.Telefono2;
        }
    }
}
