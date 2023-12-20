using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Detalle_Votos_Acta_Repository : Repository<T_Detalle_Votos_Acta>, I_T_Detalle_Votos_Acta_Repository
    {
        private readonly ApplicationDbContext _db;
        public T_Detalle_Votos_Acta_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
