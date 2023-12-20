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
    public class VotoExtranjeroController : Controller
    {
        private readonly IContenedorTrabajo _context;
        private ApplicationDbContext _db;
        private readonly UserManager<T_Usuario> _UserManager;

        public VotoExtranjeroController(IContenedorTrabajo context, ApplicationDbContext db,
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

        public IActionResult IndexVotos()
        {
            return View();
        }

        public IActionResult CreateExt()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(T_Acta_Extranjero item)
        {
            if (ModelState.IsValid)
            {
                _context.Acta_Extranjero.Add(item);
                _context.Save();
                return Json(new { success = true, mensaje = "Información Complementaria de Acta, registrada con éxito" });
            }
            return Json(new { success = false, mensaje = "Error al registrar la información Complementaria del Acta, intentelo de nuevo" });
        }

        [HttpGet]
        public IActionResult CapturaVotos()
        {
            int IdCabecera = 0;
            using (var transaccion = _db.Database.BeginTransaction())
            {
                try
                {
                    var cabecera = new T_Votos_Acta_Ext();
                    cabecera.NoRegistrados = 0;
                    cabecera.Nulos = 0;
                    cabecera.Total = 0;
                    _context.Votos_Acta_Ext.Add(cabecera);
                    _context.Save();
                    IdCabecera = cabecera.Id;
                    List<T_Candidato> Candidatos = new List<T_Candidato>();
                    Candidatos = _db.Candidatos.Where(x => x.TipoEleccionId == 1 && x.Activo == true).Include(p => p.Partido).ToList();
                    List<T_Partido> LPartidos = new List<T_Partido>();
                    List<T_Coalicion> Lcoaliciones = new List<T_Coalicion>();
                    List<T_Combinacion> LCombinaciones = new List<T_Combinacion>();
                    foreach (var candi in Candidatos)
                    {
                        
                        if (candi.Partido.Independiente == false)
                        {
                            LPartidos.Add(candi.Partido);
                        }
                        if (candi.IsCoalicion)
                        {
                            var coalicion = _db.Coaliciones.FirstOrDefault(x => x.Id == candi.CoalicionId);
                            Lcoaliciones.Add(coalicion);
                        }
                    }
                    foreach (var extra in Lcoaliciones)
                    {
                        var coaliciondet = _db.Detalle_Coaliciones.Where(x => x.CoalicionId == extra.Id).ToList();
                        foreach (var extpar in coaliciondet)
                        {
                            var partext = _db.Partidos.Where(x => x.Id == extpar.PartidoId).FirstOrDefault();
                            LPartidos.Add(partext);
                        }
                    }

                    foreach (var comb in Lcoaliciones)
                    {
                        var combinaciones = _db.Combinaciones.Where(x => x.CoalicionId == comb.Id).ToList();
                        foreach (var combi in combinaciones)
                        {
                            var combinacion = _db.Combinaciones.FirstOrDefault(x => x.Id == combi.Id);
                            LCombinaciones.Add(combinacion);
                        }
                    }
                    foreach(var par in LPartidos.OrderBy(x => x.Prioridad).Distinct())
                        {
                        var dres = new T_Detalle_Votos_Ext();
                        dres.IdPartido = par.Id;
                        dres.IdVotosActa = IdCabecera;
                        dres.Votos = 0;
                        _db.Detalle_Votos_Ext.Add(dres);
                    }
                    _db.SaveChanges();

                    foreach (var com in LCombinaciones.OrderBy(x => x.CoalicionId).ThenByDescending(x => x.Tamaño))
                    {
                        var dres = new T_Detalle_Votos_Ext();
                        dres.IdCombinacion = com.Id;
                        dres.IdCoalicion = com.CoalicionId;
                        dres.IdVotosActa = IdCabecera;
                        dres.Votos = 0;
                        _db.Detalle_Votos_Ext.Add(dres);
                        _db.SaveChanges();
                    }
                    transaccion.Commit();

                }
                catch (Exception ex)
                {
                    transaccion.Rollback();

                }
            }
            var partido = _db.Partidos.ToList().OrderBy(x => x.Id).ThenBy(x => x.Prioridad);
            var combina = _db.Combinaciones.ToList().OrderBy(x => x.Id);
            var cabe = _db.Votos_Actas_Ext.Where(x => x.Id == IdCabecera).ToList();
            var votos = _db.Detalle_Votos_Ext.Where(x => x.IdVotosActa == IdCabecera).ToList();
            ViewBag.partido = partido;
            ViewBag.combinacion = combina;
            ViewBag.Resact = votos;
            ViewBag.Registro = cabe;
            T_Votos_Actas_Extranjero_VM Rvam = new T_Votos_Actas_Extranjero_VM()
            {
                Votos_Ext = _context.Votos_Acta_Ext.Get(IdCabecera),
                DetalleVotosExt = _db.Detalle_Votos_Ext.Where(x => x.IdVotosActa == IdCabecera).ToList()
            };
            return View(Rvam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CapturaVotos(T_Votos_Actas_Extranjero_VM Vte)
        {

            int idregistro = 0;

            var rva = _context.Votos_Acta_Ext.Get(Vte.Votos_Ext.Id);
            rva.FechaRegistro = DateTime.Now;
            rva.NoRegistrados = Vte.Votos_Ext.NoRegistrados;
            rva.Nulos = Vte.Votos_Ext.Nulos;
            rva.Total = Vte.Votos_Ext.Total;            
            _db.SaveChanges();
            foreach (var v in Vte.DetalleVotosExt)
            {
                var deva = _context.Detalle_Votos_Ext.Get(v.Id);
                deva.Votos = v.Votos;
                _context.Save();
                idregistro = deva.IdVotosActa;
            }
            var votos = _context.Detalle_Votos_Ext.GetAll().Where(x => x.IdVotosActa == idregistro).ToList();
            var total = _context.Votos_Acta_Ext.GetFirstOrDefault(x => x.Id == idregistro);
            total.TotalSistema = votos.Sum(x => x.Votos) + total.NoRegistrados + total.Nulos;
            _db.SaveChanges();
            return View();
        }

        public JsonResult CargarComplemento()
        {

            var lst = _context.Acta_Extranjero.GetAll().ToList();
            return Json(new { data = lst });
        }

        public JsonResult CargarVotos()
        {

            var lst = _context.Votos_Acta_Ext.GetAll().ToList();
            return Json(new { data = lst });
        }

        [HttpGet]
        public IActionResult DetalleExt(int id)
        {
            var acta = _context.Acta_Extranjero.GetFirstOrDefault(x => x.Id == id);
            return View(acta); 
        }

        [HttpGet]
        public ActionResult DetalleVotos(int id)
        {

            var par = _context.Partido.GetAll().ToList();
            var com = _context.Combinacion.GetAll().OrderBy(x => x.Id).ToList();

            ViewBag.partido = par;
            ViewBag.combinacion = com;

            T_Votos_Actas_Extranjero_VM Rvam = new T_Votos_Actas_Extranjero_VM()
            {
                Votos_Ext = _context.Votos_Acta_Ext.Get(id),
                DetalleVotosExt = _db.Detalle_Votos_Ext.Where(x => x.IdVotosActa == id).ToList()
            };
            return View(Rvam);
        }

    }
}
