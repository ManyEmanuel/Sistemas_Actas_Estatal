using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Detalle_Combinacion_Repository: Repository<T_Detalle_Combinacion>, I_T_Detalle_Combinacion_Repository
    {
        private readonly ApplicationDbContext _db;
        public T_Detalle_Combinacion_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaDemarcacion()
        {
            throw new NotImplementedException();
        }

        public void Update(T_Combinacion Combinaciones)
        {
            throw new NotImplementedException();
        }
    }
}
