using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Seccion_Repository : Repository<T_Seccion>, I_T_Seccion_Repository
    {

        private readonly ApplicationDbContext _db;
        public T_Seccion_Repository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public T_Seccion Get(object p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem> GetListaSeccion()
        {
            return _db.Secciones.Select(i => new SelectListItem()
            {
                Text= i.Seccion,
                Value=i.Id.ToString()
            }).OrderBy(x=> x.Text);
        }

        public IEnumerable<SelectListItem> ListaCasillaByMunicipio(int Municipio)
        {
            return _db.Casillas.Where(x => x.MunicipioId == Municipio).Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            }) ;
        }
        public IEnumerable<SelectListItem> ListaCasillaByDistrito(int Municipio, int Distrito)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            if(Municipio == 0)
            {
                lst = _db.Casillas.Include(LSeccion => LSeccion.LSeccion).Where(x => x.LSeccion.DistritoId == Distrito).Select(i => new SelectListItem()
                {
                    Text = i.LSeccion.Seccion,
                    Value = i.LSeccion.Id.ToString()
                }).ToList();
            }
            else
            {
                 lst = _db.Casillas.Include(LSeccion => LSeccion.LSeccion).Where(x => x.MunicipioId == Municipio && x.LSeccion.DistritoId == Distrito).Select(i => new SelectListItem()
                {
                    Text = i.LSeccion.Seccion,
                    Value = i.LSeccion.Id.ToString()
                }).ToList();
            }
            
           
            return lst;
        }

        public IEnumerable<SelectListItem> ListaCasillaByDemarcacion(int Municipio, int Demarcacion)
        {
            var lst = _db.Casillas.Include(LSeccion => LSeccion.LSeccion).Where(x => x.MunicipioId == Municipio && x.LSeccion.DemarcacionId == Demarcacion).Select(i => new SelectListItem()
            {
                Text = i.LSeccion.Seccion,
                Value = i.LSeccion.Id.ToString()
            }).ToList();

            return lst;
        }

        public IEnumerable<SelectListItem> ListaSeccionByDemarcacion(int Municipio, int Demarcacion)
        {
            return _db.Secciones.Where(x => x.MunicipioId == Municipio && x.DemarcacionId == Demarcacion).Select(i => new SelectListItem()
            {
                Text = i.Seccion,
                Value = i.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> ListaSeccionByDistrito(int Municipio, int Distrito)
        {
            return _db.Secciones.Where(x => x.MunicipioId == Municipio && x.DistritoId == Distrito).Select(i => new SelectListItem()
            {
                Text = i.Seccion,
                Value = i.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> ListaSeccionByMunicipio(int Municipio)
        {
            return _db.Secciones.Where(x => x.MunicipioId == Municipio).Select(i => new SelectListItem()
            {
                Text = i.Seccion,
                Value = i.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> ListaRecepcionByMunicipio(int Municipio)
        {

            var b = _db.Casillas.Include(LSeccion => LSeccion.LSeccion).Where(x => x.Recibido == false && x.LSeccion.MunicipioId == Municipio).Select(i => new SelectListItem()
            {
                Text = i.LSeccion.Seccion,
                Value = i.LSeccion.Id.ToString()
            }).Distinct().OrderBy(x=> x.Text).ToList(); 
            return b;
        }


        public void Update(T_Seccion seccion)
        {
            var SeccionBD = _db.Secciones.FirstOrDefault(s => s.Id == seccion.Id);
            SeccionBD.Activo = seccion.Activo;
            SeccionBD.Cabecera_Localidad = seccion.Cabecera_Localidad;
            SeccionBD.DemarcacionId = seccion.DemarcacionId;
            SeccionBD.DistritoId = seccion.DistritoId;
            SeccionBD.MunicipioId = seccion.MunicipioId;
            SeccionBD.Padron_Electoral = seccion.Padron_Electoral;
            SeccionBD.Seccion = seccion.Seccion;
            SeccionBD.Listado_Nominal = seccion.Listado_Nominal;
            _db.SaveChanges();
        }

       
    }
}
