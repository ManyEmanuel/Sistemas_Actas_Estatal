using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Casilla_Repository : Repository<T_Casilla>, I_T_Casilla_Repository
    {
        private ApplicationDbContext _db;

        public T_Casilla_Repository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public IEnumerable<T_Casilla> GetListaCasillaMunicipio(int mun)
        {
            var casilla = _db.Casillas.Where(x => x.MunicipioId == mun).ToList();
                
            return casilla;
        }

        public IEnumerable<SelectListItem> GetListaTipoCasilla()
        {
            return _db.Casillas.Select(i => new SelectListItem()
            {
                Text = i.NoCasilla.ToString(),
                Value = i.Id.ToString()
            });
        }
              
        public void Update(T_Casilla CasillaDet)
        {
            var ObjBd = _db.Casillas.FirstOrDefault(s => s.Id == CasillaDet.Id);
            ObjBd.Activo = CasillaDet.Activo;
            ObjBd.ExtContigua = CasillaDet.ExtContigua;
            ObjBd.ListadoNominal = CasillaDet.ListadoNominal;
            ObjBd.SeccionId = CasillaDet.SeccionId;
            ObjBd.TipoCasillaId = CasillaDet.TipoCasillaId;
            ObjBd.Nombre = CasillaDet.Nombre;
            ObjBd.Recibido = CasillaDet.Recibido;
           
        }
    }
}
