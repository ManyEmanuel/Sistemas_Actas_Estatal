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
using iTextSharp.text.pdf;

namespace WebComputos.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class TRecepcionPaquetesController : Controller
    {
        private readonly IContenedorTrabajo _context;
        private ApplicationDbContext _db;
        IWebHostEnvironment _env;
        private readonly UserManager<T_Usuario> _UserManager;
        

        public TRecepcionPaquetesController(IContenedorTrabajo context, ApplicationDbContext db, UserManager<T_Usuario>UserManager/*, IConverter converter, IWebHostEnvironment env*/)
        {
            _context = context;
            _db = db;
            _UserManager = UserManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            decimal recibidos = _context.Recepcion.GetListaPaquetesByMun(mun.Id).Count();
            decimal total = _context.Seccion.ListaCasillaByMunicipio(mun.Id).Count();
            decimal t = (100 * recibidos) / total;
            decimal porcent = Math.Round(t, 4);
            var TotalCasillas = _context.Casilla.GetAll().ToList();
            var TotalRecibidas = _context.Recepcion.GetAll().ToList();
            double TotRecibi = TotalRecibidas.Count();
            double TotCasi = TotalCasillas.Count();
            double Resultado = (TotRecibi * 100) / TotCasi;
            string decimales = Resultado.ToString("N2");
            ViewBag.TotalEst = TotalCasillas.Count();
            ViewBag.RecibidosEst = TotalRecibidas.Count();
            ViewBag.PorRecibidos = Convert.ToDouble(decimales);
            ViewBag.Recibidos = recibidos;
            ViewBag.Total = total;
            ViewBag.Porcentaje = porcent;
            ViewBag.Municipio = mun.Municipio;
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            //_context.Causales.CarmbiarCausal();
            //var comprobacion = _db.Causales_recuento.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LCasilla.LSeccion.MunicipioId == 9).ToList();
            //foreach (var causal in comprobacion)
            //{
            //    int cont = 0;
            //    if (causal.Causal1 == true)
            //    {
            //        cont++;
            //    }
            //    if (causal.Causal2 == true)
            //    {
            //        cont++;
            //    }
            //    if (causal.Causal3 == true)
            //    {
            //        cont++;
            //    }
            //    if (causal.Causal4 == true)
            //    {
            //        cont++;
            //    }
            //    if (causal.Causal5 == true)
            //    {
            //        cont++;
            //    }
            //    if (causal.Causal6 == true)
            //    {
            //        cont++;
            //    }
            //    if (causal.Causal7 == true)
            //    {
            //        cont++;
            //    }
            //    if (causal.Causal8 == true)
            //    {
            //        cont++;
            //    }
            //    if (causal.Causal9 == true)
            //    {
            //        cont++;
            //    }
            //    if (causal.Causal10 == true)
            //    {
            //        cont++;
            //    }
            //    if (causal.Causal11 == true)
            //    {
            //        cont++;
            //    }

            //    if (cont != causal.Total_Causales)
            //    {
            //        var cambiar = _context.Causales.GetFirstOrDefault(x => x.Id == causal.Id);
            //        cambiar.Total_Causales = cont;
            //        _context.Save();
            //    }


           // }   
            return View();
        }

        [HttpGet]
        public IActionResult HistorialSubsanada()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            decimal recibidos = _context.Recepcion.GetListaPaquetesByMun(mun.Id).Count();
            decimal total = _context.Seccion.ListaCasillaByMunicipio(mun.Id).Count();
            decimal t = (100 * recibidos) / total;
            decimal porcent = Math.Round(t, 4);
            var TotalCasillas = _context.Casilla.GetAll().ToList();
            var TotalRecibidas = _context.Recepcion.GetAll().ToList();
            double TotRecibi = TotalRecibidas.Count();
            double TotCasi = TotalCasillas.Count();
            double Resultado = (TotRecibi * 100) / TotCasi;
            string decimales = Resultado.ToString("N2");
            ViewBag.TotalEst = TotalCasillas.Count();
            ViewBag.RecibidosEst = TotalRecibidas.Count();
            ViewBag.PorRecibidos = Convert.ToDouble(decimales);
            ViewBag.Recibidos = recibidos;
            ViewBag.Total = total;
            ViewBag.Porcentaje = porcent;
            ViewBag.Municipio = mun.Municipio;
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
              
            return View();
        }

        public JsonResult CargarHistorial()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var c = _context.HistorialSubsanar.HistorialMunicipio(mun.Id);
            return Json(new { data = c });
        }

        [HttpGet]
        public IActionResult VistaHistorial(int id)
        {

            var resultado = _context.HistorialSubsanar.Get(id);
            var Casilla = _context.Casilla.Get(resultado.CasillaId);
            var Seccion = _context.Seccion.Get(Casilla.SeccionId);
            var TipoEle = _context.TipoEleccion.Get(resultado.TipoEleccionId);
            var Usuario = _context.ApplicationUser.GetAll().Where(x => x.Id == resultado.UsuarioRegistro).FirstOrDefault();
            var Oficina = _context.Oficina.Get(Usuario.OficinaId);
            var Municipio = _context.Municipio.Get(Oficina.MunicipioId);
            ViewBag.Causal = resultado;
            ViewBag.Casilla = Casilla.Nombre;
            ViewBag.Seccion = Seccion.Seccion;
            ViewBag.Ele = TipoEle.Nombre;
            return View();
        }
        [HttpPost]
        public IActionResult SolicitaRestablecer(int id)
        {
            try
            {
                var registro = _context.HistorialSubsanar.Get(id);
                registro.Solicitud = 1;
                registro.FechaHora_Solicitud = DateTime.Now;
                _db.SaveChanges();
                return Json(new { success = true, mensaje = "Solicitud Generada" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult SolicitaModificacion(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            try
            {
                var registro = _context.Recepcion.Get(id);
                registro.Solicitud = 1;
                T_HistorialModificaciones Historial = new T_HistorialModificaciones();
                Historial.IdCasilla = registro.IdCasilla;
                Historial.Concepto = 0;
                Historial.TipoEleccion = 0;
                Historial.Estatus = 0;
                Historial.FechaSolicitud = DateTime.Now;
                Historial.UsuarioRegistro = usuario.Id;
                Historial.Paquetes = registro.IdRecepcion;
                _context.HistorialModificacion.Add(Historial);
                _db.SaveChanges();
                return Json(new { success = true, mensaje = "Solicitud Generada" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        public JsonResult CargarHistorico()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var c = _context.HistorialSubsanar.HistoricoMunicipal(mun.Id);
            return Json(new { data = c });
        }

        [HttpGet]
        public IActionResult CreateGobAdmin()
        {
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            return View();
        }

        [HttpGet]
        public IActionResult CreatePysAdmin()
        {
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            return View();
        }

        [HttpGet]
        public IActionResult CreateDipAdmin()
        {
            ViewBag.ListaDistrito = _context.Distrito.GetListaDistrito();
            return View();
        }

        [HttpGet]
        public IActionResult CreateRegAdmin()
        {
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            return View();
        }

        [HttpGet]
        public IActionResult AvancePaquetes()
        {
            var TotalCasillas = _context.Casilla.GetAll().ToList();
            var TotalRecibidas = _context.Recepcion.GetAll().ToList();
            double TotRecibi = TotalRecibidas.Count();
            double TotCasi = TotalCasillas.Count();
            double Resultado = (TotRecibi * 100) / TotCasi;
            string decimales = Resultado.ToString("N2");
            double Reci = 100 - Convert.ToDouble(decimales);
            ViewBag.Total = TotalCasillas.Count();
            ViewBag.Recibidos = TotalRecibidas.Count();
            ViewBag.Restantes = TotalCasillas.Count() - TotalRecibidas.Count();
            ViewBag.PorRecibidos = Convert.ToDouble(decimales);
            ViewBag.PorFaltantes = Reci;
            return View();
        }
       

        [HttpGet]
        public IActionResult ImprimirGob(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ConCausal = _context.Recepcion.ConCausales(mun.Id, 1,id);
            var SinCausal = _context.Recepcion.SinCausales(mun.Id, 1,id);
            ReporteCausalesVM RCVM = new ReporteCausalesVM()
            {
                CCausal = ConCausal.OrderBy(x=> x.NoSeccionCC).ToList(),
                SCausal = SinCausal.OrderBy(x=> x.NoSeccionSC).ToList()
            };
            RCVM.Municipio = mun.Municipio;
            return new ViewAsPdf("ImprimirGob", RCVM) {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
            };
        }

        [HttpGet]
        public IActionResult ImprimirCasillas(int id,int ele, int dd)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ConCausal = _context.Recepcion.ConCausales(mun.Id, ele, dd);
            var eleccion = _db.Tipos_Eleccion.Find(ele);
                       
            ReporteCausalesVM RCVM = new ReporteCausalesVM()
            {
                CCausal = ConCausal.OrderBy(x => x.NoSeccionCC).ToList(),
                Eleccion = eleccion.Nombre,
                ListadoCausales = _context.Puntos_Recuento.EjercicioSeleccionadoPorNumero(mun.Id, ele, dd, id).ToList()
        };
            RCVM.Municipio = mun.Municipio;
            return new ViewAsPdf("ImprimirCasillas", RCVM)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
            };
        }

        [HttpGet]
        public IActionResult ImprimirGobAdmin(int id)
        {

            var mun = _db.Municipios.Find(id);
            var ConCausal = _context.Recepcion.ConCausales(mun.Id, 1, 0);
            var SinCausal = _context.Recepcion.SinCausales(mun.Id, 1, 0);
            ReporteCausalesVM RCVM = new ReporteCausalesVM()
            {
                CCausal = ConCausal.OrderBy(x => x.NoSeccionCC).ToList(),
                SCausal = SinCausal.OrderBy(x => x.NoSeccionSC).ToList()
            };
            RCVM.Municipio = mun.Municipio;
            return new ViewAsPdf("ImprimirGob", RCVM)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
            };
        }

        [HttpGet]
        public IActionResult ImprimirCausal()
        {
            return new ViewAsPdf("ImprimirCausal")
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
            };
        }

        [HttpGet]
        public IActionResult ImprimirPys(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ConCausal = _context.Recepcion.ConCausales(mun.Id, 2,id);
            var SinCausal = _context.Recepcion.SinCausales(mun.Id, 2,id);
            ReporteCausalesVM RCVM = new ReporteCausalesVM()
            {
                CCausal = ConCausal.OrderBy(x => x.NoSeccionCC).ToList(),
                SCausal = SinCausal.OrderBy(x => x.NoSeccionSC).ToList()
            };
            RCVM.Municipio = mun.Municipio;
            return new ViewAsPdf("ImprimirPys", RCVM)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
            };
        }

        [HttpGet]
        public IActionResult ImprimirPysAdmin(int id)
        {

            var mun = _db.Municipios.Find(id);
            var ConCausal = _context.Recepcion.ConCausales(mun.Id, 2, 0);
            var SinCausal = _context.Recepcion.SinCausales(mun.Id, 2, 0);
            ReporteCausalesVM RCVM = new ReporteCausalesVM()
            {
                CCausal = ConCausal.OrderBy(x => x.NoSeccionCC).ToList(),
                SCausal = SinCausal.OrderBy(x => x.NoSeccionSC).ToList()
            };
            RCVM.Municipio = mun.Municipio;
            return new ViewAsPdf("ImprimirPys", RCVM)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
            };
        }

        [HttpGet]
        public IActionResult ImprimirDip(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ConCausal = _context.Recepcion.ConCausales(mun.Id, 3,id);
            var SinCausal = _context.Recepcion.SinCausales(mun.Id, 3, id);
            ReporteCausalesVM RCVM = new ReporteCausalesVM()
            {
                CCausal = ConCausal.OrderBy(x => x.NoSeccionCC).ToList(),
                SCausal = SinCausal.OrderBy(x => x.NoSeccionSC).ToList()
            };
            RCVM.Municipio = mun.Municipio;
            RCVM.Distrito = id.ToString();
            return new ViewAsPdf("ImprimirDip", RCVM)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
            };
        }

        [HttpGet]
        public IActionResult ImprimirDipAdmin(int id)
        {
            var Sec = _context.Seccion.GetFirstOrDefault(x => x.DistritoId == id);
            var mun = _db.Municipios.Find(Sec.MunicipioId);
            var ConCausal = _context.Recepcion.ConCausales(0, 3, id);
            var SinCausal = _context.Recepcion.SinCausales(0, 3, id);
            ReporteCausalesVM RCVM = new ReporteCausalesVM()
            {
                CCausal = ConCausal.OrderBy(x => x.NoSeccionCC).ToList(),
                SCausal = SinCausal.OrderBy(x => x.NoSeccionSC).ToList()
            };
            RCVM.Municipio = mun.Municipio;
            RCVM.Distrito = id.ToString();
            return new ViewAsPdf("ImprimirDip", RCVM)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
            };
        }

        [HttpGet]
        public IActionResult ImprimirRegAdmin(int id)
        {
            var sec = _context.Seccion.GetFirstOrDefault(x => x.DemarcacionId == id);
            var mun = _db.Municipios.Find(sec.MunicipioId);
            var ConCausal = _context.Recepcion.ConCausales(mun.Id, 4, id);
            var SinCausal = _context.Recepcion.SinCausales(mun.Id, 4, id);
            ReporteCausalesVM RCVM = new ReporteCausalesVM()
            {
                CCausal = ConCausal.OrderBy(x => x.NoSeccionCC).ToList(),
                SCausal = SinCausal.OrderBy(x => x.NoSeccionSC).ToList()
            };
            RCVM.Municipio = mun.Municipio;
            var Dem = _context.Demarcacion.Get(id);
            RCVM.Demarcacion = Dem.Nombre;
            return new ViewAsPdf("ImprimirReg", RCVM)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
            };
        }


        [HttpGet]
        public IActionResult ImprimirReg(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ConCausal = _context.Recepcion.ConCausales(mun.Id, 4, id);
            var SinCausal = _context.Recepcion.SinCausales(mun.Id, 4, id);
            ReporteCausalesVM RCVM = new ReporteCausalesVM()
            {
                CCausal = ConCausal.OrderBy(x => x.NoSeccionCC).ToList(),
                SCausal = SinCausal.OrderBy(x => x.NoSeccionSC).ToList()
            };
            RCVM.Municipio = mun.Municipio;
            var Dem = _context.Demarcacion.Get(id);
            RCVM.Demarcacion = Dem.Nombre;
            return new ViewAsPdf("ImprimirReg", RCVM)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
            };
        }

        [HttpGet]
        public IActionResult CausalesGob()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ca = _context.Causales.GetListaCausales(mun.Id,1,0);
            decimal NumSeccion = _context.Seccion.ListaCasillaByMunicipio(mun.Id).Count();
            decimal total = ca.Count();
            decimal completas = _context.Causales.CausalesCompletas(mun.Id, 1,0).Count();
            decimal s = (100 * completas) / NumSeccion;
            decimal porcentajecompletas = Math.Round(s, 4);
            decimal complemento = _context.Causales.CausalesComplemento(mun.Id, 1,0).Count();
            decimal j = (100 * complemento) / NumSeccion;
            decimal porcentajecomplemento = Math.Round(j, 4);
            
            decimal causal = ca.Where(x => x.numcau != 0).Count();
            decimal t = (100 * total) / NumSeccion;
            decimal porcent = Math.Round(t, 4);
            if (causal == 0)
            {
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = 0;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.Cotejo = total - causal;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.PorCompletos = porcentajecompletas;
                ViewBag.PorComplemento = porcentajecomplemento;
                ViewBag.Completos = completas;
                ViewBag.Complemento = complemento;
                ViewBag.Municipio = mun.Municipio;
                ViewBag.IdMunicipio = mun.Id;
            }
            else
            {
                decimal d = (100 * causal) / total;
                decimal porcentaje = Math.Round(d, 4);
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = porcentaje;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
                ViewBag.PorCompletos = porcentajecompletas;
                ViewBag.PorComplemento = porcentajecomplemento;
                ViewBag.Completos = completas;
                ViewBag.Complemento = complemento;
                ViewBag.Municipio = mun.Municipio;
                ViewBag.IdMunicipio = mun.Id;
            }

            /*-----------------------------------------------*/
            //var Lista = _context.Resultados_Actas.SegundoLugarEleccion(mun.Id,1,0);
            var final = _context.Causales.SegundoLugarCausal(mun.Id, 1, 0);
            //var Partido = Lista.Where(x => x.Partido != 0).ToList();
            //var SumaPartido = Partido.GroupBy(x => x.Partido).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i=> i.Votos)

            //}).ToList();
            //var Coalicion = Lista.Where(x => x.Coalicion != 0).ToList();
            //var SumaCoalicion = Coalicion.GroupBy(x => x.Coalicion).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();
            //var Independiente = Lista.Where(x => x.Independiente != 0).ToList();
            //var SumaIndependiente = Independiente.GroupBy(x => x.Independiente).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();

            //var filtro = SumaPartido.Concat(SumaIndependiente).ToList();
            //var final = filtro.Concat(SumaCoalicion).OrderByDescending(x => x.Total).ToList();
            if (final.Count != 0)
            {
                decimal diferencia = final.Select(x => x.Votos).ElementAt(0) - final.Select(x => x.Votos).ElementAt(1);
                if (diferencia != 0)
                {
                    decimal paso1 = (100 * diferencia) / final.Sum(x=> x.Votos);
                    
                    decimal paso2 = Math.Round(paso1, 4);
                    ViewBag.VotosDiferencia = diferencia;
                    ViewBag.PorcentajeDiferencia = paso2;
                }
                else
                {
                    ViewBag.VotosDiferencia = 0;
                    ViewBag.PorcentajeDiferencia = 0;
                }
                
            }
            else
            {
                ViewBag.VotosDiferencia = 0;
                ViewBag.PorcentajeDiferencia = 0;
            }
            return View();
        }

        [HttpGet]
        public IActionResult CausalesGobAdmin(int id)
        {
            var mun = _db.Municipios.Find(id);
            var ca = _context.Causales.GetListaCausales(mun.Id, 1, 0);
            decimal NumSeccion = _context.Seccion.ListaCasillaByMunicipio(mun.Id).Count();
            decimal total = ca.Count();
            decimal completas = _context.Causales.CausalesCompletas(mun.Id, 1, 0).Count();
            decimal s = (100 * completas) / NumSeccion;
            decimal porcentajecompletas = Math.Round(s, 4);
            decimal complemento = _context.Causales.CausalesComplemento(mun.Id, 1, 0).Count();
            decimal j = (100 * complemento) / NumSeccion;
            decimal porcentajecomplemento = Math.Round(j, 4);
            decimal causal = ca.Where(x => x.numcau != 0).Count();
            decimal t = (100 * total) / NumSeccion;
            decimal porcent = Math.Round(t, 4);
            if (causal == 0)
            {
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = 0;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.Cotejo = total - causal;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.PorCompletos = porcentajecompletas;
                ViewBag.PorComplemento = porcentajecomplemento;
                ViewBag.Completos = completas;
                ViewBag.Complemento = complemento;
                ViewBag.Municipio = mun.Municipio;
                ViewBag.IdMunicipio = mun.Id;
            }
            else
            {
                decimal d = (100 * causal) / total;
                decimal porcentaje = Math.Round(d, 4);
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = porcentaje;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
                ViewBag.PorCompletos = porcentajecompletas;
                ViewBag.PorComplemento = porcentajecomplemento;
                ViewBag.Completos = completas;
                ViewBag.Complemento = complemento;
                ViewBag.Municipio = mun.Municipio;
                ViewBag.IdMunicipio = mun.Id;
            }

            /*-----------------------------------------------*/
            //var Lista = _context.Resultados_Actas.SegundoLugarEleccion(mun.Id, 1, 0);
            var final = _context.Causales.SegundoLugarCausal(mun.Id, 1, 0);
            //var Partido = Lista.Where(x => x.Partido != 0).ToList();
            //var SumaPartido = Partido.GroupBy(x => x.Partido).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();
            //var Coalicion = Lista.Where(x => x.Coalicion != 0).ToList();
            //var SumaCoalicion = Coalicion.GroupBy(x => x.Coalicion).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();
            //var Independiente = Lista.Where(x => x.Independiente != 0).ToList();
            //var SumaIndependiente = Independiente.GroupBy(x => x.Independiente).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();

            //var filtro = SumaPartido.Concat(SumaIndependiente).ToList();
            //var final = filtro.Concat(SumaCoalicion).OrderByDescending(x => x.Total).ToList();
            if (final.Count != 0)
            {
                decimal diferencia = final.Select(x => x.Votos).ElementAt(0) - final.Select(x => x.Votos).ElementAt(1);
                if (diferencia != 0)
                {
                    decimal paso1 = (100 * diferencia) / final.Sum(x => x.Votos);
                    decimal? paso2 = Math.Round(paso1, 4);
                    ViewBag.VotosDiferencia = diferencia;
                    ViewBag.PorcentajeDiferencia = paso1;
                }
                else
                {
                    ViewBag.VotosDiferencia = 0;
                    ViewBag.PorcentajeDiferencia = 0;
                }

            }
            else
            {
                ViewBag.VotosDiferencia = 0;
                ViewBag.PorcentajeDiferencia = 0;
            }
            return View();
        }

        [HttpGet]
        public IActionResult CausalesPysAdmin(int id)
        {
            var mun = _db.Municipios.Find(id);
            var ca = _context.Causales.GetListaCausales(mun.Id, 2, 0);
            decimal NumSeccion = _context.Seccion.ListaCasillaByMunicipio(mun.Id).Count();
            decimal total = ca.Count();
            decimal completas = _context.Causales.CausalesCompletas(mun.Id, 2, 0).Count();
            decimal s = (100 * completas) / NumSeccion;
            decimal porcentajecompletas = Math.Round(s, 4);
            decimal complemento = _context.Causales.CausalesComplemento(mun.Id, 2, 0).Count();
            decimal j = (100 * complemento) / NumSeccion;
            decimal porcentajecomplemento = Math.Round(j, 4);
            decimal causal = ca.Where(x => x.numcau != 0).Count();
            decimal t = (100 * total) / NumSeccion;
            decimal porcent = Math.Round(t, 4);
            if (causal == 0)
            {
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = 0;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.Cotejo = total - causal;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.PorCompletos = porcentajecompletas;
                ViewBag.PorComplemento = porcentajecomplemento;
                ViewBag.Completos = completas;
                ViewBag.Complemento = complemento;
                ViewBag.Municipio = mun.Municipio;
                ViewBag.IdMunicipio = mun.Id;
            }
            else
            {
                decimal d = (100 * causal) / total;
                decimal porcentaje = Math.Round(d, 4);
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = porcentaje;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
                ViewBag.PorCompletos = porcentajecompletas;
                ViewBag.PorComplemento = porcentajecomplemento;
                ViewBag.Completos = completas;
                ViewBag.Complemento = complemento;
                ViewBag.Municipio = mun.Municipio;
                ViewBag.IdMunicipio = mun.Id;
            }

            /*-----------------------------------------------*/
            //var Lista = _context.Resultados_Actas.SegundoLugarEleccion(mun.Id, 2, 0);
            var final = _context.Causales.SegundoLugarCausal(mun.Id, 2, 0);
            //var Partido = Lista.Where(x => x.Partido != 0).ToList();
            //var SumaPartido = Partido.GroupBy(x => x.Partido).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();
            //var Coalicion = Lista.Where(x => x.Coalicion != 0).ToList();
            //var SumaCoalicion = Coalicion.GroupBy(x => x.Coalicion).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();
            //var Independiente = Lista.Where(x => x.Independiente != 0).ToList();
            //var SumaIndependiente = Independiente.GroupBy(x => x.Independiente).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();

            //var filtro = SumaPartido.Concat(SumaIndependiente).ToList();
            //var final = filtro.Concat(SumaCoalicion).OrderByDescending(x => x.Total).ToList();
            if (final.Count != 0)
            {
                decimal diferencia = final.Select(x => x.Votos).ElementAt(0) - final.Select(x => x.Votos).ElementAt(1);
                if (diferencia != 0)
                {
                    decimal paso1 = (100 * diferencia) / final.Sum(x => x.Votos);
                    decimal? paso2 = Math.Round(paso1, 4);
                    ViewBag.VotosDiferencia = diferencia;
                    ViewBag.PorcentajeDiferencia = paso1;
                }
                else
                {
                    ViewBag.VotosDiferencia = 0;
                    ViewBag.PorcentajeDiferencia = 0;
                }

            }
            else
            {
                ViewBag.VotosDiferencia = 0;
                ViewBag.PorcentajeDiferencia = 0;
            }
            return View();
        }

        [HttpGet]
        public IActionResult CausalesPys()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ca = _context.Causales.GetListaCausales(mun.Id,2,0);
            int NumSeccion = _context.Seccion.ListaCasillaByMunicipio(mun.Id).Count();
            decimal completas = _context.Causales.CausalesCompletas(mun.Id, 2,0).Count();
            decimal s = (100 * completas) / NumSeccion;
            decimal porcentajecompletas = Math.Round(s, 4);
            decimal complemento = _context.Causales.CausalesComplemento(mun.Id, 2,0).Count();
            decimal j = (100 * complemento) / NumSeccion;
            decimal porcentajecomplemento = Math.Round(j, 4);
            decimal total = ca.Count();
            decimal causal = ca.Where(x => x.numcau != 0).Count();
            decimal t = (100 * total) / NumSeccion;
            decimal porcent = Math.Round(t, 4);
            if (causal == 0)
            {
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = 0;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
                ViewBag.PorCompletos = porcentajecompletas;
                ViewBag.PorComplemento = porcentajecomplemento;
                ViewBag.Completos = completas;
                ViewBag.Complemento = complemento;
                ViewBag.Municipio = mun.Municipio;
                ViewBag.IdMunicipio = mun.Id;


            }
            else
            {
                decimal d = (100 * causal) / total;
                decimal porcentaje = Math.Round(d, 4);
                
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = porcentaje;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
                ViewBag.PorCompletos = porcentajecompletas;
                ViewBag.PorComplemento = porcentajecomplemento;
                ViewBag.Completos = completas;
                ViewBag.Complemento = complemento;
                ViewBag.Municipio = mun.Municipio;
                ViewBag.IdMunicipio = mun.Id;
            }
            //var final = _context.Resultados_Actas.SegundoLugarEleccion(mun.Id, 2, 0);
            var final = _context.Causales.SegundoLugarCausal(mun.Id, 2, 0);
            //var Partido = Lista.Where(x => x.Partido != 0).ToList();
            //var SumaPartido = Partido.GroupBy(x => x.Partido).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();
            //var Coalicion = Lista.Where(x => x.Coalicion != 0).ToList();
            //var SumaCoalicion = Coalicion.GroupBy(x => x.Coalicion).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();
            //var Independiente = Lista.Where(x => x.Independiente != 0).ToList();
            //var SumaIndependiente = Independiente.GroupBy(x => x.Independiente).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();

            //var filtro = SumaPartido.Concat(SumaIndependiente).ToList();
            //var final = filtro.Concat(SumaCoalicion).OrderByDescending(x => x.Total).ToList();
            if (final.Count != 0) { 
                decimal diferencia = final.Select(x => x.Votos).ElementAt(0) - final.Select(x => x.Votos).ElementAt(1);
                //var totalvotos = _context.ResActas.ListaVotosGobPys(mun.IdMunicipio,2).ToList();
                //decimal to = totalvotos.Sum(x => x.value);
                if(diferencia != 0) 
                { 
                    decimal paso1 = (100 * diferencia) / final.Sum(x => x.Votos);
                    decimal paso2 = Math.Round(paso1, 4);
                    ViewBag.VotosDiferencia = diferencia;
                    ViewBag.PorcentajeDiferencia = paso2;
                }
                else
                {
                    ViewBag.VotosDiferencia = 0;
                    ViewBag.PorcentajeDiferencia = 0;
                }
            }
            else
            {
                ViewBag.VotosDiferencia = 0;
                ViewBag.PorcentajeDiferencia = 0;
            }
            return View();
        }        
        public IActionResult CausalesDip(int id)
        {

            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ca = _context.Causales.GetListaCausales(mun.Id,3,id);
            var ba = ca.Where(x => x.Distrito == id).ToList();
            int NumSeccion = _context.Seccion.ListaCasillaByDistrito(mun.Id, id).Count();
            decimal completas = _context.Causales.CausalesCompletas(mun.Id,3,id).Count();
            decimal s = (100 * completas) / NumSeccion;
            decimal porcentajecompletas = Math.Round(s, 4);
            decimal complemento = _context.Causales.CausalesComplemento(mun.Id,3, id).Count();
            decimal j = (100 * complemento) / NumSeccion;
            decimal porcentajecomplemento = Math.Round(j, 4);
            decimal total = ba.Count();
            decimal causal = ba.Where(x => x.numcau != 0).Count();
            decimal t = (100 * total) / NumSeccion;
            decimal porcent = Math.Round(t, 4);
            if (causal == 0)
            {
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = 0;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
                ViewBag.PorCompletos = porcentajecompletas;
                ViewBag.PorComplemento = porcentajecomplemento;
                ViewBag.Completos = completas;
                ViewBag.Complemento = complemento;
                ViewBag.Municipio = mun.Municipio;
            }
            else
            {
                decimal d = (100 * causal) / total;
                decimal porcentaje = Math.Round(d, 4);
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = porcentaje;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
                ViewBag.PorCompletos = porcentajecompletas;
                ViewBag.PorComplemento = porcentajecomplemento;
                ViewBag.Completos = completas;
                ViewBag.Complemento = complemento;
                ViewBag.Municipio = mun.Municipio;

            }
            ViewBag.Id = id;
            //var Lista = _context.Resultados_Actas.SegundoLugarEleccion(mun.Id, 3, id);
            var final = _context.Causales.SegundoLugarCausal(mun.Id, 3, id);
            //var Partido = Lista.Where(x => x.Partido != 0).ToList();
            //var SumaPartido = Partido.GroupBy(x => x.Partido).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();
            //var Coalicion = Lista.Where(x => x.Coalicion != 0).ToList();
            //var SumaCoalicion = Coalicion.GroupBy(x => x.Coalicion).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();
            //var Independiente = Lista.Where(x => x.Independiente != 0).ToList();
            //var SumaIndependiente = Independiente.GroupBy(x => x.Independiente).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();

            //var filtro = SumaPartido.Concat(SumaIndependiente).ToList();
            //var final = filtro.Concat(SumaCoalicion).OrderByDescending(x => x.Total).ToList();
            if (final.Count != 0) { 
                decimal diferencia = final.Select(x => x.Votos).ElementAt(0) - final.Select(x => x.Votos).ElementAt(1);
                if (diferencia != 0)
                {
                    //decimal porcen1 = (100 * final.Select(x => x.Total.Value).ElementAt(0)) / final.Sum(x => x.Total.Value);
                    //decimal porcen2 = (100 * final.Select(x => x.Total.Value).ElementAt(1)) / final.Sum(x => x.Total.Value);
                    //decimal porcen11 = Math.Round(porcen1, 4);
                    //decimal porcen22 = Math.Round(porcen2, 4);
                    //decimal porcenfinal = porcen11 - porcen22;

                    decimal paso1 = (100 * diferencia) / final.Sum(x => x.Votos);
                    decimal paso2 = Math.Round(paso1, 4);
                    ViewBag.VotosDiferencia = diferencia;
                    ViewBag.PorcentajeDiferencia = paso2;
                }
                else
                {
                    ViewBag.VotosDiferencia = 0;
                    ViewBag.PorcentajeDiferencia = 0;
                }
            }
            else
            {
                ViewBag.VotosDiferencia = 0;
                ViewBag.PorcentajeDiferencia = 0;
            }
            return View();
        }

        
        public IActionResult CausalesDipAdmin(int id)
        {

            var ca = _context.Causales.GetListaCausales(0, 3, id);
            int NumSeccion = _context.Seccion.ListaCasillaByDistrito(0, id).Count();
            decimal completas = _context.Causales.CausalesCompletas(0, 3, id).Count();
            decimal s = (100 * completas) / NumSeccion;
            decimal porcentajecompletas = Math.Round(s, 4);
            decimal complemento = _context.Causales.CausalesComplemento(0, 3, id).Count();
            decimal j = (100 * complemento) / NumSeccion;
            decimal porcentajecomplemento = Math.Round(j, 4);
            decimal total = ca.Count();
            decimal causal = ca.Where(x => x.numcau != 0).Count();
            decimal t = (100 * total) / NumSeccion;
            decimal porcent = Math.Round(t, 4);

            if (causal == 0)
            {
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = 0;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
                ViewBag.PorCompletos = porcentajecompletas;
                ViewBag.PorComplemento = porcentajecomplemento;
                ViewBag.Completos = completas;
                ViewBag.Complemento = complemento;
               // ViewBag.Municipio = mun.Municipio;
            }
            else
            {
                decimal d = (100 * causal) / total;
                decimal porcentaje = Math.Round(d, 4);
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = porcentaje;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
                ViewBag.PorCompletos = porcentajecompletas;
                ViewBag.PorComplemento = porcentajecomplemento;
                ViewBag.Completos = completas;
                ViewBag.Complemento = complemento;
                //ViewBag.Municipio = mun.Municipio;

            }
            ViewBag.Id = id;
            //var Lista = _context.Resultados_Actas.SegundoLugarEleccion(0, 3, id);
            var final = _context.Causales.SegundoLugarCausal(0, 3, id);
            //var Partido = Lista.Where(x => x.Partido != 0).ToList();
            //var SumaPartido = Partido.GroupBy(x => x.Partido).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();
            //var Coalicion = Lista.Where(x => x.Coalicion != 0).ToList();
            //var SumaCoalicion = Coalicion.GroupBy(x => x.Coalicion).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();
            //var Independiente = Lista.Where(x => x.Independiente != 0).ToList();
            //var SumaIndependiente = Independiente.GroupBy(x => x.Independiente).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();

            //var filtro = SumaPartido.Concat(SumaIndependiente).ToList();
            //var final = filtro.Concat(SumaCoalicion).OrderByDescending(x => x.Total).ToList();
            if (final.Count != 0)
            {
                decimal diferencia = final.Select(x => x.Votos).ElementAt(0) - final.Select(x => x.Votos).ElementAt(1);
                if (diferencia != 0)
                {
                    //decimal? porcen1 = (100 * final.Select(x => x.Total).ElementAt(0)) / final.Sum(x => x.Total);
                    //decimal? porcen2 = (100 * final.Select(x => x.Total).ElementAt(1)) / final.Sum(x => x.Total);
                    //decimal porcen11 = Math.Round(porcen1.Value, 4);
                    //decimal porcen22 = Math.Round(porcen2.Value, 4);
                    //decimal porcenfinal = porcen11 - porcen22;

                    decimal paso1 = (100 * diferencia) / final.Sum(x => x.Votos);
                    decimal paso2 = Math.Round(paso1, 4);
                    ViewBag.VotosDiferencia = diferencia;
                    ViewBag.PorcentajeDiferencia = paso2;
                }
                else
                {
                    ViewBag.VotosDiferencia = 0;
                    ViewBag.PorcentajeDiferencia = 0;
                }
            }
            else
            {
                ViewBag.VotosDiferencia = 0;
                ViewBag.PorcentajeDiferencia = 0;
            }
            return View();
        }

        public IActionResult CausalesReg(int id)
        {

            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ca = _context.Causales.GetListaCausales(mun.Id,4,id);
            var demarcacion = _context.Demarcacion.GetAll().Where(x => x.Id == id).FirstOrDefault();
            var ba = ca.Where(x => x.Demarcacion == id).ToList();
            int NumSeccion = _context.Seccion.ListaCasillaByDemarcacion(mun.Id, id).Count();
            decimal completas = _context.Causales.CausalesCompletas(mun.Id,4, id).Count();
            decimal s = (100 * completas) / NumSeccion;
            decimal porcentajecompletas = Math.Round(s, 4);
            decimal complemento = _context.Causales.CausalesComplemento(mun.Id,4, id).Count();
            decimal j = (100 * complemento) / NumSeccion;
            decimal porcentajecomplemento = Math.Round(j, 4);
            decimal total = ba.Count();
            decimal causal = ba.Where(x => x.numcau != 0).Count();
            decimal t = (100 * total) / NumSeccion;
            decimal porcent = Math.Round(t, 4);
            if (causal == 0)
            {
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = 0;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
                ViewBag.PorCompletos = porcentajecompletas;
                ViewBag.PorComplemento = porcentajecomplemento;
                ViewBag.Completos = completas;
                ViewBag.Complemento = complemento;
                ViewBag.Municipio = mun.Municipio;
                ViewBag.Demarcacion = demarcacion.Nombre;
            }
            else
            {
                decimal d = (100 * causal) / total;
                decimal porcentaje = Math.Round(d, 4);
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = porcentaje;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
                ViewBag.PorCompletos = porcentajecompletas;
                ViewBag.PorComplemento = porcentajecomplemento;
                ViewBag.Completos = completas;
                ViewBag.Complemento = complemento;
                ViewBag.Municipio = mun.Municipio;
                ViewBag.Demarcacion = demarcacion.Nombre;
            }
            ViewBag.Id = id;
            //var Lista = _context.Resultados_Actas.SegundoLugarEleccion(mun.Id, 4, id);
            var final = _context.Causales.SegundoLugarCausal(mun.Id, 4, id);
            //var Partido = Lista.Where(x => x.Partido != 0).ToList();
            //var SumaPartido = Partido.GroupBy(x => x.Partido).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();
            //var Coalicion = Lista.Where(x => x.Coalicion != 0).ToList();
            //var SumaCoalicion = Coalicion.GroupBy(x => x.Coalicion).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();
            //var Independiente = Lista.Where(x => x.Independiente != 0).ToList();
            //var SumaIndependiente = Independiente.GroupBy(x => x.Independiente).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();

            //var filtro = SumaPartido.Concat(SumaIndependiente).ToList();
            //var final = filtro.Concat(SumaCoalicion).OrderByDescending(x => x.Total).ToList();
            if (final.Count != 0) { 
                decimal diferencia = final.Select(x => x.Votos).ElementAt(0) - final.Select(x => x.Votos).ElementAt(1);
                if (diferencia != 0)
                {
                    //decimal? por1lug = final.Select(x => x.Total).ElementAt(0);
                    //decimal? por2lug = final.Select(x => x.Total).ElementAt(1);
                    //decimal? porcen1 = (100 * por1lug) / final.Sum(x => x.Total);
                    //decimal? porcen2 = (100 * por2lug) / final.Sum(x => x.Total);
                    //var totvots = final.Sum(x => x.Total);
                    //decimal porcen11 = Math.Round(porcen1.Value, 4);
                    //decimal porcen22 = Math.Round(porcen2.Value, 4);
                    //decimal porcenfinal = porcen11 - porcen22;
                    decimal paso1 = (100 * diferencia) / final.Sum(x => x.Votos);
                    decimal paso2 = Math.Round(paso1, 4);
                    ViewBag.VotosDiferencia = diferencia;
                    ViewBag.PorcentajeDiferencia = paso2;
                }
                else
                {
                    ViewBag.VotosDiferencia = 0;
                    ViewBag.PorcentajeDiferencia = 0;
                }
            
            }
            else
            {
                ViewBag.VotosDiferencia = 0;
                ViewBag.PorcentajeDiferencia = 0;
            }
            return View();
        }

        [HttpGet]
        public IActionResult CausalesRegAdmin(int id)
        {
            var sec = _context.Seccion.GetFirstOrDefault(x => x.DemarcacionId == id);
            var mun = _db.Municipios.Find(sec.MunicipioId);
            var ca = _context.Causales.GetListaCausales(mun.Id, 4, id);
            var demarcacion = _context.Demarcacion.GetAll().Where(x => x.Id == id).FirstOrDefault();
            int NumSeccion = _context.Seccion.ListaCasillaByDemarcacion(mun.Id, id).Count();
            decimal completas = _context.Causales.CausalesCompletas(mun.Id, 4, id).Count();
            decimal s = (100 * completas) / NumSeccion;
            decimal porcentajecompletas = Math.Round(s, 4);
            decimal complemento = _context.Causales.CausalesComplemento(mun.Id, 4, id).Count();
            decimal j = (100 * complemento) / NumSeccion;
            decimal porcentajecomplemento = Math.Round(j, 4);
            decimal total = ca.Count();
            decimal causal = ca.Where(x => x.numcau != 0).Count();
            decimal t = (100 * total) / NumSeccion;
            decimal porcent = Math.Round(t, 4);
            if (causal == 0)
            {
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = 0;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
                ViewBag.PorCompletos = porcentajecompletas;
                ViewBag.PorComplemento = porcentajecomplemento;
                ViewBag.Completos = completas;
                ViewBag.Complemento = complemento;
                ViewBag.Municipio = mun.Municipio;
                ViewBag.Demarcacion = demarcacion.Nombre;
            }
            else
            {
                decimal d = (100 * causal) / total;
                decimal porcentaje = Math.Round(d, 4);
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = porcentaje;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
                ViewBag.PorCompletos = porcentajecompletas;
                ViewBag.PorComplemento = porcentajecomplemento;
                ViewBag.Completos = completas;
                ViewBag.Complemento = complemento;
                ViewBag.Municipio = mun.Municipio;
                ViewBag.Demarcacion = demarcacion.Nombre;
            }
            ViewBag.Id = id;
            //var Lista = _context.Resultados_Actas.SegundoLugarEleccion(mun.Id, 4, id);
            var final = _context.Causales.SegundoLugarCausal(mun.Id, 4, id);
            //var Partido = Lista.Where(x => x.Partido != 0).ToList();
            //var SumaPartido = Partido.GroupBy(x => x.Partido).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();
            //var Coalicion = Lista.Where(x => x.Coalicion != 0).ToList();
            //var SumaCoalicion = Coalicion.GroupBy(x => x.Coalicion).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();
            //var Independiente = Lista.Where(x => x.Independiente != 0).ToList();
            //var SumaIndependiente = Independiente.GroupBy(x => x.Independiente).Select(x => new
            //{
            //    GroupID = x.Key,
            //    Total = x.Sum(i => i.Votos)

            //}).ToList();

            //var filtro = SumaPartido.Concat(SumaIndependiente).ToList();
            //var final = filtro.Concat(SumaCoalicion).OrderByDescending(x => x.Total).ToList();
            if (final.Count != 0)
            {
                decimal diferencia = final.Select(x => x.Votos).ElementAt(0) - final.Select(x => x.Votos).ElementAt(1);
                if (diferencia != 0)
                {
                    //decimal? por1lug = final.Select(x => x.Total).ElementAt(0);
                    //decimal? por2lug = final.Select(x => x.Total).ElementAt(1);
                    //decimal? porcen1 = (100 * por1lug) / final.Sum(x => x.Total);
                    //decimal? porcen2 = (100 * por2lug) / final.Sum(x => x.Total);
                    //var totvots = final.Sum(x => x.Total);
                    //decimal porcen11 = Math.Round(porcen1.Value, 4);
                    //decimal porcen22 = Math.Round(porcen2.Value, 4);
                    //decimal porcenfinal = porcen11 - porcen22;
                    decimal paso1 = (100 * diferencia) / final.Sum(x => x.Votos);
                    decimal paso2 = Math.Round(paso1, 4);
                    ViewBag.VotosDiferencia = diferencia;
                    ViewBag.PorcentajeDiferencia = paso2;
                }
                else
                {
                    ViewBag.VotosDiferencia = 0;
                    ViewBag.PorcentajeDiferencia = 0;
                }

            }
            else
            {
                ViewBag.VotosDiferencia = 0;
                ViewBag.PorcentajeDiferencia = 0;
            }
            return View();
        }


        [HttpGet]
        public IActionResult VistaEjercicio(int id, int ele, int dd)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lst = _context.Puntos_Recuento.ObtenerEjercicosPorNumero(mun.Id, ele, dd, id);
            var Com = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, ele, dd);
            var Comprobacion = Com.Where(x => x.Tipo != 0).ToList();
            ViewBag.Comprobar = Comprobacion.Count();
            ViewBag.Ejercicio = lst;
            return View();
        }

        [HttpPost]
        public IActionResult SeleccionarEjercicio(int id, int ele, int dd)
        {
            try
            {
                var Id = _UserManager.GetUserId(User);
                var usuario = _db.Usuarios.Find(Id);
                var oficina = _db.Oficinas.Find(usuario.OficinaId);
                var mun = _db.Municipios.Find(oficina.MunicipioId);
                _context.Puntos_Recuento.EjercicioSeleccionado(mun.Id, ele, id, dd);
                return Json(new { success = true, mensaje = "Ejercicio aplicado" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }

        }

        [HttpGet]
        public IActionResult EjercicioPRGob()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ca = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, 1, 0);
            var Comprobacion = ca.Where(x => x.Tipo != 0).ToList();
            ViewBag.Comprobar = Comprobacion.Count();
            //decimal causal = ca.Where(x => x.numcau != 0).Count();
            ViewBag.Municipio = mun.Municipio;


            return View();
        }

        [HttpGet]
        public IActionResult PRGob()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ca = _context.Causales.GetListaCausales(mun.Id,1,0);
            decimal causal = ca.Where(x => x.numcau != 0).Count();
            var Ejercicio = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, 1, 0);
            var Comprobar = Ejercicio.Where(x => x.Tipo == 1).ToList();
            ViewBag.Municipio = mun.Municipio;
            ViewBag.Causal = causal;
            ViewBag.Comprobacion = Comprobar.Count();
            return View();
        }


        public JsonResult EnsayosPRGob()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lst = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, 1, 0);
            var lista = lst.Where(x => x.Tipo == 0);
            return Json(new { data = lista });
        }

        public JsonResult FinalPRGob()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lst = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, 1, 0);
            var lista = lst.Where(x => x.Tipo != 0);
            return Json(new { data = lista });
        }

        [HttpGet]
        public IActionResult EjercicioPRPys()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ca = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, 2, 0);
            var Comprobacion = ca.Where(x => x.Tipo != 0).ToList();
            ViewBag.Comprobar = Comprobacion.Count();
            //decimal causal = ca.Where(x => x.numcau != 0).Count();
            ViewBag.Municipio = mun.Municipio;


            return View();
        }

        [HttpGet]
        public IActionResult PRPys()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ca = _context.Causales.GetListaCausales(mun.Id, 2, 0);
            decimal causal = ca.Where(x => x.numcau != 0).Count();
            var Ejercicio = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, 2, 0);
            var Comprobar = Ejercicio.Where(x => x.Tipo == 1).ToList();
            ViewBag.Municipio = mun.Municipio;
            ViewBag.Causal = causal;
            ViewBag.Comprobacion = Comprobar.Count();

            return View();
        }
       
        public JsonResult EnsayosPRPys()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lst = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, 2, 0);
            var lista = lst.Where(x => x.Tipo == 0);
            return Json(new { data = lista });
        }

        public JsonResult FinalPRPys()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lst = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, 2, 0);
            var lista = lst.Where(x => x.Tipo != 0);
            return Json(new { data = lista });
        }

        public IActionResult EjercicioPRDip(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ca = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, 3, id);
            var Comprobacion = ca.Where(x => x.Tipo != 0).ToList();
            ViewBag.Comprobar = Comprobacion.Count();
            //decimal causal = ca.Where(x => x.numcau != 0).Count();
            ViewBag.Municipio = mun.Municipio;
            var dis = _db.Distritos.Find(id);
            ViewBag.Distrito = dis.NoDistrito;
            ViewBag.IdDistrito = dis.Id;
            return View();
        }

        [HttpGet]
        public IActionResult PRDip(int id)
        {

            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ca = _context.Causales.GetListaCausales(mun.Id,3,id);
            decimal causal = ca.Where(x => x.numcau != 0).Count();
            var dis = _db.Distritos.Find(id);
            ViewBag.Municipio = mun.Municipio;
            ViewBag.Causal = causal;
            var Ejercicio = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, 3, id);
            var Comprobar = Ejercicio.Where(x => x.Tipo == 1).ToList();
            ViewBag.Distrito = dis.NoDistrito;
            ViewBag.IdDistrito = dis.Id;
            ViewBag.Comprobacion = Comprobar.Count();

            return View();
        }

        public JsonResult EnsayosPRDip(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lst = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, 3, id);
            var lista = lst.Where(x => x.Tipo == 0);
            return Json(new { data = lista });
        }

        public JsonResult FinalPRDip(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lst = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, 3, id);
            var lista = lst.Where(x => x.Tipo != 0);
            return Json(new { data = lista });
        }


        public IActionResult EjercicioPRReg(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ca = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, 4, id);
            var Comprobacion = ca.Where(x => x.Tipo != 0).ToList();
            ViewBag.Comprobar = Comprobacion.Count();
            //decimal causal = ca.Where(x => x.numcau != 0).Count();
            ViewBag.Municipio = mun.Municipio;
            var dis = _db.Demarcaciones.Find(id);
            ViewBag.Demarcacion = dis.Nombre;
            ViewBag.IdDemarcacion = dis.Id;


            return View();
        }

        [HttpGet]
        public IActionResult PRReg(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ca = _context.Causales.GetListaCausales(mun.Id,4,id);
            decimal causal = ca.Where(x => x.numcau != 0).Count();
            var dem = _db.Demarcaciones.Find(id);
            var Ejercicio = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, 4, id);
            var Comprobar = Ejercicio.Where(x => x.Tipo == 1).ToList();
            ViewBag.Municipio = mun.Municipio;
            ViewBag.Causal = causal;
            ViewBag.IdDemarcacion = dem.Id;
            ViewBag.Demarcacion = dem.Nombre;
            ViewBag.Comprobacion = Comprobar.Count();

            return View();
        }

        public JsonResult EnsayosPRReg(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lst = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, 4, id);
            var lista = lst.Where(x => x.Tipo == 0);
            return Json(new { data = lista });
        }

        public JsonResult FinalPRReg(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lst = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, 4, id);
            var lista = lst.Where(x => x.Tipo != 0);
            return Json(new { data = lista });
        }


        public JsonResult Casillaid(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lst = _context.Recepcion.ObtenerCasilla(id, mun.Id);
            return Json(new SelectList(lst, "Value", "Text"));
            
        }

        [HttpGet]

        public JsonResult CargarDa()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var a = _context.Recepcion.GetListaPaquetesByMun(mun.Id);        
            // lst2.Insert(0, new ElementoJsonIntKey { value = 0, text = "Selecciona tipo de casilla" });
            return Json(new { data = a});
        }


        public JsonResult CargarDatosAdmin(int id)
        {
            var c = _context.Recepcion.GetListaPaquetesByMun(id);
            return Json(new { data = c });
        }


        [HttpGet]
        public JsonResult CargarAvance()
        {
            var res = _context.Recepcion.GetAvancePaquetes();
            return Json(new { data = res});
        }

        [HttpGet]
        public JsonResult CargarDetalle(int id)
        {
            var res = _context.Recepcion.GetDetallePaquetes(id);

            return Json(new { data = res });
        }

        [HttpGet]
        public IActionResult DetalleAvance(int id)
        {
            var Casillas = _context.Casilla.GetAll().Where(x => x.MunicipioId == id).ToList();
            var Municipio = _context.Municipio.Get(id);
            List<T_Recepcion_Paquete> Rec = new List<T_Recepcion_Paquete>();
            foreach (var item in Casillas)
            {
                if (_context.Recepcion.GetAll().Where(x => x.IdCasilla == item.Id).Count() != 0)
                {
                    Rec.Add(_db.Recepcion_Paquete.Where(x => x.IdCasilla == item.Id).FirstOrDefault());
                }

            }
            decimal recibidos = Rec.Count();
            decimal total = Casillas.Count();
            decimal t = (100 * recibidos) / total;
            decimal porcent = Math.Round(t, 4);
            ViewBag.Porcentaje = porcent;
            ViewBag.Total = Casillas.Count();
            ViewBag.Recibidas = Rec.Count();
            ViewBag.Nombre = Municipio.Municipio;
            ViewBag.Municipio = id;
            return View();
        }

        [HttpGet]
        public IActionResult DetalleAvanceMunicipal()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var Casillas = _context.Casilla.GetAll().Where(x => x.MunicipioId == mun.Id).ToList();
            var Municipio = _context.Municipio.Get(mun.Id);
            List<T_Recepcion_Paquete> Rec = new List<T_Recepcion_Paquete>();
            foreach (var item in Casillas)
            {
                if (_context.Recepcion.GetAll().Where(x => x.IdCasilla == item.Id).Count() != 0)
                {
                    Rec.Add(_db.Recepcion_Paquete.Where(x => x.IdCasilla == item.Id).FirstOrDefault());
                }

            }
            decimal recibidos = Rec.Count();
            decimal total = Casillas.Count();
            decimal t = (100 * recibidos) / total;
            decimal porcent = Math.Round(t, 4);
            ViewBag.Porcentaje = porcent;
            ViewBag.Total = Casillas.Count();
            ViewBag.Recibidas = Rec.Count();
            ViewBag.Nombre = Municipio.Municipio;
            ViewBag.Municipio = mun.Id;
            return View();
        }


      
        public IActionResult RegistroCapturado (int id)
        {
                
            _db.SaveChanges();
            return View();
        }
        public IActionResult RegistroCau(int id, int ca)
        {                   
          T_Causal_Recuento cles;
            T_Causal_Recuento clesRP;
            var Especial = _db.Casillas.Find(id);
            if(Especial.TipoCasillaId != 4) { 
                if( _context.Causales.GetAll().Where(x => x.CasillaId == id).Count()!=0)
                {
                    for(int j = 1; j<= 4; j++)
                    {
                        if(_context.Causales.GetAll().Where(x => x.CasillaId == id && x.TipoEleccionId == j).Count() != 0)
                        {
                            if (ca == 1)
                            {
                                var res = _context.Causales.GetAll().Where(x => x.CasillaId == id && x.TipoEleccionId == j).FirstOrDefault();
                                res.Causal8 = true;
                                res.Total_Causales = res.Total_Causales + 1;
                            }
                            else
                            {
                                var res = _context.Causales.GetAll().Where(x => x.CasillaId == id && x.TipoEleccionId == j).FirstOrDefault();
                                res.Causal8 = false;
                            }
                            _db.SaveChanges();
                        }
                        else
                        {
                            if (ca == 1)
                            {
                                cles = new T_Causal_Recuento();
                                cles.CasillaId = id;
                                cles.TipoEleccionId = j;
                                cles.Causal1 = false;
                                cles.Causal2 = false;
                                cles.Causal3 = false;
                                cles.Causal4 = false;
                                cles.Causal5 = false;
                                cles.Causal6 = false;
                                cles.Causal7 = false;
                                cles.Causal8 = true;
                                cles.Causal9 = false;
                                cles.Causal10 = false;
                                cles.Causal11 = false;
                                var computo =_context.Detalle_Acta_Computo.GetFirstOrDefault(x => x.TipoEleccionId == j && x.CasillaId == id);
                                cles.DetalleActaComputoId = computo.Id;
                                cles.Total_Causales = 1;
                                cles.Recuento_Total = false;
                                _context.Causales.Add(cles);
                            }
                            else
                            {
                                cles = new T_Causal_Recuento();
                                cles.CasillaId = id;
                                cles.TipoEleccionId = j;
                                cles.Causal1 = false;
                                cles.Causal2 = false;
                                cles.Causal3 = false;
                                cles.Causal4 = false;
                                cles.Causal5 = false;
                                cles.Causal6 = false;
                                cles.Causal7 = false;
                                cles.Causal8 = false;
                                cles.Causal9 = false;
                                cles.Causal10 = false;
                                cles.Causal11 = false;
                                var computo = _context.Detalle_Acta_Computo.GetFirstOrDefault(x => x.TipoEleccionId == j && x.CasillaId == id);
                                cles.DetalleActaComputoId = computo.Id;
                                cles.Total_Causales = 0;
                                cles.Recuento_Total = false;
                                _context.Causales.Add(cles);
                            }
                        }                 
                    }               
                }
                else
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        if (ca == 1)
                        {
                            cles = new T_Causal_Recuento();
                            cles.CasillaId = id;
                            cles.TipoEleccionId = i;
                            cles.Causal1 = false;
                            cles.Causal2 = false;
                            cles.Causal3 = false;
                            cles.Causal4 = false;
                            cles.Causal5 = false;
                            cles.Causal6 = false;
                            cles.Causal7 = false;
                            cles.Causal8 = true;
                            cles.Causal9 = false;
                            cles.Causal10 = false;
                            cles.Causal11 = false;
                            cles.Recuento_Total = false;
                            var computo = _context.Detalle_Acta_Computo.GetFirstOrDefault(x => x.TipoEleccionId == i && x.CasillaId == id);
                            cles.DetalleActaComputoId = computo.Id;
                            cles.Total_Causales = 1;
                            _context.Causales.Add(cles);
                        
                        }
                        else
                        {
                            cles = new T_Causal_Recuento();
                            cles.CasillaId = id;
                            cles.TipoEleccionId = i;
                            cles.Causal1 = false;
                            cles.Causal2 = false;
                            cles.Causal3 = false;
                            cles.Causal4 = false;
                            cles.Causal5 = false;
                            cles.Causal6 = false;
                            cles.Causal7 = false;
                            cles.Causal8 = false;
                            cles.Causal9 = false;
                            cles.Causal10 = false;
                            cles.Causal11 = false;
                            cles.Recuento_Total = false;
                            cles.Total_Causales = 0;
                            var computo = _context.Detalle_Acta_Computo.GetFirstOrDefault(x => x.TipoEleccionId == i && x.CasillaId == id);
                            cles.DetalleActaComputoId = computo.Id;
                            _context.Causales.Add(cles);
                        
                        }
                    }
                }
            }
            else
            {
                if (_context.Causales.GetAll().Where(x => x.CasillaId == id).Count() != 0)
                {
                    for (int j = 1; j <= 4; j++)
                    {
                        if (_context.Causales.GetAll().Where(x => x.CasillaId == id && x.TipoEleccionId == j).Count() != 0)
                        {
                            if(j == 3 || j== 4)
                            {
                                var RP = _context.Causales.GetAll().Where(x => x.CasillaId == id && x.TipoEleccionId == j).ToList();
                                foreach(var CasillasRP in RP )
                                {
                                    if(CasillasRP.RP == true) 
                                    {
                                        if (ca == 1)
                                        {
                                            var res = _context.Causales.GetAll().Where(x => x.CasillaId == id && x.TipoEleccionId == j && x.RP == true).FirstOrDefault();
                                            res.Causal8 = true;
                                            res.Total_Causales = res.Total_Causales + 1;
                                        }
                                        else
                                        {
                                            var res = _context.Causales.GetAll().Where(x => x.CasillaId == id && x.TipoEleccionId == j && x.RP == true).FirstOrDefault();
                                            res.Causal8 = false;
                                        }
                                    }
                                    else
                                    {
                                        if (ca == 1)
                                        {
                                            var res = _context.Causales.GetAll().Where(x => x.CasillaId == id && x.TipoEleccionId == j && x.RP == true).FirstOrDefault();
                                            res.Causal8 = true;
                                            res.Total_Causales = res.Total_Causales + 1;
                                        }
                                        else
                                        {
                                            var res = _context.Causales.GetAll().Where(x => x.CasillaId == id && x.TipoEleccionId == j && x.RP == true).FirstOrDefault();
                                            res.Causal8 = false;
                                        }
                                    }   
                                }
                            }
                            else
                            {
                                if (ca == 1)
                                {
                                    var res = _context.Causales.GetAll().Where(x => x.CasillaId == id && x.TipoEleccionId == j).FirstOrDefault();
                                    res.Causal8 = true;
                                    res.Total_Causales = res.Total_Causales + 1;
                                }
                                else
                                {
                                    var res = _context.Causales.GetAll().Where(x => x.CasillaId == id && x.TipoEleccionId == j).FirstOrDefault();
                                    res.Causal8 = false;
                                }
                                _db.SaveChanges();

                            }
                            
                        }
                        else
                        {
                            if(j == 3 || j == 4) {
                                if (ca == 1)
                                {
                                    cles = new T_Causal_Recuento();
                                    cles.CasillaId = id;
                                    cles.TipoEleccionId = j;
                                    cles.Causal1 = false;
                                    cles.Causal2 = false;
                                    cles.Causal3 = false;
                                    cles.Causal4 = false;
                                    cles.Causal5 = false;
                                    cles.Causal6 = false;
                                    cles.Causal7 = false;
                                    cles.Causal8 = true;
                                    cles.Causal9 = false;
                                    cles.Causal10 = false;
                                    cles.Causal11 = false;
                                    var computo = _context.Detalle_Acta_Computo.GetFirstOrDefault(x => x.TipoEleccionId == j && x.CasillaId == id);
                                    cles.DetalleActaComputoId = computo.Id;
                                    cles.Total_Causales = 1;
                                    cles.Recuento_Total = false;
                                    cles.RP = false;
                                    _context.Causales.Add(cles);
                                    clesRP = new T_Causal_Recuento();
                                    clesRP.CasillaId = id;
                                    clesRP.TipoEleccionId = j;
                                    clesRP.Causal1 = false;
                                    clesRP.Causal2 = false;
                                    clesRP.Causal3 = false;
                                    clesRP.Causal4 = false;
                                    clesRP.Causal5 = false;
                                    clesRP.Causal6 = false;
                                    clesRP.Causal7 = false;
                                    clesRP.Causal8 = true;
                                    clesRP.Causal9 = false;
                                    clesRP.Causal10 = false;
                                    clesRP.Causal11 = false;
                                    var computoRP = _context.Detalle_Acta_Computo_RP.GetFirstOrDefault(x => x.TipoEleccionId == j && x.CasillaId == id);
                                    clesRP.DetalleActaComputoRPId = computoRP.Id;
                                    clesRP.Total_Causales = 1;
                                    clesRP.Recuento_Total = false;
                                    clesRP.RP = true;
                                    _context.Causales.Add(clesRP);
                                }
                                else
                                {
                                    cles = new T_Causal_Recuento();
                                    cles.CasillaId = id;
                                    cles.TipoEleccionId = j;
                                    cles.Causal1 = false;
                                    cles.Causal2 = false;
                                    cles.Causal3 = false;
                                    cles.Causal4 = false;
                                    cles.Causal5 = false;
                                    cles.Causal6 = false;
                                    cles.Causal7 = false;
                                    cles.Causal8 = false;
                                    cles.Causal9 = false;
                                    cles.Causal10 = false;
                                    cles.Causal11 = false;
                                    var computo = _context.Detalle_Acta_Computo.GetFirstOrDefault(x => x.TipoEleccionId == j && x.CasillaId == id);
                                    cles.DetalleActaComputoId = computo.Id;
                                    cles.Total_Causales = 0;
                                    cles.Recuento_Total = false;
                                    _context.Causales.Add(cles);
                                    clesRP = new T_Causal_Recuento();
                                    clesRP.CasillaId = id;
                                    clesRP.TipoEleccionId = j;
                                    clesRP.Causal1 = false;
                                    clesRP.Causal2 = false;
                                    clesRP.Causal3 = false;
                                    clesRP.Causal4 = false;
                                    clesRP.Causal5 = false;
                                    clesRP.Causal6 = false;
                                    clesRP.Causal7 = false;
                                    clesRP.Causal8 = false;
                                    clesRP.Causal9 = false;
                                    clesRP.Causal10 = false;
                                    clesRP.Causal11 = false;
                                    var computoRP = _context.Detalle_Acta_Computo_RP.GetFirstOrDefault(x => x.TipoEleccionId == j && x.CasillaId == id);
                                    clesRP.DetalleActaComputoRPId = computoRP.Id;
                                    clesRP.Total_Causales = 0;
                                    clesRP.Recuento_Total = false;
                                    clesRP.RP = true;
                                    _context.Causales.Add(clesRP);
                                }
                            }
                            else
                            {
                                if (ca == 1)
                                {
                                    cles = new T_Causal_Recuento();
                                    cles.CasillaId = id;
                                    cles.TipoEleccionId = j;
                                    cles.Causal1 = false;
                                    cles.Causal2 = false;
                                    cles.Causal3 = false;
                                    cles.Causal4 = false;
                                    cles.Causal5 = false;
                                    cles.Causal6 = false;
                                    cles.Causal7 = false;
                                    cles.Causal8 = true;
                                    cles.Causal9 = false;
                                    cles.Causal10 = false;
                                    cles.Causal11 = false;
                                    var computo = _context.Detalle_Acta_Computo.GetFirstOrDefault(x => x.TipoEleccionId == j && x.CasillaId == id);
                                    cles.DetalleActaComputoId = computo.Id;
                                    cles.Total_Causales = 1;
                                    cles.Recuento_Total = false;
                                    _context.Causales.Add(cles);
                                }
                                else
                                {
                                    cles = new T_Causal_Recuento();
                                    cles.CasillaId = id;
                                    cles.TipoEleccionId = j;
                                    cles.Causal1 = false;
                                    cles.Causal2 = false;
                                    cles.Causal3 = false;
                                    cles.Causal4 = false;
                                    cles.Causal5 = false;
                                    cles.Causal6 = false;
                                    cles.Causal7 = false;
                                    cles.Causal8 = false;
                                    cles.Causal9 = false;
                                    cles.Causal10 = false;
                                    cles.Causal11 = false;
                                    var computo = _context.Detalle_Acta_Computo.GetFirstOrDefault(x => x.TipoEleccionId == j && x.CasillaId == id);
                                    cles.DetalleActaComputoId = computo.Id;
                                    cles.Total_Causales = 0;
                                    cles.Recuento_Total = false;
                                    _context.Causales.Add(cles);
                                }
                            }
                           
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        if(i == 3 || i== 4)
                        {
                            if (ca == 1)
                            {
                                cles = new T_Causal_Recuento();
                                cles.CasillaId = id;
                                cles.TipoEleccionId = i;
                                cles.Causal1 = false;
                                cles.Causal2 = false;
                                cles.Causal3 = false;
                                cles.Causal4 = false;
                                cles.Causal5 = false;
                                cles.Causal6 = false;
                                cles.Causal7 = false;
                                cles.Causal8 = true;
                                cles.Causal9 = false;
                                cles.Causal10 = false;
                                cles.Causal11 = false;
                                cles.Recuento_Total = false;
                                var computo = _context.Detalle_Acta_Computo.GetFirstOrDefault(x => x.TipoEleccionId == i && x.CasillaId == id);
                                cles.DetalleActaComputoId = computo.Id;
                                cles.Total_Causales = 1;
                                _context.Causales.Add(cles);
                                clesRP = new T_Causal_Recuento();
                                clesRP.CasillaId = id;
                                clesRP.TipoEleccionId = i;
                                clesRP.Causal1 = false;
                                clesRP.Causal2 = false;
                                clesRP.Causal3 = false;
                                clesRP.Causal4 = false;
                                clesRP.Causal5 = false;
                                clesRP.Causal6 = false;
                                clesRP.Causal7 = false;
                                clesRP.Causal8 = true;
                                clesRP.Causal9 = false;
                                clesRP.Causal10 = false;
                                clesRP.Causal11 = false;
                                var computoRP = _context.Detalle_Acta_Computo_RP.GetFirstOrDefault(x => x.TipoEleccionId == i && x.CasillaId == id);
                                clesRP.DetalleActaComputoRPId = computoRP.Id;
                                clesRP.Total_Causales = 1;
                                clesRP.Recuento_Total = false;
                                clesRP.RP = true;
                                _context.Causales.Add(clesRP);

                            }
                            else
                            {
                                cles = new T_Causal_Recuento();
                                cles.CasillaId = id;
                                cles.TipoEleccionId = i;
                                cles.Causal1 = false;
                                cles.Causal2 = false;
                                cles.Causal3 = false;
                                cles.Causal4 = false;
                                cles.Causal5 = false;
                                cles.Causal6 = false;
                                cles.Causal7 = false;
                                cles.Causal8 = false;
                                cles.Causal9 = false;
                                cles.Causal10 = false;
                                cles.Causal11 = false;
                                cles.Recuento_Total = false;
                                cles.Total_Causales = 0;
                                var computo = _context.Detalle_Acta_Computo.GetFirstOrDefault(x => x.TipoEleccionId == i && x.CasillaId == id);
                                cles.DetalleActaComputoId = computo.Id;
                                _context.Causales.Add(cles);
                                clesRP = new T_Causal_Recuento();
                                clesRP.CasillaId = id;
                                clesRP.TipoEleccionId = i;
                                clesRP.Causal1 = false;
                                clesRP.Causal2 = false;
                                clesRP.Causal3 = false;
                                clesRP.Causal4 = false;
                                clesRP.Causal5 = false;
                                clesRP.Causal6 = false;
                                clesRP.Causal7 = false;
                                clesRP.Causal8 = false;
                                clesRP.Causal9 = false;
                                clesRP.Causal10 = false;
                                clesRP.Causal11 = false;
                                var computoRP = _context.Detalle_Acta_Computo_RP.GetFirstOrDefault(x => x.TipoEleccionId == i && x.CasillaId == id);
                                clesRP.DetalleActaComputoRPId = computoRP.Id;
                                clesRP.Total_Causales = 0;
                                clesRP.Recuento_Total = false;
                                clesRP.RP = true;
                                _context.Causales.Add(clesRP);

                            }
                        }
                        else
                        {
                            if (ca == 1)
                            {
                                cles = new T_Causal_Recuento();
                                cles.CasillaId = id;
                                cles.TipoEleccionId = i;
                                cles.Causal1 = false;
                                cles.Causal2 = false;
                                cles.Causal3 = false;
                                cles.Causal4 = false;
                                cles.Causal5 = false;
                                cles.Causal6 = false;
                                cles.Causal7 = false;
                                cles.Causal8 = true;
                                cles.Causal9 = false;
                                cles.Causal10 = false;
                                cles.Causal11 = false;
                                cles.Recuento_Total = false;
                                var computo = _context.Detalle_Acta_Computo.GetFirstOrDefault(x => x.TipoEleccionId == i && x.CasillaId == id);
                                cles.DetalleActaComputoId = computo.Id;
                                cles.Total_Causales = 1;
                                _context.Causales.Add(cles);

                            }
                            else
                            {
                                cles = new T_Causal_Recuento();
                                cles.CasillaId = id;
                                cles.TipoEleccionId = i;
                                cles.Causal1 = false;
                                cles.Causal2 = false;
                                cles.Causal3 = false;
                                cles.Causal4 = false;
                                cles.Causal5 = false;
                                cles.Causal6 = false;
                                cles.Causal7 = false;
                                cles.Causal8 = false;
                                cles.Causal9 = false;
                                cles.Causal10 = false;
                                cles.Causal11 = false;
                                cles.Recuento_Total = false;
                                cles.Total_Causales = 0;
                                var computo = _context.Detalle_Acta_Computo.GetFirstOrDefault(x => x.TipoEleccionId == i && x.CasillaId == id);
                                cles.DetalleActaComputoId = computo.Id;
                                _context.Causales.Add(cles);

                            }
                        }
                       
                    }
                }
            }
            _db.SaveChanges();

            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _context.Recepcion.GetAll() });
        }

        [HttpPost]
        public IActionResult Create(T_Recepcion_Paquete item)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            if (ModelState.IsValid)
            {
                item.FechaRegistro = DateTime.Now;
                item.HoraRegistro = DateTime.Now;
                item.UsuarioRegistro = usuario.Id;
                _context.Recepcion.Add(item);
                var Captura = _context.Casilla.GetAll(x => x.Id == item.IdCasilla).FirstOrDefault();
                Captura.Recibido = true;
                if(_context.Recepcion.GetAll().Where(x=> x.IdCasilla == item.IdCasilla).Count() < 1)
                {
                    _context.Save();
                    int id = item.IdCasilla;
                    int cau = Convert.ToInt32(item.Alteracion);
                    RegistroCau(id, cau);
                    VerificarRecuento();
                }

                return Json(new { success = true, mensaje = "Paquete registrado con éxito" });

            }
            return Json(new { success = false, mensaje = "Error al registrar el paquete, intentelo de nuevo" });
        }

        public void VerificarRecuento()
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
        }

        public void VerificarRecuentoCausal()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            //var casillas = _context.Casilla.GetListaCasillaMunicipio(mun.Id);
            //var paquetes = _context.Recepcion.GetPaquetes(mun.Id);
            //var recibidos = paquetes.Where(x => x.LCasilla.Recibido == true).ToList();
            //if (casillas.Count() == recibidos.Count())
            //{
                //var actas = _context.Recepcion.CapturaCompleta(mun.Id);
                //var Gob = actas.Where(x => x.IdEleccion == 1).ToList();
                //var Pys = actas.Where(x => x.IdEleccion == 2).ToList();

                //var GobCom = Gob.Where(x => x.CapturadoComplemento == true && x.CapturadoVotos == true).ToList();
                //var PysCom = Pys.Where(x => x.CapturadoComplemento == true && x.CapturadoVotos == true).ToList();


                //if (Gob.Count() == GobCom.Count())
                //{
                //-------------------------------------------------------------------------------------------------------------------------------------------//
                    var CaGob = _context.Causales.GetListaCausales(mun.Id, 1, 0);
                    decimal causalGob = CaGob.Where(x => x.numcau != 0).Count();
                    decimal totalGob = CaGob.Count();
                    decimal dGob = (100 * causalGob) / totalGob;
                    decimal porcentajeGob;
                    if (causalGob == 0)
                    {
                        porcentajeGob = 0;
                    }
                    else
                    {
                        porcentajeGob = Math.Round(dGob, 4);
                    }

                    var ListaGob = _context.Resultados_Actas.SegundoLugarEleccion(mun.Id, 1, 0);
                    var PartidoGob = ListaGob.Where(x => x.Partido != 0).ToList();
                    var SumaPartidoGob = PartidoGob.GroupBy(x => x.Partido).Select(x => new
                    {
                        GroupID = x.Key,
                        Total = x.Sum(i => i.Votos)

                    }).ToList();
                    var CoalicionGob = ListaGob.Where(x => x.Coalicion != 0).ToList();
                    var SumaCoalicionGob = CoalicionGob.GroupBy(x => x.Coalicion).Select(x => new
                    {
                        GroupID = x.Key,
                        Total = x.Sum(i => i.Votos)

                    }).ToList();
                    var IndependienteGob = ListaGob.Where(x => x.Independiente != 0).ToList();
                    var SumaIndependienteGob = IndependienteGob.GroupBy(x => x.Independiente).Select(x => new
                    {
                        GroupID = x.Key,
                        Total = x.Sum(i => i.Votos)

                    }).ToList();

                    var filtroGob = SumaPartidoGob.Concat(SumaIndependienteGob).ToList();
                    var finalGob = filtroGob.Concat(SumaCoalicionGob).OrderByDescending(x => x.Total).ToList();
                    if(finalGob.Count() != 0)
                    {
                        decimal diferenciaGob = finalGob.Select(x => x.Total.Value).ElementAt(0) - finalGob.Select(x => x.Total.Value).ElementAt(1);
                        decimal paso2Gob;
                        if (diferenciaGob != 0)
                        {
                            decimal paso1 = (100 * diferenciaGob) / finalGob.Sum(x => x.Total.Value);
                            paso2Gob = Math.Round(paso1, 4);

                        }
                        else
                        {
                            paso2Gob = 0;
                        }
                        if (paso2Gob <= 2 && porcentajeGob <= 20)
                        {
                            foreach (var Cambiar in CaGob)
                            {
                                var Recuento = _db.Causales_recuento.FirstOrDefault(x => x.Id == Cambiar.idcau);
                                Recuento.Recuento_Total = false;
                            }
                            _db.SaveChanges();
                        }
                    }
                    
                    //-----------------------------------------------------------------------------------------------------------------------------//

                //}------------------------------------------------------------------------------------------------------------------------------------------//
                
                    var CaPys = _context.Causales.GetListaCausales(mun.Id, 2, 0);
                    decimal causalPys = CaPys.Where(x => x.numcau != 0).Count();
                    decimal totalPys = CaPys.Count();
                    decimal dPys = (100 * causalPys) / totalPys;
                    decimal porcentajePys;
                    if (causalPys == 0)
                    {
                        porcentajePys = 0;
                    }
                    else
                    {
                        porcentajePys = Math.Round(dPys, 4);
                    }

                    var ListaPys = _context.Resultados_Actas.SegundoLugarEleccion(mun.Id, 2, 0);
                    var PartidoPys = ListaPys.Where(x => x.Partido != 0).ToList();
                    var SumaPartidoPys = PartidoPys.GroupBy(x => x.Partido).Select(x => new
                    {
                        GroupID = x.Key,
                        Total = x.Sum(i => i.Votos)

                    }).ToList();
                    var CoalicionPys = ListaPys.Where(x => x.Coalicion != 0).ToList();
                    var SumaCoalicionPys = CoalicionPys.GroupBy(x => x.Coalicion).Select(x => new
                    {
                        GroupID = x.Key,
                        Total = x.Sum(i => i.Votos)

                    }).ToList();
                    var IndependientePys = ListaPys.Where(x => x.Independiente != 0).ToList();
                    var SumaIndependientePys = IndependientePys.GroupBy(x => x.Independiente).Select(x => new
                    {
                        GroupID = x.Key,
                        Total = x.Sum(i => i.Votos)

                    }).ToList();

                    var filtroPys = SumaPartidoPys.Concat(SumaIndependientePys).ToList();
                    var finalPys = filtroPys.Concat(SumaCoalicionPys).OrderByDescending(x => x.Total).ToList();
                    if (finalPys.Count !=0)
                    {
                        decimal diferenciaPys = finalPys.Select(x => x.Total.Value).ElementAt(0) - finalPys.Select(x => x.Total.Value).ElementAt(1);
                        decimal paso2Pys;
                        if (diferenciaPys != 0)
                        {
                            decimal paso1 = (100 * diferenciaPys) / finalPys.Sum(x => x.Total.Value);
                            paso2Pys = Math.Round(paso1, 4);
                            //ViewBag.VotosDiferencia = diferencia;
                            //ViewBag.PorcentajeDiferencia = paso1;
                        }
                        else
                        {
                            paso2Pys = 0;
                        }

                        if (paso2Pys <= 2 && porcentajePys <= 20)
                        {
                            foreach (var Cambiar in CaPys)
                            {
                                var Recuento = _db.Causales_recuento.FirstOrDefault(x => x.Id == Cambiar.idcau);
                                Recuento.Recuento_Total = false;
                            }
                            _db.SaveChanges();
                        }
                     }
                   
                //-------------------------------------------------------------------------------------------------------------------------------------------------//

                //------------------------------------------------------------------------------------------------------------------------//
                var ListaDistrito = _context.Recepcion.ListaDD(mun.Id, 3);
                foreach (var Distrito in ListaDistrito)
                {
                    var Dip = _context.Recepcion.CapturaCompletaDD(mun.Id, 3, Convert.ToInt32(Distrito.Value));
                    var DipCom = Dip.Where(x => x.CapturadoComplemento == true && x.CapturadoVotos == true).ToList();
                    
                        var ca = _context.Causales.GetListaCausales(mun.Id, 3, Convert.ToInt32(Distrito.Value));
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
                        var Lista = _context.Resultados_Actas.SegundoLugarEleccion(mun.Id, 3, Convert.ToInt32(Distrito.Value));
                        var Partido = Lista.Where(x => x.Partido != 0).ToList();
                        var SumaPartido = Partido.GroupBy(x => x.Partido).Select(x => new
                        {
                            GroupID = x.Key,
                            Total = x.Sum(i => i.Votos)

                        }).ToList();
                        var Coalicion = Lista.Where(x => x.Coalicion != 0).ToList();
                        var SumaCoalicion = Coalicion.GroupBy(x => x.Coalicion).Select(x => new
                        {
                            GroupID = x.Key,
                            Total = x.Sum(i => i.Votos)

                        }).ToList();
                        var Independiente = Lista.Where(x => x.Independiente != 0).ToList();
                        var SumaIndependiente = Independiente.GroupBy(x => x.Independiente).Select(x => new
                        {
                            GroupID = x.Key,
                            Total = x.Sum(i => i.Votos)

                        }).ToList();

                        var filtro = SumaPartido.Concat(SumaIndependiente).ToList();
                        var final = filtro.Concat(SumaCoalicion).OrderByDescending(x => x.Total).ToList();
                        if (final.Count != 0)
                        {
                            decimal diferencia = final.Select(x => x.Total.Value).ElementAt(0) - final.Select(x => x.Total.Value).ElementAt(1);
                       
                            decimal paso2;
                            if (diferencia != 0)
                            {
                                decimal paso1 = (100 * diferencia) / final.Sum(x => x.Total.Value);
                                paso2 = Math.Round(paso1, 4);
                                //ViewBag.VotosDiferencia = diferencia;
                                //ViewBag.PorcentajeDiferencia = paso1;
                            }
                            else
                            {
                                paso2 = 0;
                            }

                            if (paso2 <= 2 && porcentaje <= 20)
                            {
                                foreach (var Cambiar in ca)
                                {
                                    var Recuento = _db.Causales_recuento.FirstOrDefault(x => x.Id == Cambiar.idcau);
                                    Recuento.Recuento_Total = false;
                                }
                                _db.SaveChanges();
                            }
                        }
                    //----------------------------------------------------------------------------------------------------------------------------------------------//
                }

                var ListaDemarcacion = _context.Recepcion.ListaDD(mun.Id, 4);
                foreach (var Demarcacion in ListaDemarcacion)
                {
                    var Reg = _context.Recepcion.CapturaCompletaDD(mun.Id, 4, Convert.ToInt32(Demarcacion.Value));
                    var RegCom = Reg.Where(x => x.CapturadoComplemento == true && x.CapturadoVotos == true).ToList();
                    
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
                        var Lista = _context.Resultados_Actas.SegundoLugarEleccion(mun.Id, 4, Convert.ToInt32(Demarcacion.Value));
                        var Partido = Lista.Where(x => x.Partido != 0).ToList();
                        var SumaPartido = Partido.GroupBy(x => x.Partido).Select(x => new
                        {
                            GroupID = x.Key,
                            Total = x.Sum(i => i.Votos)

                        }).ToList();
                        var Coalicion = Lista.Where(x => x.Coalicion != 0).ToList();
                        var SumaCoalicion = Coalicion.GroupBy(x => x.Coalicion).Select(x => new
                        {
                            GroupID = x.Key,
                            Total = x.Sum(i => i.Votos)

                        }).ToList();
                        var Independiente = Lista.Where(x => x.Independiente != 0).ToList();
                        var SumaIndependiente = Independiente.GroupBy(x => x.Independiente).Select(x => new
                        {
                            GroupID = x.Key,
                            Total = x.Sum(i => i.Votos)

                        }).ToList();

                        var filtro = SumaPartido.Concat(SumaIndependiente).ToList();
                        var final = filtro.Concat(SumaCoalicion).OrderByDescending(x => x.Total).ToList();
                        if (final.Count !=0)
                        {
                            decimal diferencia = final.Select(x => x.Total.Value).ElementAt(0) - final.Select(x => x.Total.Value).ElementAt(1);
                            decimal paso2;
                            if (diferencia != 0)
                            {
                                decimal paso1 = (100 * diferencia) / final.Sum(x => x.Total.Value);
                                paso2 = Math.Round(paso1, 4);
                                //ViewBag.VotosDiferencia = diferencia;
                                //ViewBag.PorcentajeDiferencia = paso1;
                            }
                            else
                            {
                                paso2 = 0;
                            }

                            if (paso2 <= 2 && porcentaje <= 20)
                            {
                                foreach (var Cambiar in ca)
                                {
                                    var Recuento = _db.Causales_recuento.FirstOrDefault(x => x.Id == Cambiar.idcau);
                                    Recuento.Recuento_Total = false;
                                }
                                _db.SaveChanges();
                            }

                        }
                                            
                }

           // }
        }

        [HttpGet]
        public IActionResult Create()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.Seccion = _context.Seccion.ListaRecepcionByMunicipio(mun.Id);
            string[] Opcion = new[] { "True", "False" };

            List<SelectListItem> Cargo = new List<SelectListItem>
            {
                new SelectListItem{Text ="Presidente/a de Casilla", Value="1"},
                new SelectListItem{Text ="Secretario/a de Casilla", Value="2"},
                new SelectListItem{Text ="Escrutador/a", Value="3"},
                new SelectListItem{Text ="Otro/a", Value="4"}
            };
            List<SelectListItem> Medio = new List<SelectListItem>
            {
                new SelectListItem{Text ="DAT - Dispositivo de Acopio y Traslado", Value="1"},
                new SelectListItem{Text ="CRyT FIJO - Centro de Recepción y Traslado", Value="2"},
                new SelectListItem{Text ="CRyT ITINERANTE - Centro de Recepción y Traslado", Value="3"},
                new SelectListItem{Text ="DAT - CRyT FIJO", Value="4"},
                new SelectListItem{Text ="DAT - CRyT ITINERANTE", Value="5"}
            };

            List<SelectListItem> Lugar = new List<SelectListItem>
            {
                new SelectListItem{Text ="Consejo Municipal", Value="1"},
                new SelectListItem{Text ="Centro de Recepción y Traslado", Value="2"}
            };
            List<SelectListItem> Entrega = new List<SelectListItem>
            {
                new SelectListItem{Text ="Funcionario/a de Casilla", Value="1"},
                new SelectListItem{Text ="CAE/SE", Value="2"}
            };
            ViewBag.Entrega = Entrega;
            ViewBag.Cargo = Cargo;
            ViewBag.Lugar = Lugar;
            ViewBag.Opcion = Opcion;
            ViewBag.Medio = Medio;

            return View();
        }
        public IActionResult Detalle(int id)
        {
            var Paquete = _context.Recepcion.Get(id);
            string[] Opcion = new[] { "True", "False" };

            List<SelectListItem> Cargo = new List<SelectListItem>
            {
                new SelectListItem{Text ="Presidente/a de Casilla", Value="1"},
                new SelectListItem{Text ="Secretario/a de Casilla", Value="2"},
                new SelectListItem{Text ="Escrutador/a", Value="3"}
            };
            List<SelectListItem> Medio = new List<SelectListItem>
            {
                new SelectListItem{Text ="DAT - Dispositivo de Acopio y Traslado", Value="1"},
                new SelectListItem{Text ="CRyT FIJO - Centro de Recepción y Traslado", Value="2"},
                new SelectListItem{Text ="CRyT ITINERANTE - Centro de Recepción y Traslado", Value="3"},
                new SelectListItem{Text ="DAT - CRyT FIJO", Value="4"},
                new SelectListItem{Text ="DAT - CRyT ITINERANTE", Value="5"}
            };

            List<SelectListItem> Lugar = new List<SelectListItem>
            {
                new SelectListItem{Text ="Consejo Municipal", Value="1"},
                new SelectListItem{Text ="Centro de Recepción y Traslado", Value="2"}
            };
            List<SelectListItem> Entrega = new List<SelectListItem>
            {
                new SelectListItem{Text ="Funcionario/a de Casilla", Value="1"},
                new SelectListItem{Text ="CAE/SE", Value="2"}
            };
            ViewBag.Entrega = Entrega;
            ViewBag.Cargo = Cargo;
            ViewBag.Lugar = Lugar;
            ViewBag.Opcion = Opcion;
            ViewBag.Medio = Medio;
            ViewBag.Paquete = Paquete;

                var Casilla = _context.Casilla.GetAll().Where(x=> x.Id == Paquete.IdCasilla).FirstOrDefault();
                var Seccion = _context.Seccion.GetAll().Where(x => x.Id == Casilla.SeccionId).FirstOrDefault();
                ViewBag.NombreSeccion = Seccion.Seccion;
                ViewBag.Casilla = Casilla.Nombre;
          
            
            return View();            
        }

        public IActionResult ImprimirDetalle(int id)
        {
            var Paquete = _context.Recepcion.Get(id);
            var Casilla = _context.Casilla.Get(Paquete.IdCasilla);
            var Seccion = _context.Seccion.Get(Casilla.SeccionId);
            var Distrito = _context.Distrito.Get(Seccion.DistritoId.Value);
            var Municipio = _context.Municipio.Get(Seccion.MunicipioId.Value);
            DateTime dt = Paquete.HoraRecepcion;
            string[] Palabras = Paquete.Nombre_Entrega.Split(' ');
            int nombres = Palabras.Length;
            int hora = Convert.ToInt32(dt.ToString("HH"));
            string CargoRecibe;
            if(Paquete.Cargo_Entrega == 1)
            {
                CargoRecibe = "Presidente/a";
            }   
            else if(Paquete.Cargo_Entrega == 2)
            {
                CargoRecibe = "Secretario/a";
            }
            else
            {
                CargoRecibe = "Escrutador";
            }


            var Ruta = @"wwwroot\Template\";
            var rutatemplate = Path.Combine(Ruta, @"PruebaPDF.pdf");
            var rutasalida = Path.Combine(Ruta, @"Prueba_PDF.pdf");
            if (System.IO.File.Exists(rutasalida))
            {
                System.IO.File.Delete(rutasalida);
            }
            using (var pdf = new FileStream(rutatemplate, FileMode.Open))
            using (var nuevopdf = new FileStream(rutasalida, FileMode.Create))
            {
                var pdfreader = new PdfReader(pdf);
                var stamper = new PdfStamper(pdfreader, nuevopdf);
                AcroFields fields = stamper.AcroFields;
                fields.SetField("ENTIDAD FEDERATIVA", "NAYARIT");
                fields.SetField("MUNICIPIO", Municipio.Municipio);
                fields.SetField("DISTRITO", Distrito.NoDistrito.ToString());
                fields.SetField("HORA", dt.ToString("hh"));
                fields.SetField("HORACOMPLETA", dt.ToString("hh:mm"));
                fields.SetField("NOMBRECOMPLETO", Paquete.Nombre_Entrega);
                fields.SetField("MINUTO", dt.ToString("mm"));
                fields.SetField("DIA", dt.ToString("dd"));

                fields.SetField("FUNCIONARIO", CargoRecibe);
                fields.SetField("TIPO", Casilla.Nombre);
                fields.SetField("SECCION", Seccion.Seccion);
                switch (nombres)
                {
                    case 1:
                        fields.SetField("NOMBRE", Palabras[0]);
                        break;
                    case 2:
                        fields.SetField("NOMBRE", Palabras[0]+" "+ Palabras[1]);
                        break;
                   
                    case 3:
                        fields.SetField("NOMBRE", Palabras[0] + " " + Palabras[1]);
                        fields.SetField("APELLIDO", Palabras[2]);
                        break;
                    case 4:
                        fields.SetField("NOMBRE", Palabras[0] + " " + Palabras[1]);
                        fields.SetField("APELLIDO", Palabras[2]+" " + Palabras[3]);
                        break;
                    case 5:
                        fields.SetField("NOMBRE", Palabras[0] + " " + Palabras[1]);
                        fields.SetField("APELLIDO", Palabras[2]+" " + Palabras[3] + " " + Palabras[4]);
                        break;
                }
                if (hora < 12)
                {
                    fields.SetField("AM", "Si");
                }
                else
                {
                    fields.SetField("PM", "Si");
                }
                //------------------------------------------//
                if(Paquete.Firma == true)
                {
                    fields.SetField("FIRMASI", "Si");
                }
                else
                {
                    fields.SetField("FIRMANO", "Si");
                }

                //------------------------------------------//
                if (Paquete.Alteracion == true)
                {
                    fields.SetField("ALTERACIONSI", "Si");
                }
                else
                {
                    fields.SetField("ALTERACIONNO", "Si");
                }

                //------------------------------------------//
                if (Paquete.Cinta == true)
                {
                    fields.SetField("CINTASI", "Si");
                }
                else
                {
                    fields.SetField("CINTANO", "Si");
                }
                //------------------------------------------//

                if (Paquete.SobrePrep == true)
                {
                    fields.SetField("SOBRESI", "Si");
                }
                else
                {
                    fields.SetField("SOBRENO", "Si");
                }

                //------------------------------------------//

                if (Paquete.PaqueteElec == true)
                {
                    fields.SetField("BOLSASI", "Si");
                }
                else
                {
                    fields.SetField("BOLSANO", "Si");
                }
                //------------------------------------------//
                if(Paquete.Cargo_Recibe == 1)
                {
                    fields.SetField("ENTREGA1", "Si");
                }
                else if(Paquete.Cargo_Recibe == 2)
                {
                    fields.SetField("ENTREGA2", "Si");
                }
                //------------------------------------------//

                if (Paquete.Lugar_Entrega == 1)
                {
                    fields.SetField("RECIBE1", "Si");
                }
                else if (Paquete.Lugar_Entrega == 2)
                {
                    fields.SetField("RECIBE2", "Si");
                }

                //------------------------------------------//
                //------------------------------------------//


                stamper.FormFlattening = true;
                stamper.Close();
                pdfreader.Close();
            }
            var applicationpdf = "application/pdf";
            var myfile = System.IO.File.ReadAllBytes(rutasalida);
            return new FileContentResult(myfile, applicationpdf);

            //string FilePath = @"Template\";
            //string Nombre = @"PruebaPDF.pdf";
            //string NombreCompleto = FilePath + Nombre;

            //PdfWriter llenado = PdfWriter.GetInstance("",File);
            //    var pdfreader = new PdfReader(AbrirArchivo);
            //    AcroFields fields = pdfreader.AcroFields;

            //    pdfreader.Close();





         
            //T_Recepcion_Paquete_VM Paq = new T_Recepcion_Paquete_VM()
            //{
            //    RecPaquetes = new T_Recepcion_Paquete(),
            //    LSeccion = _context.Seccion.GetListaSeccion(),
            //    LTipoCasilla = _context.TipoCasilla.GetListaTipoCasilla(),
            //};
            //if (id != null)
            //{
            //    Paq.RecPaquetes = _context.Recepcion.Get(id);
            //    var IdcasillaDet = _context.Recepcion.GetAll().Where(x => x.IdRecepcion == id).FirstOrDefault();
            //    var CasillaDet = _context.Casilla.GetAll().Where(x => x.Id == IdcasillaDet.IdCasilla).FirstOrDefault();
            //    var Municipio = _context.Municipio.GetAll().Where(x => x.Id == CasillaDet.MunicipioId).FirstOrDefault();
            //    var Seccion = _context.Seccion.GetAll().Where(x => x.Id == CasillaDet.SeccionId).FirstOrDefault();
            //    var Demarcacion = _context.Demarcacion.GetAll().Where(x => x.Id == Seccion.DemarcacionId).FirstOrDefault();
            //    var Distrito = _context.Distrito.GetAll().Where(x => x.Id == Seccion.DistritoId).FirstOrDefault();
            //    Paq.NombreCas = CasillaDet.Nombre;
            //    Paq.Municipio = Municipio.Municipio;
            //    Paq.NSeccion = Seccion.Seccion;
            //    Paq.Demarcacion = Demarcacion.No_Demarcacion.ToString();
            //    Paq.Distrito = Distrito.NoDistrito.ToString();
            //}
            //return new ViewAsPdf("ImprimirDetalle", Paq)
            //{
            //    PageSize = Rotativa.AspNetCore.Options.Size.Letter,
                
            //};

        }
        public JsonResult CargarCauGob()
        {

            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lst = _context.Causales.GetListaCausales(mun.Id, 1, 0);


            return Json(new { data = lst });
        }

        public JsonResult CargarCauGobAdmin(int id)
        {
            var lst = _context.Causales.GetListaCausales(id, 1, 0);
            return Json(new { data = lst });
        }

        public JsonResult CargarCauPysAdmin(int id)
        {
            var lst = _context.Causales.GetListaCausales(id, 2, 0);
            return Json(new { data = lst });
        }

        public JsonResult CargarCauDipAdmin(int id)
        {
            var lst = _context.Causales.GetListaCausales(0, 3, id);
            return Json(new { data = lst });
        }

        public JsonResult CargarCauRegAdmin(int id, int ids)
        {
            var lst = _context.Causales.GetListaCausales(id, 4, ids);
            return Json(new { data = lst });
        }

        public JsonResult CargarCauPys()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lst = _context.Causales.GetListaCausales(mun.Id, 2, 0);


            return Json(new { data = lst });
        }
        public JsonResult CargarCauDip(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lst = _context.Causales.GetListaCausales(mun.Id, 3, id);
            return Json(new { data = lst });
        }
        public JsonResult CargarCauReg(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lst = _context.Causales.GetListaCausales(mun.Id, 4, id);
            return Json(new { data = lst });
            
        }

        [HttpPost]
        public IActionResult SubsanarCausal(int id)
        {

            try
            {
                Historial(id);
                int eleccion = 0;
                int casdet = 0;
                var cles = _context.Causales.GetAll().Where(x => x.Id == id).FirstOrDefault();
                cles.Causal1 = false;
                cles.Causal2 = false;
                cles.Causal3 = false;
                cles.Causal4 = false;
                cles.Causal5 = false;
                cles.Causal6 = false;
                cles.Causal7 = false;
                cles.Causal8 = false;
                cles.Causal9 = false;
                cles.Causal10 = false;
                cles.Causal11 = false;
                cles.Total_Causales = 0;
                eleccion = cles.TipoEleccionId;
                casdet = cles.CasillaId;
                var casilladet = _context.Casilla.Get(casdet);
                var seccion = _context.Seccion.Get(casilladet.SeccionId);
                _db.SaveChanges();
                VerificarRecuentoCausal();
                return Json(new { success = true, mensaje = "Causales Subsanadas" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        public void Historial(int causal)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var cles = _context.Causales.GetAll().Where(x => x.Id == causal).FirstOrDefault();
            var his = new T_HistorialSubsanar();
            his.IdCausal = cles.Id;
            his.CasillaId = cles.CasillaId;
            his.TipoEleccionId = cles.TipoEleccionId;
            his.Causal1 = cles.Causal1;
            his.Causal2 = cles.Causal2;
            his.Causal3 = cles.Causal3;
            his.Causal4 = cles.Causal4;
            his.Causal5 = cles.Causal5;
            his.Causal6 = cles.Causal6;
            his.Causal7 = cles.Causal7;
            his.Causal8 = cles.Causal8;
            his.Causal9 = cles.Causal9;
            his.Causal10 = cles.Causal10;
            his.Causal11 = cles.Causal11;
            his.Total_Causales = cles.Total_Causales;
            his.Recuento_Total = cles.Recuento_Total;
            his.RP = cles.RP;
            his.UsuarioRegistro = usuario.Id;
            his.FechaHora = DateTime.Now;
            _context.HistorialSubsanar.Add(his);
            _context.Save();
        }

        [HttpPost]
        public IActionResult PuntosRecuentos(long[][] data)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            int eleccion = Convert.ToInt32(data[0][3]);
            int DD = 0;
            int TotEjercicio;
            
            if(eleccion == 3 )
            {
                DD = Convert.ToInt32(data[0][6]);
                var Ejercicios = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, eleccion, DD);
                TotEjercicio = Ejercicios.Count();
            }
            else if(eleccion == 4)
            {
                DD = Convert.ToInt32(data[0][5]);
                var Ejercicios = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, eleccion, DD);
                TotEjercicio = Ejercicios.Count();
            }
            else
            {
                var Ejercicios = _context.Puntos_Recuento.ObtenerEjercicos(mun.Id, eleccion, DD);
                TotEjercicio = Ejercicios.Count();
            }
                        
            T_Puntos_Recuento pr;
            int z = data.Count();
            for (int i = 0; i < z; i++) {
                pr = new T_Puntos_Recuento();
                pr.GrupoTrabajo = Convert.ToInt32(data[i][0]);
                pr.PuntoRecu = Convert.ToInt32(data[i][1]);
                pr.CasillasTot = Convert.ToInt32(data[i][2]);
                pr.Eleccion = Convert.ToInt32(data[i][3]);
                pr.Tipo = Convert.ToInt32(data[i][4]);
                pr.Demarcacion = Convert.ToInt32(data[i][5]);
                pr.Distrito = Convert.ToInt32(data[i][6]);
                pr.NumEjercicio = TotEjercicio + 1;
                pr.Municipio = mun.Id;
                _db.Add(pr);
            }
            _db.SaveChanges();

            return Json(new { success = true});
        }
    }
}

