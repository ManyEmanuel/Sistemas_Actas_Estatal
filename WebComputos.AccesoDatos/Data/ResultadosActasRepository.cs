using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WebComputos.AccesoDatos.Data;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class ResultadosActasRepository : Repository <T_Votos_Acta>, IResultadosActasRepository
    {
        private readonly ApplicationDbContext _db;

        public ResultadosActasRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<T_Causal_Recuento> Causales(int Eleccion)
        {
            var Resultado = _db.Causales_recuento.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == Eleccion).ToList();
            return Resultado;
        }

        public T_Votos_Acta Get(object p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T_Votos_Acta> ResultadosExcel(int Eleccion)
        {
            var Resultado = _db.Votos_Actas.Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LDistrito => LDistrito.LDistrito).
                Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion=> LSeccion.LSeccion).ThenInclude(LMunicipio => LMunicipio.LMunicipio).Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LDemarcacion => LDemarcacion.LDemarcacion).Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LTipo => LTipo.LTipoCasilla).Where(x=> x.LActaDetalle.CapturadoVotos == true && x.LActaDetalle.IdEleccion == Eleccion).OrderBy(x=> x.LActaDetalle.LCasilla.LSeccion.Seccion).ToList();

                return Resultado;
        }

        public IEnumerable<ElementosListas> SegundoLugarEleccion(int Municipio, int eleccion, int DR)
        {
            List<ElementosListas> lst = new List<ElementosListas>();
            if(eleccion == 3){
                if(Municipio == 0)
                {
                    lst = _db.Detalle_Votos_Acta.Include(LVotos => LVotos.LVotosActa).ThenInclude(LActa => LActa.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true  && x.LVotosActa.LActaDetalle.IdEleccion == eleccion && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.DistritoId == DR).Select(i => new ElementosListas()
                    {
                        seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                        casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                        idreg = i.LVotosActa.IdRegistroVotos,
                        Independiente = i.IdIndependiente,
                        Coalicion = i.IdCoalicion,
                        Partido = i.IdPartido,
                        Votos = i.Votos

                    }).ToList();
                }
                else
                {
                    lst = _db.Detalle_Votos_Acta.Include(LVotos => LVotos.LVotosActa).ThenInclude(LActa => LActa.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio && x.LVotosActa.LActaDetalle.IdEleccion == eleccion && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.DistritoId == DR).Select(i => new ElementosListas()
                    {
                        seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                        casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                        idreg = i.LVotosActa.IdRegistroVotos,
                        Independiente = i.IdIndependiente,
                        Coalicion = i.IdCoalicion,
                        Partido = i.IdPartido,
                        Votos = i.Votos

                    }).ToList();
                }
               
            }
            else if( eleccion == 4)
            {
                if (Municipio == 0)
                {
                    lst = _db.Detalle_Votos_Acta.Include(LVotos => LVotos.LVotosActa).ThenInclude(LActa => LActa.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == eleccion && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.DemarcacionId == DR).Select(i => new ElementosListas()
                    {
                        seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                        casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                        idreg = i.LVotosActa.IdRegistroVotos,
                        Independiente = i.IdIndependiente,
                        Coalicion = i.IdCoalicion,
                        Partido = i.IdPartido,
                        Votos = i.Votos

                    }).ToList();
                }
                else
                {
                    lst = _db.Detalle_Votos_Acta.Include(LVotos => LVotos.LVotosActa).ThenInclude(LActa => LActa.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio && x.LVotosActa.LActaDetalle.IdEleccion == eleccion && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.DemarcacionId == DR).Select(i => new ElementosListas()
                    {
                        seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                        casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                        idreg = i.LVotosActa.IdRegistroVotos,
                        Independiente = i.IdIndependiente,
                        Coalicion = i.IdCoalicion,
                        Partido = i.IdPartido,
                        Votos = i.Votos

                    }).ToList();
                }
            }
            else
            {
                if(Municipio == 0)
                {
                    lst = _db.Detalle_Votos_Acta.Include(LVotos => LVotos.LVotosActa).ThenInclude(LActa => LActa.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true  && x.LVotosActa.LActaDetalle.IdEleccion == eleccion).Select(i => new ElementosListas()
                    {
                        seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                        casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                        idreg = i.LVotosActa.IdRegistroVotos,
                        Independiente = i.IdIndependiente,
                        Coalicion = i.IdCoalicion,
                        Partido = i.IdPartido,
                        Votos = i.Votos

                    }).ToList();
                }
                else
                {
                    lst = _db.Detalle_Votos_Acta.Include(LVotos => LVotos.LVotosActa).ThenInclude(LActa => LActa.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio && x.LVotosActa.LActaDetalle.IdEleccion == eleccion).Select(i => new ElementosListas()
                    {
                        seccion = i.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion,
                        casilla = i.LVotosActa.LActaDetalle.LCasilla.Nombre,
                        idreg = i.LVotosActa.IdRegistroVotos,
                        Independiente = i.IdIndependiente,
                        Coalicion = i.IdCoalicion,
                        Partido = i.IdPartido,
                        Votos = i.Votos

                    }).ToList();
                }
                

            }
            return lst;
        }

        public IEnumerable<T_Detalle_Votos_Acta> VotosExcel(int Eleccion)
        {
            var Resultado = _db.Detalle_Votos_Acta.Include(LVotos=> LVotos.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LDistrito => LDistrito.LDistrito).
                 Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == Eleccion).OrderBy(x => x.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion).ToList();
            
            return Resultado;
        }


        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________//

        public IEnumerable<T_Causal_Recuento> CausalesMunicipal(int Eleccion, int Municipio)
        {
            var Resultado = _db.Causales_recuento.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == Eleccion && x.LCasilla.LSeccion.MunicipioId == Municipio).ToList();
            return Resultado;
        }

        public IEnumerable<T_Detalle_Votos_Acta> VotosExcelMunicipal(int Eleccion, int Municipio)
        {
            var Resultado = _db.Detalle_Votos_Acta.Include(LVotos => LVotos.LVotosActa).ThenInclude(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LDistrito => LDistrito.LDistrito).
                 Where(x => x.LVotosActa.LActaDetalle.CapturadoVotos == true && x.LVotosActa.LActaDetalle.IdEleccion == Eleccion && x.LVotosActa.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio).OrderBy(x => x.LVotosActa.LActaDetalle.LCasilla.LSeccion.Seccion).ToList();

            return Resultado;
        }

        public IEnumerable<T_Votos_Acta> ResultadosExcelMunicipal(int Eleccion, int Municipio)
        {
            var Resultado = _db.Votos_Actas.Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LDistrito => LDistrito.LDistrito).
                Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LMunicipio => LMunicipio.LMunicipio).Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LDemarcacion => LDemarcacion.LDemarcacion).Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LTipo => LTipo.LTipoCasilla).Where(x => x.LActaDetalle.CapturadoVotos == true && x.LActaDetalle.IdEleccion == Eleccion && x.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio).OrderBy(x => x.LActaDetalle.LCasilla.LSeccion.Seccion).ToList();

            return Resultado;
        }

        public IEnumerable<T_Recepcion_Paquete> Paquetes()
        {
            var Resultado = _db.Recepcion_Paquete.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LMunicipio => LMunicipio.LMunicipio).Include(LCasilla => LCasilla.LCasilla).ThenInclude(LTIpo => LTIpo.LTipoCasilla).OrderBy(x => x.LCasilla.LSeccion.Seccion).ToList();
            return Resultado;
        }

        public IEnumerable<T_Recepcion_Paquete> PaquetesMunicipal(int Municipio)
        {
            var Resultado = _db.Recepcion_Paquete.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LMunicipio => LMunicipio.LMunicipio).Include(LCasilla => LCasilla.LCasilla).ThenInclude(LTIpo => LTIpo.LTipoCasilla).Where(x=> x.LCasilla.LSeccion.MunicipioId == Municipio).OrderBy(x => x.LCasilla.LSeccion.Seccion).ToList();
            return Resultado;
        }

        public IEnumerable<T_Acta> Complementaria(int Eleccion)
        {
            var Resultado = _db.Actas.Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.IdEleccion == Eleccion).ToList();

            return Resultado;
        }

        public IEnumerable<T_Acta> ComplementariaMunicipal(int Eleccion, int Municipio)
        {
            var Resultado = _db.Actas.Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.IdEleccion == Eleccion && x.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio).ToList();

            return Resultado;
        }

        public IEnumerable<T_Recepcion_Paquete> PaquetesINE()
        {
            var Resultado = _db.Recepcion_Paquete.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LMunicipio => LMunicipio.LMunicipio).Include(LCasilla => LCasilla.LCasilla).ThenInclude(LTIpo => LTIpo.LTipoCasilla).Include(LCasilla=> LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LDemarcacion=> LDemarcacion.LDemarcacion).Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LDistrito => LDistrito.LDistrito).OrderBy(x => x.LCasilla.LSeccion.Seccion).ToList();
            return Resultado;
        }

        public IEnumerable<T_HistorialModificaciones> GetListaVotosModificacion()
        {
            var res = _db.HistorialModificaciones.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LMunicipio => LMunicipio.LMunicipio).Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(Ltipo => Ltipo.LTipoCasilla).Where(x => x.Concepto == 2 && x.Estatus == 0 && x.Votos != 0).Include(Lusuario => Lusuario.LUsuario).ToList();
            return res;
        }

        public IEnumerable<T_HistorialModificaciones> GetVotosComplementariaHistorial()
        {
            var res = _db.HistorialModificaciones.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LMunicipio => LMunicipio.LMunicipio).Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(Ltipo => Ltipo.LTipoCasilla).Where(x => x.Concepto == 2 && x.Estatus != 0 && x.Votos != 0).Include(Lusuario => Lusuario.LUsuario).ToList();
            return res;
        }

        public IEnumerable<T_HistorialModificaciones> GetListaVotosHistorial()
        {
            throw new NotImplementedException();
        }
    }
}

    
    
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   