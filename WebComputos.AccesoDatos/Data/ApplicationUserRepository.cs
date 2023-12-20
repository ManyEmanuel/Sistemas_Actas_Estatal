using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class ApplicationUserRepository : Repository<T_Usuario>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaUsuarios()
        {
            return _db.Usuarios.Select(i => new SelectListItem()
            {
                Text = (i.Nombres + " " + i.Apellido_Paterno + " " + i.Apellido_Materno),
                Value = i.Id
            });
        }

        public void Update(T_Usuario user)
        {
            var Obj = _db.Usuarios.Find(user.Id);
            Obj.Nombres = user.Nombres;
            Obj.Apellido_Paterno = user.Apellido_Paterno;
            Obj.Apellido_Materno = user.Apellido_Materno;
            Obj.Email = user.Email;
            if (user.Foto_Url != null)
            {
                Obj.Foto_Url = user.Foto_Url;
            }
            Obj.OficinaId = user.OficinaId;
            Obj.UserName = user.UserName;
            Obj.PasswordHash = user.PasswordHash;
        }
    }
}
