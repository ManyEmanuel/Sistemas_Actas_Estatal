using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebComputos.AccesoDatos.Data;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using WebComputos.Models.ViewModels;
using System.Diagnostics;
using System.IO;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http.Extensions;
using Rotativa.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using WebComputos.Utilerias;

namespace WebComputos.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ConsultaResultadosController : Controller
    {
        private readonly IContenedorTrabajo _context;
        private ApplicationDbContext _db;
        private readonly UserManager<T_Usuario> _UserManager;

        public ConsultaResultadosController(IContenedorTrabajo context, ApplicationDbContext db,
            UserManager<T_Usuario> UserManager)
        {
            _context = context;
            _db = db;
            _UserManager = UserManager;
        }

        [HttpGet]

        public IActionResult IndexExt()
        {
            return View();
        }

        public IActionResult CreateExt()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GobernadorMunicipioAdmin()
        {
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            return View();
        }
        [HttpGet]
        public IActionResult AyuntamientoMunicipioAdmin()
        {
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            return View();
        }

        [HttpGet]
        public IActionResult DiputadoMunicipioAdmin()
        {
            ViewBag.ListaDistrito = _context.Distrito.GetListaDistrito();
            return View();
        }

        [HttpGet]
        public IActionResult RegidorMunicipioAdmin()
        {
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            return View();
        }

        [HttpGet]
        public IActionResult VistaGobernadorAdminMunicipio(int id)
        {

            var mun = _db.Municipios.Find(id);
            List<ElementosListas> LreParActa = new List<ElementosListas>();
            List<ElementosListas> LreCoActa = new List<ElementosListas>();
            List<ElementosListas> LreIndActa = new List<ElementosListas>();
            List<ElementosListas> LreParActor = new List<ElementosListas>();
            List<ElementosListas> LreCoActor = new List<ElementosListas>();
            List<ElementosListas> LreIndActor = new List<ElementosListas>();
            /*------------------------------------------------------------------------*/

            var Cabecera = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraGobPys(1, mun.Id);
            var TotCaptura = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraGobPysCompleta(1, mun.Id);
            List<T_Votos_Acta> Lrega = new List<T_Votos_Acta>();
            T_Votos_Acta Rgistoo = new T_Votos_Acta();
            Rgistoo.NoRegistrados = Cabecera.Sum(x => x.NoRegistrados);
            Rgistoo.Nulos = Cabecera.Sum(x => x.Nulos);
            Rgistoo.Total = Cabecera.Sum(x => x.Total);
            Lrega.Add(Rgistoo);
            ViewBag.ResultadosCabecera = Lrega;
            /*-----------------------------------------------------------------------*/

            var ResultadosActas = _context.Detalle_Votos_Acta_Partido.GobernadorPorMunicipio(mun.Id);
            var ResultadosActorPol = _context.Detalle_Votos_Acta_Partido.GobernadorPorMunicipioActorPolitico(mun.Id);
            /* -----------------------------------------------------------------------------*/
            var rePar = ResultadosActas.Where(x => x.Partido != 0).ToList();
            var reCoa = ResultadosActas.Where(x => x.Coalicion != 0).ToList();
            var reInd = ResultadosActas.Where(x => x.Independiente != 0).ToList();
            LreParActa = rePar.GroupBy(x => x.Partido).Select(g => new ElementosListas
            {
                Partido = g.Key,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos),

            }).ToList();

            LreCoActa = reCoa.GroupBy(x => x.Combinacion).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.Key,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            LreIndActa = reInd.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.Key,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            var PriUnion = LreParActa.Concat(LreCoActa).ToList();
            var SecUnion = PriUnion.Concat(LreIndActa).ToList();
            ViewBag.ResultadosActas = SecUnion;
            /*-----------------------------------------------------------------------------*/

            //if (Cabecera.Count() == TotCaptura.Count())
            //{
            //    var comprobacion = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 1 && x.Municipio == mun.Id).ToList();
            //    if (comprobacion.Count() != 0)
            //    {
            //        foreach (var borr in comprobacion)
            //        {
            //            var resbo = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdDetalleVotosPartidos == borr.IdDetalleVotosPartidos).FirstOrDefault();
            //            _db.Remove(resbo);
            //        }
            //        _db.SaveChanges();
            //    }
            //    //if (comprobacion.Count() == 0)
            //    //{
            //    var distribucionPartidos = SecUnion.Where(x => x.Partido != 0).ToList();
            //    foreach (var parti in distribucionPartidos)
            //    {
            //        T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //        detpar.IdEleccion = 1;
            //        detpar.Municipio = mun.Id;
            //        detpar.IdPartido = parti.Partido.Value;
            //        detpar.Votos = parti.Votos.Value;
            //        _db.Add(detpar);
            //    }
            //    _db.SaveChanges();
            //    var distribucionIndependientes = SecUnion.Where(x => x.Independiente != 0).ToList();
            //    foreach (var indepe in distribucionIndependientes)
            //    {
            //        T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //        detpar.IdEleccion = 1;
            //        detpar.Municipio = mun.Id;
            //        detpar.IdIndependiente = indepe.Independiente.Value;
            //        detpar.Votos = indepe.Votos.Value;
            //        _db.Add(detpar);
            //        _db.SaveChanges();
            //    }
            //    var listcoali = SecUnion.Where(x => x.Coalicion != 0).Select(x => x.Coalicion).Distinct().ToList();
            //    foreach (var coali in listcoali)
            //    {
            //        var coalicion = _context.Combinacion.GetAll().Where(x => x.CoalicionId == coali).ToList();
            //        foreach (var combi in coalicion)
            //        {
            //            List<ElementosListas> Ldet = new List<ElementosListas>();
            //            var combinacion = _context.Combinacion_Detalle.GetAll().Where(x => x.CombinacionId == combi.Id).ToList();
            //            foreach (var combidet in combinacion)
            //            {

            //                var listpartcoali = SecUnion.Where(x => x.Partido == combidet.PartidoId).FirstOrDefault();
            //                Ldet.Add(listpartcoali);
            //            }
            //            var listapartidos = Ldet.OrderByDescending(x => x.Votos).ToList();
            //            var resultadocombi = SecUnion.Where(x => x.Combinacion == combi.Id).FirstOrDefault();
            //            int cont = 0;
            //            decimal pos = combi.Tamaño;
            //            decimal votos = resultadocombi.Votos.Value;
            //            for (int i = 0; i < combi.Tamaño; i++)
            //            {
            //                if (votos == 0)
            //                {
            //                    break;
            //                }
            //                decimal divisionvotos = votos / pos;
            //                decimal entero = Math.Floor(divisionvotos);
            //                decimal deci = divisionvotos - Math.Floor(divisionvotos);
            //                double decim = Convert.ToDouble(deci);
            //                if (decim > 0.0)
            //                {
            //                    entero = entero + 1;
            //                }

            //                var partido = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdPartido == listapartidos.Select(x => x.Partido).ElementAt(cont) && x.IdEleccion == 1 && x.Municipio == mun.Id).FirstOrDefault();
            //                int votosentero = Convert.ToInt32(entero);
            //                partido.Votos = partido.Votos + votosentero;
            //                _db.SaveChanges();
            //                votos = votos - votosentero;
            //                if (votos == 0)
            //                {
            //                    break;
            //                }

            //                cont = cont + 1;
            //                pos = pos - 1;
            //            }
            //        }
            //    }
            //    var Resuparti = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 1 && x.Municipio == mun.Id).ToList();
            //    ViewBag.ResultadosDistribucion = Resuparti;
            //    //}
            //    //else
            //    //{
            //    //    ViewBag.ResultadosDistribucion = comprobacion;
            //    //}
            //}

            ///*--------------------------------------------------------------------------------------*/
            //var reCoAct = ResultadosActorPol.Where(x => x.Coalicion != 0).ToList();
            //var reParAct = ResultadosActorPol.Where(x => x.Partido != 0).ToList();
            //var reIndAct = ResultadosActorPol.Where(x => x.Independiente != 0).ToList();
            //LreParActor = reParAct.GroupBy(x => x.Partido).Select(g => new ElementosListas
            //{
            //    Partido = g.Key,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.First().Independiente,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreCoActor = reCoAct.GroupBy(x => x.Coalicion).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.Key,
            //    Independiente = g.First().Independiente,
            //    Combinacion = g.First().Combinacion,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreIndActor = reIndAct.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.Key,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //var PriUnionActor = LreParActor.Concat(LreCoActor).ToList();
            //var SecUnionActor = PriUnionActor.Concat(LreIndActor).ToList();
            var par = _db.Partidos.ToList().OrderBy(x => x.Id).ThenBy(x => x.Prioridad);
            var com = _db.Combinaciones.ToList().OrderBy(x => x.Id);
            var coa = _db.Coaliciones.ToList().OrderBy(x => x.Id);
            ViewBag.Partido = par.OrderBy(x => x.Id);
            ViewBag.Combinacion = com.OrderBy(x => x.Coalicion).ThenByDescending(x => x.Tamaño);
            //ViewBag.Coalicion = coa;
            //ViewBag.ResultadosActor = SecUnionActor;
            ViewBag.Municipio = mun.Municipio;
            return View();
        }

        [HttpGet]
        public IActionResult VistaAyuntamientoAdminMunicipio(int id)
        {

            var mun = _db.Municipios.Find(id);
            List<ElementosListas> LreParActa = new List<ElementosListas>();
            List<ElementosListas> LreCoActa = new List<ElementosListas>();
            List<ElementosListas> LreIndActa = new List<ElementosListas>();
            List<ElementosListas> LreParActor = new List<ElementosListas>();
            List<ElementosListas> LreCoActor = new List<ElementosListas>();
            List<ElementosListas> LreIndActor = new List<ElementosListas>();
            /*------------------------------------------------------------------------*/

            var Cabecera = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraGobPys(2, mun.Id);
            var TotCaptura = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraGobPysCompleta(2, mun.Id);
            List<T_Votos_Acta> Lrega = new List<T_Votos_Acta>();
            T_Votos_Acta Rgistoo = new T_Votos_Acta();
            Rgistoo.NoRegistrados = Cabecera.Sum(x => x.NoRegistrados);
            Rgistoo.Nulos = Cabecera.Sum(x => x.Nulos);
            Rgistoo.Total = Cabecera.Sum(x => x.Total);
            Lrega.Add(Rgistoo);
            ViewBag.ResultadosCabecera = Lrega;
            /*-----------------------------------------------------------------------*/

            var ResultadosActas = _context.Detalle_Votos_Acta_Partido.PySMunicipio(mun.Id);
            var ResultadosActorPol = _context.Detalle_Votos_Acta_Partido.PySMunicipioActorPolitico(mun.Id);
            /* -----------------------------------------------------------------------------*/
            var rePar = ResultadosActas.Where(x => x.Partido != 0).ToList();
            var reCoa = ResultadosActas.Where(x => x.Coalicion != 0).ToList();
            var reInd = ResultadosActas.Where(x => x.Independiente != 0).ToList();
            LreParActa = rePar.GroupBy(x => x.Partido).Select(g => new ElementosListas
            {
                Partido = g.Key,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos),

            }).ToList();

            LreCoActa = reCoa.GroupBy(x => x.Combinacion).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.Key,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            LreIndActa = reInd.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.Key,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            var PriUnion = LreParActa.Concat(LreCoActa).ToList();
            var SecUnion = PriUnion.Concat(LreIndActa).ToList();
            ViewBag.ResultadosActas = SecUnion;
            //if (Cabecera.Count() == TotCaptura.Count())
            //{
            //    var comprobacion = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 2 && x.Municipio == mun.Id).ToList();
            //    if (comprobacion.Count() != 0)
            //    {
            //        foreach (var borr in comprobacion)
            //        {
            //            var resbo = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdDetalleVotosPartidos == borr.IdDetalleVotosPartidos).FirstOrDefault();
            //            _db.Remove(resbo);
            //        }
            //        _db.SaveChanges();
            //    }
            //    //if (comprobacion.Count() == 0)
            //    //{
            //    var distribucionPartidos = SecUnion.Where(x => x.Partido != 0).ToList();
            //    foreach (var parti in distribucionPartidos)
            //    {
            //        T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //        detpar.IdEleccion = 2;
            //        detpar.Municipio = mun.Id;
            //        detpar.IdPartido = parti.Partido.Value;
            //        detpar.Votos = parti.Votos.Value;
            //        _db.Add(detpar);
            //    }
            //    _db.SaveChanges();
            //    var distribucionIndependientes = SecUnion.Where(x => x.Independiente != 0).ToList();
            //    foreach (var indepe in distribucionIndependientes)
            //    {
            //        T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //        detpar.IdEleccion = 2;
            //        detpar.Municipio = mun.Id;
            //        detpar.IdIndependiente = indepe.Independiente.Value;
            //        detpar.Votos = indepe.Votos.Value;
            //        _db.Add(detpar);
            //        _db.SaveChanges();
            //    }
            //    var listcoali = SecUnion.Where(x => x.Coalicion != 0).Select(x => x.Coalicion).Distinct().ToList();
            //    foreach (var coali in listcoali)
            //    {
            //        var coalicion = _context.Combinacion.GetAll().Where(x => x.CoalicionId == coali).ToList();
            //        foreach (var combi in coalicion)
            //        {
            //            List<ElementosListas> Ldet = new List<ElementosListas>();
            //            var combinacion = _context.Combinacion_Detalle.GetAll().Where(x => x.CombinacionId == combi.Id).ToList();
            //            foreach (var combidet in combinacion)
            //            {

            //                var listpartcoali = SecUnion.Where(x => x.Partido == combidet.PartidoId).FirstOrDefault();
            //                Ldet.Add(listpartcoali);
            //            }
            //            var listapartidos = Ldet.OrderByDescending(x => x.Votos).ToList();
            //            var resultadocombi = SecUnion.Where(x => x.Combinacion == combi.Id).FirstOrDefault();
            //            int cont = 0;
            //            decimal pos = combi.Tamaño;
            //            decimal votos = resultadocombi.Votos.Value;
            //            for (int i = 0; i < combi.Tamaño; i++)
            //            {
            //                if (votos == 0)
            //                {
            //                    break;
            //                }
            //                decimal divisionvotos = votos / pos;
            //                decimal entero = Math.Floor(divisionvotos);
            //                decimal deci = divisionvotos - Math.Floor(divisionvotos);
            //                double decim = Convert.ToDouble(deci);
            //                if (decim > 0.0)
            //                {
            //                    entero = entero + 1;
            //                }

            //                var partido = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdPartido == listapartidos.Select(x => x.Partido).ElementAt(cont) && x.IdEleccion == 2 && x.Municipio == mun.Id).FirstOrDefault();
            //                int votosentero = Convert.ToInt32(entero);
            //                partido.Votos = partido.Votos + votosentero;
            //                _db.SaveChanges();
            //                votos = votos - votosentero;
            //                if (votos == 0)
            //                {
            //                    break;
            //                }

            //                cont = cont + 1;
            //                pos = pos - 1;
            //            }
            //        }
            //    }
            //    var Resuparti = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 2 && x.Municipio == mun.Id).ToList();
            //    ViewBag.ResultadosDistribucion = Resuparti;
            //    //}
            //    //else
            //    //{
            //    //    ViewBag.ResultadosDistribucion = comprobacion;
            //    //}
            //}
            ///*--------------------------------------------------------------------------------------*/
            //var reCoAct = ResultadosActorPol.Where(x => x.Coalicion != 0).ToList();
            //var reParAct = ResultadosActorPol.Where(x => x.Partido != 0).ToList();
            //var reIndAct = ResultadosActorPol.Where(x => x.Independiente != 0).ToList();
            //LreParActor = reParAct.GroupBy(x => x.Partido).Select(g => new ElementosListas
            //{
            //    Partido = g.Key,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.First().Independiente,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreCoActor = reCoAct.GroupBy(x => x.Coalicion).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.Key,
            //    Independiente = g.First().Independiente,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreIndActor = reIndAct.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.Key,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //var PriUnionActor = LreParActor.Concat(LreCoActor).ToList();
            //var SecUnionActor = PriUnionActor.Concat(LreIndActor).ToList();
            var par = _db.Partidos.ToList().OrderBy(x => x.Id).ThenBy(x => x.Prioridad);
            var com = _db.Combinaciones.ToList().OrderBy(x => x.Id);
            var coa = _db.Coaliciones.ToList().OrderBy(x => x.Id);
            ViewBag.Partido = par;
            ViewBag.Combinacion = com;
            //ViewBag.Coalicion = coa;
            //ViewBag.ResultadosActor = SecUnionActor;
            ViewBag.Municipio = mun.Municipio;
            return View();
        }

        [HttpGet]
        public IActionResult VistaDiputadosAdminMunicipio(int id)


        {
            var sec = _context.Seccion.GetFirstOrDefault(x => x.DistritoId == id);
            var mun = _db.Municipios.Find(sec.MunicipioId);
            var dis = _db.Distritos.Find(id);
            List<ElementosListas> LreParActa = new List<ElementosListas>();
            List<ElementosListas> LreCoActa = new List<ElementosListas>();
            List<ElementosListas> LreIndActa = new List<ElementosListas>();
            List<ElementosListas> LreParActor = new List<ElementosListas>();
            List<ElementosListas> LreCoActor = new List<ElementosListas>();
            List<ElementosListas> LreIndActor = new List<ElementosListas>();
            /*------------------------------------------------------------------------*/

            var Cabecera = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraDip(0, id);
            var TotCaptura = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraDipCompleta(0, id);
            List<T_Votos_Acta> Lrega = new List<T_Votos_Acta>();
            T_Votos_Acta Rgistoo = new T_Votos_Acta();
            Rgistoo.NoRegistrados = Cabecera.Sum(x => x.NoRegistrados);
            Rgistoo.Nulos = Cabecera.Sum(x => x.Nulos);
            Rgistoo.Total = Cabecera.Sum(x => x.Total);
            Lrega.Add(Rgistoo);
            ViewBag.ResultadosCabecera = Lrega;
            /*-----------------------------------------------------------------------*/

            var ResultadosActas = _context.Detalle_Votos_Acta_Partido.DiputadosDistrito(id);
            var ResultadosActorPol = _context.Detalle_Votos_Acta_Partido.DiputadosDistritoActorPolitico(id);
            /* -----------------------------------------------------------------------------*/
            var rePar = ResultadosActas.Where(x => x.Partido != 0).ToList();
            var reCoa = ResultadosActas.Where(x => x.Coalicion != 0).ToList();
            var reInd = ResultadosActas.Where(x => x.Independiente != 0).ToList();
            LreParActa = rePar.GroupBy(x => x.Partido).Select(g => new ElementosListas
            {
                Partido = g.Key,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos),

            }).ToList();

            LreCoActa = reCoa.GroupBy(x => x.Combinacion).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.Key,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            LreIndActa = reInd.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.Key,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            var PriUnion = LreParActa.Concat(LreCoActa).ToList();
            var SecUnion = PriUnion.Concat(LreIndActa).ToList();
            ViewBag.ResultadosActas = SecUnion;
            /*----------------------------------------------------------------------*/
            //if (Cabecera.Count() == TotCaptura.Count())
            //{
            //    var comprobacion = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 3 && x.Distrito == id).ToList();
            //    if (comprobacion.Count() != 0)
            //    {
            //        foreach (var borr in comprobacion)
            //        {
            //            var resbo = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdDetalleVotosPartidos == borr.IdDetalleVotosPartidos).FirstOrDefault();
            //            _db.Remove(resbo);
            //        }
            //        _db.SaveChanges();
            //    }
            //    var distribucionPartidos = SecUnion.Where(x => x.Partido != 0).ToList();
            //    foreach (var parti in distribucionPartidos)
            //    {
            //        T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //        detpar.IdEleccion = 3;
            //        detpar.Distrito = id;
            //        detpar.IdPartido = parti.Partido.Value;
            //        detpar.Votos = parti.Votos.Value;
            //        _db.Add(detpar);
            //    }
            //    _db.SaveChanges();
            //    var distribucionIndependientes = SecUnion.Where(x => x.Independiente != 0).ToList();
            //    foreach (var indepe in distribucionIndependientes)
            //    {
            //        T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //        detpar.IdEleccion = 3;
            //        detpar.Distrito = id;
            //        detpar.IdIndependiente = indepe.Independiente.Value;
            //        detpar.Votos = indepe.Votos.Value;
            //        _db.Add(detpar);
            //        _db.SaveChanges();
            //    }
            //    var listcoali = SecUnion.Where(x => x.Coalicion != 0).Select(x => x.Coalicion).Distinct().ToList();
            //    foreach (var coali in listcoali)
            //    {
            //        var coalicion = _context.Combinacion.GetAll().Where(x => x.CoalicionId == coali).ToList();
            //        foreach (var combi in coalicion)
            //        {
            //            List<ElementosListas> Ldet = new List<ElementosListas>();
            //            var combinacion = _context.Combinacion_Detalle.GetAll().Where(x => x.CombinacionId == combi.Id).ToList();
            //            foreach (var combidet in combinacion)
            //            {

            //                var listpartcoali = SecUnion.Where(x => x.Partido == combidet.PartidoId).FirstOrDefault();
            //                Ldet.Add(listpartcoali);
            //            }
            //            var listapartidos = Ldet.OrderByDescending(x => x.Votos).ToList();
            //            var resultadocombi = SecUnion.Where(x => x.Combinacion == combi.Id).FirstOrDefault();
            //            int cont = 0;
            //            decimal pos = combi.Tamaño;
            //            decimal votos = resultadocombi.Votos.Value;
            //            for (int i = 0; i < combi.Tamaño; i++)
            //            {
            //                if (votos == 0)
            //                {
            //                    break;
            //                }
            //                decimal divisionvotos = votos / pos;
            //                decimal entero = Math.Floor(divisionvotos);
            //                decimal deci = divisionvotos - Math.Floor(divisionvotos);
            //                double decim = Convert.ToDouble(deci);
            //                if (decim > 0.0)
            //                {
            //                    entero = entero + 1;
            //                }

            //                var partido = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdPartido == listapartidos.Select(x => x.Partido).ElementAt(cont) && x.IdEleccion == 3 && x.Distrito == id).FirstOrDefault();
            //                int votosentero = Convert.ToInt32(entero);
            //                partido.Votos = partido.Votos + votosentero;
            //                _db.SaveChanges();
            //                votos = votos - votosentero;
            //                if (votos == 0)
            //                {
            //                    break;
            //                }

            //                cont = cont + 1;
            //                pos = pos - 1;
            //            }
            //        }
            //    }
            //    var Resuparti = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 3 && x.Distrito == id).ToList();
            //    ViewBag.ResultadosDistribucion = Resuparti;
            //    //}
            //    //else
            //    //{
            //    //    ViewBag.ResultadosDistribucion = comprobacion;
            //    //}
            //}

            ///*--------------------------------------------------------------------------------------*/
            //var reCoAct = ResultadosActorPol.Where(x => x.Coalicion != 0).ToList();
            //var reParAct = ResultadosActorPol.Where(x => x.Partido != 0).ToList();
            //var reIndAct = ResultadosActorPol.Where(x => x.Independiente != 0).ToList();
            //LreParActor = reParAct.GroupBy(x => x.Partido).Select(g => new ElementosListas
            //{
            //    Partido = g.Key,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.First().Independiente,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreCoActor = reCoAct.GroupBy(x => x.Coalicion).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.Key,
            //    Independiente = g.First().Independiente,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreIndActor = reIndAct.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.Key,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //var PriUnionActor = LreParActor.Concat(LreCoActor).ToList();
            //var SecUnionActor = PriUnionActor.Concat(LreIndActor).ToList();
            var par = _db.Partidos.ToList().OrderBy(x => x.Id).ThenBy(x => x.Prioridad);
            var com = _db.Combinaciones.ToList().OrderBy(x => x.Id);
            var coa = _db.Coaliciones.ToList().OrderBy(x => x.Id);
            ViewBag.Partido = par;
            ViewBag.Combinacion = com;
            //ViewBag.Coalicion = coa;
            //ViewBag.ResultadosActor = SecUnionActor;
            ViewBag.Municipio = mun.Municipio;
            ViewBag.Distritos = "Distrito "+ dis.NoDistrito;

            return View();
        }

        [HttpGet]
        public IActionResult VistaRegidorAdminMunicipio (int id)
        {
            var dem = _db.Demarcaciones.Find(id);
            var sec = _context.Seccion.GetFirstOrDefault(x => x.DemarcacionId == id);
            var mun = _db.Municipios.Find(sec.MunicipioId);
            List<ElementosListas> LreParActa = new List<ElementosListas>();
            List<ElementosListas> LreCoActa = new List<ElementosListas>();
            List<ElementosListas> LreIndActa = new List<ElementosListas>();
            List<ElementosListas> LreParActor = new List<ElementosListas>();
            List<ElementosListas> LreCoActor = new List<ElementosListas>();
            List<ElementosListas> LreIndActor = new List<ElementosListas>();
            /*------------------------------------------------------------------------*/

            var Cabecera = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraReg(mun.Id, id);
            var TotCaptura = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraRegCompleta(mun.Id, id);
            List<T_Votos_Acta> Lrega = new List<T_Votos_Acta>();
            T_Votos_Acta Rgistoo = new T_Votos_Acta();
            Rgistoo.NoRegistrados = Cabecera.Sum(x => x.NoRegistrados);
            Rgistoo.Nulos = Cabecera.Sum(x => x.Nulos);
            Rgistoo.Total = Cabecera.Sum(x => x.Total);
            Lrega.Add(Rgistoo);
            ViewBag.ResultadosCabecera = Lrega;
            /*-----------------------------------------------------------------------*/

            var ResultadosActas = _context.Detalle_Votos_Acta_Partido.RegidorMunicipioDemarcacion(mun.Id, id);
            var ResultadosActorPol = _context.Detalle_Votos_Acta_Partido.RegidorMunicipioDemarcacionActorPolitico(mun.Id, id);
            /* -----------------------------------------------------------------------------*/
            var rePar = ResultadosActas.Where(x => x.Partido != 0).ToList();
            var reCoa = ResultadosActas.Where(x => x.Coalicion != 0).ToList();
            var reInd = ResultadosActas.Where(x => x.Independiente != 0).ToList();
            LreParActa = rePar.GroupBy(x => x.Partido).Select(g => new ElementosListas
            {
                Partido = g.Key,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos),

            }).ToList();

            LreCoActa = reCoa.GroupBy(x => x.Combinacion).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.Key,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            LreIndActa = reInd.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.Key,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            var PriUnion = LreParActa.Concat(LreCoActa).ToList();
            var SecUnion = PriUnion.Concat(LreIndActa).ToList();
            ViewBag.ResultadosActas = SecUnion;
            /*--------------------------------------------------------------------------------*/
            //if (Cabecera.Count() == TotCaptura.Count())
            //{
            //    var comprobacion = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 4 && x.Municipio == mun.Id && x.Demarcacion == id).ToList();
            //    if (comprobacion.Count() != 0)
            //    {
            //        foreach (var borr in comprobacion)
            //        {
            //            var resbo = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdDetalleVotosPartidos == borr.IdDetalleVotosPartidos).FirstOrDefault();
            //            _db.Remove(resbo);
            //        }
            //        _db.SaveChanges();
            //    }
            //    var distribucionPartidos = SecUnion.Where(x => x.Partido != 0).ToList();
            //    foreach (var parti in distribucionPartidos)
            //    {
            //        T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //        detpar.IdEleccion = 4;
            //        detpar.Municipio = mun.Id;
            //        detpar.Demarcacion = id;
            //        detpar.IdPartido = parti.Partido.Value;
            //        detpar.Votos = parti.Votos.Value;
            //        _db.Add(detpar);
            //    }
            //    _db.SaveChanges();
            //    var distribucionIndependientes = SecUnion.Where(x => x.Independiente != 0).ToList();
            //    foreach (var indepe in distribucionIndependientes)
            //    {
            //        T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //        detpar.IdEleccion = 4;
            //        detpar.Municipio = mun.Id;
            //        detpar.Demarcacion = id;
            //        detpar.IdIndependiente = indepe.Independiente.Value;
            //        detpar.Votos = indepe.Votos.Value;
            //        _db.Add(detpar);
            //        _db.SaveChanges();
            //    }
            //    var listcoali = SecUnion.Where(x => x.Coalicion != 0).Select(x => x.Coalicion).Distinct().ToList();
            //    foreach (var coali in listcoali)
            //    {
            //        var coalicion = _context.Combinacion.GetAll().Where(x => x.CoalicionId == coali).ToList();
            //        foreach (var combi in coalicion)
            //        {
            //            List<ElementosListas> Ldet = new List<ElementosListas>();
            //            var combinacion = _context.Combinacion_Detalle.GetAll().Where(x => x.CombinacionId == combi.Id).ToList();
            //            foreach (var combidet in combinacion)
            //            {

            //                var listpartcoali = SecUnion.Where(x => x.Partido == combidet.PartidoId).FirstOrDefault();
            //                Ldet.Add(listpartcoali);
            //            }
            //            var listapartidos = Ldet.OrderByDescending(x => x.Votos).ToList();
            //            var resultadocombi = SecUnion.Where(x => x.Combinacion == combi.Id).FirstOrDefault();
            //            int cont = 0;
            //            decimal pos = combi.Tamaño;
            //            decimal votos = resultadocombi.Votos.Value;
            //            for (int i = 0; i < combi.Tamaño; i++)
            //            {
            //                if (votos == 0)
            //                {
            //                    break;
            //                }
            //                decimal divisionvotos = votos / pos;
            //                decimal entero = Math.Floor(divisionvotos);
            //                decimal deci = divisionvotos - Math.Floor(divisionvotos);
            //                double decim = Convert.ToDouble(deci);
            //                if (decim > 0.0)
            //                {
            //                    entero = entero + 1;
            //                }

            //                var partido = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdPartido == listapartidos.Select(x => x.Partido).ElementAt(cont) && x.IdEleccion == 4 && x.Municipio == mun.Id && x.Demarcacion == id).FirstOrDefault();
            //                int votosentero = Convert.ToInt32(entero);
            //                partido.Votos = partido.Votos + votosentero;
            //                _db.SaveChanges();
            //                votos = votos - votosentero;
            //                if (votos == 0)
            //                {
            //                    break;
            //                }

            //                cont = cont + 1;
            //                pos = pos - 1;
            //            }
            //        }
            //    }
            //    var Resuparti = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 4 && x.Municipio == mun.Id && x.Demarcacion == id).ToList();
            //    ViewBag.ResultadosDistribucion = Resuparti;
            //    //}
            //    //else
            //    //{
            //    //    ViewBag.ResultadosDistribucion = comprobacion;
            //    //}
            //}

            ///*--------------------------------------------------------------------------------------*/
            //var reCoAct = ResultadosActorPol.Where(x => x.Coalicion != 0).ToList();
            //var reParAct = ResultadosActorPol.Where(x => x.Partido != 0).ToList();
            //var reIndAct = ResultadosActorPol.Where(x => x.Independiente != 0).ToList();
            //LreParActor = reParAct.GroupBy(x => x.Partido).Select(g => new ElementosListas
            //{
            //    Partido = g.Key,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.First().Independiente,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreCoActor = reCoAct.GroupBy(x => x.Coalicion).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.Key,
            //    Independiente = g.First().Independiente,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreIndActor = reIndAct.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.Key,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //var PriUnionActor = LreParActor.Concat(LreCoActor).ToList();
            //var SecUnionActor = PriUnionActor.Concat(LreIndActor).ToList();
            var par = _db.Partidos.ToList().OrderBy(x => x.Id).ThenBy(x => x.Prioridad);
            var com = _db.Combinaciones.ToList().OrderBy(x => x.Id);
            var coa = _db.Coaliciones.ToList().OrderBy(x => x.Id);
            ViewBag.Partido = par;
            ViewBag.Combinacion = com;
            //ViewBag.Coalicion = coa;
            //ViewBag.ResultadosActor = SecUnionActor;
            ViewBag.Municipio = mun.Municipio;
            ViewBag.Demarcacion = dem.Nombre;
            return View();
        }

        [HttpGet]     
        public IActionResult GobernadorMunicipio()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            List<ElementosListas> LreParActa = new List<ElementosListas>();
            List<ElementosListas> LreCoActa = new List<ElementosListas>();
            List<ElementosListas> LreIndActa = new List<ElementosListas>();
            List<ElementosListas> LreParActor = new List<ElementosListas>();
            List<ElementosListas> LreCoActor = new List<ElementosListas>();
            List<ElementosListas> LreIndActor = new List<ElementosListas>();
            /*------------------------------------------------------------------------*/

            var Cabecera = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraGobPys(1, mun.Id);
            var TotCaptura = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraGobPysCompleta(1,mun.Id);
            List<T_Votos_Acta> Lrega = new List<T_Votos_Acta>();
            T_Votos_Acta Rgistoo = new T_Votos_Acta();
            Rgistoo.NoRegistrados = Cabecera.Sum(x => x.NoRegistrados);
            Rgistoo.Nulos = Cabecera.Sum(x => x.Nulos);
            Rgistoo.Total = Cabecera.Sum(x => x.Total);
            Lrega.Add(Rgistoo);
            ViewBag.ResultadosCabecera = Lrega;
            /*-----------------------------------------------------------------------*/

            var ResultadosActas = _context.Detalle_Votos_Acta_Partido.GobernadorPorMunicipio(mun.Id);
            var ResultadosActorPol = _context.Detalle_Votos_Acta_Partido.GobernadorPorMunicipioActorPolitico(mun.Id);
            /* -----------------------------------------------------------------------------*/
            var rePar = ResultadosActas.Where(x => x.Partido != 0).ToList();
            var reCoa = ResultadosActas.Where(x => x.Coalicion != 0).ToList();
            var reInd = ResultadosActas.Where(x => x.Independiente != 0).ToList();
            LreParActa = rePar.GroupBy(x => x.Partido).Select(g => new ElementosListas
            {
                Partido = g.Key,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos),

            }).ToList();

            LreCoActa = reCoa.GroupBy(x => x.Combinacion).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.Key,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            LreIndActa = reInd.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.Key,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            var PriUnion = LreParActa.Concat(LreCoActa).ToList();
            var SecUnion = PriUnion.Concat(LreIndActa).ToList();
            ViewBag.ResultadosActas = SecUnion;
            /*-----------------------------------------------------------------------------*/

            //if (Cabecera.Count() == TotCaptura.Count())
            //{
            //    var comprobacion = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 1 && x.Municipio == mun.Id).ToList();
            //    if (comprobacion.Count() != 0)
            //    {
            //        foreach (var borr in comprobacion)
            //        {
            //            var resbo = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdDetalleVotosPartidos == borr.IdDetalleVotosPartidos).FirstOrDefault();
            //            _db.Remove(resbo);
            //        }
            //        _db.SaveChanges();
            //    }
            //    //if (comprobacion.Count() == 0)
            //    //{
            //    var distribucionPartidos = SecUnion.Where(x => x.Partido != 0).ToList();
            //        foreach (var parti in distribucionPartidos)
            //        {
            //            T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //            detpar.IdEleccion = 1;
            //            detpar.Municipio = mun.Id;
            //            detpar.IdPartido = parti.Partido.Value;
            //            detpar.Votos = parti.Votos.Value;
            //            _db.Add(detpar);
            //        }
            //        _db.SaveChanges();
            //        var distribucionIndependientes = SecUnion.Where(x => x.Independiente != 0).ToList();
            //        foreach (var indepe in distribucionIndependientes)
            //        {
            //            T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //            detpar.IdEleccion = 1;
            //            detpar.Municipio = mun.Id;
            //            detpar.IdIndependiente = indepe.Independiente.Value;
            //            detpar.Votos = indepe.Votos.Value;
            //            _db.Add(detpar);
            //            _db.SaveChanges();
            //        }
            //        var listcoali = SecUnion.Where(x => x.Coalicion != 0).Select(x => x.Coalicion).Distinct().ToList();
            //        foreach (var coali in listcoali)
            //        {
            //            var coalicion = _context.Combinacion.GetAll().Where(x => x.CoalicionId == coali).ToList();
            //            foreach (var combi in coalicion)
            //            {
            //                List<ElementosListas> Ldet = new List<ElementosListas>();
            //                var combinacion = _context.Combinacion_Detalle.GetAll().Where(x => x.CombinacionId == combi.Id).ToList();
            //                foreach (var combidet in combinacion)
            //                {

            //                    var listpartcoali = SecUnion.Where(x => x.Partido == combidet.PartidoId).FirstOrDefault();
            //                    Ldet.Add(listpartcoali);
            //                }
            //                var listapartidos = Ldet.OrderByDescending(x => x.Votos).ToList();
            //                var resultadocombi = SecUnion.Where(x => x.Combinacion == combi.Id).FirstOrDefault();
            //                int cont = 0;
            //                decimal pos = combi.Tamaño;
            //                decimal votos = resultadocombi.Votos.Value;
            //                for (int i = 0; i < combi.Tamaño; i++)
            //                {
            //                    if (votos == 0)
            //                    {
            //                        break;
            //                    }
            //                    decimal divisionvotos = votos / pos;
            //                    decimal entero = Math.Floor(divisionvotos);
            //                    decimal deci = divisionvotos - Math.Floor(divisionvotos);
            //                    double decim = Convert.ToDouble(deci);
            //                    if (decim > 0.0)
            //                    {
            //                        entero = entero + 1;
            //                    }

            //                    var partido = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdPartido == listapartidos.Select(x => x.Partido).ElementAt(cont) && x.IdEleccion == 1 && x.Municipio == mun.Id).FirstOrDefault();
            //                    int votosentero = Convert.ToInt32(entero);
            //                    partido.Votos = partido.Votos + votosentero;
            //                    _db.SaveChanges();
            //                    votos = votos - votosentero;
            //                    if (votos == 0)
            //                    {
            //                        break;
            //                    }

            //                    cont = cont + 1;
            //                    pos = pos - 1;
            //                }
            //            }
            //        }
            //        var Resuparti = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 1 && x.Municipio == mun.Id).ToList();
            //        ViewBag.ResultadosDistribucion = Resuparti;
            //    //}
            //    //else
            //    //{
            //    //    ViewBag.ResultadosDistribucion = comprobacion;
            //    //}
            //}

            /*--------------------------------------------------------------------------------------*/
            //var reCoAct = ResultadosActorPol.Where(x => x.Coalicion != 0).ToList();
            //var reParAct = ResultadosActorPol.Where(x => x.Partido != 0).ToList();
            //var reIndAct = ResultadosActorPol.Where(x => x.Independiente != 0).ToList();
            //LreParActor = reParAct.GroupBy(x => x.Partido).Select(g => new ElementosListas
            //{
            //    Partido = g.Key,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.First().Independiente,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreCoActor = reCoAct.GroupBy(x => x.Coalicion).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.Key,
            //    Independiente = g.First().Independiente,
            //    Combinacion = g.First().Combinacion,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreIndActor = reIndAct.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.Key,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //var PriUnionActor = LreParActor.Concat(LreCoActor).ToList();
            //var SecUnionActor = PriUnionActor.Concat(LreIndActor).ToList();
            var par = _db.Partidos.ToList().OrderBy(x => x.Id).ThenBy(x => x.Prioridad);
            var com = _db.Combinaciones.ToList().OrderBy(x => x.Id);
            //var coa = _db.Coaliciones.ToList().OrderBy(x => x.Id);
            ViewBag.Partido = par.OrderBy(x=> x.Id);
            ViewBag.Combinacion = com.OrderBy(x=> x.Coalicion).ThenByDescending(x => x.Tamaño);
            //ViewBag.Coalicion = coa;
            //ViewBag.ResultadosActor = SecUnionActor;
            ViewBag.Municipio = mun.Municipio;
            return View();
        }


        [HttpGet]
        public IActionResult GobernadorEstatalAdmin()
        {

            List<ElementosListas> LreParActa = new List<ElementosListas>();
            List<ElementosListas> LreCoActa = new List<ElementosListas>();
            List<ElementosListas> LreIndActa = new List<ElementosListas>();
            List<ElementosListas> LreParActor = new List<ElementosListas>();
            List<ElementosListas> LreCoActor = new List<ElementosListas>();
            List<ElementosListas> LreIndActor = new List<ElementosListas>();
            /*------------------------------------------------------------------------*/

            var Cabecera = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraGobPys(1, 0);
            var TotCaptura = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraGobPysCompleta(1, 0);
            List<T_Votos_Acta> Lrega = new List<T_Votos_Acta>();
            T_Votos_Acta Rgistoo = new T_Votos_Acta();
            Rgistoo.NoRegistrados = Cabecera.Sum(x => x.NoRegistrados);
            Rgistoo.Nulos = Cabecera.Sum(x => x.Nulos);
            Rgistoo.Total = Cabecera.Sum(x => x.Total);
            Lrega.Add(Rgistoo);
            ViewBag.ResultadosCabecera = Lrega;
            /*-----------------------------------------------------------------------*/

            var ResultadosActas = _context.Detalle_Votos_Acta_Partido.GobernadorPorMunicipio(0);
            var ResultadosActorPol = _context.Detalle_Votos_Acta_Partido.GobernadorPorMunicipioActorPolitico(0);
            /* -----------------------------------------------------------------------------*/
            var rePar = ResultadosActas.Where(x => x.Partido != 0).ToList();
            var reCoa = ResultadosActas.Where(x => x.Coalicion != 0).ToList();
            var reInd = ResultadosActas.Where(x => x.Independiente != 0).ToList();
            LreParActa = rePar.GroupBy(x => x.Partido).Select(g => new ElementosListas
            {
                Partido = g.Key,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos),

            }).ToList();

            LreCoActa = reCoa.GroupBy(x => x.Combinacion).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.Key,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            LreIndActa = reInd.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.Key,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            var PriUnion = LreParActa.Concat(LreCoActa).ToList();
            var SecUnion = PriUnion.Concat(LreIndActa).ToList();
            ViewBag.ResultadosActas = SecUnion;
            /*-----------------------------------------------------------------------------*/

            //if (Cabecera.Count() == TotCaptura.Count())
            //{
            //    var comprobacion = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 1 && x.Municipio == 21).ToList();
            //    if (comprobacion.Count() != 0)
            //    {
            //        foreach (var borr in comprobacion)
            //        {
            //            var resbo = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdDetalleVotosPartidos == borr.IdDetalleVotosPartidos).FirstOrDefault();
            //            _db.Remove(resbo);
            //        }
            //        _db.SaveChanges();
            //    }
            //    //if (comprobacion.Count() == 0)
            //    //{
            //    var distribucionPartidos = SecUnion.Where(x => x.Partido != 0).ToList();
            //    foreach (var parti in distribucionPartidos)
            //    {
            //        T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //        detpar.IdEleccion = 1;
            //        detpar.Municipio = 21;
            //        detpar.IdPartido = parti.Partido.Value;
            //        detpar.Votos = parti.Votos.Value;
            //        _db.Add(detpar);
            //    }
            //    _db.SaveChanges();
            //    var distribucionIndependientes = SecUnion.Where(x => x.Independiente != 0).ToList();
            //    foreach (var indepe in distribucionIndependientes)
            //    {
            //        T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //        detpar.IdEleccion = 1;
            //        detpar.Municipio = 21;
            //        detpar.IdIndependiente = indepe.Independiente.Value;
            //        detpar.Votos = indepe.Votos.Value;
            //        _db.Add(detpar);
            //        _db.SaveChanges();
            //    }
            //    var listcoali = SecUnion.Where(x => x.Coalicion != 0).Select(x => x.Coalicion).Distinct().ToList();
            //    foreach (var coali in listcoali)
            //    {
            //        var coalicion = _context.Combinacion.GetAll().Where(x => x.CoalicionId == coali).ToList();
            //        foreach (var combi in coalicion)
            //        {
            //            List<ElementosListas> Ldet = new List<ElementosListas>();
            //            var combinacion = _context.Combinacion_Detalle.GetAll().Where(x => x.CombinacionId == combi.Id).ToList();
            //            foreach (var combidet in combinacion)
            //            {

            //                var listpartcoali = SecUnion.Where(x => x.Partido == combidet.PartidoId).FirstOrDefault();
            //                Ldet.Add(listpartcoali);
            //            }
            //            var listapartidos = Ldet.OrderByDescending(x => x.Votos).ToList();
            //            var resultadocombi = SecUnion.Where(x => x.Combinacion == combi.Id).FirstOrDefault();
            //            int cont = 0;
            //            decimal pos = combi.Tamaño;
            //            decimal votos = resultadocombi.Votos.Value;
            //            for (int i = 0; i < combi.Tamaño; i++)
            //            {
            //                if (votos == 0)
            //                {
            //                    break;
            //                }
            //                decimal divisionvotos = votos / pos;
            //                decimal entero = Math.Floor(divisionvotos);
            //                decimal deci = divisionvotos - Math.Floor(divisionvotos);
            //                double decim = Convert.ToDouble(deci);
            //                if (decim > 0.0)
            //                {
            //                    entero = entero + 1;
            //                }

            //                var partido = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdPartido == listapartidos.Select(x => x.Partido).ElementAt(cont) && x.IdEleccion == 1 && x.Municipio == 21).FirstOrDefault();
            //                int votosentero = Convert.ToInt32(entero);
            //                partido.Votos = partido.Votos + votosentero;
            //                _db.SaveChanges();
            //                votos = votos - votosentero;
            //                if (votos == 0)
            //                {
            //                    break;
            //                }

            //                cont = cont + 1;
            //                pos = pos - 1;
            //            }
            //        }
            //    }
            //    var Resuparti = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 1 && x.Municipio == 21).ToList();
            //    ViewBag.ResultadosDistribucion = Resuparti;
            //    //}
            //    //else
            //    //{
            //    //    ViewBag.ResultadosDistribucion = comprobacion;
            //    //}
            //}

            /*--------------------------------------------------------------------------------------*/
            //var reCoAct = ResultadosActorPol.Where(x => x.Coalicion != 0).ToList();
            //var reParAct = ResultadosActorPol.Where(x => x.Partido != 0).ToList();
            //var reIndAct = ResultadosActorPol.Where(x => x.Independiente != 0).ToList();
            //LreParActor = reParAct.GroupBy(x => x.Partido).Select(g => new ElementosListas
            //{
            //    Partido = g.Key,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.First().Independiente,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreCoActor = reCoAct.GroupBy(x => x.Coalicion).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.Key,
            //    Independiente = g.First().Independiente,
            //    Combinacion = g.First().Combinacion,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreIndActor = reIndAct.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.Key,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //var PriUnionActor = LreParActor.Concat(LreCoActor).ToList();
            //var SecUnionActor = PriUnionActor.Concat(LreIndActor).ToList();
            var par = _db.Partidos.ToList().OrderBy(x => x.Id).ThenBy(x => x.Prioridad);
            var com = _db.Combinaciones.ToList().OrderBy(x => x.Id);
            var coa = _db.Coaliciones.ToList().OrderBy(x => x.Id);
            ViewBag.Partido = par.OrderBy(x => x.Id);
            ViewBag.Combinacion = com.OrderBy(x => x.Coalicion).ThenByDescending(x => x.Tamaño);
            //ViewBag.Coalicion = coa;
            //ViewBag.ResultadosActor = SecUnionActor;
            return View();
        }

        [HttpGet]
        public IActionResult PysMunicipio()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            List<ElementosListas> LreParActa = new List<ElementosListas>();
            List<ElementosListas> LreCoActa = new List<ElementosListas>();
            List<ElementosListas> LreIndActa = new List<ElementosListas>();
            List<ElementosListas> LreParActor = new List<ElementosListas>();
            List<ElementosListas> LreCoActor = new List<ElementosListas>();
            List<ElementosListas> LreIndActor = new List<ElementosListas>();
            /*------------------------------------------------------------------------*/

            var Cabecera = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraGobPys(2, mun.Id);
            var TotCaptura = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraGobPysCompleta(2, mun.Id);
            List<T_Votos_Acta> Lrega = new List<T_Votos_Acta>();
            T_Votos_Acta Rgistoo = new T_Votos_Acta();
            Rgistoo.NoRegistrados = Cabecera.Sum(x => x.NoRegistrados);
            Rgistoo.Nulos = Cabecera.Sum(x => x.Nulos);
            Rgistoo.Total = Cabecera.Sum(x => x.Total);
            Lrega.Add(Rgistoo);
            ViewBag.ResultadosCabecera = Lrega;
            /*-----------------------------------------------------------------------*/

            var ResultadosActas = _context.Detalle_Votos_Acta_Partido.PySMunicipio(mun.Id);
            var ResultadosActorPol = _context.Detalle_Votos_Acta_Partido.PySMunicipioActorPolitico(mun.Id);
            /* -----------------------------------------------------------------------------*/
            var rePar = ResultadosActas.Where(x => x.Partido != 0).ToList();
            var reCoa = ResultadosActas.Where(x => x.Coalicion != 0).ToList();
            var reInd = ResultadosActas.Where(x => x.Independiente != 0).ToList();
            LreParActa = rePar.GroupBy(x => x.Partido).Select(g => new ElementosListas
            {
                Partido = g.Key,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos),

            }).ToList();

            LreCoActa = reCoa.GroupBy(x => x.Combinacion).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.Key,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            LreIndActa = reInd.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.Key,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            var PriUnion = LreParActa.Concat(LreCoActa).ToList();
            var SecUnion = PriUnion.Concat(LreIndActa).ToList();
            ViewBag.ResultadosActas = SecUnion;
            //if (Cabecera.Count() == TotCaptura.Count())
            //{
            //    var comprobacion = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 2 && x.Municipio == mun.Id).ToList();
            //    if (comprobacion.Count() != 0)
            //    {
            //        foreach (var borr in comprobacion)
            //        {
            //            var resbo = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdDetalleVotosPartidos == borr.IdDetalleVotosPartidos).FirstOrDefault();
            //            _db.Remove(resbo);
            //        }
            //        _db.SaveChanges();
            //    }
            //    //if (comprobacion.Count() == 0)
            //    //{
            //    var distribucionPartidos = SecUnion.Where(x => x.Partido != 0).ToList();
            //        foreach (var parti in distribucionPartidos)
            //        {
            //            T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //            detpar.IdEleccion = 2;
            //            detpar.Municipio = mun.Id;
            //            detpar.IdPartido = parti.Partido.Value;
            //            detpar.Votos = parti.Votos.Value;
            //            _db.Add(detpar);
            //        }
            //        _db.SaveChanges();
            //        var distribucionIndependientes = SecUnion.Where(x => x.Independiente != 0).ToList();
            //        foreach (var indepe in distribucionIndependientes)
            //        {
            //            T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //            detpar.IdEleccion = 2;
            //            detpar.Municipio = mun.Id;
            //            detpar.IdIndependiente = indepe.Independiente.Value;
            //            detpar.Votos = indepe.Votos.Value;
            //            _db.Add(detpar);
            //            _db.SaveChanges();
            //        }
            //        var listcoali = SecUnion.Where(x => x.Coalicion != 0).Select(x => x.Coalicion).Distinct().ToList();
            //        foreach (var coali in listcoali)
            //        {
            //            var coalicion = _context.Combinacion.GetAll().Where(x => x.CoalicionId == coali).ToList();
            //            foreach (var combi in coalicion)
            //            {
            //                List<ElementosListas> Ldet = new List<ElementosListas>();
            //                var combinacion = _context.Combinacion_Detalle.GetAll().Where(x => x.CombinacionId == combi.Id).ToList();
            //                foreach (var combidet in combinacion)
            //                {

            //                    var listpartcoali = SecUnion.Where(x => x.Partido == combidet.PartidoId).FirstOrDefault();
            //                    Ldet.Add(listpartcoali);
            //                }
            //                var listapartidos = Ldet.OrderByDescending(x => x.Votos).ToList();
            //                var resultadocombi = SecUnion.Where(x => x.Combinacion == combi.Id).FirstOrDefault();
            //                int cont = 0;
            //                decimal pos = combi.Tamaño;
            //                decimal votos = resultadocombi.Votos.Value;
            //                for (int i = 0; i < combi.Tamaño; i++)
            //                {
            //                    if (votos == 0)
            //                    {
            //                        break;
            //                    }
            //                    decimal divisionvotos = votos / pos;
            //                    decimal entero = Math.Floor(divisionvotos);
            //                    decimal deci = divisionvotos - Math.Floor(divisionvotos);
            //                    double decim = Convert.ToDouble(deci);
            //                    if (decim > 0.0)
            //                    {
            //                        entero = entero + 1;
            //                    }

            //                    var partido = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdPartido == listapartidos.Select(x => x.Partido).ElementAt(cont) && x.IdEleccion == 2 && x.Municipio == mun.Id).FirstOrDefault();
            //                    int votosentero = Convert.ToInt32(entero);
            //                    partido.Votos = partido.Votos + votosentero;
            //                    _db.SaveChanges();
            //                    votos = votos - votosentero;
            //                    if (votos == 0)
            //                    {
            //                        break;
            //                    }

            //                    cont = cont + 1;
            //                    pos = pos - 1;
            //                }
            //            }
            //        }
            //        var Resuparti = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 2 && x.Municipio == mun.Id).ToList();
            //        ViewBag.ResultadosDistribucion = Resuparti;
            //    //}
            //    //else
            //    //{
            //    //    ViewBag.ResultadosDistribucion = comprobacion;
            //    //}
            //}
            //    /*--------------------------------------------------------------------------------------*/
            //    var reCoAct = ResultadosActorPol.Where(x => x.Coalicion != 0).ToList();
            //var reParAct = ResultadosActorPol.Where(x => x.Partido != 0).ToList();
            //var reIndAct = ResultadosActorPol.Where(x => x.Independiente != 0).ToList();
            //LreParActor = reParAct.GroupBy(x => x.Partido).Select(g => new ElementosListas
            //{
            //    Partido = g.Key,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.First().Independiente,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreCoActor = reCoAct.GroupBy(x => x.Coalicion).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.Key,
            //    Independiente = g.First().Independiente,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreIndActor = reIndAct.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.Key,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //var PriUnionActor = LreParActor.Concat(LreCoActor).ToList();
            //var SecUnionActor = PriUnionActor.Concat(LreIndActor).ToList();
            var par = _db.Partidos.ToList().OrderBy(x => x.Id).ThenBy(x => x.Prioridad);
            var com = _db.Combinaciones.ToList().OrderBy(x => x.Id);
            var coa = _db.Coaliciones.ToList().OrderBy(x => x.Id);
            ViewBag.Partido = par;
            ViewBag.Combinacion = com;
            ViewBag.Coalicion = coa;
            //ViewBag.ResultadosActor = SecUnionActor;
            ViewBag.Municipio = mun.Municipio;
            return View();
        }

        public IActionResult DiputadoMunicipio(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);

            List<ElementosListas> LreParActa = new List<ElementosListas>();
            List<ElementosListas> LreCoActa = new List<ElementosListas>();
            List<ElementosListas> LreIndActa = new List<ElementosListas>();
            List<ElementosListas> LreParActor = new List<ElementosListas>();
            List<ElementosListas> LreCoActor = new List<ElementosListas>();
            List<ElementosListas> LreIndActor = new List<ElementosListas>();
            /*------------------------------------------------------------------------*/

            var Cabecera = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraDip(mun.Id, id);
            var TotCaptura = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraDipCompleta(mun.Id, id);
            List<T_Votos_Acta> Lrega = new List<T_Votos_Acta>();
            T_Votos_Acta Rgistoo = new T_Votos_Acta();
            Rgistoo.NoRegistrados = Cabecera.Sum(x => x.NoRegistrados);
            Rgistoo.Nulos = Cabecera.Sum(x => x.Nulos);
            Rgistoo.Total = Cabecera.Sum(x => x.Total);
            Lrega.Add(Rgistoo);
            ViewBag.ResultadosCabecera = Lrega;
            /*-----------------------------------------------------------------------*/

            var ResultadosActas = _context.Detalle_Votos_Acta_Partido.DiputadosMunicipioDistrito(mun.Id, id);
            var ResultadosActorPol = _context.Detalle_Votos_Acta_Partido.DiputadosMunicipioDistritoActorPolitico(mun.Id, id);
            /* -----------------------------------------------------------------------------*/
            var rePar = ResultadosActas.Where(x => x.Partido != 0).ToList();
            var reCoa = ResultadosActas.Where(x => x.Coalicion != 0).ToList();
            var reInd = ResultadosActas.Where(x => x.Independiente != 0).ToList();
            LreParActa = rePar.GroupBy(x => x.Partido).Select(g => new ElementosListas
            {
                Partido = g.Key,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos),

            }).ToList();

            LreCoActa = reCoa.GroupBy(x => x.Combinacion).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.Key,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            LreIndActa = reInd.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.Key,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            var PriUnion = LreParActa.Concat(LreCoActa).ToList();
            var SecUnion = PriUnion.Concat(LreIndActa).ToList();
            ViewBag.ResultadosActas = SecUnion;
            /*----------------------------------------------------------------------------------------------*/
            //if (Cabecera.Count() == TotCaptura.Count())
            //{
            //    var comprobacion = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 3 && x.Municipio == mun.Id && x.Distrito == id).ToList();
            //    if (comprobacion.Count() != 0)
            //    {
            //        foreach (var borr in comprobacion)
            //        {
            //            var resbo = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdDetalleVotosPartidos == borr.IdDetalleVotosPartidos).FirstOrDefault();
            //            _db.Remove(resbo);
            //        }
            //        _db.SaveChanges();
            //    }
            //    //if (comprobacion.Count() == 0)
            //    //{
            //    var distribucionPartidos = SecUnion.Where(x => x.Partido != 0).ToList();
            //        foreach (var parti in distribucionPartidos)
            //        {
            //            T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //            detpar.IdEleccion = 3;
            //            detpar.Municipio = mun.Id;
            //            detpar.Distrito = id;
            //            detpar.IdPartido = parti.Partido.Value;
            //            detpar.Votos = parti.Votos.Value;
            //            _db.Add(detpar);
            //        }
            //        _db.SaveChanges();
            //        var distribucionIndependientes = SecUnion.Where(x => x.Independiente != 0).ToList();
            //        foreach (var indepe in distribucionIndependientes)
            //        {
            //            T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //            detpar.IdEleccion = 3;
            //            detpar.Municipio = mun.Id;
            //            detpar.Distrito = id;
            //            detpar.IdIndependiente = indepe.Independiente.Value;
            //            detpar.Votos = indepe.Votos.Value;
            //            _db.Add(detpar);
            //            _db.SaveChanges();
            //        }
            //        var listcoali = SecUnion.Where(x => x.Coalicion != 0).Select(x => x.Coalicion).Distinct().ToList();
            //        foreach (var coali in listcoali)
            //        {
            //            var coalicion = _context.Combinacion.GetAll().Where(x => x.CoalicionId == coali).ToList();
            //            foreach (var combi in coalicion)
            //            {
            //                List<ElementosListas> Ldet = new List<ElementosListas>();
            //                var combinacion = _context.Combinacion_Detalle.GetAll().Where(x => x.CombinacionId == combi.Id).ToList();
            //                foreach (var combidet in combinacion)
            //                {

            //                    var listpartcoali = SecUnion.Where(x => x.Partido == combidet.PartidoId).FirstOrDefault();
            //                    Ldet.Add(listpartcoali);
            //                }
            //                var listapartidos = Ldet.OrderByDescending(x => x.Votos).ToList();
            //                var resultadocombi = SecUnion.Where(x => x.Combinacion == combi.Id).FirstOrDefault();
            //                int cont = 0;
            //                decimal pos = combi.Tamaño;
            //                decimal votos = resultadocombi.Votos.Value;
            //                for (int i = 0; i < combi.Tamaño; i++)
            //                {
            //                    if (votos == 0)
            //                    {
            //                        break;
            //                    }
            //                    decimal divisionvotos = votos / pos;
            //                    decimal entero = Math.Floor(divisionvotos);
            //                    decimal deci = divisionvotos - Math.Floor(divisionvotos);
            //                    double decim = Convert.ToDouble(deci);
            //                    if (decim > 0.0)
            //                    {
            //                        entero = entero + 1;
            //                    }

            //                    var partido = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdPartido == listapartidos.Select(x => x.Partido).ElementAt(cont) && x.IdEleccion == 3 && x.Municipio == mun.Id && x.Distrito == id).FirstOrDefault();
            //                    int votosentero = Convert.ToInt32(entero);
            //                    partido.Votos = partido.Votos + votosentero;
            //                    _db.SaveChanges();
            //                    votos = votos - votosentero;
            //                    if (votos == 0)
            //                    {
            //                        break;
            //                    }

            //                    cont = cont + 1;
            //                    pos = pos - 1;
            //                }
            //            }
            //        }
            //        var Resuparti = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 3 && x.Municipio == mun.Id && x.Distrito == id).ToList();
            //        ViewBag.ResultadosDistribucion = Resuparti;
            //    //}
            //    //else
            //    //{
            //    //    ViewBag.ResultadosDistribucion = comprobacion;
            //    //}
            //}

            ///*--------------------------------------------------------------------------------------*/
            //var reCoAct = ResultadosActorPol.Where(x => x.Coalicion != 0).ToList();
            //var reParAct = ResultadosActorPol.Where(x => x.Partido != 0).ToList();
            //var reIndAct = ResultadosActorPol.Where(x => x.Independiente != 0).ToList();
            //LreParActor = reParAct.GroupBy(x => x.Partido).Select(g => new ElementosListas
            //{
            //    Partido = g.Key,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.First().Independiente,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreCoActor = reCoAct.GroupBy(x => x.Coalicion).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.Key,
            //    Independiente = g.First().Independiente,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreIndActor = reIndAct.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.Key,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //var PriUnionActor = LreParActor.Concat(LreCoActor).ToList();
            //var SecUnionActor = PriUnionActor.Concat(LreIndActor).ToList();
            var par = _db.Partidos.ToList().OrderBy(x => x.Id).ThenBy(x => x.Prioridad);
            var com = _db.Combinaciones.ToList().OrderBy(x => x.Id);
            var coa = _db.Coaliciones.ToList().OrderBy(x => x.Id);
            ViewBag.Partido = par;
            ViewBag.Combinacion = com;
            //ViewBag.Coalicion = coa;
            //ViewBag.ResultadosActor = SecUnionActor;
            ViewBag.Municipio = mun.Municipio;
            return View();
        }
        public IActionResult DiputadoDistrito(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            List<ElementosListas> LreParActa = new List<ElementosListas>();
            List<ElementosListas> LreCoActa = new List<ElementosListas>();
            List<ElementosListas> LreIndActa = new List<ElementosListas>();
            List<ElementosListas> LreParActor = new List<ElementosListas>();
            List<ElementosListas> LreCoActor = new List<ElementosListas>();
            List<ElementosListas> LreIndActor = new List<ElementosListas>();
            /*------------------------------------------------------------------------*/

            var Cabecera = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraDip(0, id);
            var TotCaptura = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraDipCompleta(0, id);
            List<T_Votos_Acta> Lrega = new List<T_Votos_Acta>();
            T_Votos_Acta Rgistoo = new T_Votos_Acta();
            Rgistoo.NoRegistrados = Cabecera.Sum(x => x.NoRegistrados);
            Rgistoo.Nulos = Cabecera.Sum(x => x.Nulos);
            Rgistoo.Total = Cabecera.Sum(x => x.Total);
            Lrega.Add(Rgistoo);
            ViewBag.ResultadosCabecera = Lrega;
            /*-----------------------------------------------------------------------*/

            var ResultadosActas = _context.Detalle_Votos_Acta_Partido.DiputadosDistrito(id);
            var ResultadosActorPol = _context.Detalle_Votos_Acta_Partido.DiputadosDistritoActorPolitico(id);
            /* -----------------------------------------------------------------------------*/
            var rePar = ResultadosActas.Where(x => x.Partido != 0).ToList();
            var reCoa = ResultadosActas.Where(x => x.Coalicion != 0).ToList();
            var reInd = ResultadosActas.Where(x => x.Independiente != 0).ToList();
            LreParActa = rePar.GroupBy(x => x.Partido).Select(g => new ElementosListas
            {
                Partido = g.Key,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos),

            }).ToList();

            LreCoActa = reCoa.GroupBy(x => x.Combinacion).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.Key,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            LreIndActa = reInd.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.Key,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            var PriUnion = LreParActa.Concat(LreCoActa).ToList();
            var SecUnion = PriUnion.Concat(LreIndActa).ToList();
            ViewBag.ResultadosActas = SecUnion;
            /*----------------------------------------------------------------------*/
            //if (Cabecera.Count() == TotCaptura.Count())
            //{
            //    var comprobacion = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 3 && x.Distrito == id).ToList();
            //    if (comprobacion.Count() != 0)
            //    {
            //        foreach (var borr in comprobacion)
            //        {
            //            var resbo = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdDetalleVotosPartidos == borr.IdDetalleVotosPartidos).FirstOrDefault();
            //            _db.Remove(resbo);
            //        }
            //        _db.SaveChanges();
            //    }
            //        var distribucionPartidos = SecUnion.Where(x => x.Partido != 0).ToList();
            //        foreach (var parti in distribucionPartidos)
            //        {
            //            T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //            detpar.IdEleccion = 3;
            //            detpar.Distrito = id;
            //            detpar.IdPartido = parti.Partido.Value;
            //            detpar.Votos = parti.Votos.Value;
            //            _db.Add(detpar);
            //        }
            //        _db.SaveChanges();
            //        var distribucionIndependientes = SecUnion.Where(x => x.Independiente != 0).ToList();
            //        foreach (var indepe in distribucionIndependientes)
            //        {
            //            T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //            detpar.IdEleccion = 3;
            //            detpar.Distrito = id;
            //            detpar.IdIndependiente = indepe.Independiente.Value;
            //            detpar.Votos = indepe.Votos.Value;
            //            _db.Add(detpar);
            //            _db.SaveChanges();
            //        }
            //        var listcoali = SecUnion.Where(x => x.Coalicion != 0).Select(x => x.Coalicion).Distinct().ToList();
            //        foreach (var coali in listcoali)
            //        {
            //            var coalicion = _context.Combinacion.GetAll().Where(x => x.CoalicionId == coali).ToList();
            //            foreach (var combi in coalicion)
            //            {
            //                List<ElementosListas> Ldet = new List<ElementosListas>();
            //                var combinacion = _context.Combinacion_Detalle.GetAll().Where(x => x.CombinacionId == combi.Id).ToList();
            //                foreach (var combidet in combinacion)
            //                {

            //                    var listpartcoali = SecUnion.Where(x => x.Partido == combidet.PartidoId).FirstOrDefault();
            //                    Ldet.Add(listpartcoali);
            //                }
            //                var listapartidos = Ldet.OrderByDescending(x => x.Votos).ToList();
            //                var resultadocombi = SecUnion.Where(x => x.Combinacion == combi.Id).FirstOrDefault();
            //                int cont = 0;
            //                decimal pos = combi.Tamaño;
            //                decimal votos = resultadocombi.Votos.Value;
            //                for (int i = 0; i < combi.Tamaño; i++)
            //                {
            //                    if (votos == 0)
            //                    {
            //                        break;
            //                    }
            //                    decimal divisionvotos = votos / pos;
            //                    decimal entero = Math.Floor(divisionvotos);
            //                    decimal deci = divisionvotos - Math.Floor(divisionvotos);
            //                    double decim = Convert.ToDouble(deci);
            //                    if (decim > 0.0)
            //                    {
            //                        entero = entero + 1;
            //                    }

            //                    var partido = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdPartido == listapartidos.Select(x => x.Partido).ElementAt(cont) && x.IdEleccion == 3  && x.Distrito == id).FirstOrDefault();
            //                    int votosentero = Convert.ToInt32(entero);
            //                    partido.Votos = partido.Votos + votosentero;
            //                    _db.SaveChanges();
            //                    votos = votos - votosentero;
            //                    if (votos == 0)
            //                    {
            //                        break;
            //                    }

            //                    cont = cont + 1;
            //                    pos = pos - 1;
            //                }
            //            }
            //        }
            //        var Resuparti = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 3 &&  x.Distrito == id).ToList();
            //        ViewBag.ResultadosDistribucion = Resuparti;
            //    //}
            //    //else
            //    //{
            //    //    ViewBag.ResultadosDistribucion = comprobacion;
            //    //}
            //}

            ///*--------------------------------------------------------------------------------------*/
            //var reCoAct = ResultadosActorPol.Where(x => x.Coalicion != 0).ToList();
            //var reParAct = ResultadosActorPol.Where(x => x.Partido != 0).ToList();
            //var reIndAct = ResultadosActorPol.Where(x => x.Independiente != 0).ToList();
            //LreParActor = reParAct.GroupBy(x => x.Partido).Select(g => new ElementosListas
            //{
            //    Partido = g.Key,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.First().Independiente,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreCoActor = reCoAct.GroupBy(x => x.Coalicion).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.Key,
            //    Independiente = g.First().Independiente,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreIndActor = reIndAct.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.Key,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //var PriUnionActor = LreParActor.Concat(LreCoActor).ToList();
            //var SecUnionActor = PriUnionActor.Concat(LreIndActor).ToList();
            var par = _db.Partidos.ToList().OrderBy(x => x.Id).ThenBy(x => x.Prioridad);
            var com = _db.Combinaciones.ToList().OrderBy(x => x.Id);
            var coa = _db.Coaliciones.ToList().OrderBy(x => x.Id);
            ViewBag.Partido = par;
            ViewBag.Combinacion = com;
            //ViewBag.Coalicion = coa;
            //ViewBag.ResultadosActor = SecUnionActor;
            ViewBag.Municipio = mun.Municipio;
            return View();
        }

        [HttpGet]

        public IActionResult RegidorMunicipio(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            List<ElementosListas> LreParActa = new List<ElementosListas>();
            List<ElementosListas> LreCoActa = new List<ElementosListas>();
            List<ElementosListas> LreIndActa = new List<ElementosListas>();
            List<ElementosListas> LreParActor = new List<ElementosListas>();
            List<ElementosListas> LreCoActor = new List<ElementosListas>();
            List<ElementosListas> LreIndActor = new List<ElementosListas>();
            /*------------------------------------------------------------------------*/

            var Cabecera = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraReg(mun.Id, id);
            var TotCaptura = _context.Detalle_Votos_Acta_Partido.ResultadosCabeceraRegCompleta(mun.Id, id);
            List<T_Votos_Acta> Lrega = new List<T_Votos_Acta>();
            T_Votos_Acta Rgistoo = new T_Votos_Acta();
            Rgistoo.NoRegistrados = Cabecera.Sum(x => x.NoRegistrados);
            Rgistoo.Nulos = Cabecera.Sum(x => x.Nulos);
            Rgistoo.Total = Cabecera.Sum(x => x.Total);
            Lrega.Add(Rgistoo);
            ViewBag.ResultadosCabecera = Lrega;
            /*-----------------------------------------------------------------------*/

            var ResultadosActas = _context.Detalle_Votos_Acta_Partido.RegidorMunicipioDemarcacion(mun.Id, id);
            var ResultadosActorPol = _context.Detalle_Votos_Acta_Partido.RegidorMunicipioDemarcacionActorPolitico(mun.Id, id);
            /* -----------------------------------------------------------------------------*/
            var rePar = ResultadosActas.Where(x => x.Partido != 0).ToList();
            var reCoa = ResultadosActas.Where(x => x.Coalicion != 0).ToList();
            var reInd = ResultadosActas.Where(x => x.Independiente != 0).ToList();
            LreParActa = rePar.GroupBy(x => x.Partido).Select(g => new ElementosListas
            {
                Partido = g.Key,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos),

            }).ToList();

            LreCoActa = reCoa.GroupBy(x => x.Combinacion).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.Key,
                Independiente = g.First().Independiente,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            LreIndActa = reInd.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            {
                Partido = g.First().Partido,
                Coalicion = g.First().Coalicion,
                Combinacion = g.First().Combinacion,
                Independiente = g.Key,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            var PriUnion = LreParActa.Concat(LreCoActa).ToList();
            var SecUnion = PriUnion.Concat(LreIndActa).ToList();
            ViewBag.ResultadosActas = SecUnion;
            /*--------------------------------------------------------------------------------*/
            //if (Cabecera.Count() == TotCaptura.Count())
            //{
            //    var comprobacion = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 4 && x.Municipio == mun.Id && x.Demarcacion == id).ToList();
            //    if (comprobacion.Count() != 0)
            //    { 
            //        foreach(var borr in comprobacion)
            //        {
            //            var resbo = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdDetalleVotosPartidos == borr.IdDetalleVotosPartidos).FirstOrDefault();
            //            _db.Remove(resbo);
            //        }
            //        _db.SaveChanges();
            //    }
            //        var distribucionPartidos = SecUnion.Where(x => x.Partido != 0).ToList();
            //        foreach (var parti in distribucionPartidos)
            //        {
            //            T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //            detpar.IdEleccion = 4;
            //            detpar.Municipio = mun.Id;
            //            detpar.Demarcacion = id;
            //            detpar.IdPartido = parti.Partido.Value;
            //            detpar.Votos = parti.Votos.Value;
            //            _db.Add(detpar);
            //        }
            //        _db.SaveChanges();
            //        var distribucionIndependientes = SecUnion.Where(x => x.Independiente != 0).ToList();
            //        foreach (var indepe in distribucionIndependientes)
            //        {
            //            T_Detalle_Votos_Acta_Partido detpar = new T_Detalle_Votos_Acta_Partido();
            //            detpar.IdEleccion = 4;
            //            detpar.Municipio = mun.Id;
            //            detpar.Demarcacion = id;
            //            detpar.IdIndependiente = indepe.Independiente.Value;
            //            detpar.Votos = indepe.Votos.Value;
            //            _db.Add(detpar);
            //            _db.SaveChanges();
            //        }
            //        var listcoali = SecUnion.Where(x => x.Coalicion != 0).Select(x => x.Coalicion).Distinct().ToList();
            //        foreach (var coali in listcoali)
            //        {
            //            var coalicion = _context.Combinacion.GetAll().Where(x => x.CoalicionId == coali).ToList();
            //            foreach (var combi in coalicion)
            //            {
            //                List<ElementosListas> Ldet = new List<ElementosListas>();
            //                var combinacion = _context.Combinacion_Detalle.GetAll().Where(x => x.CombinacionId == combi.Id).ToList();
            //                foreach (var combidet in combinacion)
            //                {

            //                    var listpartcoali = SecUnion.Where(x => x.Partido == combidet.PartidoId).FirstOrDefault();
            //                    Ldet.Add(listpartcoali);
            //                }
            //                var listapartidos = Ldet.OrderByDescending(x => x.Votos).ToList();
            //                var resultadocombi = SecUnion.Where(x => x.Combinacion == combi.Id).FirstOrDefault();
            //                int cont = 0;
            //                decimal pos = combi.Tamaño;
            //                decimal votos = resultadocombi.Votos.Value;
            //                for (int i = 0; i < combi.Tamaño; i++)
            //                {
            //                    if (votos == 0)
            //                    {
            //                        break;
            //                    }
            //                    decimal divisionvotos = votos / pos;
            //                    decimal entero = Math.Floor(divisionvotos);
            //                    decimal deci = divisionvotos - Math.Floor(divisionvotos);
            //                    double decim = Convert.ToDouble(deci);
            //                    if (decim > 0.0)
            //                    {
            //                        entero = entero + 1;
            //                    }

            //                    var partido = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdPartido == listapartidos.Select(x => x.Partido).ElementAt(cont) && x.IdEleccion == 4 && x.Municipio == mun.Id && x.Demarcacion == id).FirstOrDefault();
            //                    int votosentero = Convert.ToInt32(entero);
            //                    partido.Votos = partido.Votos + votosentero;
            //                    _db.SaveChanges();
            //                    votos = votos - votosentero;
            //                    if (votos == 0)
            //                    {
            //                        break;
            //                    }

            //                    cont = cont + 1;
            //                    pos = pos - 1;
            //                }
            //            }
            //        }
            //        var Resuparti = _context.Detalle_Votos_Acta_Partido.GetAll().Where(x => x.IdEleccion == 4 && x.Municipio == mun.Id && x.Demarcacion == id).ToList();
            //        ViewBag.ResultadosDistribucion = Resuparti;
            //    //}
            //    //else
            //    //{
            //    //    ViewBag.ResultadosDistribucion = comprobacion;
            //    //}
            //}

            ///*--------------------------------------------------------------------------------------*/
            //var reCoAct = ResultadosActorPol.Where(x => x.Coalicion != 0).ToList();
            //var reParAct = ResultadosActorPol.Where(x => x.Partido != 0).ToList();
            //var reIndAct = ResultadosActorPol.Where(x => x.Independiente != 0).ToList();
            //LreParActor = reParAct.GroupBy(x => x.Partido).Select(g => new ElementosListas
            //{
            //    Partido = g.Key,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.First().Independiente,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreCoActor = reCoAct.GroupBy(x => x.Coalicion).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.Key,
            //    Independiente = g.First().Independiente,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //LreIndActor = reIndAct.GroupBy(x => x.Independiente).Select(g => new ElementosListas
            //{
            //    Partido = g.First().Partido,
            //    Coalicion = g.First().Coalicion,
            //    Independiente = g.Key,
            //    Votos = g.Sum(x => x.Votos)

            //}).ToList();
            //var PriUnionActor = LreParActor.Concat(LreCoActor).ToList();
            //var SecUnionActor = PriUnionActor.Concat(LreIndActor).ToList();
            var par = _db.Partidos.ToList().OrderBy(x => x.Id).ThenBy(x => x.Prioridad);
            var com = _db.Combinaciones.ToList().OrderBy(x => x.Id);
            var coa = _db.Coaliciones.ToList().OrderBy(x => x.Id);
            ViewBag.Partido = par;
            ViewBag.Combinacion = com;
            //ViewBag.Coalicion = coa;
            //ViewBag.ResultadosActor = SecUnionActor;
            ViewBag.Municipio = mun.Municipio;
            return View();
        }

        [HttpGet]
        public IActionResult ImprimirEleccion()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var NumeroDistritoDemarcacion = _db.Secciones.Include(LMunicipio => LMunicipio.LMunicipio).Include(LDistrito => LDistrito.LDistrito).Include(LDemarcacion => LDemarcacion.LDemarcacion).Where(x => x.MunicipioId == mun.Id).ToList();
            var totaldistrito = NumeroDistritoDemarcacion.GroupBy(x => x.DistritoId).Select(i => new T_Distrito
            {
                Id = i.Key.Value,
                NoDistrito = i.First().LDistrito.NoDistrito
            }).OrderBy(x=> x.Id).ToList();
            var totaldemarcacion = NumeroDistritoDemarcacion.GroupBy(x => x.DemarcacionId).Select(i => new T_Demarcacion
            {
                Id = i.Key.Value,
                Nombre = i.First().LDemarcacion.Nombre,
                No_Demarcacion = i.First().LDemarcacion.No_Demarcacion
               
            }).OrderBy(x=> x.Id).ToList();
            var ConEspeciales = _context.Casilla.GetAll().Where(x => x.MunicipioId == mun.Id && x.TipoCasillaId == 4).ToList();


            var Distrito = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LDistrito => LDistrito.LDistrito).Where(x => x.LCasilla.LSeccion.MunicipioId == mun.Id).FirstOrDefault();
            var DistritoRP = _db.Acta_Detalle_RP.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LDistrito => LDistrito.LDistrito).Where(x => x.LCasilla.LSeccion.MunicipioId == mun.Id).FirstOrDefault();
            var CTotales = _db.Casillas.Include(LSeccion => LSeccion.LSeccion).Where(x => x.LSeccion.MunicipioId == mun.Id).ToList();
            var Casillas = CTotales.Where(x => x.Recibido == true).ToList();
            var partido = _context.Partido.GetAll().OrderBy(x => x.Prioridad).ToList();
            var Combinacion = _context.Combinacion.GetAll().OrderBy(x => x.Id).ToList();
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            var CabecerasPrincipales = _context.Votos_Actas.VotosActas(mun.Id);
            var CabecerasPrincipalesRP = _context.Votos_Actas.VotosActasRP(mun.Id);
            var CabeceraGob = CabecerasPrincipales.Where(x => x.LActaDetalle.IdEleccion == 1).ToList();
            var CabeceraAyu = CabecerasPrincipales.Where(x => x.LActaDetalle.IdEleccion == 2).ToList();
            var CabeceraDip = CabecerasPrincipales.Where(x => x.LActaDetalle.IdEleccion == 3).ToList();
            var CabeceraReg = CabecerasPrincipales.Where(x => x.LActaDetalle.IdEleccion == 4).ToList();
            var CabecerDipRP = CabecerasPrincipalesRP.Where(x => x.LActaDetalle.IdEleccion == 3).ToList();
            var CabecerRegRP = CabecerasPrincipalesRP.Where(x => x.LActaDetalle.IdEleccion == 4).ToList();

            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            List<ElementosCartel> PartidosGob = new List<ElementosCartel>();
            List<ElementosCartel> CoalicionGob = new List<ElementosCartel>();

            List<ElementosCartel> PartidosAyu = new List<ElementosCartel>();
            List<ElementosCartel> CoalicionAyu = new List<ElementosCartel>();
            List<ElementosCartel> IndependienteAyu = new List<ElementosCartel>();

            List<ElementosCartel> PartidosDip = new List<ElementosCartel>();
            List<ElementosCartel> CoalicionDip = new List<ElementosCartel>();

            List<ElementosCartel> PartidosReg = new List<ElementosCartel>();
            List<ElementosCartel> CoalicionReg = new List<ElementosCartel>();
            List<ElementosCartel> IndependienteReg = new List<ElementosCartel>();

            List<ElementosCartel> ListDiputadosRP = new List<ElementosCartel>();

            List<ElementosCartel> ListRegidorRP = new List<ElementosCartel>();

            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            var ResultadosGenerales = _context.Votos_Actas.DetalleVotos(mun.Id);
            var ResultadosGeneralesRP = _context.Votos_Actas.DetalleVotosRP(mun.Id);
            var ResultadosActasGob = ResultadosGenerales.Where(x => x.LVotosActa.LActaDetalle.IdEleccion == 1).ToList();
            var ResultadosActasAyu = ResultadosGenerales.Where(x => x.LVotosActa.LActaDetalle.IdEleccion == 2).ToList();
            var ResultadosActasDip = ResultadosGenerales.Where(x => x.LVotosActa.LActaDetalle.IdEleccion == 3).ToList();
            var ResultadosActasReg = ResultadosGenerales.Where(x => x.LVotosActa.LActaDetalle.IdEleccion == 4).ToList();
            var ResultadosActasDipRP = ResultadosGeneralesRP.Where(x => x.LVotosActa.LActaDetalle.IdEleccion == 3).ToList();
            var ResultadosActasRegRP = ResultadosGeneralesRP.Where(x => x.LVotosActa.LActaDetalle.IdEleccion == 4).ToList();

            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            var PartidoResGob = ResultadosActasGob.Where(x => x.IdPartido != 0).ToList();
            var CoalicionResGob = ResultadosActasGob.Where(x => x.IdCoalicion != 0).ToList();

            var PartidoResAyu = ResultadosActasAyu.Where(x => x.IdPartido != 0).ToList();
            var CoalicionResAyu = ResultadosActasAyu.Where(x => x.IdCoalicion != 0).ToList();
            var IndeResAyu = ResultadosActasAyu.Where(x => x.IdIndependiente != 0).ToList();

            var PartidoResDip = ResultadosActasDip.Where(x => x.IdPartido != 0).ToList();
            var CoalicionResDip = ResultadosActasDip.Where(x => x.IdCoalicion != 0).ToList();

            var PartidoResReg = ResultadosActasReg.Where(x => x.IdPartido != 0).ToList();
            var CoalicionResReg = ResultadosActasReg.Where(x => x.IdCoalicion != 0).ToList();
            var IndeResReg = ResultadosActasReg.Where(x => x.IdIndependiente != 0).ToList();

            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            PartidosGob = PartidoResGob.GroupBy(x => x.IdPartido).Select(g => new ElementosCartel
            {
                Partido = g.Key,
                Coalicion = g.First().IdCoalicion,
                Combinacion = g.First().IdCombinacion,
                Independiente = g.First().IdIndependiente,
                Votos = g.Sum(x => x.Votos)
            }).ToList();
            CoalicionGob = CoalicionResGob.GroupBy(x => x.IdCombinacion).Select(g => new ElementosCartel
            {
                Partido = g.First().IdPartido,
                Coalicion = g.First().IdCoalicion,
                Combinacion = g.Key,
                Independiente = g.First().IdIndependiente,
                Votos = g.Sum(x => x.Votos)

            }).ToList();
            var UnionGob = PartidosGob.Concat(CoalicionGob).ToList();


            PartidosAyu = PartidoResAyu.GroupBy(x => x.IdPartido).Select(g => new ElementosCartel
            {
                Partido = g.Key,
                Coalicion = g.First().IdCoalicion,
                Combinacion = g.First().IdCombinacion,
                Independiente = g.First().IdIndependiente,
                Votos = g.Sum(x => x.Votos)
            }).ToList();
            CoalicionAyu = CoalicionResAyu.GroupBy(x => x.IdCombinacion).Select(g => new ElementosCartel
            {
                Partido = g.First().IdPartido,
                Coalicion = g.First().IdCoalicion,
                Combinacion = g.Key,
                Independiente = g.First().IdIndependiente,
                Votos = g.Sum(x => x.Votos)
            }).ToList();
            IndependienteAyu = IndeResAyu.GroupBy(x => x.IdIndependiente).Select(g => new ElementosCartel
            {
                Partido = g.First().IdPartido,
                Coalicion = g.First().IdCoalicion,
                Combinacion = g.First().IdCombinacion,
                Independiente = g.Key,
                Votos = g.Sum(x => x.Votos)
            }).ToList();
            var PrimeraAyu = PartidosAyu.Concat(CoalicionAyu).ToList();
            var UnionAyu = PrimeraAyu.Concat(IndependienteAyu).ToList();


            

            ListDiputadosRP = ResultadosActasDipRP.GroupBy(x => x.IdPartido).Select(g => new ElementosCartel
            {
                Partido = g.Key,
                Votos = g.Sum(x => x.Votos)
            }).ToList();

            ListRegidorRP = ResultadosActasRegRP.GroupBy(x => x.IdPartido).Select(g => new ElementosCartel
            {
                Partido = g.Key,
                Votos = g.Sum(x => x.Votos)
            }).ToList();

            //-------------------------------------------------------------------------------------------------------------------
           
            
            if(totaldistrito.Count() != 1)
            {
                if(ConEspeciales.Count() != 0)
                {
                    //Con RP y Mas de un Distrito FORMATO 3//
                    T_Detalle_Votos_Actas_VM RCVM = new T_Detalle_Votos_Actas_VM()
                    {
                        Gobernador = UnionGob,
                        Ayuntamiento = UnionAyu,
                        //Diputado = UnionDip,
                        //Regidor = UnionReg,
                        RegidorLista = ResultadosActasReg,
                        DiputadoLista = ResultadosActasDip,
                        DiputadosRP = ListDiputadosRP,
                        RegidoresRP = ListRegidorRP,
                        Partidos = partido,
                        Combinaciones = Combinacion,
                        VotosActaGob = CabeceraGob,
                        VotosActaAyu = CabeceraAyu,
                        VotosActaDip = CabeceraDip,
                        VotosActaReg = CabeceraReg,
                        VotosActaDipRP = CabecerDipRP,
                        VotosActaRegRP = CabecerRegRP,
                        Municipio = mun.Municipio,
                        Distrito = Distrito.LCasilla.LSeccion.LDistrito.NoDistrito,
                        CasillasTotales = CTotales.Count(),
                        CasillasCapturadas = Casillas.Count(),
                        HoraFin = DateTime.Now.ToString("HH:mm"),
                        DiaFin = DateTime.Today.ToString("dd"),
                        TotalDemarcaciones = totaldemarcacion.Count(),
                        ListaDemarcacion = totaldemarcacion.ToList(),
                        TotalDistritos = totaldistrito.Count(),
                        ListaDistritos = totaldistrito.ToList()

                    };
                    return new ViewAsPdf("ImprimirCartelF3", RCVM)
                    {
                        PageSize = Rotativa.AspNetCore.Options.Size.Legal,
                    };
                }
                else
                {
                    // Sin RP y mas de un Distrito FORMATO 4//
                    T_Detalle_Votos_Actas_VM RCVM = new T_Detalle_Votos_Actas_VM()
                    {
                        Gobernador = UnionGob,
                        Ayuntamiento = UnionAyu,
                        //Diputado = UnionDip,
                        //Regidor = UnionReg,
                        RegidorLista = ResultadosActasReg,
                        DiputadoLista = ResultadosActasDip,
                        DiputadosRP = ListDiputadosRP,
                        RegidoresRP = ListRegidorRP,
                        Partidos = partido,
                        Combinaciones = Combinacion,
                        VotosActaGob = CabeceraGob,
                        VotosActaAyu = CabeceraAyu,
                        VotosActaDip = CabeceraDip,
                        VotosActaReg = CabeceraReg,
                        //VotosActaDipRP = CabecerDipRP,
                        //VotosActaRegRP = CabecerRegRP,
                        Municipio = mun.Municipio,
                        Distrito = Distrito.LCasilla.LSeccion.LDistrito.NoDistrito,
                        CasillasTotales = CTotales.Count(),
                        CasillasCapturadas = Casillas.Count(),
                        HoraFin = DateTime.Now.ToString("HH:mm"),
                        DiaFin = DateTime.Today.ToString("dd"),
                        TotalDemarcaciones = totaldemarcacion.Count(),
                        ListaDemarcacion = totaldemarcacion.ToList(),
                        TotalDistritos = totaldistrito.Count(),
                        ListaDistritos = totaldistrito.ToList()

                    };
                    return new ViewAsPdf("ImprimirCartelF4", RCVM)
                    {
                        PageSize = Rotativa.AspNetCore.Options.Size.Legal,
                    };
                }
            }
            else
            {
                if (ConEspeciales.Count() != 0)
                {

                    //Con RP y un Distrito FORMATO 1//
                    PartidosDip = PartidoResDip.GroupBy(x => x.IdPartido).Select(g => new ElementosCartel
                    {
                        Partido = g.Key,
                        Coalicion = g.First().IdCoalicion,
                        Combinacion = g.First().IdCombinacion,
                        Independiente = g.First().IdIndependiente,
                        Distrito = g.First().LVotosActa.LActaDetalle.LCasilla.LSeccion.DistritoId,
                        Votos = g.Sum(x => x.Votos)
                    }).ToList();
                    CoalicionDip = CoalicionResDip.GroupBy(x => x.IdCombinacion).Select(g => new ElementosCartel
                    {
                        Partido = g.First().IdPartido,
                        Coalicion = g.First().IdCoalicion,
                        Combinacion = g.Key,
                        Independiente = g.First().IdIndependiente,
                        Distrito = g.First().LVotosActa.LActaDetalle.LCasilla.LSeccion.DistritoId,
                        Votos = g.Sum(x => x.Votos)

                    }).ToList();
                    var UnionDip = PartidosDip.Concat(CoalicionDip).ToList();
                    T_Detalle_Votos_Actas_VM RCVM = new T_Detalle_Votos_Actas_VM()
                    {

                        Gobernador = UnionGob,
                        Ayuntamiento = UnionAyu,
                        Diputado = UnionDip,
                        RegidorLista = ResultadosActasReg,
                        DiputadosRP = ListDiputadosRP,
                        RegidoresRP = ListRegidorRP,
                        Partidos = partido,
                        Combinaciones = Combinacion,
                        VotosActaGob = CabeceraGob,
                        VotosActaAyu = CabeceraAyu,
                        VotosActaDip = CabeceraDip,
                        VotosActaReg = CabeceraReg,
                        VotosActaDipRP = CabecerDipRP,
                        VotosActaRegRP = CabecerRegRP,
                        Municipio = mun.Municipio,
                        Distrito = Distrito.LCasilla.LSeccion.LDistrito.NoDistrito,
                        CasillasTotales = CTotales.Count(),
                        CasillasCapturadas = Casillas.Count(),
                        HoraFin = DateTime.Now.ToString("HH:mm"),
                        DiaFin = DateTime.Today.ToString("dd"),
                        TotalDemarcaciones = totaldemarcacion.Count(),
                        ListaDemarcacion = totaldemarcacion.ToList(),
                        TotalDistritos = totaldistrito.Count(),
                        ListaDistritos = totaldistrito.ToList()

                    };
                    return new ViewAsPdf("ImprimirCartelF1", RCVM)
                    {
                        PageSize = Rotativa.AspNetCore.Options.Size.Legal,
                    };
                }
                else
                {  
                    //Sin RP y un Distrito FORMATO 2//
                    PartidosDip = PartidoResDip.GroupBy(x => x.IdPartido).Select(g => new ElementosCartel
                    {
                        Partido = g.Key,
                        Coalicion = g.First().IdCoalicion,
                        Combinacion = g.First().IdCombinacion,
                        Independiente = g.First().IdIndependiente,
                        Distrito = g.First().LVotosActa.LActaDetalle.LCasilla.LSeccion.DistritoId,
                        Votos = g.Sum(x => x.Votos)
                    }).ToList();
                    CoalicionDip = CoalicionResDip.GroupBy(x => x.IdCombinacion).Select(g => new ElementosCartel
                    {
                        Partido = g.First().IdPartido,
                        Coalicion = g.First().IdCoalicion,
                        Combinacion = g.Key,
                        Independiente = g.First().IdIndependiente,
                        Distrito = g.First().LVotosActa.LActaDetalle.LCasilla.LSeccion.DistritoId,
                        Votos = g.Sum(x => x.Votos)

                    }).ToList();
                    var UnionDip = PartidosDip.Concat(CoalicionDip).ToList();
                   
                    T_Detalle_Votos_Actas_VM RCVM = new T_Detalle_Votos_Actas_VM()
                    {
                        Gobernador = UnionGob,
                        Ayuntamiento = UnionAyu,
                        Diputado = UnionDip,
                        RegidorLista = ResultadosActasReg,
                        DiputadosRP = ListDiputadosRP,
                        RegidoresRP = ListRegidorRP,
                        Partidos = partido,
                        Combinaciones = Combinacion,
                        VotosActaGob = CabeceraGob,
                        VotosActaAyu = CabeceraAyu,
                        VotosActaDip = CabeceraDip,
                        VotosActaReg = CabeceraReg,
                        //VotosActaDipRP = CabecerDipRP,
                        //VotosActaRegRP = CabecerRegRP,
                        Municipio = mun.Municipio,
                        Distrito = Distrito.LCasilla.LSeccion.LDistrito.NoDistrito,
                        CasillasTotales = CTotales.Count(),
                        CasillasCapturadas = Casillas.Count(),
                        HoraFin = DateTime.Now.ToString("HH:mm"),
                        DiaFin = DateTime.Today.ToString("dd"),
                        TotalDemarcaciones = totaldemarcacion.Count(),
                        ListaDemarcacion = totaldemarcacion.ToList(),
                        TotalDistritos = totaldistrito.Count(),
                        ListaDistritos = totaldistrito.ToList()

                    };
                    return new ViewAsPdf("ImprimirCartelF2", RCVM)
                    {
                        PageSize = Rotativa.AspNetCore.Options.Size.Legal,
                    };
                }
            }
            
        }
    }
}
