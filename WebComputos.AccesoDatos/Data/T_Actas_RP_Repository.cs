using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebComputos.AccesoDatos.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Actas_RP_Repository : Repository<T_Acta_RP>, I_T_Actas_RP_Repository
    {
        private readonly ApplicationDbContext _db;
        public T_Actas_RP_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<T_Acta_RP> CargarTablaRP(int Mun, int Ele)
        {
            var lstda = new List<T_Acta_RP>();
            if (Ele == 3)
            {

                   lstda = _db.Acta_RP.Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoComplemento == true && x.LActaDetalle.LCasilla.LSeccion.MunicipioId == Mun && x.LActaDetalle.IdEleccion == Ele).Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LtipoEleccion => LtipoEleccion.LTipoEleccion).ToList();
                
            }
            else if (Ele == 4)
            {
                lstda = _db.Acta_RP.Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoComplemento == true && x.LActaDetalle.LCasilla.LSeccion.MunicipioId == Mun && x.LActaDetalle.IdEleccion == Ele).Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LtipoEleccion => LtipoEleccion.LTipoEleccion).ToList();
            }

            return lstda;
        }
    }


}
