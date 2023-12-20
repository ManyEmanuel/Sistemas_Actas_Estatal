using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using Microsoft.EntityFrameworkCore;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Detalle_Votos_Acta_Partido_Repository : Repository<T_Detalle_Votos_Acta_Partido>, I_T_Detalle_Votos_Acta_Partido_Repository
    {
        private readonly ApplicationDbContext _db;
        public T_Detalle_Votos_Acta_Partido_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<ElementosListas> ResultadosCabecera()
        {
            var lst = _db.Votos_Actas.Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoVotos == true && x.LActaDetalle.IdEleccion == 1).Select(i => new ElementosListas()
            {
                seccion = i.LActaDetalle.LCasilla.LSeccion.Seccion,
                casilla = i.LActaDetalle.LCasilla.Nombre,
                Nulos = i.Nulos,
                NoRegistrados = i.NoRegistrados,
                Total = i.Total
            }).ToList();           
            return lst;
        }
        public IEnumerable<ElementosListas> ResultadosCabeceraGobPys(int eleccion, int Municipio)
        {
            List<ElementosListas> lst = new List<ElementosListas>();
            if(Municipio == 0)
            {
                lst = _db.Votos_Actas.Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoVotos == true && x.LActaDetalle.IdEleccion == eleccion).Select(i => new ElementosListas()
                {
                    seccion = i.LActaDetalle.LCasilla.LSeccion.Seccion,
                    casilla = i.LActaDetalle.LCasilla.Nombre,
                    Nulos = i.Nulos,
                    NoRegistrados = i.NoRegistrados,
                    Total = i.Total
                }).ToList();
            }
            else
            {
                lst = _db.Votos_Actas.Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoVotos == true && x.LActaDetalle.IdEleccion == eleccion && x.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio).Select(i => new ElementosListas()
                {
                    seccion = i.LActaDetalle.LCasilla.LSeccion.Seccion,
                    casilla = i.LActaDetalle.LCasilla.Nombre,
                    Nulos = i.Nulos,
                    NoRegistrados = i.NoRegistrados,
                    Total = i.Total
                }).ToList();

            }
                    
            return lst;
        }
        public IEnumerable<ElementosListas> ResultadosCabeceraGobPysCompleta(int eleccion, int Municipio)
        {
            List<ElementosListas> lst = new List<ElementosListas>();
           if(Municipio == 0)
            {
                lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == eleccion).Select(i => new ElementosListas()
                {

                    seccion = i.LCasilla.LSeccion.Seccion,
                    casilla = i.LCasilla.Nombre

                }).ToList();
            }
            else
            {
                 lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == eleccion && x.LCasilla.MunicipioId == Municipio).Select(i => new ElementosListas()
                 {

                    seccion = i.LCasilla.LSeccion.Seccion,
                    casilla = i.LCasilla.Nombre

                 }).ToList();
            }
            return lst;
        }

       

        public IEnumerable<ElementosListas> ResultadosCabeceraDip(int Municipio, int Distrito)
        {
            List<ElementosListas> lst = new List<ElementosListas>();

            
            if(Municipio == 0) 
            {
                lst = _db.Votos_Actas.Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoVotos == true && x.LActaDetalle.IdEleccion == 3 && x.LActaDetalle.LCasilla.LSeccion.DistritoId == Distrito).Select(i => new ElementosListas()
                {
                    seccion = i.LActaDetalle.LCasilla.LSeccion.Seccion,
                    casilla = i.LActaDetalle.LCasilla.Nombre,
                    Nulos = i.Nulos,
                    NoRegistrados = i.NoRegistrados,
                    Total = i.Total
                }).ToList();


            } 
            else 
            {
                lst = _db.Votos_Actas.Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoVotos == true && x.LActaDetalle.IdEleccion == 3 && x.LActaDetalle.LCasilla.LSeccion.DistritoId == Distrito && x.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio).Select(i => new ElementosListas()
                {
                    seccion = i.LActaDetalle.LCasilla.LSeccion.Seccion,
                    casilla = i.LActaDetalle.LCasilla.Nombre,
                    Nulos = i.Nulos,
                    NoRegistrados = i.NoRegistrados,
                    Total = i.Total
                }).ToList();

            }

            return lst;
        }
        public IEnumerable<ElementosListas> ResultadosCabeceraDipCompleta(int Municipio, int Distrito)
        {
            List<ElementosListas> lst = new List<ElementosListas>();
            

            if (Municipio == 0)
            {
                lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == 3 && x.LCasilla.LSeccion.DistritoId == Distrito).Select(i => new ElementosListas()
                {
                    seccion = i.LCasilla.LSeccion.Seccion,
                    casilla = i.LCasilla.Nombre
                }).ToList();
            }
            else
            {
                lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == 3 && x.LCasilla.LSeccion.DistritoId == Distrito && x.LCasilla.LSeccion.MunicipioId == Municipio).Select(i => new ElementosListas()
                {
                    seccion = i.LCasilla.LSeccion.Seccion,
                    casilla = i.LCasilla.Nombre
                }).ToList();
            }
            return lst;
        }

        public IEnumerable<ElementosListas> ResultadosCabeceraReg(int Municipio, int Demarcacion)
        {
            var lst = _db.Votos_Actas.Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoVotos == true && x.LActaDetalle.IdEleccion == 4 && x.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio && x.LActaDetalle.LCasilla.LSeccion.DemarcacionId == Demarcacion).Select(i => new ElementosListas()
            {
                seccion = i.LActaDetalle.LCasilla.LSeccion.Seccion,
                casilla = i.LActaDetalle.LCasilla.Nombre,
                Nulos = i.Nulos,
                NoRegistrados = i.NoRegistrados,
                Total = i.Total
            }).ToList();           
            return lst;
        }

        public IEnumerable<ElementosListas> ResultadosCabeceraRegCompleta(int Municipio, int Demarcacion)
        {
            var lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == 4 && x.LCasilla.LSeccion.MunicipioId == Municipio && x.LCasilla.LSeccion.DemarcacionId == Demarcacion).Select(i => new ElementosListas()
            {
                seccion = i.LCasilla.LSeccion.Seccion,
                casilla = i.LCasilla.Nombre
            }).ToList();

            return lst;

        }
        /* ------------------------------------------------------------------------------------------------------------------ */

        public IEnumerable<ElementosListas> GobernadorEstatal()
        {
            var lst = _db.Detalle_Votos_Acta.Include(LVotosActas => LVotosActas.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == 1).Select(i => new ElementosListas()
            {
                seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                Partido = i.IdPartido,
                Coalicion = i.IdCoalicion,
                Combinacion = i.IdCombinacion,
                Independiente = i.IdIndependiente,
                Votos = i.Votos
            }).ToList();
            return lst;
        }
        public IEnumerable<ElementosListas> GobernadorPorMunicipio(int Municipio)
        {
            List<ElementosListas> lst = new List<ElementosListas>();
            if(Municipio == 0)
            {
                lst = _db.Detalle_Votos_Acta.Include(LVotosActas => LVotosActas.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == 1).Select(i => new ElementosListas()
                {
                    seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                    casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                    Partido = i.IdPartido,
                    Coalicion = i.IdCoalicion,
                    Combinacion = i.IdCombinacion,
                    Independiente = i.IdIndependiente,
                    Votos = i.Votos
                }).ToList();
            }
            else
            {
                lst = _db.Detalle_Votos_Acta.Include(LVotosActas => LVotosActas.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == 1 && x.LVotosActa.LActaDetalle.LCasilla.MunicipioId == Municipio).Select(i => new ElementosListas()
                {
                    seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                    casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                    Partido = i.IdPartido,
                    Coalicion = i.IdCoalicion,
                    Combinacion = i.IdCombinacion,
                    Independiente = i.IdIndependiente,
                    Votos = i.Votos
                }).ToList();
            }
            

            return lst;
        }

        public IEnumerable<ElementosListas> PySMunicipio(int Municipio)
        {
            var lst = _db.Detalle_Votos_Acta.Include(LVotosActas => LVotosActas.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == 2 && x.LVotosActa.LActaDetalle.LCasilla.MunicipioId == Municipio).Select(i => new ElementosListas()
            {
                seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                Partido = i.IdPartido,
                Coalicion = i.IdCoalicion,
                Combinacion = i.IdCombinacion,
                Independiente = i.IdIndependiente,
                Votos = i.Votos
            }).ToList();
            return lst;
        }
        public IEnumerable<ElementosListas> DiputadosDistrito(int Distrito)
        {

            var lst = _db.Detalle_Votos_Acta.Include(LVotosActas => LVotosActas.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == 3 && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.DistritoId == Distrito).Select(i => new ElementosListas()
            {
                seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                Partido = i.IdPartido,
                Coalicion = i.IdCoalicion,
                Combinacion = i.IdCombinacion,
                Independiente = i.IdIndependiente,
                Votos = i.Votos
            }).ToList();
            return lst;
        }

        public IEnumerable<ElementosListas> DiputadosMunicipioDistrito(int Municipio, int Distrito)
        {
            var lst = _db.Detalle_Votos_Acta.Include(LVotosActas => LVotosActas.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == 3 && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.DistritoId == Distrito && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio).Select(i => new ElementosListas()
            {
                seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                Partido = i.IdPartido,
                Coalicion = i.IdCoalicion,
                Combinacion = i.IdCombinacion,
                Independiente = i.IdIndependiente,
                Votos = i.Votos
            }).ToList();

            return lst;
        }

        public IEnumerable<ElementosListas> RegidorMunicipioDemarcacion(int Municipio, int Demarcacion)
        {

            var lst = _db.Detalle_Votos_Acta.Include(LVotosActas => LVotosActas.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == 4 && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.DemarcacionId == Demarcacion && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio).Select(i => new ElementosListas()
            {
                seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                Partido = i.IdPartido,
                Coalicion = i.IdCoalicion,
                Combinacion = i.IdCombinacion,
                Independiente = i.IdIndependiente,
                Votos = i.Votos
            }).ToList();

            return lst;
        }

        /*-----------------------------------------------------------------------------------------------------------------------*/
        public IEnumerable<ElementosListas> GobernadorEstatalActorPolitico()
        {
            var lst = _db.Detalle_Votos_Acta_Actor.Include(LVotosActas => LVotosActas.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == 1).Select(i => new ElementosListas()
            {
                seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                Partido = i.IdPartido,
                Coalicion = i.IdCoalicion,
                Independiente = i.IdIndependiente,
                Votos = i.Votos
            }).ToList();
           
            return lst;
        }

        public IEnumerable<ElementosListas> GobernadorPorMunicipioActorPolitico(int Municipio)
        {
            List<ElementosListas> lst = new List<ElementosListas>();
            if (Municipio == 0)
            {
                lst = _db.Detalle_Votos_Acta_Actor.Include(LVotosActas => LVotosActas.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == 1).Select(i => new ElementosListas()
                {
                    seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                    casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                    Partido = i.IdPartido,
                    Coalicion = i.IdCoalicion,
                    Independiente = i.IdIndependiente,
                    Votos = i.Votos
                }).ToList();
            }
            else
            {
                lst = _db.Detalle_Votos_Acta_Actor.Include(LVotosActas => LVotosActas.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == 1 && x.LVotosActa.LActaDetalle.LCasilla.MunicipioId == Municipio).Select(i => new ElementosListas()
                {
                    seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                    casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                    Partido = i.IdPartido,
                    Coalicion = i.IdCoalicion,
                    Independiente = i.IdIndependiente,
                    Votos = i.Votos
                }).ToList();
            }
            
            
           
            return lst;
        }

        public IEnumerable<ElementosListas> PySMunicipioActorPolitico(int Municipio)
        {

            var lst = _db.Detalle_Votos_Acta_Actor.Include(LVotosActas => LVotosActas.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == 2 && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio).Select(i => new ElementosListas()
            {
                seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                Partido = i.IdPartido,
                Coalicion = i.IdCoalicion,
                Independiente = i.IdIndependiente,
                Votos = i.Votos
            }).ToList();

            return lst;
        }

        public IEnumerable<ElementosListas> DiputadosMunicipioDistritoActorPolitico(int Municipio, int Distrito)
        {

            var lst = _db.Detalle_Votos_Acta_Actor.Include(LVotosActas => LVotosActas.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == 3 && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.DistritoId == Distrito).Select(i => new ElementosListas()
            {
                seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                Partido = i.IdPartido,
                Coalicion = i.IdCoalicion,
                Independiente = i.IdIndependiente,
                Votos = i.Votos
            }).ToList();

            return lst;
        }

        public IEnumerable<ElementosListas> DiputadosDistritoActorPolitico(int Distrito)
        {

            var lst = _db.Detalle_Votos_Acta_Actor.Include(LVotosActas => LVotosActas.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == 3  && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.DistritoId == Distrito).Select(i => new ElementosListas()
            {
                seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                Partido = i.IdPartido,
                Coalicion = i.IdCoalicion,
                Independiente = i.IdIndependiente,
                Votos = i.Votos
            }).ToList();
            
            return lst;
        }

        public IEnumerable<ElementosListas> RegidorMunicipioDemarcacionActorPolitico(int Municipio, int Demarcacion)
        {

            var lst = _db.Detalle_Votos_Acta_Actor.Include(LVotosActas => LVotosActas.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == 4 && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.DemarcacionId == Demarcacion).Select(i => new ElementosListas()
            {
                seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                Partido = i.IdPartido,
                Coalicion = i.IdCoalicion,
                Independiente = i.IdIndependiente,
                Votos = i.Votos
            }).ToList();
           
            return lst;
        }

        
    }
}
