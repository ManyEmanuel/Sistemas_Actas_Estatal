using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebComputos.AccesoDatos.Data;
using WebComputos.Models.ViewModels;

namespace WebComputos.AccesoDatos.Data
{
    public class UbicaCasillaRepository: Repository<UbicaCasillaVM>, IUbicaCasillaRepository
    {
        private readonly ApplicationDbContext _db;

        public UbicaCasillaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<ReporteUbica> GetListaUbica(int tipo, int id)
        {
            List<T_Casilla> Ubica = new List<T_Casilla>();
            Ubica = _db.Casillas.Include(LSeccion => LSeccion.LSeccion).ToList();
            List<ReporteUbica> lst = new List<ReporteUbica>();

            switch (tipo)
            {
                case 1:
                    lst = Ubica.Select(i => new ReporteUbica()
                    {
                        NoSeccion = i.LSeccion.Seccion,
                        TipoSeccion = i.LSeccion.TipoSeccion,
                        Padron = i.PadronElec,
                        Lista = i.ListadoNominal,
                        TipoCasilla = i.Nombre,
                        Domicilio = i.Domicilio,
                        Ubicacion = i.Ubicacion,
                        Referencia = i.Referencia,
                        NumMunicipio = i.MunicipioId,
                        Lugar = i.TipoLugar.ToString(),
                        NoCas = i.TipoCasillaId
                        
                    }).OrderBy(x => x.NoSeccion).ToList();
                    break;
                case 2:
                    lst = Ubica.Where(x=> x.MunicipioId == id).Select(i => new ReporteUbica()
                    {
                        NoSeccion = i.LSeccion.Seccion,
                        TipoSeccion = i.LSeccion.TipoSeccion,
                        Padron = i.PadronElec,
                        Lista = i.ListadoNominal,
                        TipoCasilla = i.Nombre,
                        Domicilio = i.Domicilio,
                        Ubicacion = i.Ubicacion,
                        NumMunicipio = i.MunicipioId,
                        Referencia = i.Referencia,
                        Lugar = i.TipoLugar.ToString(),
                        NoCas = i.TipoCasillaId
                    }).OrderBy(x => x.NoSeccion).ToList();
                    break;
                case 3:
                    lst = Ubica.Where(x => x.LSeccion.DistritoId == id).Select(i => new ReporteUbica()
                    {
                        NoSeccion = i.LSeccion.Seccion,
                        TipoSeccion = i.LSeccion.TipoSeccion,
                        Padron = i.PadronElec,
                        Lista = i.ListadoNominal,
                        TipoCasilla = i.Nombre,
                        Domicilio = i.Domicilio,
                        Ubicacion = i.Ubicacion,
                        NumMunicipio = i.MunicipioId,
                        Referencia = i.Referencia,
                        Lugar = i.TipoLugar.ToString(),
                        NoCas = i.TipoCasillaId
                    }).OrderBy(x => x.NoSeccion).ToList();
                    break;
                case 4:
                    lst = Ubica.Where(x => x.LSeccion.DemarcacionId == id).Select(i => new ReporteUbica()
                    {
                        NoSeccion = i.LSeccion.Seccion,
                        TipoSeccion = i.LSeccion.TipoSeccion,
                        Padron = i.PadronElec,
                        Lista = i.ListadoNominal,
                        TipoCasilla = i.Nombre,
                        Domicilio = i.Domicilio,
                        Ubicacion = i.Ubicacion,
                        Referencia = i.Referencia,
                        NumMunicipio = i.MunicipioId,
                        Lugar = i.TipoLugar.ToString(),
                        NoCas = i.TipoCasillaId
                    }).OrderBy(x => x.NoSeccion).ToList();
                    break;
                case 5:
                    lst = Ubica.Where(x => x.SeccionId == id).Select(i => new ReporteUbica()
                    {
                        NoSeccion = i.LSeccion.Seccion,
                        TipoSeccion = i.LSeccion.TipoSeccion,
                        Padron = i.PadronElec,
                        Lista = i.ListadoNominal,
                        TipoCasilla = i.Nombre,
                        Domicilio = i.Domicilio,
                        Ubicacion = i.Ubicacion,
                        Referencia = i.Referencia,
                        NumMunicipio = i.MunicipioId,
                        Lugar = i.TipoLugar.ToString(),
                        NoCas = i.TipoCasillaId
                    }).OrderBy(x => x.NoSeccion).ToList();
                    break;
            }

            return lst;
        }     
    }
}
