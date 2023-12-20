using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Detalle_Acta_Computo_Repository : Repository<T_Detalle_Acta_Computo>, I_T_Detalle_Acta_Computo_Repository
    {
        private readonly ApplicationDbContext _db;

        public T_Detalle_Acta_Computo_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
