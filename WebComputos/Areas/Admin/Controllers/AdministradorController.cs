using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using WebComputos.AccesoDatos.Data;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using WebComputos.Models.ViewModels;

namespace WebComputos.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AdministradorController : Controller
    {
        private readonly IContenedorTrabajo _context;
        private ApplicationDbContext _db;
        private readonly UserManager<T_Usuario> _UserManager;
        
       public AdministradorController(IContenedorTrabajo context, ApplicationDbContext db,
            UserManager<T_Usuario> UserManager)
        {
            _context = context;
            _db = db;
            _UserManager = UserManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HistorialSubsanar()
        {
            return View();
        }

        public IActionResult HistoricoSolicitudes()
        {
            return View();
        }

        public IActionResult HistorialModificaciones()
        {
            return View();
        }

        public IActionResult Paquetes()
        {
            return View();
        }
        public JsonResult CargarPaquetesModificacion()
        {
            var c = _context.Recepcion.GetListaPaquetesModificacion();
            return Json(new { data = c });
        }

        public JsonResult CargarPaquetesHistorial()
        {
            var c = _context.Recepcion.GetListaPaquetesHistorial();
            return Json(new { data = c });
        }

        public IActionResult Complementaria()
        {
            return View();
        }

        public JsonResult CargarComplementeriaModificacion()
        {
            var c = _context.Acta.GetListaComplementariaModificacion();
            return Json(new { data = c });
        }

        public JsonResult CargarComplementariaHistorial()
        {
            var c = _context.Acta.GetListaComplementariaHistorial();
            return Json(new { data = c });
        }

        public IActionResult Votos()
        {
            return View();
        }

        public JsonResult CargarVotosModificacion()
        {
            var c = _context.Acta.GetListaVotosModificacion();
            return Json(new { data = c });
        }

        public JsonResult CargarVotosHistorial()
        {
            var c = _context.Acta.GetListaVotosHistorial();
            return Json(new { data = c });
        }


        public JsonResult CargarHistorial()
        {
            var c = _context.HistorialSubsanar.Historial();
            return Json(new { data = c });
        }
        public JsonResult CargarSolicitudes()
        {
            var c = _context.HistorialSubsanar.Solicitudes();
            return Json(new { data = c });
        }

        public JsonResult CargarHistorico()
        {
            var c = _context.HistorialSubsanar.Historico();
            return Json(new { data = c });
        }

        [HttpGet]
        public IActionResult VistaHistoria(int id)
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
            ViewBag.Usuario = Usuario.Nombres + " " + Usuario.Apellido_Paterno + " " + Usuario.Apellido_Materno;
            ViewBag.Municipio = Municipio.Municipio;
            ViewBag.Fecha = resultado.FechaHora.ToString("dd / MM / yyyy");
            ViewBag.Hora = resultado.FechaHora.ToString("HH : mm");
            return View();
        }

        [HttpPost]
        public IActionResult AceptarSolicitud(int id)
        {
            try
            {
                var registro = _context.HistorialSubsanar.Get(id);
                var causal = _context.Causales.Get(registro.IdCausal);
                T_HistoricoRestablecer historico = new T_HistoricoRestablecer();
                //var historico = _context
                causal.Causal1 = registro.Causal1;
                causal.Causal2 = registro.Causal2;
                causal.Causal3 = registro.Causal3;
                causal.Causal4 = registro.Causal4;
                causal.Causal5 = registro.Causal5;
                causal.Causal6 = registro.Causal6;
                causal.Causal7 = registro.Causal7;
                causal.Causal8 = registro.Causal8;
                causal.Causal9 = registro.Causal9;
                causal.Causal10 = registro.Causal10;
                causal.Causal11 = registro.Causal11;
                causal.Total_Causales = registro.Total_Causales;
                causal.Recuento_Total = registro.Recuento_Total;
                historico.IdHistorial = registro.Id;
                historico.IdCausal = registro.IdCausal;
                historico.CasillaId = registro.CasillaId;
                historico.TipoEleccionId = registro.TipoEleccionId;
                historico.Causal1 = registro.Causal1;
                historico.Causal2 = registro.Causal2;
                historico.Causal3 = registro.Causal3;
                historico.Causal4 = registro.Causal4;
                historico.Causal5 = registro.Causal5;
                historico.Causal6 = registro.Causal6;
                historico.Causal7 = registro.Causal7;
                historico.Causal8 = registro.Causal8;
                historico.Causal9 = registro.Causal9;
                historico.Causal10 = registro.Causal10;
                historico.Causal11 = registro.Causal11;
                historico.Total_Causales = registro.Total_Causales;
                historico.Recuento_Total = registro.Recuento_Total;
                historico.RP = registro.RP;
                historico.UsuarioRegistro = registro.UsuarioRegistro;
                historico.FechaHora = registro.FechaHora;
                historico.FechaHoraRespuesta = DateTime.Now;
                historico.Estatus = true;
                _context.HistoricoRestablecer.Add(historico);
                registro.Eliminar = true;
                registro.Solicitud = 2;
                _db.SaveChanges();
                return Json(new { success = true, mensaje = "Solicitud Aceptada" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CancelarSolicitud(int id)
        {
            try
            {
                var registro = _context.HistorialSubsanar.Get(id);
                var causal = _context.Causales.Get(registro.IdCausal);
                T_HistoricoRestablecer historico = new T_HistoricoRestablecer();
                //var historico = _context
                registro.Solicitud = 0;
                historico.IdHistorial = registro.Id;
                historico.IdCausal = registro.IdCausal;
                historico.CasillaId = registro.CasillaId;
                historico.TipoEleccionId = registro.TipoEleccionId;
                historico.Causal1 = registro.Causal1;
                historico.Causal2 = registro.Causal2;
                historico.Causal3 = registro.Causal3;
                historico.Causal4 = registro.Causal4;
                historico.Causal5 = registro.Causal5;
                historico.Causal6 = registro.Causal6;
                historico.Causal7 = registro.Causal7;
                historico.Causal8 = registro.Causal8;
                historico.Causal9 = registro.Causal9;
                historico.Causal10 = registro.Causal10;
                historico.Causal11 = registro.Causal11;
                historico.Total_Causales = registro.Total_Causales;
                historico.Recuento_Total = registro.Recuento_Total;
                historico.RP = registro.RP;
                historico.UsuarioRegistro = registro.UsuarioRegistro;
                historico.FechaHora = registro.FechaHora;
                historico.FechaHoraRespuesta = DateTime.Now;
                historico.Estatus = false;
                _context.HistoricoRestablecer.Add(historico);
                _db.SaveChanges();
                return Json(new { success = true, mensaje = "Solicitud Rechazada" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }


        [HttpPost]
        public IActionResult RestaurarCausal(int id)
        {
            try
            {
                var registro = _context.HistorialSubsanar.Get(id);
                var causal = _context.Causales.Get(registro.IdCausal);
                causal.Causal1 = registro.Causal1;
                causal.Causal2 = registro.Causal2;
                causal.Causal3 = registro.Causal3;
                causal.Causal4 = registro.Causal4;
                causal.Causal5 = registro.Causal5;
                causal.Causal6 = registro.Causal6;
                causal.Causal7 = registro.Causal7;
                causal.Causal8 = registro.Causal8;
                causal.Causal9 = registro.Causal9;
                causal.Causal10 = registro.Causal10;
                causal.Causal11 = registro.Causal11;
                causal.Total_Causales = registro.Total_Causales;
                causal.Recuento_Total = registro.Recuento_Total;
                registro.Eliminar = true;
                _db.SaveChanges();
                return Json(new { success = true, mensaje = "Causales Restablecidas" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult RestablecerPaquete(int idPaquete, int idHistorial)
        {
            try
            {
                var Paquete =_context.Recepcion.Get(idPaquete);
                var Casilla = Paquete.IdCasilla;
                _context.Recepcion.EliminarPaquetes(Casilla);
                var historial =_context.HistorialModificacion.Get(idHistorial);
                historial.Estatus = 1;
                historial.FechaAprobacion = DateTime.Now;
                _context.Recepcion.Remove(idPaquete);
                _context.Save();
                return Json(new { success = true, mensaje = "Paquete restablecido" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }


        [HttpPost]
        public IActionResult CancelarSolicitudPaquete(int idPaquete, int idHistorial)
        {
            try
            {
                var Paquete = _context.Recepcion.Get(idPaquete);
                Paquete.Solicitud = 0;
                var historial = _context.HistorialModificacion.Get(idHistorial);
                historial.Estatus = 2;
                historial.FechaAprobacion = DateTime.Now;
                _context.Save();
                return Json(new { success = true, mensaje = "Solicitud Cancelada" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        public IActionResult ComplementariaGob()
        {
            return View();
        }
        public JsonResult CargarReg(int Ele)
        {
            var lstda = _context.Acta.CargarTablaComplementaria(Ele);
            return Json(new { data = lstda });
        }

        [HttpPost]
        public IActionResult RestablecerComplementaria(int idComplementaria, int idHistorial)
        {
            try
            {
                var Acta = _context.Acta.Get(idComplementaria);
                var CasillaDetalle = Acta.IdActaDetalle;
                var historial = _context.HistorialModificacion.Get(idHistorial);
                historial.Estatus = 1;
                historial.FechaAprobacion = DateTime.Now;
                _context.Acta.EliminarComplementaria(CasillaDetalle,historial.TipoEleccion);
                _context.Acta.Remove(idComplementaria);
                _context.Save();
                return Json(new { success = true, mensaje = "Información complementaria restablecida" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CancelarSolicitudComplementaria(int idComplementaria, int idHistorial)
        {
            try
            {
                var complementaria = _context.Acta.Get(idComplementaria);
                complementaria.Solicitud = 0;
                var historial = _context.HistorialModificacion.Get(idHistorial);
                historial.Estatus = 2;
                historial.FechaAprobacion = DateTime.Now;
                _context.Save();
                return Json(new { success = true, mensaje = "Solicitud Cancelada" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult RestablecerVotos(int idVotos, int idHistorial)
        {
            try
            {
                var Acta = _context.Votos_Actas.Get(idVotos);
                var CasillaDetalle = Acta.IdActaDetalle;
                var historial = _context.HistorialModificacion.Get(idHistorial);
                historial.Estatus = 1;
                historial.FechaAprobacion = DateTime.Now;
                _context.Votos_Actas.EliminarVotos(CasillaDetalle, historial.TipoEleccion);
                _context.Votos_Actas.Remove(idVotos);
                _context.Save();
                return Json(new { success = true, mensaje = "Registro de votos restablecida" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CancelarSolicitudVotos(int idVotos, int idHistorial)
        {
            try
            {
                var votos = _context.Votos_Actas.Get(idVotos);
                votos.Solicitud = 0;
                var historial = _context.HistorialModificacion.Get(idHistorial);
                historial.Estatus = 2;
                historial.FechaAprobacion = DateTime.Now;
                _context.Save();
                return Json(new { success = true, mensaje = "Solicitud Cancelada" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        public IActionResult ComplementariaPys()
        {
            return View();
        }
        public IActionResult ComplementariaDip()
        {
            return View();
        }
        public IActionResult ComplementariaReg()
        {
            return View();
        }
        public IActionResult VotosGob()
        {
            return View();
        }
        public IActionResult VotosPys()
        {
            return View();
        }
        public IActionResult VotosDip()
        {
            return View();
        }
        public IActionResult VotosReg()
        {
            return View();
        }
        public JsonResult CargaTabVotos(int Ele)
        {
            var a = _context.Votos_Actas.TablasVotos(Ele);
            return Json(new { data = a });
        }

        [HttpGet]
        public IActionResult ImprimirCausal()
        {
            return new ViewAsPdf("ImprimirCausal")
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
            };
        }


        public IActionResult CausalesGobernador()
        {
            //var Id = _UserManager.GetUserId(User);
            //var usuario = _db.Usuarios.Find(Id);
            //var oficina = _db.Oficinas.Find(usuario.OficinaId);
            //var mun = _db.Municipios.Find(oficina.MunicipioId);
            var ca = _context.Causales.GetListaCausales(0, 1, 0);
            decimal NumSeccion = _context.Casilla.GetAll().ToList().Count();
            decimal total = ca.Count();
            decimal completas = _context.Causales.CausalesCompletas(0, 1, 0).Count();
            decimal s = (100 * completas) / NumSeccion;
            decimal porcentajecompletas = Math.Round(s, 4);
            decimal complemento = _context.Causales.CausalesComplemento(0, 1, 0).Count();
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

            }

            /*-----------------------------------------------*/
            //var Lista = _context.Resultados_Actas.SegundoLugarEleccion(0, 1, 0);
            var final = _context.Causales.SegundoLugarCausal(0, 1, 0);
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
        public IActionResult CausalesDiputado()
        {
            ViewBag.ListaDistrito = _context.Distrito.GetListaDistrito();
            return View();
        }

        [HttpGet]
        public IActionResult ImprimirGobernador(int id)
        {

            var ConCausal = _context.Recepcion.ConCausales(0, 1, id);
            var SinCausal = _context.Recepcion.SinCausales(0, 1, id);
            ReporteCausalesVM RCVM = new ReporteCausalesVM()
            {
                CCausal = ConCausal.OrderBy(x => x.NoSeccionCC).ToList(),
                SCausal = SinCausal.OrderBy(x => x.NoSeccionSC).ToList()
            };

            return new ViewAsPdf("ImprimirGobernador", RCVM)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
            };
        }

        public JsonResult CargarCauGob()
        {

            var lst = _context.Causales.GetListaCausales(0, 1, 0);


            return Json(new { data = lst });
        }

        public JsonResult CargarCauDipAdmin(int id)
        {
            var lst = _context.Causales.GetListaCausales(0, 3, id);
            return Json(new { data = lst });
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

        [HttpPost]
        public IActionResult SubsanarCausal(int id)
        {
            try
            {
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
            //if (eleccion == 1)
            //{
            //    return RedirectToAction("CausalesGob");
            //}
            //else if (eleccion == 2)
            //{
            //    return RedirectToAction("CausalesPys");
            //}
            //else if (eleccion == 3)
            //{
            //    return RedirectToAction("CausalesDipu", new { id = seccion.DistritoId });
            //}
            //else if (eleccion == 4)
            //{
            //    return RedirectToAction("CausalesRegi", new { id = seccion.DemarcacionId });
            //}
            //return View();
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
            if (finalGob.Count() != 0)
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
            if (finalPys.Count != 0)
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

            }

            // }
        }
    }
}