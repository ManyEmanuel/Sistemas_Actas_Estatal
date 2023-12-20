using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class T_HistorialModificacion_Repository : Repository<T_HistorialModificaciones>, I_T_HistorialModificacion_Repository
    {
        private readonly ApplicationDbContext _db;

        public T_HistorialModificacion_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
