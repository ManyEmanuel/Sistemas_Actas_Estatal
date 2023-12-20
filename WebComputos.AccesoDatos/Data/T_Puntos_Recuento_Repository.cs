using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebComputos.AccesoDatos.Data.Repository;
using System.Linq;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public class T_Puntos_Recuento_Repository : Repository<T_Puntos_Recuento>, I_T_Puntos_Recuento_Repository
    {
        private readonly ApplicationDbContext _db;
        public T_Puntos_Recuento_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void EjercicioSeleccionado(int Municipio, int Eleccion, int Ejercicio, int DD)
        {
            List<T_Puntos_Recuento> lst = new List<T_Puntos_Recuento>();
            if (Eleccion == 3)
            {
                lst = _db.Puntos_Recuento.Where(x => x.Eleccion == Eleccion && x.Municipio == Municipio && x.NumEjercicio == Ejercicio && x.Distrito == DD).ToList();
            }
            else if (Eleccion == 4)
            {
                lst = _db.Puntos_Recuento.Where(x => x.Eleccion == Eleccion && x.Municipio == Municipio && x.NumEjercicio == Ejercicio && x.Demarcacion == DD).ToList();
            }
            else
            {
                lst = _db.Puntos_Recuento.Where(x => x.Eleccion == Eleccion && x.Municipio == Municipio && x.NumEjercicio == Ejercicio).ToList();
            }

            foreach(var lista in lst)
            {
                var pun = _db.Puntos_Recuento.Where(x => x.IdPuntosRecuento == lista.IdPuntosRecuento).FirstOrDefault();
                pun.Tipo = 1;
            }
            _db.SaveChanges();
        }

        public IEnumerable<PuntosRec> ObtenerEjercicos(int Municipio, int Eleccion, int DD)
        {
            List<PuntosRec> res = new List<PuntosRec>();
            if(Eleccion == 3)
            {
                res = _db.Puntos_Recuento.Where(x => x.Municipio == Municipio && x.Eleccion == Eleccion && x.Distrito == DD).Select(i => new PuntosRec
                {
                    Elecciones = i.Eleccion,
                    TotalCasillas = i.CasillasTot,
                    PuntosRecuento = i.PuntoRecu,
                    NoGrupos = i.GrupoTrabajo,
                    NoEjercicio = i.NumEjercicio,
                    Tipo = i.Tipo
                }).ToList();
            }
            else if(Eleccion == 4)
            {
                res = _db.Puntos_Recuento.Where(x => x.Municipio == Municipio && x.Eleccion == Eleccion && x.Demarcacion == DD).Select(i => new PuntosRec
                {
                    Elecciones = i.Eleccion,
                    TotalCasillas = i.CasillasTot,
                    PuntosRecuento = i.PuntoRecu,
                    NoGrupos = i.GrupoTrabajo,
                    NoEjercicio = i.NumEjercicio,
                    Tipo = i.Tipo
                }).ToList();
            }
            else
            {
                res = _db.Puntos_Recuento.Where(x => x.Municipio == Municipio && x.Eleccion == Eleccion).Select(i => new PuntosRec
                {
                    Elecciones = i.Eleccion,
                    TotalCasillas = i.CasillasTot,
                    PuntosRecuento = i.PuntoRecu,
                    NoGrupos = i.GrupoTrabajo,
                    NoEjercicio = i.NumEjercicio,
                    Tipo = i.Tipo
                }).ToList();
            }

            var grs = res.GroupBy(x => x.NoEjercicio).Select(g => new PuntosRec
            {
                Elecciones = g.First().Elecciones,
                TotalCasillas = g.Sum(x=> x.TotalCasillas),
                PuntosRecuento = g.Last().PuntosRecuento,
                NoGrupos = g.Last().NoGrupos,
                NoEjercicio = g.Key,
                Tipo = g.First().Tipo
            }).ToList();

            return grs;
        }

        public IEnumerable<PuntosRec> ObtenerEjercicosPorNumero(int Municipio, int Eleccion, int DD, int numejercicio)
        {
            List<PuntosRec> res = new List<PuntosRec>();
            if (Eleccion == 3)
            {
                res = _db.Puntos_Recuento.Where(x => x.Municipio == Municipio && x.Eleccion == Eleccion && x.Distrito == DD && x.NumEjercicio == numejercicio).Select(i => new PuntosRec
                {
                    Elecciones = i.Eleccion,
                    TotalCasillas = i.CasillasTot,
                    PuntosRecuento = i.PuntoRecu,
                    NoGrupos = i.GrupoTrabajo,
                    NoEjercicio = i.NumEjercicio,
                    Tipo = i.Tipo
                }).ToList();
            }
            else if (Eleccion == 4)
            {
                res = _db.Puntos_Recuento.Where(x => x.Municipio == Municipio && x.Eleccion == Eleccion && x.Demarcacion == DD && x.NumEjercicio == numejercicio).Select(i => new PuntosRec
                {
                    Elecciones = i.Eleccion,
                    TotalCasillas = i.CasillasTot,
                    PuntosRecuento = i.PuntoRecu,
                    NoGrupos = i.GrupoTrabajo,
                    NoEjercicio = i.NumEjercicio,
                    Tipo = i.Tipo
                }).ToList();
            }
            else
            {
                res = _db.Puntos_Recuento.Where(x => x.Municipio == Municipio && x.Eleccion == Eleccion && x.NumEjercicio == numejercicio).Select(i => new PuntosRec
                {
                    Elecciones = i.Eleccion,
                    TotalCasillas = i.CasillasTot,
                    PuntosRecuento = i.PuntoRecu,
                    NoGrupos = i.GrupoTrabajo,
                    NoEjercicio = i.NumEjercicio,
                    Tipo = i.Tipo
                }).ToList();
            }
            return res;
        }

        public IEnumerable<PuntosRec> EjercicioSeleccionadoPorNumero(int Municipio, int Eleccion, int DD, int numejercicio)
        {
            List<PuntosRec> res = new List<PuntosRec>();
            if (Eleccion == 3)
            {
                res = _db.Puntos_Recuento.Where(x => x.Municipio == Municipio && x.Eleccion == Eleccion && x.Distrito == DD && x.NumEjercicio == numejercicio).Select(i=> new PuntosRec {
                    Elecciones = i.Eleccion,
                    TotalCasillas = i.CasillasTot,
                    PuntosRecuento = i.PuntoRecu,
                    NoGrupos = i.GrupoTrabajo,
                    NoEjercicio = i.NumEjercicio,
                    Tipo = i.Tipo
                }).ToList();
            }
            else if (Eleccion == 4)
            {
                res = _db.Puntos_Recuento.Where(x => x.Municipio == Municipio && x.Eleccion == Eleccion && x.Demarcacion == DD && x.NumEjercicio == numejercicio).Select(i => new PuntosRec
                {
                    Elecciones = i.Eleccion,
                    TotalCasillas = i.CasillasTot,
                    PuntosRecuento = i.PuntoRecu,
                    NoGrupos = i.GrupoTrabajo,
                    NoEjercicio = i.NumEjercicio,
                    Tipo = i.Tipo
                }).ToList();
            }
            else
            {
                res = _db.Puntos_Recuento.Where(x => x.Municipio == Municipio && x.Eleccion == Eleccion && x.NumEjercicio == numejercicio).Select(i => new PuntosRec
                {
                    Elecciones = i.Eleccion,
                    TotalCasillas = i.CasillasTot,
                    PuntosRecuento = i.PuntoRecu,
                    NoGrupos = i.GrupoTrabajo,
                    NoEjercicio = i.NumEjercicio,
                    Tipo = i.Tipo
                }).ToList();
            }

            var grs = res.GroupBy(x => x.NoGrupos).Select(g => new PuntosRec
            {
                Elecciones = g.First().Elecciones,
                TotalCasillas = g.Sum(x => x.TotalCasillas),
                PuntosRecuento = g.Last().PuntosRecuento,
                NoGrupos = g.Key,
                Tipo = g.First().Tipo
            }).ToList();

            return grs;

        }

    }
}
