﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Detalle_Acta_Computo_RP_Repository : Repository<T_Detalle_Acta_Computo_RP>, I_T_Detalle_Acta_Computo_RP_Repository
    {
        private readonly ApplicationDbContext _db;
        public T_Detalle_Acta_Computo_RP_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
