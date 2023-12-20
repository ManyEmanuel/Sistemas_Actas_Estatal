using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Acta_Extranjero_Repository : Repository<T_Acta_Extranjero>, I_T_Acta_Extranjero_Repository
    {
        private readonly ApplicationDbContext _db;

        public T_Acta_Extranjero_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
