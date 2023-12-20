 using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using WebComputos.AccesoDatos.Data;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using WebComputos.Models.ViewModels;

namespace WebComputos.Areas.Admin.Controllers
{   [Authorize]
    [Area("Admin")]
    public class TResultadosActasController : Controller
    {
        private readonly IContenedorTrabajo _context;
        private ApplicationDbContext _db;
        private readonly UserManager<T_Usuario> _UserManager;

        public TResultadosActasController(IContenedorTrabajo context, ApplicationDbContext db, UserManager<T_Usuario> UserManager)
        {
            _context = context;
            _db = db;
            _UserManager = UserManager;

        }


        [HttpGet]
        public IActionResult IndexGob()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.Municipio = mun.Municipio;
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            return View();
        }

        public IActionResult CreateGob()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.Create = mun.Municipio;
            T_Actas_VM Act = new T_Actas_VM()
            {
                LSeccionGob = _context.Acta.ListaSeccion(mun.Id,1,0),
            };
            return View(Act);
        }
        // ACTAS -----------------------------------------------------------------------------------//
        public JsonResult CargarRegAdmin(int Mun, int Ele, int DD)
        {
            var lstda = _context.Acta.CargarTabla(Mun, Ele, DD);
            return Json(new { data = lstda });
        }

        //----------------------------------------------------------------------------------------------//
        public IActionResult CreateDipRP()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.Create = mun.Municipio;
            T_Actas_RP_VM Act = new T_Actas_RP_VM()
            {
                LSeccionDip = _context.Acta.ListaSeccionRP(mun.Id, 3),
            };
            return View(Act);
        }
        public IActionResult CreateRegRP()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.Create = mun.Municipio;
            T_Actas_RP_VM Act = new T_Actas_RP_VM()
            {
                LSeccionReg = _context.Acta.ListaSeccionRP(mun.Id, 4),
            };
            return View(Act);
        }



        [HttpGet]
        public IActionResult IndexPys()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.Municipio = mun.Municipio;
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            ViewBag.prueba = 0;
            return View();
        }

        public IActionResult CreatePys()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            T_Actas_VM Act = new T_Actas_VM()
            {
                LSeccionPys = _context.Acta.ListaSeccion(mun.Id, 2, 0),
            };
            return View(Act);
        }

        [HttpGet]
        public IActionResult IndexDip()
        {
            //var Distrito = _db.Distritos.Find(id);
            //ViewBag.NoDistrito = Distrito.NoDistrito;
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.Municipio = mun.Municipio;
            ViewBag.Distrito = _context.Distrito.GetListaDistrito();
            //ViewBag.IdDistrito = Distrito.Id;
            return View();
        }
        [HttpGet]
        public IActionResult IndexDipAdmin()
        {
            ViewBag.Distrito = _context.Distrito.GetListaDistrito();
            return View();
        }

        [HttpGet]
        public IActionResult IndexRegAdmin()
        {
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            return View();
        }



        public IActionResult CreateDip()
        {
            //var val = TempData["Distrito"];
            //string res = val.ToString();
            //int valor = int.Parse(res);
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            T_Actas_VM Act = new T_Actas_VM()
            {
                LSeccionDip = _context.Acta.ListaSeccion(mun.Id, 3, 0),
            };
            //ViewBag.ele = id;
            return View(Act);
        }

        [HttpGet]
        public IActionResult IndexReg()
        {
            //ViewBag.DemarcacionId = id;
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            //var Dem = _context.Demarcacion.Get(id);
            //ViewBag.Demarcacion = Dem.Nombre;
            ViewBag.Municipio = mun.Municipio;
            return View();
        }

        [HttpGet]
        public IActionResult IndexDipRP()
        {

            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.Municipio = mun.Municipio;
            return View();
        }

        [HttpGet]
        public IActionResult IndexRegRP()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.Municipio = mun.Municipio;
            return View();
        }


        public IActionResult CreateReg()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            T_Actas_VM Act = new T_Actas_VM()
            {
                LSeccionReg = _context.Acta.ListaSeccion(mun.Id, 4, 0),
            };
            return View(Act);
        }

        public JsonResult DemarcacionAdmin(int demarcacion)
        {
            var a = _context.Demarcacion.DemarcacionMunicipio(demarcacion);
            return Json(new SelectList(a, "Value", "Text"));
        }

        public JsonResult CasillaGob(int seccion)
        {
            var a = _context.Acta.ListaCasilla(seccion,1);
            return Json(new SelectList(a, "Value", "Text"));
        }

        public JsonResult CasillaDipRP(int seccion)
        {
            var a = _context.Acta.ListaCasillaRP(seccion, 3);
            return Json(new SelectList(a, "Value", "Text"));
        }
        public JsonResult CasillaRegRP(int seccion)
        {
            var a = _context.Acta.ListaCasillaRP(seccion, 4);
            return Json(new SelectList(a, "Value", "Text"));
        }

        public JsonResult CargarTablasResultados( int Eleccion, int DD)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var a = _context.Acta.CargarTablasElecciones(mun.Id, Eleccion, DD);
            return Json(new { data = a });
        }
        public JsonResult CargaTabGob()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var a = _context.Acta.CargarTablasElecciones(mun.Id,1,0);
            return Json(new { data = a });

        }
        public JsonResult CargaTabGobAdmin(int id)
        {
            var a = _context.Acta.CargarTablasElecciones(id, 1, 0);
            return Json(new { data = a });

        }

        public JsonResult CargaTabDipRP()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var a = _context.Acta.CargarTablasEleccionesRP(mun.Id, 3);
            return Json(new { data = a });

        }
        public JsonResult CargaTabRegRP()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var a = _context.Acta.CargarTablasEleccionesRP(mun.Id, 4);
            return Json(new { data = a });

        }

        public JsonResult CasillaPys(int seccion)
        {
            var a = _context.Acta.ListaCasilla(seccion, 2);
            return Json(new SelectList(a, "Value", "Text"));
        }
        public JsonResult CargaTabPys()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var a = _context.Acta.CargarTablasElecciones(mun.Id, 2, 0);
            return Json(new { data = a });

        }

        public JsonResult CargaTabPysAdmin(int id)
        {
            ViewBag.prueba = 50; 
            var a = _context.Acta.CargarTablasElecciones(id, 2, 0);
            return Json(new { data = a});

        }
        public JsonResult CasillaDip(int seccion)
        {
            var a = _context.Acta.ListaCasilla(seccion, 3);
            return Json(new SelectList(a, "Value", "Text"));
        }
        public JsonResult CargaTabDip(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var a = _context.Acta.CargarTablasElecciones(mun.Id, 3, id);
            return Json(new { data = a });

        }

        public JsonResult CargaTabDipAdmin(int id)
        {

            var a = _context.Acta.CargarTablasElecciones(0, 3, id);
            return Json(new { data = a });

        }

        public JsonResult Prueba(int id)
        {
            var a = 50;
            return Json(new { data = a });
        }
        public JsonResult CasillaReg(int seccion)
        {
            var a = _context.Acta.ListaCasilla(seccion, 4);
            return Json(new SelectList(a, "Value", "Text"));
        }
        public JsonResult CargaTabReg()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var a = _context.Acta.CargarTablasElecciones(mun.Id, 4, 0);
            return Json(new { data = a });

        }

        public JsonResult CargaTabRegAdmin(int id)
        {
            var a = _context.Acta.CargarTablasElecciones(0, 4, id);
            return Json(new { data = a });
        }

        [HttpGet]
        public ActionResult DetalleResultado(int id)
        {
            var r = _context.Votos_Actas.Get(id);
            var a = _context.ActasDetalles.Get(r.IdActaDetalle);
            var e = _context.TipoEleccion.Get(a.IdEleccion);
            var c = _context.Casilla.Get(a.IdCasilla);
            var s = _context.Seccion.Get(c.SeccionId);
            var par = _context.Partido.GetAll().ToList();
            var com = _context.Combinacion.GetAll().OrderBy(x => x.Id).ToList();
            var reg = _context.Votos_Actas.GetAll().Where(x => x.IdRegistroVotos == id).ToList();
            var votos = _context.Detalle_Votos_Acta.GetAll().Where(x => x.IdVotosActa == id).ToList();
            ViewBag.partido = par;
            ViewBag.combinacion = com;
            ViewBag.resultado = reg;
            ViewBag.votos = votos;
            ViewBag.Seccion = s.Seccion;
            ViewBag.Casilla = c.Nombre;
            ViewBag.Eleccion = e.Nombre;
            if (e.Id == 1)
            {
                ViewBag.Index = "IndexGob";
            }
            if (e.Id == 2)
            {
                ViewBag.Index = "IndexPys";
            }
            if (e.Id == 3)
            {
                ViewBag.Index = "IndexDip";
            }
            if (e.Id == 4)
            {
                ViewBag.Index = "IndexReg";
            }

            T_Votos_Actas_VM Rvam = new T_Votos_Actas_VM()
            {
                Votos_Acta = _context.Votos_Actas.Get(id),
                DetalleVotosActasList = _db.Detalle_Votos_Acta.Where(x => x.IdVotosActa == id).ToList()
            };
            return View(Rvam);
        }

        public ActionResult DetalleResultadoRP(int id)
        {
            var r = _context.Votos_Actas_RP.Get(id);
            var a = _context.Actas_Detalle_RP.Get(r.IdActaDetalle);
            var e = _context.TipoEleccion.Get(a.IdEleccion);
            var c = _context.Casilla.Get(a.IdCasilla);
            var s = _context.Seccion.Get(c.SeccionId);
            var par = _context.Partido.GetAll().ToList();
            var reg = _context.Votos_Actas_RP.GetAll().Where(x => x.IdRegistroVotosRP == id).ToList();
            var votos = _context.Detalle_Votos_Acta_RP.GetAll().Where(x => x.IdVotosActa == id).ToList();
            ViewBag.partido = par;
            ViewBag.resultado = reg;
            ViewBag.votos = votos;
            ViewBag.Seccion = s.Seccion;
            ViewBag.Casilla = c.Nombre;
            ViewBag.Eleccion = e.Nombre;

            if (e.Id == 3)
            {
                ViewBag.Index = "IndexDipRP";
            }
            if (e.Id == 4)
            {
                ViewBag.Index = "IndexRegRP";
            }

            T_Votos_Actas_RP_VM Rvam = new T_Votos_Actas_RP_VM()
            {
                Votos_Acta = _context.Votos_Actas_RP.Get(id),
                DetalleVotosActasRPList = _db.Detalle_Votos_Acta_RP.Where(x => x.IdVotosActa == id).ToList()
            };
            return View(Rvam);
        }

        [HttpGet]
        public JsonResult ResultadosGob(int id)
        {
            using (var transaccion = _db.Database.BeginTransaction())
            {
                try
                {
                    int Result = 0;
                    int detalle = 0;
                    ResponseModel resp = new ResponseModel();
                    var Resultados = _context.Votos_Actas.GetAll(x => x.IdActaDetalle == id).ToList();
                    var DetalleActa = _context.ActasDetalles.GetAll().Where(x => x.IdActaDetalle == id).FirstOrDefault();
                    var CasillaDet = _context.Casilla.Get(DetalleActa.IdCasilla);
                    var Seccion = _context.Seccion.Get(CasillaDet.SeccionId);
                    if (Resultados.Count() == 0)
                    {
                        var res = new T_Votos_Acta();
                        res.IdActaDetalle = id;
                        res.NoRegistrados = 0;
                        res.Nulos = 0;
                        res.Total = 0;
                        _context.Votos_Actas.Add(res);
                        _context.Save();
                        Result = res.IdRegistroVotos;
                        detalle = res.IdActaDetalle;
                        //-------------------------------------------
                        List<T_Candidato> Candidatos = new List<T_Candidato>();
                        List<T_Candidato> CanRP = new List<T_Candidato>();
                        List<ElementosCartel> ListaRP = new List<ElementosCartel>();
                        if (DetalleActa.IdEleccion == 1)
                        {
                            Candidatos = _db.Candidatos.Where(x => x.TipoEleccionId == DetalleActa.IdEleccion && x.Activo == true).Include(p => p.Partido).ToList();
                        }
                        if (DetalleActa.IdEleccion == 2)
                        {
                            Candidatos = _db.Candidatos.Where(x => x.TipoEleccionId == DetalleActa.IdEleccion && x.MunicipioId == CasillaDet.MunicipioId && x.Activo == true).Include(p => p.Partido).ToList();
                        }
                        if (DetalleActa.IdEleccion == 3)
                        {
                            Candidatos = _db.Candidatos.Where(x => x.TipoEleccionId == DetalleActa.IdEleccion && x.DistritoId == Seccion.DistritoId && x.Activo == true).Include(p => p.Partido).ToList();                          
                            CanRP = _db.Candidatos.Where(x => x.TipoEleccionId == DetalleActa.IdEleccion && x.MR_RP == "RP" && x.Activo == true).Include(p => p.Partido).Distinct().ToList();
                            ListaRP = CanRP.GroupBy(x => x.PartidoId).Select(g => new ElementosCartel
                            {
                                Partido = g.Key
                            }).ToList();
                           
                        }
                        if (DetalleActa.IdEleccion == 4)
                        {

                            Candidatos = _db.Candidatos.Where(x => x.TipoEleccionId == DetalleActa.IdEleccion && x.MunicipioId == Seccion.MunicipioId && x.DemarcacionId == Seccion.DemarcacionId && x.Activo == true).Include(p => p.Partido).ToList();                          
                            CanRP = _db.Candidatos.Where(x => x.TipoEleccionId == DetalleActa.IdEleccion && x.MR_RP == "RP" && x.Activo == true && x.MunicipioId == CasillaDet.MunicipioId).Include(p => p.Partido).Distinct().ToList();
                            ListaRP = CanRP.GroupBy(x => x.PartidoId).Select(g => new ElementosCartel
                            {
                                Partido = g.Key
                            }).ToList();
                        }
                        List<T_Partido> LPartidos = new List<T_Partido>();
                        List<T_Coalicion> Lcoaliciones = new List<T_Coalicion>();
                        List<T_Partido> LIndependientes = new List<T_Partido>();
                        List<T_Combinacion> LCombinaciones = new List<T_Combinacion>();

                        foreach (var candi in Candidatos)
                        {
                            if (candi.Partido.Independiente == true)
                            {
                                LIndependientes.Add(candi.Partido);
                            }
                            if (candi.Partido.Independiente == false)
                            {
                                LPartidos.Add(candi.Partido);
                            }
                            //LPartidos.Add(candi.LPartido);
                            if (candi.IsCoalicion)
                            {
                                var coalicion = _db.Coaliciones.FirstOrDefault(x => x.Id == candi.CoalicionId);
                                Lcoaliciones.Add(coalicion);
                            }
                        }
                        if (CanRP.Count != 0 || CanRP.Count != null)
                        {
                            foreach (var rp in ListaRP)
                            {
                                var ParRP = _db.Partidos.Find(rp.Partido);
                                LPartidos.Add(ParRP); 
                                
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

                        var partidos = LPartidos.OrderBy(x => x.Prioridad).ToList();
                        foreach (var par in partidos.Distinct())
                        {
                            var dres = new T_Detalle_Votos_Acta();
                            dres.IdPartido = par.Id;
                            dres.IdVotosActa = Result;
                            dres.Votos = 0;
                            _context.Detalle_Votos_Acta.Add(dres);
                            //_db.Detalle_Votos_Acta.Add(dres);
                            _context.Save();
                        }
                        //_db.SaveChanges();

                        var Combinaciones = LCombinaciones.OrderBy(x => x.Id).ToList();
                        foreach (var com in Combinaciones)
                        {
                            var dres = new T_Detalle_Votos_Acta();
                            dres.IdCombinacion = com.Id;
                            dres.IdCoalicion = com.CoalicionId;
                            dres.IdVotosActa = Result;
                            dres.Votos = 0;
                            _context.Detalle_Votos_Acta.Add(dres);
                            //_db.Detalle_Votos_Acta.Add(dres);
                            //_db.SaveChanges();
                            _context.Save();
                        }

                        var independientes = LIndependientes.OrderBy(x => x.Prioridad).ToList();
                        foreach (var ind in independientes)
                        {
                            var dres = new T_Detalle_Votos_Acta();
                            dres.IdIndependiente = ind.Id;
                            dres.IdVotosActa = Result;
                            dres.Votos = 0;
                            _context.Detalle_Votos_Acta.Add(dres);
                            //_db.Detalle_Votos_Acta.Add(dres);
                            //_db.SaveChanges();
                            _context.Save();
                        }
                        
                        T_Votos_Actas_VM mres = new T_Votos_Actas_VM()
                        {
                            Votos_Acta = res,
                            DetalleVotosActasList = _context.Detalle_Votos_Acta.GetAll().Where(x => x.IdVotosActa == res.IdRegistroVotos).ToList()
                        };
                    }
                    else
                    {
                        var Regs = _db.Votos_Actas.Where(x => x.IdActaDetalle == id).FirstOrDefault();
                        Result = Regs.IdRegistroVotos;
                    }

                    transaccion.Commit();
                    var re = _db.Detalle_Votos_Acta.Where(x => x.IdVotosActa == Result).ToList();
                    var nul = _db.Votos_Actas.Where(x => x.IdActaDetalle == id).ToList();
                   
                    ViewBag.Resact = re;
                    ViewBag.Registro = nul;
                    resp.Error = false;
                    resp.Descripcion = "";

                    return Json(resp);
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    return Json(null);
                }

            }
        }

        [HttpGet]
        public JsonResult ResultadosRP(int id)
        {
            using (var transaccion = _db.Database.BeginTransaction())
            {
                try
                {
                    int Result = 0;
                    int detalle = 0;
                    ResponseModel resp = new ResponseModel();
                    var Resultados = _context.Votos_Actas_RP.GetAll(x => x.IdActaDetalle == id).ToList();
                    var DetalleActa = _context.Actas_Detalle_RP.GetAll().Where(x => x.IdActaDetalle == id).FirstOrDefault();
                    var CasillaDet = _context.Casilla.Get(DetalleActa.IdCasilla);
                    var Seccion = _context.Seccion.Get(CasillaDet.SeccionId);
                    if (Resultados.Count() == 0)
                    {
                        var res = new T_Votos_Acta_RP();
                        res.IdActaDetalle = id;
                        res.NoRegistrados = 0;
                        res.Nulos = 0;
                        res.Total = 0;
                        _db.Votos_Acta_RP.Add(res);
                        _db.SaveChanges();
                        Result = res.IdRegistroVotosRP;
                        detalle = res.IdActaDetalle;
                        List<T_Candidato> CanRP = new List<T_Candidato>();
                        List<T_Partido> LPartidos = new List<T_Partido>();
                        List<ElementosCartel> ListaRP = new List<ElementosCartel>();
                        //List<T_Partido> LPartidos = _context.Partido.GetAll().Where(x => x.Independiente != true).ToList();

                        if (DetalleActa.IdEleccion == 3) 
                        {
                            CanRP = _db.Candidatos.Where(x => x.TipoEleccionId == DetalleActa.IdEleccion && x.MR_RP == "RP" && x.Activo == true).Include(p => p.Partido).Distinct().ToList();
                            ListaRP = CanRP.GroupBy(x => x.PartidoId).Select(g => new ElementosCartel
                            {
                                Partido = g.Key
                            }).ToList();
                        }
                     
                        if(DetalleActa.IdEleccion == 4)
                        {
                            CanRP = _db.Candidatos.Where(x => x.TipoEleccionId == DetalleActa.IdEleccion && x.MR_RP == "RP" && x.Activo == true && x.MunicipioId == CasillaDet.MunicipioId).Include(p => p.Partido).Distinct().ToList();
                            ListaRP = CanRP.GroupBy(x => x.PartidoId).Select(g => new ElementosCartel
                            {
                                Partido = g.Key
                            }).ToList();
                        }
                        foreach (var rp in ListaRP)
                        {
                            var ParRP = _db.Partidos.Find(rp.Partido);
                            LPartidos.Add(ParRP);

                        }

                        foreach (var par in LPartidos.OrderBy(x => x.Prioridad).Distinct())
                        {
                            var dres = new T_Detalle_Votos_Acta_RP();
                            dres.IdPartido = par.Id;
                            dres.IdVotosActa = Result;
                            dres.Votos = 0;
                            _db.Detalle_Votos_Acta_RP.Add(dres);
                        }
                        _db.SaveChanges();

                        T_Votos_Actas_RP_VM mres = new T_Votos_Actas_RP_VM()
                        {
                            Votos_Acta = res,
                            DetalleVotosActasRPList = _context.Detalle_Votos_Acta_RP.GetAll().Where(x => x.IdVotosActa == res.IdRegistroVotosRP).ToList()
                        };
                    }
                    else
                    {
                        var Regs = _db.Votos_Acta_RP.Where(x => x.IdActaDetalle == id).FirstOrDefault();
                        Result = Regs.IdRegistroVotosRP;
                    }

                    transaccion.Commit();

                    //var par = _db.TPartido.ToList().OrderBy(x => x.IdPartido).ThenBy(x => x.Prioridad);
                    //var com = _db.Combinaciones.ToList().OrderBy(x => x.idCombinacion);
                    var re = _db.Detalle_Votos_Acta_RP.Where(x => x.IdVotosActa == Result).ToList();
                    var nul = _db.Votos_Acta_RP.Where(x => x.IdActaDetalle == id).ToList();
                    //ViewBag.partido = par;
                    //ViewBag.combinacion = com;
                    ViewBag.Resact = re;
                    ViewBag.Registro = nul;
                    resp.Error = false;
                    resp.Descripcion = "";

                    return Json(resp);
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    return Json(null);
                }

            }
        }

        [HttpGet]
        public ActionResult Resultados(int id)
        {

            var par = _db.Partidos.ToList().OrderBy(x => x.Id).ThenBy(x => x.Prioridad);
            var com = _db.Combinaciones.ToList().OrderBy(x => x.Id);
            var nul = _db.Votos_Actas.Where(x => x.IdActaDetalle == id).ToList();
            var ele = _context.ActasDetalles.Get(id);
            int idres = nul.Select(x => x.IdRegistroVotos).FirstOrDefault();
            var re = _db.Detalle_Votos_Acta.Where(x => x.IdVotosActa == idres).ToList();
            if (ele.IdEleccion == 3)
            {
                var cas = _context.Casilla.Get(ele.IdCasilla);
                var secc = _context.Seccion.Get(cas.SeccionId);
                ViewBag.Distrito = secc.DistritoId;
            }
            if (ele.IdEleccion == 4)
            {
                var cas = _context.Casilla.Get(ele.IdCasilla);
                var secc = _context.Seccion.Get(cas.SeccionId);
                ViewBag.Demarcacion = secc.DemarcacionId;
            }
            ViewBag.Eleccion = ele.IdEleccion;
            ViewBag.partido = par;
            ViewBag.combinacion = com;
            ViewBag.Resact = re;
            ViewBag.Registro = nul;
            T_Votos_Actas_VM Rvam = new T_Votos_Actas_VM()
            {
                Votos_Acta = _context.Votos_Actas.Get(idres),
                DetalleVotosActasList = _db.Detalle_Votos_Acta.Where(x => x.IdVotosActa == idres).ToList()
            };
            return View(Rvam);
        }

        [HttpGet]
        public ActionResult ResultadosCRP(int id)
        {

            var par = _db.Partidos.ToList().OrderBy(x => x.Id).ThenBy(x => x.Prioridad);           
            var nul = _db.Votos_Acta_RP.Where(x => x.IdActaDetalle == id).ToList();
            var ele = _context.Actas_Detalle_RP.Get(id);
            int idres = nul.Select(x => x.IdRegistroVotosRP).FirstOrDefault();
            var re = _db.Detalle_Votos_Acta_RP.Where(x => x.IdVotosActa == idres).ToList();
            
            ViewBag.Eleccion = ele.IdEleccion;
            ViewBag.partido = par;
            ViewBag.Resact = re;
            ViewBag.Registro = nul;
            T_Votos_Actas_RP_VM Rvam = new T_Votos_Actas_RP_VM()
            {
                Votos_Acta = _context.Votos_Actas_RP.Get(idres),
                DetalleVotosActasRPList = _db.Detalle_Votos_Acta_RP.Where(x => x.IdVotosActa == idres).ToList()
            };
            return View(Rvam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CapturaVotos(T_Votos_Actas_VM Dva)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            int idregistro = 0;
            int ele = 0;
            int validacion;
            string eleccion = "";
            var rva = _context.Votos_Actas.Get(Dva.Votos_Acta.IdRegistroVotos);
            rva.FechaRegistro = DateTime.Now;
            rva.NoRegistrados = Dva.Votos_Acta.NoRegistrados;
            rva.Nulos = Dva.Votos_Acta.Nulos;
            rva.Total = Dva.Votos_Acta.Total;
            rva.UsuarioRegistro = usuario.Id;
            ele = Dva.Votos_Acta.IdActaDetalle;
            foreach (var v in Dva.DetalleVotosActasList)
            {
                var deva = _context.Detalle_Votos_Acta.Get(v.IdDetalleVotosActa);
                deva.Votos = v.Votos;              
                idregistro = deva.IdVotosActa;
            }        
            //DetallePorPartido(idregistro);
            T_Acta_Detalle tcd = new T_Acta_Detalle();
            tcd = _context.ActasDetalles.GetAll().Where(x => x.IdActaDetalle == ele).FirstOrDefault();
            validacion = tcd.IdEleccion;
            var tsis = _context.Detalle_Votos_Acta.GetAll().Where(x => x.IdVotosActa == idregistro).ToList();
            var totalsistema = _context.Votos_Actas.GetAll().Where(x => x.IdRegistroVotos == idregistro).FirstOrDefault();
            totalsistema.TotalSistema = tsis.Sum(x => x.Votos) + totalsistema.NoRegistrados + totalsistema.Nulos;
            tcd.CapturadoVotos = true;
            _context.Save();
            //ActorPolitico(idregistro);
            Causales(idregistro, ele);
            if (validacion != 1 && validacion != 3) { 
            VerificarRecuento(validacion);
            }

            if (tcd.IdEleccion == 1)
            {
                eleccion = "CreateGob";
                return RedirectToAction(eleccion);
            }
            else if (tcd.IdEleccion == 2)
            {
                eleccion = "CreatePys";
                return RedirectToAction(eleccion);
            }
            else if (tcd.IdEleccion == 3)
            {
                eleccion = "CreateDip";
                return RedirectToAction(eleccion);
            }
            else if (tcd.IdEleccion == 4)
            {
                eleccion = "CreateReg";
                return RedirectToAction(eleccion);
            }
            throw new NotImplementedException();

        }

        public void VerificarRecuento(int Eleccion)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var casillas = _context.Casilla.GetListaCasillaMunicipio(mun.Id);
            var paquetes = _context.Recepcion.GetPaquetes(mun.Id);
            var recibidos = paquetes.Where(x => x.LCasilla.Recibido == true).ToList();
            if (casillas.Count() == recibidos.Count())
            {
                if(Eleccion == 2)
                {
                    var actas = _context.Recepcion.CapturaCompleta(mun.Id);
                    var Pys = actas.Where(x => x.IdEleccion == 2).ToList();
                    var PysCom = Pys.Where(x => x.CapturadoComplemento == true && x.CapturadoVotos == true).ToList();
                    if (Pys.Count() == PysCom.Count())
                    {
                        var ca = _context.Causales.GetListaCausales(mun.Id, 2, 0);
                        decimal causal = ca.Where(x => x.numcau != 0).Count();
                        decimal total = ca.Count();
                        decimal d = (100 * causal) / total;
                        decimal porcentaje;
                        if (causal == 0)
                        {
                            porcentaje = 0;
                        }
                        else
                        {
                            porcentaje = Math.Round(d, 4);
                        }

                        //ViewBag.Causal = causal;
                        //ViewBag.Porcentaje = porcentaje;
                        var Lista = _context.Causales.SegundoLugarCausal(mun.Id, 2, 0);
                        //var Partido = Lista.Where(x => x.IdPartido != 0).ToList();
                        //var SumaPartido = Partido.GroupBy(x => x.IdPartido).Select(x => new
                        //{
                        //    GroupID = x.Key,
                        //    Total = x.Sum(i => i.Votos)

                        //}).ToList();
                        //var Coalicion = Lista.Where(x => x.IdCoalicion != 0).ToList();
                        //var SumaCoalicion = Coalicion.GroupBy(x => x.IdCoalicion).Select(x => new
                        //{
                        //    GroupID = x.Key,
                        //    Total = x.Sum(i => i.Votos)

                        //}).ToList();
                        //var Independiente = Lista.Where(x => x.IdIndependiente != 0).ToList();
                        //var SumaIndependiente = Independiente.GroupBy(x => x.IdIndependiente).Select(x => new
                        //{
                        //    GroupID = x.Key,
                        //    Total = x.Sum(i => i.Votos)

                        //}).ToList();

                        //var filtro = SumaPartido.Concat(SumaIndependiente).ToList();
                        //var final = filtro.Concat(SumaCoalicion).OrderByDescending(x => x.Total).ToList();
                        decimal diferencia = Lista.Select(x => x.Votos).ElementAt(0) - Lista.Select(x => x.Votos).ElementAt(1);
                        decimal paso2;
                        if (diferencia != 0)
                        {
                            decimal paso1 = (100 * diferencia) / Lista.Sum(x => x.Votos);
                            paso2 = Math.Round(paso1, 4);
                            //ViewBag.VotosDiferencia = diferencia;
                            //ViewBag.PorcentajeDiferencia = paso1;
                        }
                        else
                        {
                            paso2 = 0;
                        }
                        if (paso2 <= 1)
                        {
                            foreach (var Cambiar in ca)
                            {
                                var Recuento = _db.Causales_recuento.FirstOrDefault(x => x.Id == Cambiar.idcau);
                                Recuento.Recuento_Total = true;
                            }
                            _db.SaveChanges();
                        }
                        else if (paso2 <= 2 && porcentaje > 20)
                        {
                            foreach (var Cambiar in ca)
                            {
                                var Recuento = _db.Causales_recuento.FirstOrDefault(x => x.Id == Cambiar.idcau);
                                Recuento.Recuento_Total = true;
                            }
                            _db.SaveChanges();
                        }
                    }
                }
                else if(Eleccion == 4)
                {
                    var ListaDemarcacion = _context.Recepcion.ListaDD(mun.Id, 4);
                    foreach (var Demarcacion in ListaDemarcacion)
                    {
                        var Reg = _context.Recepcion.CapturaCompletaDD(mun.Id, 4, Convert.ToInt32(Demarcacion.Value));
                        var RegCom = Reg.Where(x => x.CapturadoComplemento == true && x.CapturadoVotos == true).ToList();
                        if (RegCom.Count() == Reg.Count())
                        {
                            var ca = _context.Causales.GetListaCausales(mun.Id, 4, Convert.ToInt32(Demarcacion.Value));
                            decimal causal = ca.Where(x => x.numcau != 0).Count();
                            decimal total = ca.Count();
                            decimal d = (100 * causal) / total;
                            decimal porcentaje;
                            if (causal == 0)
                            {
                                porcentaje = 0;
                            }
                            else
                            {
                                porcentaje = Math.Round(d, 4);
                            }

                            //ViewBag.Causal = causal;
                            //ViewBag.Porcentaje = porcentaje;
                            var Lista = _context.Causales.SegundoLugarCausal(mun.Id, 4, Convert.ToInt32(Demarcacion.Value));
                            //var Partido = Lista.Where(x => x.IdPartido != 0).ToList();
                            //var SumaPartido = Partido.GroupBy(x => x.IdPartido).Select(x => new
                            //{
                            //    GroupID = x.Key,
                            //    Total = x.Sum(i => i.Votos)

                            //}).ToList();
                            //var Coalicion = Lista.Where(x => x.IdCoalicion != 0).ToList();
                            //var SumaCoalicion = Coalicion.GroupBy(x => x.IdCoalicion).Select(x => new
                            //{
                            //    GroupID = x.Key,
                            //    Total = x.Sum(i => i.Votos)

                            //}).ToList();
                            //var Independiente = Lista.Where(x => x.IdIndependiente != 0).ToList();
                            //var SumaIndependiente = Independiente.GroupBy(x => x.IdIndependiente).Select(x => new
                            //{
                            //    GroupID = x.Key,
                            //    Total = x.Sum(i => i.Votos)

                            //}).ToList();

                            //var filtro = SumaPartido.Concat(SumaIndependiente).ToList();
                            //var final = filtro.Concat(SumaCoalicion).OrderByDescending(x => x.Total).ToList();
                            decimal diferencia = Lista.Select(x => x.Votos).ElementAt(0) - Lista.Select(x => x.Votos).ElementAt(1);
                            decimal paso2;
                            if (diferencia != 0)
                            {
                                decimal paso1 = (100 * diferencia) / Lista.Sum(x => x.Votos);
                                paso2 = Math.Round(paso1, 4);
                                //ViewBag.VotosDiferencia = diferencia;
                                //ViewBag.PorcentajeDiferencia = paso1;
                            }
                            else
                            {
                                paso2 = 0;
                            }
                            if (paso2 <= 1)
                            {
                                foreach (var Cambiar in ca)
                                {
                                    var Recuento = _db.Causales_recuento.FirstOrDefault(x => x.Id == Cambiar.idcau);
                                    Recuento.Recuento_Total = true;
                                }
                                _db.SaveChanges();
                            }
                            else if (paso2 <= 2 && porcentaje > 20)
                            {
                                foreach (var Cambiar in ca)
                                {
                                    var Recuento = _db.Causales_recuento.FirstOrDefault(x => x.Id == Cambiar.idcau);
                                    Recuento.Recuento_Total = true;
                                }
                                _db.SaveChanges();
                            }

                        }
                    }

                }



                //if (Gob.Count() == GobCom.Count())
                //{
                //    var ca = _context.Causales.GetListaCausales(mun.Id, 1, 0);
                //    decimal causal = ca.Where(x => x.numcau != 0).Count();
                //    decimal total = ca.Count();
                //    decimal d = (100 * causal) / total;
                //    decimal porcentaje;
                //    if (causal == 0)
                //    {
                //        porcentaje = 0;
                //    }
                //    else
                //    {
                //        porcentaje = Math.Round(d, 4);
                //    }

                //    //ViewBag.Causal = causal;
                //    //ViewBag.Porcentaje = porcentaje;
                //    var Lista = _context.Resultados_Actas.SegundoLugarEleccion(mun.Id, 1, 0);
                //    var Partido = Lista.Where(x => x.Partido != 0).ToList();
                //    var SumaPartido = Partido.GroupBy(x => x.Partido).Select(x => new
                //    {
                //        GroupID = x.Key,
                //        Total = x.Sum(i => i.Votos)

                //    }).ToList();
                //    var Coalicion = Lista.Where(x => x.Coalicion != 0).ToList();
                //    var SumaCoalicion = Coalicion.GroupBy(x => x.Coalicion).Select(x => new
                //    {
                //        GroupID = x.Key,
                //        Total = x.Sum(i => i.Votos)

                //    }).ToList();
                //    var Independiente = Lista.Where(x => x.Independiente != 0).ToList();
                //    var SumaIndependiente = Independiente.GroupBy(x => x.Independiente).Select(x => new
                //    {
                //        GroupID = x.Key,
                //        Total = x.Sum(i => i.Votos)

                //    }).ToList();

                //    var filtro = SumaPartido.Concat(SumaIndependiente).ToList();
                //    var final = filtro.Concat(SumaCoalicion).OrderByDescending(x => x.Total).ToList();
                //    decimal diferencia = final.Select(x => x.Total.Value).ElementAt(0) - final.Select(x => x.Total.Value).ElementAt(1);
                //    decimal paso2;
                //    if (diferencia != 0)
                //    {
                //        decimal paso1 = (100 * diferencia) / final.Sum(x => x.Total.Value);
                //        paso2 = Math.Round(paso1, 4);
                //        //ViewBag.VotosDiferencia = diferencia;
                //        //ViewBag.PorcentajeDiferencia = paso1;
                //    }
                //    else
                //    {
                //        paso2 = 0;
                //    }
                //    if (paso2 <= 1)
                //    {
                //        foreach (var Cambiar in ca)
                //        {
                //            var Recuento = _db.Causales_recuento.FirstOrDefault(x => x.Id == Cambiar.idcau);
                //            Recuento.Recuento_Total = true;
                //        }
                //        _db.SaveChanges();
                //    }
                //    else if (paso2 <= 2 && porcentaje > 20)
                //    {
                //        foreach (var Cambiar in ca)
                //        {
                //            var Recuento = _db.Causales_recuento.FirstOrDefault(x => x.Id == Cambiar.idcau);
                //            Recuento.Recuento_Total = true;
                //        }
                //        _db.SaveChanges();
                //    }
                //    //-----------------------------------------------------------------------------------------------------------------------------//

                //}


                //------------------------------------------------------------------------------------------------------------------------//
                //var ListaDistrito = _context.Recepcion.ListaDD(mun.Id, 3);
                //foreach (var Distrito in ListaDistrito)
                //{
                //    var Dip = _context.Recepcion.CapturaCompletaDD(mun.Id, 3, Convert.ToInt32(Distrito.Value));
                //    var DipCom = Dip.Where(x => x.CapturadoComplemento == true && x.CapturadoVotos == true).ToList();
                //    if (DipCom.Count() == Dip.Count())
                //    {
                //        var ca = _context.Causales.GetListaCausales(mun.Id, 3, Convert.ToInt32(Distrito.Value));
                //        decimal causal = ca.Where(x => x.numcau != 0).Count();
                //        decimal total = ca.Count();
                //        decimal d = (100 * causal) / total;
                //        decimal porcentaje;
                //        if (causal == 0)
                //        {
                //            porcentaje = 0;
                //        }
                //        else
                //        {
                //            porcentaje = Math.Round(d, 4);
                //        }

                //        //ViewBag.Causal = causal;
                //        //ViewBag.Porcentaje = porcentaje;
                //        var Lista = _context.Resultados_Actas.SegundoLugarEleccion(mun.Id, 3, Convert.ToInt32(Distrito.Value));
                //        var Partido = Lista.Where(x => x.Partido != 0).ToList();
                //        var SumaPartido = Partido.GroupBy(x => x.Partido).Select(x => new
                //        {
                //            GroupID = x.Key,
                //            Total = x.Sum(i => i.Votos)

                //        }).ToList();
                //        var Coalicion = Lista.Where(x => x.Coalicion != 0).ToList();
                //        var SumaCoalicion = Coalicion.GroupBy(x => x.Coalicion).Select(x => new
                //        {
                //            GroupID = x.Key,
                //            Total = x.Sum(i => i.Votos)

                //        }).ToList();
                //        var Independiente = Lista.Where(x => x.Independiente != 0).ToList();
                //        var SumaIndependiente = Independiente.GroupBy(x => x.Independiente).Select(x => new
                //        {
                //            GroupID = x.Key,
                //            Total = x.Sum(i => i.Votos)

                //        }).ToList();

                //        var filtro = SumaPartido.Concat(SumaIndependiente).ToList();
                //        var final = filtro.Concat(SumaCoalicion).OrderByDescending(x => x.Total).ToList();
                //        decimal diferencia = final.Select(x => x.Total.Value).ElementAt(0) - final.Select(x => x.Total.Value).ElementAt(1);
                //        decimal paso2;
                //        if (diferencia != 0)
                //        {
                //            decimal paso1 = (100 * diferencia) / final.Sum(x => x.Total.Value);
                //            paso2 = Math.Round(paso1, 4);
                //            //ViewBag.VotosDiferencia = diferencia;
                //            //ViewBag.PorcentajeDiferencia = paso1;
                //        }
                //        else
                //        {
                //            paso2 = 0;
                //        }
                //        if (paso2 <= 1)
                //        {
                //            foreach (var Cambiar in ca)
                //            {
                //                var Recuento = _db.Causales_recuento.FirstOrDefault(x => x.Id == Cambiar.idcau);
                //                Recuento.Recuento_Total = true;
                //            }
                //            _db.SaveChanges();
                //        }
                //        else if (paso2 <= 2 && porcentaje > 20)
                //        {
                //            foreach (var Cambiar in ca)
                //            {
                //                var Recuento = _db.Causales_recuento.FirstOrDefault(x => x.Id == Cambiar.idcau);
                //                Recuento.Recuento_Total = true;
                //            }
                //            _db.SaveChanges();
                //        }

                //    }

                //    //-----------------------------------------------------------------------------------------------------------------------------------------------//


                //}
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CapturaVotosRP(T_Votos_Actas_RP_VM Dva)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            int idregistro = 0;
            int ele = 0;
            string eleccion = "";
            var rva = _context.Votos_Actas_RP.Get(Dva.Votos_Acta.IdRegistroVotosRP);
            rva.FechaRegistro = DateTime.Now;
            rva.NoRegistrados = Dva.Votos_Acta.NoRegistrados;
            rva.Nulos = Dva.Votos_Acta.Nulos;
            rva.Total = Dva.Votos_Acta.Total;
            rva.UsuarioRegistro = usuario.Id;
            ele = Dva.Votos_Acta.IdActaDetalle;
            _db.SaveChanges();
            foreach (var v in Dva.DetalleVotosActasRPList)
            {
                var deva = _context.Detalle_Votos_Acta_RP.Get(v.IdDetalleVotosActa);
                deva.Votos = v.Votos;
                _context.Save();
                idregistro = deva.IdVotosActa;
            }

            var tcd = _context.Actas_Detalle_RP.GetAll().Where(x => x.IdActaDetalle == ele).FirstOrDefault();   
            tcd.CapturadoVotos = true;
            _db.SaveChanges();
            CausalesRP(idregistro, ele);
            if (tcd.IdEleccion == 3)
            {
                eleccion = "CreateDipRP";
                return RedirectToAction(eleccion);
            }
            else if (tcd.IdEleccion == 4)
            {
                eleccion = "CreateRegRP";
                return RedirectToAction(eleccion);
            }
            
            return View();
        }


        public void Causales(int registro, int detalleActa)
        {
            var DetalledeActa = _context.ActasDetalles.GetAll().Where(x => x.IdActaDetalle == detalleActa).FirstOrDefault();
            var NumCausales = _context.Causales.GetAll().Where(x => x.CasillaId == DetalledeActa.IdCasilla && x.TipoEleccionId == DetalledeActa.IdEleccion && x.RP == false).ToList();
            var regvoto = _context.Votos_Actas.GetAll().Where(x => x.IdActaDetalle == detalleActa).FirstOrDefault();
            var votos = _context.Detalle_Votos_Acta.GetAll().Where(x => x.IdVotosActa == registro && x.Votos != 0).ToList();
            var actor = _context.Causales.SegundoLugar(registro).OrderByDescending(x => x.Votos).ToList();
            //var actor = _context.Detalle_Votos_Acta_Actor.GetAll().Where(x => x.IdVotosActas == registro).OrderByDescending(x => x.Votos).ToList();
            var casilladet = _context.Casilla.GetAll().Where(x => x.Id == DetalledeActa.IdCasilla).FirstOrDefault();
            var acta = _context.Acta.GetAll().Where(x => x.IdActaDetalle == detalleActa).FirstOrDefault();
            

            if (NumCausales.Count != 0)
            {
                var Causal = _context.Causales.GetAll().Where(x => x.CasillaId == DetalledeActa.IdCasilla && x.TipoEleccionId == DetalledeActa.IdEleccion).FirstOrDefault();               
                var VotosCaptura = _context.ActasDetalles.GetAll().Where(x => x.CapturadoComplemento == true && x.IdCasilla == DetalledeActa.IdCasilla && x.IdEleccion == DetalledeActa.IdEleccion).ToList();

                if(VotosCaptura.Count == 1)
                {
                    int diferencia = actor.Select(x => x.Votos).ElementAt(0) - actor.Select(x => x.Votos).ElementAt(1);
                    if (regvoto.Nulos > diferencia)
                    {
                        Causal.Causal2 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (regvoto.TotalSistema > casilladet.Boletas_Entregadas)
                    {
                        Causal.Causal3 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (regvoto.TotalSistema != regvoto.Total)
                    {
                        Causal.Causal4 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (votos.Count == 1)
                    {
                        Causal.Causal5 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if ((acta.VotosCiudadanos + acta.VotosRepresentantes ) != regvoto.TotalSistema)
                    {
                        Causal.Causal9 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if ((acta.Sobrantes + regvoto.TotalSistema) > casilladet.Boletas_Entregadas)
                    {
                        Causal.Causal11 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                }
                else
                {
                    int diferencia = actor.Select(x => x.Votos).ElementAt(0) - actor.Select(x => x.Votos).ElementAt(1);
                    if (regvoto.Nulos > diferencia)
                    {
                        Causal.Causal2 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (regvoto.TotalSistema > casilladet.Boletas_Entregadas)
                    {
                        Causal.Causal3 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (regvoto.TotalSistema != regvoto.Total)
                    {
                        Causal.Causal4 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (votos.Count == 1)
                    {
                        Causal.Causal5 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                }
                _db.SaveChanges();
            }
            else
            {
                int totcau = 0;
                bool Nullo = false;
                bool Entregadas = false;
                bool Diferentes = false;
                bool unPartido = false;
                int diferencia = actor.Select(x => x.Votos).ElementAt(0) - actor.Select(x => x.Votos).ElementAt(1);
                if (regvoto.Nulos > diferencia)
                {
                    Nullo = true;
                    totcau = totcau + 1;
                }
                if (regvoto.TotalSistema > casilladet.Boletas_Entregadas)
                {
                    Entregadas = true;
                    totcau = totcau + 1;
                }
                if (regvoto.TotalSistema != regvoto.Total)
                {
                    Diferentes = true;
                    totcau = totcau + 1;
                }
                if (votos.Count == 1)
                {
                    unPartido = true;
                    totcau = totcau + 1;
                }
                T_Causal_Recuento caus = new T_Causal_Recuento();
                caus.CasillaId = DetalledeActa.IdCasilla;
                caus.TipoEleccionId = DetalledeActa.IdEleccion;
                caus.Causal1 = false;
                caus.Causal2 = Nullo;
                caus.Causal3 = Entregadas;
                caus.Causal4 = Diferentes;
                caus.Causal5 = unPartido;
                caus.Causal6 = false;
                caus.Causal7 = false;
                caus.Causal8 = false;
                caus.Causal9 = false;
                caus.Causal10 = false;
                caus.Causal11 = false;
                caus.Recuento_Total = false;
                caus.Total_Causales = totcau;
                var computo = _context.Detalle_Acta_Computo.GetFirstOrDefault(x => x.TipoEleccionId == DetalledeActa.IdEleccion && x.CasillaId == DetalledeActa.IdCasilla);
                caus.DetalleActaComputoId = computo.Id;
                _db.Causales_recuento.Add(caus);
                _db.SaveChanges();
            }           
        }

        public IActionResult CausalesRP(int registro, int detalleActa)
        {
            var DetalledeActa = _context.Actas_Detalle_RP.GetAll().Where(x => x.IdActaDetalle == detalleActa).FirstOrDefault();
            var NumCausales = _context.Causales.GetAll().Where(x => x.CasillaId == DetalledeActa.IdCasilla && x.TipoEleccionId == DetalledeActa.IdEleccion && x.RP == true).ToList();
            var regvoto = _context.Votos_Actas_RP.GetAll().Where(x => x.IdActaDetalle == detalleActa).FirstOrDefault();
            var votos = _context.Detalle_Votos_Acta_RP.GetAll().Where(x => x.IdVotosActa == registro && x.Votos != 0).ToList();
            var actor = _context.Detalle_Votos_Acta_RP.GetAll().Where(x => x.IdVotosActa == registro).OrderByDescending(x => x.Votos).ToList();
            var casilladet = _context.Casilla.GetAll().Where(x => x.Id == DetalledeActa.IdCasilla).FirstOrDefault();
            var acta = _context.Actas_RP.GetAll().Where(x => x.IdActaDetalle == detalleActa).FirstOrDefault();


            if (NumCausales.Count == 1)
            {
                var Causal = _context.Causales.GetAll().Where(x => x.CasillaId == DetalledeActa.IdCasilla && x.TipoEleccionId == DetalledeActa.IdEleccion && x.RP == true).FirstOrDefault();
                var VotosCaptura = _context.Actas_Detalle_RP.GetAll().Where(x => x.CapturadoComplemento == true && x.IdCasilla == DetalledeActa.IdCasilla && x.IdEleccion == DetalledeActa.IdEleccion).ToList();

                if (VotosCaptura.Count == 1)
                {
                    int diferencia = actor.Select(x => x.Votos).ElementAt(0) - actor.Select(x => x.Votos).ElementAt(1);
                    if (regvoto.Nulos > diferencia)
                    {
                        Causal.Causal2 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (regvoto.TotalSistema > casilladet.Boletas_Entregadas)
                    {
                        Causal.Causal3 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (regvoto.TotalSistema != regvoto.Total)
                    {
                        Causal.Causal4 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (votos.Count == 1)
                    {
                        Causal.Causal5 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (acta.VotosCiudadanos != regvoto.TotalSistema)
                    {
                        Causal.Causal9 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if ((acta.Sobrantes + regvoto.TotalSistema) > casilladet.Boletas_Entregadas)
                    {
                        Causal.Causal11 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                }
                else
                {
                    int diferencia = actor.Select(x => x.Votos).ElementAt(0) - actor.Select(x => x.Votos).ElementAt(1);
                    if (regvoto.Nulos > diferencia)
                    {
                        Causal.Causal2 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (regvoto.TotalSistema > casilladet.Boletas_Entregadas)
                    {
                        Causal.Causal3 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (regvoto.TotalSistema != regvoto.Total)
                    {
                        Causal.Causal4 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (votos.Count == 1)
                    {
                        Causal.Causal5 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                }
                _db.SaveChanges();
            }
            else
            {
                int totcau = 0;
                bool Nullo = false;
                bool Entregadas = false;
                bool Diferentes = false;
                bool unPartido = false;
                int diferencia = actor.Select(x => x.Votos).ElementAt(0) - actor.Select(x => x.Votos).ElementAt(1);
                if (regvoto.Nulos > diferencia)
                {
                    Nullo = true;
                    totcau = totcau + 1;
                }
                if (regvoto.TotalSistema > casilladet.Boletas_Entregadas)
                {
                    Entregadas = true;
                    totcau = totcau + 1;
                }
                if (regvoto.TotalSistema != regvoto.Total)
                {
                    Diferentes = true;
                    totcau = totcau + 1;
                }
                if (votos.Count == 1)
                {
                    unPartido = true;
                    totcau = totcau + 1;
                }
                T_Causal_Recuento caus = new T_Causal_Recuento();
                caus.CasillaId = DetalledeActa.IdCasilla;
                caus.TipoEleccionId = DetalledeActa.IdEleccion;
                caus.Causal1 = false;
                caus.Causal2 = Nullo;
                caus.Causal3 = Entregadas;
                caus.Causal4 = Diferentes;
                caus.Causal5 = unPartido;
                caus.Causal6 = false;
                caus.Causal7 = false;
                caus.Causal8 = false;
                caus.Causal9 = false;
                caus.Causal10 = false;
                caus.Causal11 = false;
                caus.Recuento_Total = false;
                caus.Total_Causales = totcau;
                var computo = _context.Detalle_Acta_Computo_RP.GetFirstOrDefault(x => x.TipoEleccionId == DetalledeActa.IdEleccion && x.CasillaId == DetalledeActa.IdCasilla);
                caus.DetalleActaComputoRPId = computo.Id;
                caus.RP = true;
                _db.Causales_recuento.Add(caus);
                _db.SaveChanges();
            }
            return View();
        }

        [HttpPost]
        public IActionResult SolicitaModificacion(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            try
            {
                var registro = _context.Resultados_Actas.Get(id);
                var detalle = _context.ActasDetalles.GetFirstOrDefault(x => x.IdActaDetalle == registro.IdActaDetalle);
                registro.Solicitud = 1;
                T_HistorialModificaciones Historial = new T_HistorialModificaciones();
                Historial.IdCasilla = detalle.IdCasilla;
                Historial.Concepto = 2;
                Historial.TipoEleccion = detalle.IdEleccion;
                Historial.Estatus = 0;
                Historial.FechaSolicitud = DateTime.Now;
                Historial.UsuarioRegistro = usuario.Id;
                Historial.Votos = registro.IdRegistroVotos;
                _context.HistorialModificacion.Add(Historial);
                _db.SaveChanges();
                return Json(new { success = true, mensaje = "Solicitud Generada" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
    }
}
