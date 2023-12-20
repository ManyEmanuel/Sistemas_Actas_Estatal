using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class T_HistoricoRestablecer_Repository : Repository<T_HistoricoRestablecer>, I_T_HistoricoRestablecer_Repository
    {
        private readonly ApplicationDbContext _db;

        public T_HistoricoRestablecer_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
