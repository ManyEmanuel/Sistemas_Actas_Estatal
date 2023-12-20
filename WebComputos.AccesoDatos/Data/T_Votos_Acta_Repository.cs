using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using Microsoft.EntityFrameworkCore;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Votos_Acta_Repository : Repository<T_Votos_Acta>, I_T_Votos_Acta_Repository
    {
        private readonly ApplicationDbContext _db;
        public T_Votos_Acta_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public List<T_Detalle_Votos_Acta> DetalleVotos(int Municipio)
        {
            var res = _db.Detalle_Votos_Acta.Include(LVotos => LVotos.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x=> x.LVotosActa.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio).ToList();
            return res;
        }

        public List<T_Detalle_Votos_Acta_RP> DetalleVotosRP(int Municipio)
        {
            var res = _db.Detalle_Votos_Acta_RP.Include(LVotos => LVotos.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio).ToList();
            return res;
        }

        public void EliminarVotos(int CasillaDetalle, int Eleccion)
        {
            var casilla = _db.Actas_Detalle.FirstOrDefault(x => x.IdActaDetalle == CasillaDetalle);
            var VotosActa = _db.Votos_Actas.FirstOrDefault(x => x.IdActaDetalle == CasillaDetalle);
            var causal = _db.Causales_recuento.Where(x => x.CasillaId == casilla.IdCasilla && x.TipoEleccionId == Eleccion).FirstOrDefault();
            casilla.CapturadoVotos = false;
            var RegistrosVotos = _db.Detalle_Votos_Acta.Where(x => x.IdVotosActa == VotosActa.IdRegistroVotos).ToList();

            foreach (var Registros in RegistrosVotos)
            {
                var Baja = _db.Detalle_Votos_Acta.FirstOrDefault(x => x.IdDetalleVotosActa == Registros.IdDetalleVotosActa);
                _db.Remove(Baja);
            }
            if (causal.Causal2 == true)
            {
                causal.Causal2 = false;
                causal.Total_Causales = causal.Total_Causales - 1;
            }
            if (causal.Causal3 == true)
            {
                causal.Causal3 = false;
                causal.Total_Causales = causal.Total_Causales - 1;
            }
            if (causal.Causal4 == true)
            {
                causal.Causal4 = false;
                causal.Total_Causales = causal.Total_Causales - 1;
            }
            if (causal.Causal5 == true)
            {
                causal.Causal5 = false;
                causal.Total_Causales = causal.Total_Causales - 1;
            }
            if (causal.Causal9 == true)
            {
                causal.Causal9 = false;
                causal.Total_Causales = causal.Total_Causales - 1;
            }
            if (causal.Causal11 == true)
            {
                causal.Causal11 = false;
                causal.Total_Causales = causal.Total_Causales - 1;
            }
            _db.SaveChanges();
        }

        public List<ElementosListas> TablasVotos(int Eleccion)
        {
            var lst = _db.Votos_Actas.Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoVotos == true && x.LActaDetalle.IdEleccion == Eleccion).Select(i => new ElementosListas()
            {
                seccion = i.LActaDetalle.LCasilla.LSeccion.Seccion,
                casilla = i.LActaDetalle.LCasilla.Nombre,
                idreg = i.IdRegistroVotos
            }).ToList();
            return lst;
        }

        public List<T_Votos_Acta> VotosActas(int Municipio)
        {
            var res = _db.Votos_Actas.Include(LDetalle => LDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x=>x.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio).ToList();
            return res;
        }

        public List<T_Votos_Acta_RP> VotosActasRP(int Municipio)
        {
            var res = _db.Votos_Acta_RP.Include(LDetalle => LDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio).ToList();
            return res;
        }

    }
}
