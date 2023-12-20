using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rotativa.AspNetCore;
using WebComputos.AccesoDatos.Data;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using WebComputos.Models.ViewModels;

namespace WebComputos.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class UbicaController : Controller
    {
        private readonly IContenedorTrabajo _context;
        private ApplicationDbContext _db;
        private readonly UserManager<T_Usuario> _UserManager;

        public UbicaController(IContenedorTrabajo context, ApplicationDbContext db, UserManager<T_Usuario> UserManager)
        {
            _context = context;
            _db = db;
            _UserManager = UserManager;
        }
        public IActionResult Index()
        {
            UbicaCasillaVM ubvm = new UbicaCasillaVM
            {
                Municipio = _context.Municipio.GetListaMunicipio(),
                Distrito = _context.Distrito.GetListaDistrito(),
                Demarcacion = _context.Demarcacion.GetListaDemarcacion(),
                Seccion = _context.Seccion.GetListaSeccion()

            };
            return View(ubvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Reporte(UbicaCasillaVM UbicaCasilla)
        {
            string NomReporte = "";
            string Municipio = "";
            string Distrito = "";
            string Demarcacion = "";
            string Seccion = "";
            int Basica = 0;
            int Contigua = 0;
            int Extra = 0;
            int ExtraCon = 0;
            int Especial = 0;
            int Total = 0;
            int valor = UbicaCasilla.TipoBusqueda;
            int valor2 = UbicaCasilla.PrimerNum;
            int valor3 = UbicaCasilla.SegundoNum;

            List<ReporteUbica> rep = new List<ReporteUbica>();
            switch (valor)
            {
                case 1:
                    var g = _context.UbicaCasilla.GetListaUbica(1,0);
                    NomReporte = "General";
                    Total = g.Count();
                    Basica = g.Where(x => x.NoCas == 1).Count();
                    Contigua = g.Where(x => x.NoCas == 2).Count();
                    Extra = g.Where(x => x.NoCas == 3 && x.TipoCasilla.Split(' ').Length <= 2).Count();
                    ExtraCon = g.Where(x => x.NoCas == 3 && x.TipoCasilla.Split(' ').Length > 2).Count();
                    Especial = g.Where(x => x.NoCas == 4).Count();
                    rep = g.ToList();
                    break;
                
                case 2:
                    var m = _context.UbicaCasilla.GetListaUbica(2,valor2);
                    NomReporte = "Municipio";
                    Total = m.Count();
                    Basica = m.Where(x => x.NoCas == 1).Count();
                    Contigua = m.Where(x => x.NoCas == 2).Count();
                    Extra = m.Where(x => x.NoCas == 3 && x.TipoCasilla.Split(' ').Length <= 2).Count();
                    ExtraCon =  m.Where(x => x.NoCas == 3 && x.TipoCasilla.Split(' ').Length > 2).Count();
                    Especial = m.Where(x => x.NoCas == 4).Count();
                    rep = m.ToList();
                    var mun = _db.Municipios.Find(valor2);
                    Municipio = mun.Municipio;                  
                    break;

                case 3:
                    var d = _context.UbicaCasilla.GetListaUbica(3,valor2);
                    NomReporte = "Distrito";
                    Total = d.Count();
                    Basica = d.Where(x => x.NoCas == 1).Count();
                    Contigua = d.Where(x => x.NoCas == 2).Count();
                    Extra = d.Where(x => x.NoCas == 3 && x.TipoCasilla.Split(' ').Length <= 2).Count();
                    ExtraCon = d.Where(x => x.NoCas == 3 && x.TipoCasilla.Split(' ').Length > 2).Count();
                    Especial = d.Where(x => x.NoCas == 4).Count();
                    var dis = _db.Distritos.Find(valor2);
                    Distrito = dis.NoDistrito.ToString();
                    rep = d.ToList();
                    break;
                case 4:
                    var e = _context.UbicaCasilla.GetListaUbica(4,valor3);
                    NomReporte = "Demarcacion";
                    Total = e.Count();
                    Basica = e.Where(x => x.NoCas == 1).Count();
                    Contigua = e.Where(x => x.NoCas == 2).Count();
                    Extra = e.Where(x => x.NoCas == 3 && x.TipoCasilla.Split(' ').Length <= 2).Count();
                    ExtraCon = e.Where(x => x.NoCas == 3 && x.TipoCasilla.Split(' ').Length > 2).Count();
                    Especial = e.Where(x => x.NoCas == 4).Count();
                    rep = e.ToList();
                    var mun1 = _db.Municipios.Find(valor2);
                    Municipio = mun1.Municipio;
                    var der = _db.Demarcaciones.Find(valor3);
                    Demarcacion = der.Nombre;
                    
                    
                    break;

                case 5:
                    var s = _context.UbicaCasilla.GetListaUbica(5,valor3);
                    NomReporte = "Seccion";
                    Total = s.Count();
                    Basica = s.Where(x => x.NoCas == 1).Count();
                    Contigua = s.Where(x => x.NoCas == 2).Count();
                    Extra = s.Where(x => x.NoCas == 3 && x.TipoCasilla.Split(' ').Length <= 2).Count();
                    ExtraCon = s.Where(x => x.NoCas == 3 && x.TipoCasilla.Split(' ').Length > 2).Count();
                    Especial = s.Where(x => x.NoCas == 4).Count();
                    rep = s.ToList();
                    var mun2 = _db.Municipios.Find(valor2);
                    Municipio = mun2.Municipio;
                    var sec = _db.Secciones.Find(valor3);
                    Seccion = sec.Seccion;
                    break;

            }
            UbicaCasillaVM uc = new UbicaCasillaVM() {
                ReporteCasilla = rep.OrderBy(x => x.NoSeccion).ToList(),
                Mun = Municipio,
                Dis = Distrito,
                Dem = Demarcacion,
                Secc = Seccion,
                Basica = Basica,
                Contigua = Contigua,
                Extra = Extra,
                ExtraCon = ExtraCon,
                Especial = Especial,
                Total = Total,
                NombreMun = _context.Municipio.GetAll().ToList()
                
            };
            return new ViewAsPdf(NomReporte, uc) {
                PageSize = Rotativa.AspNetCore.Options.Size.Legal,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
               
                
                
            };

        }

        public JsonResult CargarDem (int id)
        {
            List<T_Demarcacion> res = new List<T_Demarcacion>();
            res = _context.Demarcacion.GetAll().Where(x => x.MunicipioId == id).ToList();
            return Json(new SelectList(res,"Id","Nombre"));            
        }

        public JsonResult CargarSec(int id)
        {
            List<T_Seccion> res = new List<T_Seccion>();
            res = _context.Seccion.GetAll().Where(x => x.MunicipioId == id).ToList();
            return Json(new SelectList(res, "Id", "Seccion"));
        }

    }
}