using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using WebComputos.Models.ViewModels;

namespace WebComputos.Components
{
    public class MenuPR :ViewComponent
    {
        private readonly IContenedorTrabajo _ctx;
        private readonly UserManager<T_Usuario> _userManager;

        public MenuPR(IContenedorTrabajo ctx, UserManager<T_Usuario> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {
            var Usuario = _userManager.GetUserId(UserClaimsPrincipal);
            var CurrentUser = _ctx.ApplicationUser.GetFirstOrDefault(x => x.Id == Usuario);
            var Oficina = _ctx.Oficina.Get(CurrentUser.OficinaId);

            MenuDinamicoVM Munu = new MenuDinamicoVM()
            {
                LDemarcaciones = _ctx.Demarcacion.GetAll(x => x.MunicipioId == Oficina.MunicipioId),
                Lsecciones = _ctx.Seccion.GetAll(x => x.MunicipioId == Oficina.MunicipioId),
                LDistrito = _ctx.Distrito.DistritoBySeccion(Oficina.MunicipioId)
            };
            return View(Munu);
        }
    }
}
