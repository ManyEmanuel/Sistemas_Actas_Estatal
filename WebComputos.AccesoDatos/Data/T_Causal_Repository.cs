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
using System.Security.Cryptography.X509Certificates;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Causal_Repository : Repository<T_Causal_Recuento>, I_T_Causal_Repository

    {
        private readonly ApplicationDbContext _db;
        public T_Causal_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<ElementosListas> GetListaCausales(int mun, int ele, int rd)
        {
            List<ElementosListas> lst = new List<ElementosListas>();
            if (ele == 3)
            {
                if (mun == 0)
                {
                    lst = _db.Causales_recuento.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.LCasilla.LSeccion.DistritoId == rd && x.RP == false).Select(i => new ElementosListas()
                    {
                        idr = i.LCasilla.TipoCasillaId,
                        seccion = i.LCasilla.LSeccion.Seccion,
                        casilla = i.LCasilla.Nombre,
                        cau1 = i.Causal1,
                        cau2 = i.Causal2,
                        cau3 = i.Causal3,
                        cau4 = i.Causal4,
                        cau5 = i.Causal5,
                        cau6 = i.Causal6,
                        cau7 = i.Causal7,
                        cau8 = i.Causal8,
                        cau9 = i.Causal9,
                        cau10 = i.Causal10,
                        cau11 = i.Causal11,
                        numcau = i.Total_Causales,
                        idcau = i.Id,
                        Distrito = i.LCasilla.LSeccion.DistritoId
                    }).OrderBy(x => x.seccion).ThenBy(x => x.idr).ToList();
                }
                else
                {
                    if (rd == 0)
                    {
                        lst = _db.Causales_recuento.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.LCasilla.LSeccion.MunicipioId == mun && x.RP == false).Select(i => new ElementosListas()
                        {
                            idr = i.LCasilla.TipoCasillaId,
                            seccion = i.LCasilla.LSeccion.Seccion,
                            casilla = i.LCasilla.Nombre,
                            cau1 = i.Causal1,
                            cau2 = i.Causal2,
                            cau3 = i.Causal3,
                            cau4 = i.Causal4,
                            cau5 = i.Causal5,
                            cau6 = i.Causal6,
                            cau7 = i.Causal7,
                            cau8 = i.Causal8,
                            cau9 = i.Causal9,
                            cau10 = i.Causal10,
                            cau11 = i.Causal11,
                            numcau = i.Total_Causales,
                            idcau = i.Id,

                        }).OrderBy(x => x.seccion).ThenBy(x => x.idr).ToList();
                    }
                    else
                    {
                        lst = _db.Causales_recuento.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.LCasilla.LSeccion.MunicipioId == mun && x.LCasilla.LSeccion.DistritoId == rd && x.RP == false).Select(i => new ElementosListas()
                        {
                            idr = i.LCasilla.TipoCasillaId,
                            seccion = i.LCasilla.LSeccion.Seccion,
                            casilla = i.LCasilla.Nombre,
                            cau1 = i.Causal1,
                            cau2 = i.Causal2,
                            cau3 = i.Causal3,
                            cau4 = i.Causal4,
                            cau5 = i.Causal5,
                            cau6 = i.Causal6,
                            cau7 = i.Causal7,
                            cau8 = i.Causal8,
                            cau9 = i.Causal9,
                            cau10 = i.Causal10,
                            cau11 = i.Causal11,
                            numcau = i.Total_Causales,
                            idcau = i.Id,
                            Distrito = i.LCasilla.LSeccion.DistritoId
                        }).OrderBy(x => x.seccion).ThenBy(x => x.idr).ToList();
                    }
                }

            }
            else if (ele == 4)
            {
                if (rd == 0)
                {
                    lst = _db.Causales_recuento.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.LCasilla.LSeccion.MunicipioId == mun && x.RP == false).Select(i => new ElementosListas()
                    {
                        idr = i.LCasilla.TipoCasillaId,
                        seccion = i.LCasilla.LSeccion.Seccion,
                        casilla = i.LCasilla.Nombre,
                        cau1 = i.Causal1,
                        cau2 = i.Causal2,
                        cau3 = i.Causal3,
                        cau4 = i.Causal4,
                        cau5 = i.Causal5,
                        cau6 = i.Causal6,
                        cau7 = i.Causal7,
                        cau8 = i.Causal8,
                        cau9 = i.Causal9,
                        cau10 = i.Causal10,
                        cau11 = i.Causal11,
                        numcau = i.Total_Causales,
                        idcau = i.Id
                    }).OrderBy(x => x.seccion).ThenBy(x => x.idr).ToList();
                }
                else
                {
                    lst = _db.Causales_recuento.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.LCasilla.LSeccion.MunicipioId == mun && x.LCasilla.LSeccion.DemarcacionId == rd && x.RP == false).Select(i => new ElementosListas()
                    {
                        idr = i.LCasilla.TipoCasillaId,
                        seccion = i.LCasilla.LSeccion.Seccion,
                        casilla = i.LCasilla.Nombre,
                        cau1 = i.Causal1,
                        cau2 = i.Causal2,
                        cau3 = i.Causal3,
                        cau4 = i.Causal4,
                        cau5 = i.Causal5,
                        cau6 = i.Causal6,
                        cau7 = i.Causal7,
                        cau8 = i.Causal8,
                        cau9 = i.Causal9,
                        cau10 = i.Causal10,
                        cau11 = i.Causal11,
                        numcau = i.Total_Causales,
                        idcau = i.Id,
                        Demarcacion = i.LCasilla.LSeccion.DemarcacionId
                    }).OrderBy(x => x.seccion).ThenBy(x => x.idr).ToList();
                }

            }
            else
            {
                if (mun == 0)
                {

                    lst = _db.Causales_recuento.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele).Select(i => new ElementosListas()
                    {
                        idr = i.LCasilla.TipoCasillaId,
                        seccion = i.LCasilla.LSeccion.Seccion,
                        casilla = i.LCasilla.Nombre,
                        cau1 = i.Causal1,
                        cau2 = i.Causal2,
                        cau3 = i.Causal3,
                        cau4 = i.Causal4,
                        cau5 = i.Causal5,
                        cau6 = i.Causal6,
                        cau7 = i.Causal7,
                        cau8 = i.Causal8,
                        cau9 = i.Causal9,
                        cau10 = i.Causal10,
                        cau11 = i.Causal11,
                        numcau = i.Total_Causales,
                        idcau = i.Id
                    }).OrderBy(x => x.seccion).ThenBy(x => x.idr).ToList();
                }
                else
                {


                    lst = _db.Causales_recuento.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.LCasilla.LSeccion.MunicipioId == mun).Select(i => new ElementosListas()
                    {
                        idr = i.LCasilla.TipoCasillaId,
                        seccion = i.LCasilla.LSeccion.Seccion,
                        casilla = i.LCasilla.Nombre,
                        cau1 = i.Causal1,
                        cau2 = i.Causal2,
                        cau3 = i.Causal3,
                        cau4 = i.Causal4,
                        cau5 = i.Causal5,
                        cau6 = i.Causal6,
                        cau7 = i.Causal7,
                        cau8 = i.Causal8,
                        cau9 = i.Causal9,
                        cau10 = i.Causal10,
                        cau11 = i.Causal11,
                        numcau = i.Total_Causales,
                        idcau = i.Id
                    }).OrderBy(x => x.seccion).ThenBy(x => x.idr).ToList();
                }
            }
            return lst;
        }
        public IEnumerable<T_Acta_Detalle> CausalesCompletas(int Municipio, int Eleccion, int DD)
        {
            List<T_Acta_Detalle> lst = new List<T_Acta_Detalle>();
            if (Eleccion == 3)
            {
                if (Municipio == 0)
                {
                    lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == Eleccion && x.CapturadoComplemento == true && x.CapturadoVotos == true && x.LCasilla.LSeccion.DistritoId == DD).ToList();

                }
                else
                {
                    lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LCasilla.MunicipioId == Municipio && x.IdEleccion == Eleccion && x.CapturadoComplemento == true && x.CapturadoVotos == true && x.LCasilla.LSeccion.DistritoId == DD).ToList();
                }

            }
            else if (Eleccion == 4)
            {
                lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LCasilla.MunicipioId == Municipio && x.IdEleccion == Eleccion && x.CapturadoComplemento == true && x.CapturadoVotos == true && x.LCasilla.LSeccion.DemarcacionId == DD).ToList();
            }
            else
            {
                if (Municipio == 0)
                {
                    lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == Eleccion && x.CapturadoComplemento == true && x.CapturadoVotos == true).ToList();
                }
                else
                {
                    lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LCasilla.MunicipioId == Municipio && x.IdEleccion == Eleccion && x.CapturadoComplemento == true && x.CapturadoVotos == true).ToList();
                }

            }
            return lst;
        }

        public IEnumerable<T_Acta_Detalle> CausalesComplemento(int Municipio, int Eleccion, int DD)
        {
            List<T_Acta_Detalle> lst = new List<T_Acta_Detalle>();
            if (Eleccion == 3)
            {
                if (Municipio == 0)
                {
                    lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == Eleccion && x.CapturadoComplemento == true && x.LCasilla.LSeccion.DistritoId == DD).ToList();
                }
                else
                {
                    lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LCasilla.MunicipioId == Municipio && x.IdEleccion == Eleccion && x.CapturadoComplemento == true && x.LCasilla.LSeccion.DistritoId == DD).ToList();

                }

            }
            else if (Eleccion == 4)
            {
                lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LCasilla.MunicipioId == Municipio && x.IdEleccion == Eleccion && x.CapturadoComplemento == true && x.LCasilla.LSeccion.DemarcacionId == DD).ToList();
            }
            else
            {
                if (Municipio == 0)
                {
                    lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == Eleccion && x.CapturadoComplemento == true).ToList();
                }
                else
                {
                    lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LCasilla.MunicipioId == Municipio && x.IdEleccion == Eleccion && x.CapturadoComplemento == true).ToList();
                }

            }
            return lst;
        }

        public List<T_Detalle_Votos_Acta> SegundoLugar(int Registro)
        {
            List<T_Detalle_Votos_Acta> lstda = new List<T_Detalle_Votos_Acta>();
            var filtro = _db.Detalle_Votos_Acta.Where(x => x.IdVotosActa == Registro).ToList();

            if (filtro.Where(x => x.IdCoalicion != 0).Count() != 0)
            {
                var coaliciones = filtro.Where(x => x.IdCoalicion != 0).GroupBy(x => x.IdCoalicion).Select(i => new T_Detalle_Votos_Acta
                {
                    IdCoalicion = i.Key,
                    Votos = i.Sum(x => x.Votos)
                }).ToList();

                var eliminarCoalicion = filtro.Where(x => x.IdCoalicion != 0).ToList();
                foreach (var elimina in eliminarCoalicion)
                {
                    var comprueba = filtro.Where(x => x.IdCombinacion == elimina.IdCombinacion).FirstOrDefault();
                    filtro.Remove(comprueba);
                }
                List<T_Detalle_Votos_Acta> nueva = new List<T_Detalle_Votos_Acta>();
                foreach (var lista in coaliciones)
                {
                    var partidos = _db.Detalle_Coaliciones.Where(x => x.CoalicionId == lista.IdCoalicion).ToList();
                    foreach (var agregar in partidos)
                    {
                        var votospartidos = filtro.Where(x => x.IdPartido == agregar.PartidoId).FirstOrDefault();
                        var nuevo = new T_Detalle_Votos_Acta();
                        nuevo.IdCoalicion = lista.IdCoalicion;
                        nuevo.Votos = votospartidos.Votos;
                        nueva.Add(nuevo);
                        filtro.Remove(votospartidos);
                    }
                }
                var primeraunion = coaliciones.Concat(nueva).ToList();
                var nuevalista = primeraunion.Where(x => x.IdCoalicion != 0).GroupBy(x => x.IdCoalicion).Select(i => new T_Detalle_Votos_Acta
                {
                    IdCoalicion = i.Key,
                    Votos = i.Sum(x => x.Votos)
                }).ToList();

                lstda = nuevalista.Concat(filtro).ToList();
            }
            else
            {
                lstda = _db.Detalle_Votos_Acta.Where(x => x.IdVotosActa == Registro).ToList();
            }

            return lstda;
        }

        public List<T_Detalle_Votos_Acta> SegundoLugarCausal(int Municipio, int Eleccion, int DR)
        {
            List<T_Detalle_Votos_Acta> lstfinal = new List<T_Detalle_Votos_Acta>();
            List<T_Detalle_Votos_Acta> lstda = new List<T_Detalle_Votos_Acta>();
            List<T_Detalle_Votos_Acta> lst = new List<T_Detalle_Votos_Acta>();
            if (Eleccion == 3)
            {
                if (Municipio == 0)
                {
                    lst = _db.Detalle_Votos_Acta.Include(LVotos => LVotos.LVotosActa).ThenInclude(LActa => LActa.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == Eleccion && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.DistritoId == DR).Select(i => new T_Detalle_Votos_Acta()
                    {
                        IdPartido = i.IdPartido,
                        IdCoalicion = i.IdCoalicion,
                        IdCombinacion = i.IdCombinacion,
                        IdIndependiente = i.IdIndependiente,
                        Votos = i.Votos

                    }).ToList();
                }
                else
                {
                    lst = _db.Detalle_Votos_Acta.Include(LVotos => LVotos.LVotosActa).ThenInclude(LActa => LActa.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio && x.LVotosActa.LActaDetalle.IdEleccion == Eleccion && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.DistritoId == DR).Select(i => new T_Detalle_Votos_Acta()
                    {
                        IdPartido = i.IdPartido,
                        IdCoalicion = i.IdCoalicion,
                        IdCombinacion = i.IdCombinacion,
                        IdIndependiente = i.IdIndependiente,
                        Votos = i.Votos

                    }).ToList();
                }

            }
            else if (Eleccion == 4)
            {
                if (Municipio == 0)
                {
                    lst = _db.Detalle_Votos_Acta.Include(LVotos => LVotos.LVotosActa).ThenInclude(LActa => LActa.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == Eleccion && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.DemarcacionId == DR).Select(i => new T_Detalle_Votos_Acta()
                    {
                        IdPartido = i.IdPartido,
                        IdCoalicion = i.IdCoalicion,
                        IdCombinacion = i.IdCombinacion,
                        IdIndependiente = i.IdIndependiente,
                        Votos = i.Votos

                    }).ToList();
                }
                else
                {
                    lst = _db.Detalle_Votos_Acta.Include(LVotos => LVotos.LVotosActa).ThenInclude(LActa => LActa.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio && x.LVotosActa.LActaDetalle.IdEleccion == Eleccion && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.DemarcacionId == DR).Select(i => new T_Detalle_Votos_Acta()
                    {
                        IdPartido = i.IdPartido,
                        IdCoalicion = i.IdCoalicion,
                        IdCombinacion = i.IdCombinacion,
                        IdIndependiente = i.IdIndependiente,
                        Votos = i.Votos
                    }).ToList();
                }
            }
            else
            {
                if (Municipio == 0)
                {
                    lst = _db.Detalle_Votos_Acta.Include(LVotos => LVotos.LVotosActa).ThenInclude(LActa => LActa.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == Eleccion).Select(i => new T_Detalle_Votos_Acta()
                    {
                        IdPartido = i.IdPartido,
                        IdCoalicion = i.IdCoalicion,
                        IdCombinacion = i.IdCombinacion,
                        IdIndependiente = i.IdIndependiente,
                        Votos = i.Votos

                    }).ToList();
                }
                else
                {
                    lst = _db.Detalle_Votos_Acta.Include(LVotos => LVotos.LVotosActa).ThenInclude(LActa => LActa.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio && x.LVotosActa.LActaDetalle.IdEleccion == Eleccion).Select(i => new T_Detalle_Votos_Acta()
                    {
                        IdPartido = i.IdPartido,
                        IdCoalicion = i.IdCoalicion,
                        IdCombinacion = i.IdCombinacion,
                        IdIndependiente = i.IdIndependiente,
                        Votos = i.Votos
                    }).ToList();
                }

            }

            var partidos = lst.Where(x => x.IdPartido != 0 & x.IdIndependiente == 0).ToList();
            var SumaPartidos = partidos.GroupBy(x => x.IdPartido).Select(x => new T_Detalle_Votos_Acta
            {
                IdPartido = x.Key,
                Votos = x.Sum(x => x.Votos)
            }).ToList();
            var coalicion = lst.Where(x => x.IdCoalicion != 0 ).ToList();
            var SumaCoalicion = coalicion.GroupBy(x => x.IdCoalicion).Select(x => new T_Detalle_Votos_Acta
            {
                IdCoalicion = x.Key,
                Votos = x.Sum(x => x.Votos)
            }).ToList();
            var independientes = lst.Where(x => x.IdPartido == 0 & x.IdIndependiente != 0).ToList();
            var SumaIndependiente = independientes.GroupBy(x => x.IdPartido).Select(x => new T_Detalle_Votos_Acta
            {
                IdIndependiente = x.Key,
                Votos = x.Sum(x => x.Votos)
            }).ToList();

            var Primerfiltro = SumaPartidos.Concat(SumaCoalicion).ToList();
            var filtro = Primerfiltro.Concat(SumaIndependiente).ToList();
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------//
            if (filtro.Where(x => x.IdCoalicion != 0).Count() != 0)
            {
                var coaliciones = filtro.Where(x => x.IdCoalicion != 0).GroupBy(x => x.IdCoalicion).Select(i => new T_Detalle_Votos_Acta
                {
                    IdCoalicion = i.Key,
                    Votos = i.Sum(x => x.Votos)
                }).ToList();

                var eliminarCoalicion = filtro.Where(x => x.IdCoalicion != 0).ToList();
                foreach (var elimina in eliminarCoalicion)
                {
                    var comprueba = filtro.Where(x => x.IdCoalicion == elimina.IdCoalicion).FirstOrDefault();
                    filtro.Remove(comprueba);
                }


                List<T_Detalle_Votos_Acta> nueva = new List<T_Detalle_Votos_Acta>();
                foreach (var lista in coaliciones)
                {
                    var partidospol = _db.Detalle_Coaliciones.Where(x => x.CoalicionId == lista.IdCoalicion).ToList();
                    foreach (var agregar in partidospol)
                    {
                        var votospartidos = filtro.Where(x => x.IdPartido == agregar.PartidoId).FirstOrDefault();
                        var nuevo = new T_Detalle_Votos_Acta();
                        nuevo.IdCoalicion = lista.IdCoalicion;
                        nuevo.Votos = votospartidos.Votos;
                        nueva.Add(nuevo);
                        filtro.Remove(votospartidos);
                    }
                }
                var primeraunion = coaliciones.Concat(nueva).ToList();
                var nuevalista = primeraunion.Where(x => x.IdCoalicion != 0).GroupBy(x => x.IdCoalicion).Select(i => new T_Detalle_Votos_Acta
                {
                    IdCoalicion = i.Key,
                    Votos = i.Sum(x => x.Votos)
                }).ToList();

                lstfinal = nuevalista.Concat(filtro).OrderByDescending(x=> x.Votos).ToList();
            }
            else
            {
                lstfinal = filtro.OrderByDescending(x => x.Votos).ToList();
            }


            return lstfinal;
        }

        public void CarmbiarCausal()
        {
            var Causal = _db.Causales_recuento.Include(x => x.LCasilla).ThenInclude(x => x.LSeccion).Where(x => x.LCasilla.LSeccion.MunicipioId == 17 && x.TipoEleccionId == 1 && x.CasillaId != 683 && x.CasillaId != 907 && x.CasillaId !=923 && x.CasillaId != 1010).ToList();

            foreach(var resolver in Causal)
            {
                var test = _db.Causales_recuento.FirstOrDefault(x => x.Id == resolver.Id);
                test.Causal1 = false;
                test.Causal2 = false;
                test.Causal3 = false;
                test.Causal4 = false;
                test.Causal5 = false;
                test.Causal6 = false;
                test.Causal7 = false;
                test.Causal8 = false;
                test.Causal9 = false;
                test.Causal10 = false;
                test.Causal11 = false;
                test.Total_Causales = 0;

                _db.SaveChanges();
            }

            var CausalPys = _db.Causales_recuento.Include(x => x.LCasilla).ThenInclude(x => x.LSeccion).Where(x => x.LCasilla.LSeccion.MunicipioId == 17 && x.TipoEleccionId == 2 && x.CasillaId != 607 && x.CasillaId != 713 && x.CasillaId != 768 && x.CasillaId != 782 && x.CasillaId != 912 && x.CasillaId != 1158).ToList();

            foreach (var resolver in CausalPys)
            {
                var test = _db.Causales_recuento.FirstOrDefault(x => x.Id == resolver.Id);
                test.Causal1 = false;
                test.Causal2 = false;
                test.Causal3 = false;
                test.Causal4 = false;
                test.Causal5 = false;
                test.Causal6 = false;
                test.Causal7 = false;
                test.Causal8 = false;
                test.Causal9 = false;
                test.Causal10 = false;
                test.Causal11 = false;
                test.Total_Causales = 0;

                _db.SaveChanges();
            }
            var CausalDip = _db.Causales_recuento.Include(x => x.LCasilla).ThenInclude(x => x.LSeccion).Where(x => x.LCasilla.LSeccion.MunicipioId == 17&& x.TipoEleccionId == 3 && x.CasillaId != 700 && x.CasillaId != 907 && x.CasillaId != 919 && x.CasillaId != 1159 && x.CasillaId != 628 && x.CasillaId != 720 && x.CasillaId != 713 && x.CasillaId != 737 && x.CasillaId != 1165).ToList();

            foreach (var resolver in CausalDip)
            {
                var test = _db.Causales_recuento.FirstOrDefault(x => x.Id == resolver.Id);
                test.Causal1 = false;
                test.Causal2 = false;
                test.Causal3 = false;
                test.Causal4 = false;
                test.Causal5 = false;
                test.Causal6 = false;
                test.Causal7 = false;
                test.Causal8 = false;
                test.Causal9 = false;
                test.Causal10 = false;
                test.Causal11 = false;
                test.Total_Causales = 0;

                _db.SaveChanges();
            }

            var CausalReg = _db.Causales_recuento.Include(x => x.LCasilla).ThenInclude(x => x.LSeccion).Where(x => x.LCasilla.LSeccion.MunicipioId == 17 && x.TipoEleccionId == 4 && x.CasillaId != 737 && x.CasillaId != 647 && x.CasillaId != 924 && x.CasillaId != 927 && x.CasillaId != 929 && x.CasillaId != 992 && x.CasillaId != 907 && x.CasillaId != 913 && x.CasillaId != 941 && x.CasillaId != 908 && x.CasillaId != 805 && x.CasillaId != 1101 && x.CasillaId != 1158 && x.CasillaId != 1169 && x.CasillaId !=762 && x.CasillaId !=796 && x.CasillaId !=819 && x.CasillaId !=694 && x.CasillaId !=704).ToList();

            foreach (var resolver in CausalReg)
            {
                var test = _db.Causales_recuento.FirstOrDefault(x => x.Id == resolver.Id);
                test.Causal1 = false;
                test.Causal2 = false;
                test.Causal3 = false;
                test.Causal4 = false;
                test.Causal5 = false;
                test.Causal6 = false;
                test.Causal7 = false;
                test.Causal8 = false;
                test.Causal9 = false;
                test.Causal10 = false;
                test.Causal11 = false;
                test.Total_Causales = 0;

                _db.SaveChanges();
            }
        }
    }
}


