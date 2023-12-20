using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Votos_Acta_RP_Repository : Repository<T_Votos_Acta_RP>, I_T_Votos_Acta_RP_Repository
    {
        private readonly ApplicationDbContext _db;
        public T_Votos_Acta_RP_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
