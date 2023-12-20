using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class T_HistorialSubsanar_Repository : Repository<T_HistorialSubsanar>, I_T_HistorialSubsanar_Repository
    {
        private readonly ApplicationDbContext _db;
        public T_HistorialSubsanar_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public List<T_HistorialSubsanar> Historial()
        {
            List<T_HistorialSubsanar> nueva = new List<T_HistorialSubsanar>();
            nueva = _db.HistorialSubsanar.Include(Lcasilla => Lcasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Include(LEccion => LEccion.LTipo_Eleccion).Include(LCausal => LCausal.LCausal).Include(LUsuario => LUsuario.LUsuario).Where(x=> x.Eliminar == false &&  x.Solicitud == 0).ToList(); 
            return nueva;
        }

        public List<T_HistorialSubsanar> HistorialMunicipio(int id)
        {
            List<T_HistorialSubsanar> nueva = new List<T_HistorialSubsanar>();
            nueva = _db.HistorialSubsanar.Include(Lcasilla => Lcasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Include(LEccion => LEccion.LTipo_Eleccion).Include(LCausal => LCausal.LCausal).Include(LUsuario => LUsuario.LUsuario).Where(x=> x.LCasilla.MunicipioId == id && x.Eliminar == false &&  x.Solicitud != 2).ToList();
            return nueva;
        }

        public List<T_HistoricoRestablecer> Historico()
        {
            List<T_HistoricoRestablecer> nueva = new List<T_HistoricoRestablecer>();
            nueva = _db.HistoricoRestablecer.Include(Lcasilla => Lcasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Include(LEccion => LEccion.LTipo_Eleccion).Include(LCausal => LCausal.LCausal).Include(LUsuario => LUsuario.LUsuario).ToList();
            return nueva;
        }

        public List<T_HistoricoRestablecer> HistoricoMunicipal(int id)
        {
            List<T_HistoricoRestablecer> nueva = new List<T_HistoricoRestablecer>();
            nueva = _db.HistoricoRestablecer.Include(Lcasilla => Lcasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Include(LEccion => LEccion.LTipo_Eleccion).Include(LCausal => LCausal.LCausal).Include(LUsuario => LUsuario.LUsuario).Where(x=> x.LCasilla.MunicipioId == id).ToList();
            return nueva;
        }

        public List<T_Recepcion_Paquete> Recepcion()
        {
            List<T_Recepcion_Paquete> nueva = new List<T_Recepcion_Paquete>();

            _db.Recepcion_Paquete.Include(Lusuario => Lusuario.LUsuario);
            return nueva;
        }

        public List<T_HistorialSubsanar> Solicitudes()
        {
            List<T_HistorialSubsanar> nueva = new List<T_HistorialSubsanar>();
            nueva = _db.HistorialSubsanar.Include(Lcasilla => Lcasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Include(LEccion => LEccion.LTipo_Eleccion).Include(LCausal => LCausal.LCausal).Include(LUsuario => LUsuario.LUsuario).Where(x => x.Eliminar == false && x.Solicitud == 1).ToList();
            return nueva;
        }
    }
}
