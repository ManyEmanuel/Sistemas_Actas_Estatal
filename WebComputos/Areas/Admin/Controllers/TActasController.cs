using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebComputos.AccesoDatos.Data;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using WebComputos.Models.ViewModels;

namespace WebComputos.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class TActasController : Controller
    {
        private readonly IContenedorTrabajo _context;
        private ApplicationDbContext _db;
        private readonly UserManager<T_Usuario> _UserManager;

        public TActasController(IContenedorTrabajo context, ApplicationDbContext db, UserManager<T_Usuario> UserManager)
        {
            _context = context;
            _db = db;
            _UserManager = UserManager;
        }
        [HttpGet]
        public IActionResult Entrega()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.Municipio = mun.Municipio;
            return View();
        }

        [HttpGet]
        public IActionResult EntregaDetalle(int id)
        {            
            var mun = _db.Municipios.Find(id);
            ViewBag.IdMun = id;
            ViewBag.Municipio = mun.Municipio;
            return View();
        }


        [HttpGet]
        public IActionResult Index()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            ViewBag.Municipio = mun.Municipio;
            return View();
        }

        public IActionResult IndexGob()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            ViewBag.Municipio = mun.Municipio;
            return View();
        }

        public IActionResult IndexAyu()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            ViewBag.Municipio = mun.Municipio;
            return View();
        }

        public IActionResult IndexDip()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            //var Distrito = _db.Distritos.Find(id);
            //ViewBag.NoDistrito = Distrito.NoDistrito;
            //ViewBag.IdDistrito = Distrito.Id;
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            ViewBag.Municipio = mun.Municipio;
            return View();
        }

        public IActionResult IndexDipAdmin()
        {
            ViewBag.Distrito = _context.Distrito.GetListaDistrito();
            
            return View();
        }

        public IActionResult IndexRegAdmin()
        {
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            return View();
        }

        public IActionResult IndexDipRP(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            ViewBag.Municipio = mun.Municipio;
            return View();
        }

        public IActionResult IndexRegRP(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            ViewBag.Municipio = mun.Municipio;
            return View();
        }

        [HttpPost]
        public IActionResult SolicitaModificacion(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            try
            {
                var registro = _context.Acta.Get(id);
                var detalle = _context.ActasDetalles.GetFirstOrDefault(x => x.IdActaDetalle == registro.IdActaDetalle);
                registro.Solicitud = 1;
                T_HistorialModificaciones Historial = new T_HistorialModificaciones();
                Historial.IdCasilla = detalle.IdCasilla;
                Historial.Concepto = 1;
                Historial.TipoEleccion = detalle.IdEleccion;
                Historial.Estatus = 0;
                Historial.FechaSolicitud = DateTime.Now;
                Historial.UsuarioRegistro = usuario.Id;
                Historial.Complementaria = registro.IdActa;
                _context.HistorialModificacion.Add(Historial);
                _db.SaveChanges();
                return Json(new { success = true, mensaje = "Solicitud Generada" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        public IActionResult IndexReg()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            //var Demarcacion = _db.Demarcaciones.Find(id);
            //ViewBag.NoDemarcacion = Demarcacion.Nombre;
            //ViewBag.IdDemarcacion = Demarcacion.Id;
            ViewBag.ListaMunicipio = _context.Municipio.GetListaMunicipio();
            ViewBag.Municipio = mun.Municipio;
            return View();
        }

        [HttpGet]
        public IActionResult AvancEstatal()
        {

            return View();
        }
        public IActionResult Create()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.Gubernatura = _context.Acta.ListaSeccionInfoComByMunicipioGob(mun.Id);
            ViewBag.Ayuntamiento = _context.Acta.ListaSeccionInfoComByMunicipioPys(mun.Id);
            ViewBag.Diputacion = _context.Acta.ListaSeccionInfoComByMunicipioDip(mun.Id,0);
            ViewBag.Regiduria = _context.Acta.ListaSeccionInfoComByMunicipioReg(mun.Id,0);
            ViewBag.DiputacionRP = _context.Acta.ListaSeccionInfoComByMunicipioDipRP(mun.Id);
            ViewBag.RegiduriaRP = _context.Acta.ListaSeccionInfoComByMunicipioRegRP(mun.Id);
            ViewBag.ComprobarDiputacionRP = _context.Acta.ComprobarDipRP(mun.Id);
            ViewBag.ComprobarRegiduriaRP = _context.Acta.ComprobarRegRP(mun.Id);
            ViewBag.Estatus = _context.EstatusActa.GetEstatusActa();

            return View();
        }

        public IActionResult CreateDipRP()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.DiputacionRP = _context.Acta.ListaSeccionInfoComByMunicipioDipRP(mun.Id);
            ViewBag.Estatus = _context.EstatusActa.GetEstatusActa();

            return View();
        }
        public IActionResult CreateRegRP()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.RegiduriaRP = _context.Acta.ListaSeccionInfoComByMunicipioRegRP(mun.Id);
            ViewBag.Estatus = _context.EstatusActa.GetEstatusActa();

            return View();
        }
        public IActionResult CreateGob()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.Gubernatura = _context.Acta.ListaSeccionInfoComByMunicipioGob(mun.Id);
            ViewBag.Estatus = _context.EstatusActa.GetEstatusActa();
            return View();
        }
        public IActionResult CreateAyu()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            ViewBag.Ayuntamiento = _context.Acta.ListaSeccionInfoComByMunicipioPys(mun.Id);
            ViewBag.Estatus = _context.EstatusActa.GetEstatusActa();
            return View();
        }
        public IActionResult CreateDip()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            //var dis = _db.Distritos.Find(id);
            //ViewBag.Distrito = dis.NoDistrito;
            ViewBag.Diputacion = _context.Acta.ListaSeccionInfoComByMunicipioDip(mun.Id, 0);
            ViewBag.Estatus = _context.EstatusActa.GetEstatusActa();
            return View();
        }
        public IActionResult CreateReg()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            //var dis = _db.Demarcaciones.Find(id);
            //ViewBag.Demarcacion = dis.Nombre;
            ViewBag.Regiduria = _context.Acta.ListaSeccionInfoComByMunicipioReg(mun.Id, 0);
            ViewBag.Estatus = _context.EstatusActa.GetEstatusActa();
            return View();
        }

        [HttpPost]
        public IActionResult Create(T_Acta item)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            int eleccion;
            if (ModelState.IsValid)
            {              
                
                item.FechaRegistro = DateTime.Now;
                item.UsuarioRegistro = usuario.Id;
                _context.Acta.Add(item);
                _context.Save();              
                var capturado = _context.ActasDetalles.GetAll().Where(x => x.IdActaDetalle == item.IdActaDetalle).FirstOrDefault();
                capturado.CapturadoComplemento = true;
                eleccion = capturado.IdEleccion;
                _db.SaveChanges();
                _context.Acta.RegistroCausal(item.IdActaDetalle, item.Estatus);
                if(eleccion != 1 && eleccion != 3) { 
                VerificarRecuento(eleccion);
                }
                return Json(new { success = true, mensaje = "Información Complementaria de Acta, registrada con éxito" });
            }
            return Json(new { success = false, mensaje = "Error al registrar la información Complementaria del Acta, intentelo de nuevo" });
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
                }else if(Eleccion == 4)
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
        public IActionResult CreateRP(T_Acta_RP item)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            if (ModelState.IsValid)
            {

                item.FechaRegistro = DateTime.Now;
                item.UsuarioRegistro = usuario.Id;
                _db.Acta_RP.Add(item);
                _db.SaveChanges();
                var capturado = _db.Acta_Detalle_RP.Where(x => x.IdActaDetalle == item.IdActaDetalle).FirstOrDefault();
                capturado.CapturadoComplemento = true;
                _db.SaveChanges();
                _context.Acta.RegistroCausalRP(item.IdActaDetalle, item.Estatus);
                return Json(new { success = true, mensaje = "Información Complementaria de Acta, registrada con éxito" });
            }
            return Json(new { success = false, mensaje = "Error al registrar la información Complementaria del Acta, intentelo de nuevo" });
        }

        public JsonResult CargarGob(int ide, int ids)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lstda = _context.Acta.CargarCombo(ids, mun.Id, ide);          
            return Json(lstda);
        }

        public JsonResult CargarRP(int ide, int ids)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lstda = _context.Acta.CargarComboRP(ids, mun.Id, ide);
            return Json(lstda);
        }

        public JsonResult CargarReg(int Ele, int DD)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lstda = _context.Acta.CargarTabla(mun.Id,Ele,DD);
            return Json(new { data = lstda });
        }

        public JsonResult CargarRegAdmin(int Mun, int Ele, int DD)
        {
            var lstda = _context.Acta.CargarTabla(Mun, Ele, DD);
            return Json(new { data = lstda });
        }

        public JsonResult CargarRegRP(int Ele)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lstda = _context.Actas_RP.CargarTablaRP(mun.Id, Ele);
            return Json(new { data = lstda });
        }

        public JsonResult CargarRegAdmin(int id)
        {
            var lstda = _context.Acta.CargarTabla(id,0,0);
            return Json(new { data = lstda });
        }

        public JsonResult CargarDoc()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lstda = _context.Acta.ListaDocumentosEntregados(mun.Id);
            return Json(new { data = lstda });
        }

        public JsonResult CargarDocDet(int id)
        {
            var lstda = _context.Acta.ListaDocumentosEntregados(id);
            return Json(new { data = lstda });
        }

        public JsonResult CargarAvanceEstatal()
        {
            var lstda = _context.Acta.ListaAvanceEstatal();
            return Json(new { data = lstda });
        }

        public JsonResult AvanceDocumentos()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var lstda = _context.Acta.GetPorcentajeDocumentos(mun.Id);
            return Json(new { data = lstda });
        }

        public JsonResult AvanceDocumentosDet(int id)
        {
            var lstda = _context.Acta.GetPorcentajeDocumentos(id);
            return Json(new { data = lstda });
        }

        public JsonResult AvanceDocumentosEstatal()
        {
            var lstda = _context.Acta.GetPorcentajeDocumentos(0);
            return Json(new { data = lstda });
        }

        [HttpGet]
        public IActionResult Detalle(int id)
        {
            T_Actas_VM Act = new T_Actas_VM()
            {
                Actas = new T_Acta(),
                LEstatusActa = _context.EstatusActa.GetEstatusActa()
            };
            if(id != null)
            {
                Act.Actas = _context.Acta.Get(id);
                var Id = _UserManager.GetUserId(User);
                var usuario = _db.Usuarios.Find(Id);
                var oficina = _db.Oficinas.Find(usuario.OficinaId);
                var mun = _db.Municipios.Find(oficina.MunicipioId);
                var a = _context.ActasDetalles.Get(Act.Actas.IdActaDetalle);
                var e = _context.TipoEleccion.Get(a.IdEleccion);
                var c = _context.Casilla.Get(a.IdCasilla);
                var s = _context.Seccion.Get(c.SeccionId);
                ViewBag.Seccion = s.Seccion;
                ViewBag.Casilla = c.Nombre;
                ViewBag.Eleccion = e.Nombre;
                ViewBag.Municipio = mun.Municipio;
            }

            return View(Act);
        }

        public IActionResult DetalleRP(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.Usuarios.Find(Id);
            var oficina = _db.Oficinas.Find(usuario.OficinaId);
            var mun = _db.Municipios.Find(oficina.MunicipioId);
            var Detalle = _context.Actas_RP.Get(id);
            var a = _context.Actas_Detalle_RP.Get(Detalle.IdActaDetalle);
            var e = _context.TipoEleccion.Get(a.IdEleccion);
            var c = _context.Casilla.Get(a.IdCasilla);
            var s = _context.Seccion.Get(c.SeccionId);
            ViewBag.Seccion = s.Seccion;
            ViewBag.Casilla = c.Nombre;
            ViewBag.Eleccion = e.Nombre;
            ViewBag.Municipio = mun.Municipio;
            ViewBag.ActaRP = Detalle;
            ViewBag.Estatus = _context.EstatusActa.GetEstatusActa();

            return View();
        }

    }
}
