using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebComputos.AccesoDatos.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebComputos.Models.ViewModels;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Recepcion_Paquete_Repository : Repository<T_Recepcion_Paquete>, I_T_Recepcion_Paquete_Repository
    {
        private readonly ApplicationDbContext _db;

        public T_Recepcion_Paquete_Repository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public T_Recepcion_Paquete Get(object p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ElementosListas> GetListaPaquetesByMun(int mun)
        {
            var lst = new List<ElementosListas>();
            var res = _db.Recepcion_Paquete.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(Ltipo => Ltipo.LTipoCasilla).Where(x => x.LCasilla.MunicipioId == mun && x.Solicitud == 0).Include(Lusuario => Lusuario.LUsuario).ToList();

            if (mun != 0) {
                lst = _db.Recepcion_Paquete.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(Ltipo => Ltipo.LTipoCasilla).Where(x => x.LCasilla.MunicipioId == mun && x.Solicitud == 0).Include(Lusuario => Lusuario.LUsuario).Select(i => new ElementosListas()
                {
                    seccion = i.LCasilla.LSeccion.Seccion,
                    casilla = i.LCasilla.Nombre,
                    recep = i.HoraRecepcion,
                    idr = i.IdRecepcion,
                    text = i.LUsuario.Nombres +" "+ i.LUsuario.Apellido_Paterno +" "+ i.LUsuario.Apellido_Materno
                }).ToList();
            }
            else
            {
                lst = _db.Recepcion_Paquete.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(Ltipo => Ltipo.LTipoCasilla).Include(LUsuario => LUsuario.LUsuario).Where(x=> x.Solicitud == 0).Select(i => new ElementosListas()
                {
                    seccion = i.LCasilla.LSeccion.Seccion,
                    casilla = i.LCasilla.Nombre,
                    recep = i.HoraRecepcion,
                    idr = i.IdRecepcion,
                    text = i.LUsuario.Nombres + " " + i.LUsuario.Apellido_Paterno + " " + i.LUsuario.Apellido_Materno
                }).ToList();
            }


            return lst;
        }
        public IEnumerable<T_HistorialModificaciones> GetListaPaquetesModificacion()
        {
            var res = _db.HistorialModificaciones.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LMunicipio=> LMunicipio.LMunicipio).Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(Ltipo => Ltipo.LTipoCasilla).Where(x => x.Concepto == 0 && x.Estatus == 0 && x.Paquetes != 0).Include(Lusuario => Lusuario.LUsuario).ToList();         
            return res;
        }

        public IEnumerable<T_HistorialModificaciones> GetListaPaquetesHistorial()
        {
            var res = _db.HistorialModificaciones.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LMunicipio => LMunicipio.LMunicipio).Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(Ltipo => Ltipo.LTipoCasilla).Where(x => x.Concepto == 0 && x.Estatus != 0 && x.Paquetes != 0).Include(Lusuario => Lusuario.LUsuario).ToList();
            return res;
        }


        public IEnumerable<SelectListItem> GetListaRecepcion()
        {
            return _db.Recepcion_Paquete.Select(i => new SelectListItem()
            {
                Text = i.Nombre_Entrega,
                Value = i.IdRecepcion.ToString()
            }
            );
        }

        public IEnumerable<AvancePaquetes> GetAvancePaquetes()
        {
            List<AvancePaquetes> lst = new List<AvancePaquetes>();
            for (int i = 1; i <= 20; i++)
            {
                var Rec = _db.Recepcion_Paquete.Include(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.LCasilla.MunicipioId == i).ToList();
                 var Total = _db.Casillas.Where(x => x.MunicipioId == i && x.Activo == true).ToList();                  
                double Recibidas = Rec.Count();
                double Faltantes = Total.Count() - Recibidas;
                double Porcentaje = (Recibidas * 100) / Total.Count();
                
                var Nombre = _db.Municipios.Where(x => x.Id == i).FirstOrDefault();
                AvancePaquetes avance = new AvancePaquetes();
                avance.Total = Total.Count();
                avance.Recibidos = Recibidas;
                avance.Faltantes = Faltantes;
                string por = Porcentaje.ToString("N2");
                avance.Porcentaje = Convert.ToDouble(por);
                avance.Municipio = Nombre.Municipio;
                avance.IdMunicipio = Nombre.Id;
                lst.Add(avance);
            }
            var lstd = lst.OrderBy(x => x.IdMunicipio).ToList();
            return lstd;
        }

        public IEnumerable<DetallePaquete> GetDetallePaquetes(int mun)
        {
            List<DetallePaquete> lst = new List<DetallePaquete>();
            var Casmun = _db.Casillas.Include(LSeccion => LSeccion.LSeccion).Where(x => x.LSeccion.MunicipioId == mun && x.Activo == true).ToList();
            var Recepcion = _db.Recepcion_Paquete.Include(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.LCasilla.MunicipioId == mun && x.LCasilla.Activo == true).ToList();
            foreach (var item in Casmun)
            {
                DetallePaquete detalle = new DetallePaquete();
                if (Recepcion.Where(x=> x.IdCasilla == item.Id).Count()!=0)
                {
                    //var Recepcion = _db.TRecepcionPaquetes.Where(x => x.IdCasillaDet == item.IdCasillaDet).FirstOrDefault();
                    detalle.Seccion = item.LSeccion.Seccion;
                    detalle.Casilla = item.Nombre;
                    var Fecha = Recepcion.Where(x => x.IdCasilla == item.Id).FirstOrDefault();
                    detalle.Fecha =  Fecha.FechaRecepcion.ToString("dd - MM - yyyy");
                    detalle.Hora = Fecha.HoraRecepcion.ToString("HH : mm");
                    detalle.Estatus = "Recibido";
                    lst.Add(detalle);
                }
                else
                {
                    detalle.Seccion = item.LSeccion.Seccion;
                    detalle.Casilla = item.Nombre;
                    detalle.Fecha = "--";
                    detalle.Hora = "--";
                    detalle.Estatus = "Pendiente";
                    lst.Add(detalle);
                }
            }
            
              return lst;
        }

        public IEnumerable<T_Recepcion_Paquete> GetPaquetes(int mun)
        {
            var res = _db.Recepcion_Paquete.Include(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.LCasilla.MunicipioId == mun).ToList();
            return res;

        }

        public IEnumerable<ConCausal> ConCausales(int mun, int ele, int tip)
        {
            List<ConCausal> res = new List<ConCausal>();
            if( ele == 3)
            {
                if(mun == 0)
                {
                    res = _db.Causales_recuento.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.Total_Causales > 0 && x.LCasilla.LSeccion.DistritoId == tip).Select(i => new ConCausal()
                    {
                        NoSeccionCC = i.LCasilla.LSeccion.Seccion,
                        CasillaCC = i.LCasilla.Nombre,
                        NoCausales = i.Total_Causales.ToString()
                    }).ToList();
                }
                else
                {
                    res = _db.Causales_recuento.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.Total_Causales > 0 && x.LCasilla.MunicipioId == mun && x.LCasilla.LSeccion.DistritoId == tip).Select(i => new ConCausal()
                    {
                        NoSeccionCC = i.LCasilla.LSeccion.Seccion,
                        CasillaCC = i.LCasilla.Nombre,
                        NoCausales = i.Total_Causales.ToString()
                    }).ToList();
                }
                
            }
            else if(ele == 4)
            {
                if(mun == 0)
                {
                    res = _db.Causales_recuento.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.Total_Causales > 0 && x.LCasilla.LSeccion.DemarcacionId == tip).Select(i => new ConCausal()
                    {
                        NoSeccionCC = i.LCasilla.LSeccion.Seccion,
                        CasillaCC = i.LCasilla.Nombre,
                        NoCausales = i.Total_Causales.ToString()
                    }).ToList();
                }
                else
                {
                    res = _db.Causales_recuento.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.Total_Causales > 0 && x.LCasilla.MunicipioId == mun && x.LCasilla.LSeccion.DemarcacionId == tip).Select(i => new ConCausal()
                    {
                        NoSeccionCC = i.LCasilla.LSeccion.Seccion,
                        CasillaCC = i.LCasilla.Nombre,
                        NoCausales = i.Total_Causales.ToString()
                    }).ToList();
                }
               
            }
            else
            {
                if(mun == 0)
                {
                    res = _db.Causales_recuento.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.Total_Causales > 0).Select(i => new ConCausal()
                    {
                        NoSeccionCC = i.LCasilla.LSeccion.Seccion,
                        CasillaCC = i.LCasilla.Nombre,
                        NoCausales = i.Total_Causales.ToString()
                    }).ToList();
                }
                else
                {
                    res = _db.Causales_recuento.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.Total_Causales > 0 && x.LCasilla.MunicipioId == mun).Select(i => new ConCausal()
                    {
                        
                        NoSeccionCC = i.LCasilla.LSeccion.Seccion,
                        CasillaCC = i.LCasilla.Nombre,
                        NoCausales = i.Total_Causales.ToString()
                    }).ToList();

                }
                
            }
            
            return res;
        }

        public IEnumerable<SinCausal> SinCausales(int mun, int ele, int tip)
        {
            List<SinCausal> res = new List<SinCausal>();
            if(ele == 3)
            {
                if(mun == 0)
                {
                    res = _db.Causales_recuento.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.Total_Causales == 0&& x.LCasilla.LSeccion.DistritoId == tip).Select(i => new SinCausal()
                    {
                        NoSeccionSC = i.LCasilla.LSeccion.Seccion,
                        CasillaSC = i.LCasilla.Nombre
                    }).ToList();

                }
                else
                {
                    res = _db.Causales_recuento.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.Total_Causales == 0 && x.LCasilla.MunicipioId == mun && x.LCasilla.LSeccion.DistritoId == tip).Select(i => new SinCausal()
                    {
                        NoSeccionSC = i.LCasilla.LSeccion.Seccion,
                        CasillaSC = i.LCasilla.Nombre
                    }).ToList();
                }
                
            }
            else if(ele == 4)
            {
                if(mun == 0)
                {
                    res = _db.Causales_recuento.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.LCasilla.LSeccion.DemarcacionId == tip).Select(i => new SinCausal()
                    {
                        NoSeccionSC = i.LCasilla.LSeccion.Seccion,
                        CasillaSC = i.LCasilla.Nombre
                    }).ToList();
                }
                else
                {
                    res = _db.Causales_recuento.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.Total_Causales == 0 && x.LCasilla.MunicipioId == mun && x.LCasilla.LSeccion.DemarcacionId == tip).Select(i => new SinCausal()
                    {
                        NoSeccionSC = i.LCasilla.LSeccion.Seccion,
                        CasillaSC = i.LCasilla.Nombre
                    }).ToList();

                }
                
            }
            else
            {
                if (mun == 0)
                {
                    res = _db.Causales_recuento.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.Total_Causales == 0).Select(i => new SinCausal()
                    {
                        NoSeccionSC = i.LCasilla.LSeccion.Seccion,
                        CasillaSC = i.LCasilla.Nombre
                    }).ToList();
                }
                else
                {
                    res = _db.Causales_recuento.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.TipoEleccionId == ele && x.Total_Causales == 0 && x.LCasilla.MunicipioId == mun).Select(i => new SinCausal()
                    {
                        
                        NoSeccionSC = i.LCasilla.LSeccion.Seccion,
                        CasillaSC = i.LCasilla.Nombre
                    }).ToList();
                }
               
            }
             
            return res;
        }

        public IEnumerable<SelectListItem> ObtenerCasilla(int seccion, int municipio)
        {
            var lst = _db.Casillas.Include(LSeccion => LSeccion.LSeccion).Where(x => x.SeccionId == seccion && x.Activo == true && x.Recibido == false && x.LSeccion.MunicipioId == municipio).Select(i => new SelectListItem()
            {
                Value = i.Id.ToString(),
                Text = i.Nombre
                
            }).OrderBy(x=> x.Value).ToList();
            return lst;
        }

        public IEnumerable<T_Acta_Detalle> CapturaCompleta(int mun)
        {
            var Acta = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).Where(x => x.LCasilla.MunicipioId == mun).ToList();
            return Acta;
        }
        public IEnumerable<SelectListItem> ListaDD(int mun, int ele)
        {
            List<T_Acta_Detalle> Acta = new List<T_Acta_Detalle>();
            List<SelectListItem> Resultado = new List<SelectListItem>();

            if (ele == 3)
            {
                Acta = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LDistrito => LDistrito.LDistrito).Where(x=> x.LCasilla.LSeccion.MunicipioId == mun && x.IdEleccion == ele).ToList();
                Resultado = Acta.GroupBy(x => x.LCasilla.LSeccion.DistritoId.Value).Select(i => new SelectListItem()
                {
                    Text = i.First().LCasilla.LSeccion.LDistrito.NoDistrito.ToString(),
                    Value = i.Key.ToString()
                 }).ToList();
            }
            else if(ele == 4)
            {
                Acta = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LDemarcacion => LDemarcacion.LDemarcacion).Where(x => x.LCasilla.LSeccion.MunicipioId == mun && x.IdEleccion == ele ).ToList();
                Resultado = Acta.GroupBy(x => x.LCasilla.LSeccion.DemarcacionId.Value).Select(i => new SelectListItem()
                {
                    Text = i.First().LCasilla.LSeccion.LDemarcacion.Nombre.ToString(),
                    Value = i.Key.ToString()
                }).ToList();
            }

            return Resultado;
            
            
        }

        public IEnumerable<T_Acta_Detalle> CapturaCompletaDD(int mun, int ele, int DD)
        {
            List<T_Acta_Detalle> Acta = new List<T_Acta_Detalle>();
            

            if (ele == 3)
            {
                Acta = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LDistrito => LDistrito.LDistrito).Where(x => x.LCasilla.LSeccion.MunicipioId == mun && x.IdEleccion == ele).ToList();
               
            }
            else if (ele == 4)
            {
                Acta = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LDemarcacion => LDemarcacion.LDemarcacion).Where(x => x.LCasilla.LSeccion.MunicipioId == mun && x.IdEleccion == ele && x.LCasilla.LSeccion.DemarcacionId == DD).ToList();
               
            }
            return Acta;
        }

        public void EliminarPaquetes(int casilla)
        {
            var Causales = _db.Causales_recuento.Where(x => x.CasillaId == casilla).ToList();

            foreach (var Actualiza in Causales)
            {
                var nuevo = _db.Causales_recuento.FirstOrDefault(x => x.Id == Actualiza.Id);
                if(nuevo.Causal8 == true)
                {
                    nuevo.Causal8 = false;
                    nuevo.Total_Causales = nuevo.Total_Causales - 1;
                }
                
            }
            var Paquete = _db.Casillas.Where(x => x.Id == casilla).FirstOrDefault();
            Paquete.Recibido = false;
            _db.SaveChanges();


        }


    }
}
