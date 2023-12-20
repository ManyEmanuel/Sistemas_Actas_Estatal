using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using WebComputos.Models.ViewModels;
using WebComputos.AccesoDatos.Data;

namespace WebComputos.Components
{
    public class MenuResultados :ViewComponent
    {
        private readonly IContenedorTrabajo _context;
        private ApplicationDbContext _db;
        private readonly UserManager<T_Usuario> _UserManager;

        public MenuResultados(IContenedorTrabajo context, ApplicationDbContext db, UserManager<T_Usuario> UserManager)
        {
            _context = context;
            _db = db;
            _UserManager = UserManager;
        }
        public IViewComponentResult Invoke()
        {
            var Usuario = _UserManager.GetUserId(UserClaimsPrincipal);
            var CurrentUser = _context.ApplicationUser.GetFirstOrDefault(x => x.Id == Usuario);
            var Oficina = _context.Oficina.Get(CurrentUser.OficinaId);

            MenuDinamicoVM Munu = new MenuDinamicoVM()
            {
                //LDemarcaciones = _ctx.Demarcacion.GetAll(x => x.Municipio == Oficina.Municipio),
                //Lsecciones = _ctx.Seccion.GetAll(x => x.Municipio == Oficina.Municipio),
                //LDistrito = _ctx.Distrito.DistritoBySeccion(Oficina.Municipio)


                //LDemarcaciones = _ctx.Demarcacion.GetAll(x => x.Municipio == Oficina.Municipio),
                //Lsecciones = _ctx.Seccion.GetAll(x => x.MunicipioId == Oficina.MunicipioId),
                //LDistrito = _ctx.Distrito.DistritoBySeccion(Oficina.MunicipioId)

                LDemarcaciones = _context.Demarcacion.GetAll(x => x.MunicipioId == Oficina.MunicipioId),
                Lsecciones = _context.Seccion.GetAll(x => x.MunicipioId == Oficina.MunicipioId),
                LDistrito = _context.Distrito.DistritoBySeccion(Oficina.MunicipioId)
                
            };
            ViewBag.ComprobarDipRP = _context.Acta.ComprobarDipRP(Oficina.MunicipioId);
            ViewBag.ComprobarRegRP = _context.Acta.ComprobarRegRP(Oficina.MunicipioId);
            ViewBag.DiputacionRP = _context.Acta.ListaSeccionInfoComByMunicipioDipRP(Oficina.MunicipioId);
            ViewBag.RegiduriaRP = _context.Acta.ListaSeccionInfoComByMunicipioRegRP(Oficina.MunicipioId);

            return View(Munu);
        }
    }
}
