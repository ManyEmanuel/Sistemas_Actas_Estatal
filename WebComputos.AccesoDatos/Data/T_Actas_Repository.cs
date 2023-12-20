using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebComputos.AccesoDatos.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace WebComputos.AccesoDatos.Data
{
    public class T_Actas_Repository : Repository<T_Acta>, I_T_Actas_Repository
    {
        private readonly ApplicationDbContext _db;

        public T_Actas_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public IEnumerable<SelectListItem> GetListaActas()
        {
            return _db.Actas.Select(i => new SelectListItem()
            {
                Text = i.IdActa.ToString(),
                Value = i.IdActa.ToString()
            }
            );
        }

        public IEnumerable<SelectListItem> ComprobarDipRP(int Municipio)
        {
            var res = _db.Acta_Detalle_RP.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == 3 && x.LCasilla.LSeccion.MunicipioId == Municipio).Select(x => new SelectListItem()
            {
                Text = x.LCasilla.LSeccion.Seccion,
                Value = x.LCasilla.LSeccion.Id.ToString()

            })
               .Distinct().ToList();
            return res;
        }

        public IEnumerable<SelectListItem> ComprobarRegRP(int Municipio)
        {
            var res = _db.Acta_Detalle_RP.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == 4 && x.LCasilla.LSeccion.MunicipioId == Municipio).Select(x => new SelectListItem()
            {
                Text = x.LCasilla.LSeccion.Seccion,
                Value = x.LCasilla.LSeccion.Id.ToString()

            })
               .Distinct().ToList();
            return res;
        }
        public IEnumerable<SelectListItem> ListaSeccionInfoComByMunicipioDipRP(int Municipio)
        {
            var res = _db.Acta_Detalle_RP.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == 3 && x.CapturadoComplemento == false && x.LCasilla.LSeccion.MunicipioId == Municipio).Select(x => new SelectListItem()
            {
                Text = x.LCasilla.LSeccion.Seccion,
                Value = x.LCasilla.LSeccion.Id.ToString()

            })
               .Distinct().OrderBy(x => x.Text).ToList();
            return res;
        }

        public IEnumerable<SelectListItem> ListaSeccionInfoComByMunicipioRegRP(int Municipio)
        {
            var res = _db.Acta_Detalle_RP.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == 4 && x.CapturadoComplemento == false && x.LCasilla.LSeccion.MunicipioId == Municipio).Select(x => new SelectListItem()
            {
                Text = x.LCasilla.LSeccion.Seccion,
                Value = x.LCasilla.LSeccion.Id.ToString()

            })
               .Distinct().OrderBy(x => x.Text).ToList();
            return res;
        }
    

    public IEnumerable<SelectListItem> ListaSeccionInfoComByMunicipioGob(int Municipio)
        {
            var res = _db.Actas_Detalle.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == 1 && x.CapturadoComplemento == false && x.LCasilla.LSeccion.MunicipioId == Municipio).Select(x => new SelectListItem()
            {
                Text = x.LCasilla.LSeccion.Seccion,
                Value = x.LCasilla.LSeccion.Id.ToString()

            })
                .Distinct().OrderBy(x=> x.Text).ToList();
            return res;
        }

        public IEnumerable<SelectListItem> ListaSeccionInfoComByMunicipioPys(int Municipio)
        {
            var res = _db.Actas_Detalle.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == 2 && x.CapturadoComplemento == false && x.LCasilla.LSeccion.MunicipioId == Municipio).Select(x => new SelectListItem()
            {
                Text = x.LCasilla.LSeccion.Seccion,
                Value = x.LCasilla.LSeccion.Id.ToString()

            })
                .Distinct().OrderBy(x => x.Text).ToList();
            return res;
        }

        public IEnumerable<SelectListItem> ListaSeccionInfoComByMunicipioDip(int Municipio, int Distrito)
        {
            var res = new List<SelectListItem>();
            if(Distrito != 0)
            {
                res = _db.Actas_Detalle.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == 3 && x.CapturadoComplemento == false && x.LCasilla.LSeccion.MunicipioId == Municipio && x.LCasilla.LSeccion.DistritoId == Distrito).Select(x => new SelectListItem()
                {
                    Text = x.LCasilla.LSeccion.Seccion,
                    Value = x.LCasilla.LSeccion.Id.ToString()
                }).Distinct().OrderBy(x => x.Text).ToList();
            }
            else
            {
                res = _db.Actas_Detalle.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == 3 && x.CapturadoComplemento == false && x.LCasilla.LSeccion.MunicipioId == Municipio).Select(x => new SelectListItem()
                {
                    Text = x.LCasilla.LSeccion.Seccion,
                    Value = x.LCasilla.LSeccion.Id.ToString()
                }).Distinct().OrderBy(x => x.Text).ToList();

            }

            

            return res;
        }

        public IEnumerable<SelectListItem> ListaSeccionInfoComByMunicipioReg(int Municipio, int Demarcacion)
        {
            var res = new List<SelectListItem>();
            if(Demarcacion != 0)
            {
                res = _db.Actas_Detalle.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == 4 && x.CapturadoComplemento == false && x.LCasilla.LSeccion.MunicipioId == Municipio && x.LCasilla.LSeccion.DemarcacionId == Demarcacion).Select(x => new SelectListItem()
                {
                    Text = x.LCasilla.LSeccion.Seccion,
                    Value = x.LCasilla.LSeccion.Id.ToString()

                }).Distinct().OrderBy(x => x.Text).ToList();
            }
            else
            {
                res = _db.Actas_Detalle.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.IdEleccion == 4 && x.CapturadoComplemento == false && x.LCasilla.LSeccion.MunicipioId == Municipio).Select(x => new SelectListItem()
                {
                    Text = x.LCasilla.LSeccion.Seccion,
                    Value = x.LCasilla.LSeccion.Id.ToString()

                }).Distinct().OrderBy(x => x.Text).ToList();

            }
            
            return res;
        }

        public IEnumerable<AvancePaquetes> GetPorcentajeDocumentos(int id)
        {
            List<AvancePaquetes> lst = new List<AvancePaquetes>();
            string[] Documento = { "Paquete Electoral", "Acta de Gubernatura", "Acta de Ayuntamientos", "Acta de Diputaciones", "Acta de Regidurías" };

            if (id != 0)
            {
                var Deta = _db.Actas_Detalle.Include(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.LCasilla.MunicipioId == id && x.LCasilla.Activo == true && x.CapturadoComplemento == true && x.CapturadoVotos == true).ToList();
                var EspCap = _db.Acta_Detalle_RP.Include(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.LCasilla.MunicipioId == id && x.LCasilla.Activo == true && x.CapturadoComplemento == true && x.CapturadoVotos == true).ToList();
                var Esp = _db.Actas_Detalle.Include(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.LCasilla.MunicipioId == id && x.LCasilla.Activo == true && x.LCasilla.TipoCasillaId == 4).ToList();
                var CasillaDetalle = _db.Casillas.Where(x => x.MunicipioId == id && x.Activo == true).ToList();
                var Rec = _db.Recepcion_Paquete.Include(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.LCasilla.MunicipioId == id && x.LCasilla.Activo == true).ToList();

                for (int i = 0; i <= 4; i++)
                {
                    AvancePaquetes avance = new AvancePaquetes();
                    if (i == 0)
                    {
                        double Recibidas = Rec.Count();
                        double Faltantes = CasillaDetalle.Count() - Recibidas;
                        double Porcentaje = (Recibidas * 100) / CasillaDetalle.Count();
                        var Nombre = Documento[i];
                        avance.Total = CasillaDetalle.Count();
                        avance.Recibidos = Recibidas;
                        avance.Faltantes = Faltantes;
                        string por = Porcentaje.ToString("N2");
                        avance.Porcentaje = Convert.ToDouble(por);
                        avance.Municipio = Nombre;
                        avance.IdMunicipio = i + 1;
                        lst.Add(avance);
                    }
                    else if (i == 3 || i == 4)
                    {

                        double total = CasillaDetalle.Count() + Esp.Where(x => x.IdEleccion == i).Count();
                        double Recibidas = Deta.Where(x => x.IdEleccion == i).Count() + EspCap.Where(x => x.IdEleccion == i).Count();
                        double Faltantes = total - Recibidas;
                        double Porcentaje = (Recibidas * 100) / total;
                        var Nombre = Documento[i];
                        avance.Total = total;
                        avance.Recibidos = Recibidas;
                        avance.Faltantes = Faltantes;
                        string por = Porcentaje.ToString("N2");
                        avance.Porcentaje = Convert.ToDouble(por);
                        avance.Municipio = Nombre;
                        avance.IdMunicipio = i + 1;
                        lst.Add(avance);
                    }
                    else
                    {

                        double Recibidas = Deta.Where(x => x.IdEleccion == i).Count();
                        double Faltantes = CasillaDetalle.Count() - Recibidas;
                        double Porcentaje = (Recibidas * 100) / CasillaDetalle.Count();
                        var Nombre = Documento[i];
                        avance.Total = CasillaDetalle.Count();
                        avance.Recibidos = Recibidas;
                        avance.Faltantes = Faltantes;
                        string por = Porcentaje.ToString("N2");
                        avance.Porcentaje = Convert.ToDouble(por);
                        avance.Municipio = Nombre;
                        avance.IdMunicipio = i + 1;
                        lst.Add(avance);
                    }
                }
            }
            else
            {
                var CasillaDetalle = _db.Casillas.Where(x => x.Activo == true).ToList();

                for (int i = 0; i <= 4; i++)
                {
                    AvancePaquetes avance = new AvancePaquetes();
                    if (i == 0)
                    {
                        var Rece = _db.Recepcion_Paquete.ToList();
                        double Recibidas = Rece.Count();
                        double Faltantes = CasillaDetalle.Count() - Recibidas;
                        double Porcentaje = (Recibidas * 100) / CasillaDetalle.Count();
                        var Nombre = Documento[i];
                        avance.Total = CasillaDetalle.Count();
                        avance.Recibidos = Recibidas;
                        avance.Faltantes = Faltantes;
                        string por = Porcentaje.ToString("N2");
                        avance.Porcentaje = Convert.ToDouble(por);
                        avance.Municipio = Nombre;
                        avance.IdMunicipio = i + 1;
                        lst.Add(avance);
                    }
                    else if (i == 3 || i == 4)
                    {
                        var Capturadas = _db.Actas_Detalle.Include(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.IdEleccion == i && x.CapturadoComplemento == true && x.CapturadoVotos == true).ToList();
                        var Especiales = _db.Casillas.Where(x => x.TipoCasillaId == 4).ToList();
                        var ldaEspecial = _db.Acta_Detalle_RP.Include(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.IdEleccion == i && x.CapturadoComplemento == true && x.CapturadoVotos == true).ToList();
                        double total = CasillaDetalle.Count() + Especiales.Count();
                        double Recibidas = Capturadas.Count() + ldaEspecial.Count();
                        double Faltantes = total - Recibidas;
                        double Porcentaje = (Recibidas * 100) / total;
                        var Nombre = Documento[i];
                        avance.Total = total;
                        avance.Recibidos = Recibidas;
                        avance.Faltantes = Faltantes;
                        string por = Porcentaje.ToString("N2");
                        avance.Porcentaje = Convert.ToDouble(por);
                        avance.Municipio = Nombre;
                        avance.IdMunicipio = i + 1;
                        lst.Add(avance);
                    }
                    else
                    {
                        var lda = _db.Actas_Detalle.Include(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.IdEleccion == i && x.CapturadoComplemento == true && x.CapturadoVotos == true).ToList();
                        double Recibidas = lda.Count();
                        double Faltantes = CasillaDetalle.Count() - Recibidas;
                        double Porcentaje = (Recibidas * 100) / CasillaDetalle.Count();
                        var Nombre = Documento[i];
                        avance.Total = CasillaDetalle.Count();
                        avance.Recibidos = Recibidas;
                        avance.Faltantes = Faltantes;
                        string por = Porcentaje.ToString("N2");
                        avance.Porcentaje = Convert.ToDouble(por);
                        avance.Municipio = Nombre;
                        avance.IdMunicipio = i + 1;
                        lst.Add(avance);
                    }
                }
            }

            return lst;
        }


        public IEnumerable<AvanceEstatal> ListaAvanceEstatal()
        {
            List<AvanceEstatal> lstava = new List<AvanceEstatal>();
            for (int i = 1; i <= 20; i++)
            {
                AvanceEstatal avaest = new AvanceEstatal();
                var Municipio = _db.Municipios.Where(x => x.Id == i).FirstOrDefault();
                var Total = _db.Casillas.Where(x => x.MunicipioId == i && x.Activo == true).ToList();
                var Rec = _db.Recepcion_Paquete.Include(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.LCasilla.MunicipioId == i && x.LCasilla.Activo == true);
                var TotalEspecial = _db.Casillas.Where(x => x.MunicipioId == i && x.Activo == true && x.TipoCasillaId == 4).ToList();
                double Recibidas = Rec.Count();
                double Porcentaje = (Recibidas * 100) / Total.Count();
                avaest.Municipio = Municipio.Municipio;
                avaest.idMunicipio = Municipio.Id;
                avaest.Tpaquete = Recibidas + " de " + Total.Count();
                string por = Porcentaje.ToString("N2");
                avaest.Gpaquete = Convert.ToDouble(por);
                for (int j = 1; j <= 4; j++)
                {

                    var detactas = _db.Actas_Detalle.Include(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.IdEleccion == j && x.CapturadoComplemento == true && x.CapturadoVotos == true && x.LCasilla.MunicipioId == i).ToList();
                    if (j == 1)
                    {

                        double RecibidasE = detactas.Count();
                        double PorcentajeE = (RecibidasE * 100) / Total.Count();
                        avaest.Tgobernador = RecibidasE + " de " + Total.Count();
                        string pore = PorcentajeE.ToString("N2");
                        avaest.Ggobernador = Convert.ToDouble(pore);
                    }
                    else if (j == 2)
                    {
                        double RecibidasE = detactas.Count();
                        double PorcentajeE = (RecibidasE * 100) / Total.Count();
                        avaest.Tpys = RecibidasE + " de " + Total.Count();
                        string pore = PorcentajeE.ToString("N2");
                        avaest.Gpys = Convert.ToDouble(pore);
                    }
                    else if (j == 3)
                    {
                        var detactasEsp = _db.Acta_Detalle_RP.Include(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.IdEleccion == j && x.CapturadoComplemento == true && x.CapturadoVotos == true && x.LCasilla.TipoCasillaId == 4 && x.LCasilla.MunicipioId == i).ToList();
                        double EspTotal = Total.Count() + TotalEspecial.Count();
                        double RecibidasE = detactas.Count() + detactasEsp.Count();
                        double PorcentajeE = (RecibidasE * 100) / EspTotal;
                        avaest.Tdiputado = RecibidasE + " de " + EspTotal;
                        string pore = PorcentajeE.ToString("N2");
                        avaest.Gdiputado = Convert.ToDouble(pore);
                    }
                    else if (j == 4)
                    {
                        var detactasEsp = _db.Acta_Detalle_RP.Include(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.IdEleccion == j && x.CapturadoComplemento == true && x.CapturadoVotos == true && x.LCasilla.TipoCasillaId == 4 && x.LCasilla.MunicipioId == i).ToList();
                        double EspTotal = Total.Count() + TotalEspecial.Count();
                        double RecibidasE = detactas.Count() + detactasEsp.Count();
                        double PorcentajeE = (RecibidasE * 100) / EspTotal;
                        avaest.Tregidor = RecibidasE + " de " + EspTotal;
                        string pore = PorcentajeE.ToString("N2");
                        avaest.Gregidor = Convert.ToDouble(pore);
                    }
                }
                lstava.Add(avaest);
            }
            return lstava;
        }

        public IEnumerable<T_Acta_Detalle> RegistroCausal(int id, int estatus)
        {
            var prueba2 = _db.Actas.Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.LActaDetalle.IdActaDetalle == id).FirstOrDefault();
            int sobrantes = prueba2.Sobrantes;
            int ciudadanos = prueba2.VotosCiudadanos + prueba2.VotosRepresentantes;
            int boletas = prueba2.LActaDetalle.LCasilla.Boletas_Entregadas;

            if (_db.Causales_recuento.Where(x => x.CasillaId == prueba2.LActaDetalle.IdCasilla && x.TipoEleccionId == prueba2.LActaDetalle.IdEleccion && x.RP == false).Count() != 0)
            {
                var Causal = _db.Causales_recuento.Where(x => x.CasillaId == prueba2.LActaDetalle.IdCasilla && x.TipoEleccionId == prueba2.LActaDetalle.IdEleccion).FirstOrDefault();
                if (prueba2.LActaDetalle.CapturadoVotos == true)
                {
                    var ConVotos = _db.Votos_Actas.Where(x => x.IdActaDetalle == id).FirstOrDefault();
                    if (estatus == 3)
                    {
                        Causal.Causal1 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (estatus == 7)
                    {
                        Causal.Causal6 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (estatus == 9)
                    {

                        Causal.Causal7 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if ((sobrantes + ciudadanos) > boletas)
                    {
                        Causal.Causal10 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (ciudadanos != ConVotos.TotalSistema)
                    {
                        Causal.Causal9 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if ((sobrantes + ConVotos.TotalSistema) > boletas)
                    {
                        Causal.Causal11 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                }
                else
                {
                    if (estatus == 3)
                    {
                        Causal.Causal1 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (estatus == 7)
                    {
                        Causal.Causal6 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (estatus == 9)
                    {

                        Causal.Causal7 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if ((sobrantes + ciudadanos) > boletas)
                    {
                        Causal.Causal10 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                }
                _db.SaveChanges();
            }
            else
            {
                T_Causal_Recuento caus = new T_Causal_Recuento();
                int totcau = 0;
                if (estatus == 3)
                {
                    caus.Causal1 = true;
                    totcau = totcau + 1;
                }
                if (estatus == 7)
                {
                    caus.Causal6 = true;
                    totcau = totcau + 1;
                }
                if (estatus == 9)
                {
                    caus.Causal7 = true;
                    totcau = totcau + 1;
                }
                if ((sobrantes + ciudadanos) > boletas)
                {
                    caus.Causal10 = true;
                    totcau = totcau + 1;
                }

                caus.CasillaId = prueba2.LActaDetalle.IdCasilla;
                caus.TipoEleccionId = prueba2.LActaDetalle.IdEleccion;
                caus.Causal2 = false;
                caus.Causal3 = false;
                caus.Causal4 = false;
                caus.Causal5 = false;
                caus.Causal8 = false;
                caus.Causal9 = false;
                caus.Causal11 = false;
                caus.Recuento_Total = false;
                caus.Total_Causales = totcau;
                var computos = _db.Detalle_Acta_Computos.Where(x => x.TipoEleccionId == prueba2.LActaDetalle.IdEleccion && x.CasillaId == prueba2.LActaDetalle.IdCasilla).FirstOrDefault();
                caus.DetalleActaComputoId = computos.Id;
                _db.Causales_recuento.Add(caus);
                _db.SaveChanges();
            }
            return null;
        }

        public IEnumerable<T_Acta_Detalle> RegistroCausalRP(int id, int estatus)
        {
            var prueba2 = _db.Acta_RP.Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.LActaDetalle.IdActaDetalle == id).FirstOrDefault();
            int sobrantes = prueba2.Sobrantes;
            int ciudadanos = prueba2.VotosCiudadanos;
            int boletas = prueba2.LActaDetalle.LCasilla.Boletas_Entregadas;

            if (_db.Causales_recuento.Where(x => x.CasillaId == prueba2.LActaDetalle.IdCasilla && x.TipoEleccionId == prueba2.LActaDetalle.IdEleccion && x.RP == true).Count() != 0)
            {
                var Causal = _db.Causales_recuento.Where(x => x.CasillaId == prueba2.LActaDetalle.IdCasilla && x.TipoEleccionId == prueba2.LActaDetalle.IdEleccion && x.RP== true).FirstOrDefault();
                if (prueba2.LActaDetalle.CapturadoVotos == true)
                {
                    var ConVotos = _db.Votos_Acta_RP.Where(x => x.IdActaDetalle == id).FirstOrDefault();
                    if (estatus == 3)
                    {
                        Causal.Causal1 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (estatus == 7)
                    {
                        Causal.Causal6 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (estatus == 9)
                    {

                        Causal.Causal7 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if ((sobrantes + ciudadanos) > boletas)
                    {
                        Causal.Causal10 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (ciudadanos != ConVotos.TotalSistema)
                    {
                        Causal.Causal9 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if ((sobrantes + ConVotos.TotalSistema) > boletas)
                    {
                        Causal.Causal11 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                }
                else
                {
                    if (estatus == 3)
                    {
                        Causal.Causal1 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (estatus == 7)
                    {
                        Causal.Causal6 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if (estatus == 9)
                    {

                        Causal.Causal7 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                    if ((sobrantes + ciudadanos) > boletas)
                    {
                        Causal.Causal10 = true;
                        Causal.Total_Causales = Causal.Total_Causales + 1;
                    }
                }
                _db.SaveChanges();
            }
            else
            {
                T_Causal_Recuento caus = new T_Causal_Recuento();
                int totcau = 0;
                if (estatus == 3)
                {
                    caus.Causal1 = true;
                    totcau = totcau + 1;
                }
                if (estatus == 7)
                {
                    caus.Causal6 = true;
                    totcau = totcau + 1;
                }
                if (estatus == 9)
                {
                    caus.Causal7 = true;
                    totcau = totcau + 1;
                }
                if ((sobrantes + ciudadanos) > boletas)
                {
                    caus.Causal10 = true;
                    totcau = totcau + 1;
                }

                caus.CasillaId = prueba2.LActaDetalle.IdCasilla;
                caus.TipoEleccionId = prueba2.LActaDetalle.IdEleccion;
                caus.Causal2 = false;
                caus.Causal3 = false;
                caus.Causal4 = false;
                caus.Causal5 = false;
                caus.Causal8 = false;
                caus.Causal9 = false;
                caus.Causal11 = false;
                caus.Recuento_Total = false;
                caus.Total_Causales = totcau;
                var computos = _db.Detalle_Acta_Computos_RP.Where(x => x.TipoEleccionId == prueba2.LActaDetalle.IdEleccion && x.CasillaId == prueba2.LActaDetalle.IdCasilla).FirstOrDefault();
                caus.DetalleActaComputoRPId = computos.Id;
                caus.RP = true;
                _db.Causales_recuento.Add(caus);
                _db.SaveChanges();
            }
            return null;
        }

        public IEnumerable<T_Acta_Detalle> CargarCombo(int id, int mun, int ele)
        {
            var lstda = _db.Actas_Detalle.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LCasilla.SeccionId == id && x.IdEleccion == ele && x.CapturadoComplemento == false && x.LCasilla.LSeccion.MunicipioId == mun).OrderBy(x=> x.LCasilla.TipoCasillaId).ToList();

            return lstda;
        }

        public IEnumerable<T_Acta_Detalle_RP> CargarComboRP(int id, int mun, int ele)
        {
            var lstda = _db.Acta_Detalle_RP.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LCasilla.SeccionId == id && x.IdEleccion == ele && x.CapturadoComplemento == false && x.LCasilla.LSeccion.MunicipioId == mun).ToList();

            return lstda;
        }

        public IEnumerable<T_Acta> CargarTabla(int Mun, int Ele, int DD)
        {
            var lstda = new List<T_Acta>(); 
            if(Ele == 3)
            {
                if(Mun == 0)
                {
                    lstda = _db.Actas.Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoComplemento == true && x.LActaDetalle.IdEleccion == Ele && x.LActaDetalle.LCasilla.LSeccion.DistritoId == DD).Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LtipoEleccion => LtipoEleccion.LTipoEleccion).Where(x=> x.Solicitud == 0).ToList();
                }
                else
                {
                    if(DD == 0)
                    {
                        lstda = _db.Actas.Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoComplemento == true && x.LActaDetalle.LCasilla.LSeccion.MunicipioId == Mun && x.LActaDetalle.IdEleccion == Ele).Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LtipoEleccion => LtipoEleccion.LTipoEleccion).Where(x => x.Solicitud == 0).ToList();
                    }
                    else
                    {
                        lstda = _db.Actas.Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoComplemento == true && x.LActaDetalle.LCasilla.LSeccion.MunicipioId == Mun && x.LActaDetalle.IdEleccion == Ele && x.LActaDetalle.LCasilla.LSeccion.DistritoId == DD).Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LtipoEleccion => LtipoEleccion.LTipoEleccion).Where(x => x.Solicitud == 0).ToList();
                    }
                    
                }
            }
            else if (Ele == 4)
            {
                if(Mun == 0)
                {
                    lstda = _db.Actas.Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoComplemento == true && x.LActaDetalle.IdEleccion == Ele && x.LActaDetalle.LCasilla.LSeccion.DemarcacionId == DD).Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LtipoEleccion => LtipoEleccion.LTipoEleccion).Where(x => x.Solicitud == 0).ToList();
                }
                else
                {
                    if(DD == 0)
                    {
                        lstda = _db.Actas.Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoComplemento == true && x.LActaDetalle.LCasilla.LSeccion.MunicipioId == Mun && x.LActaDetalle.IdEleccion == Ele).Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LtipoEleccion => LtipoEleccion.LTipoEleccion).Where(x => x.Solicitud == 0).ToList();
                    }
                    else
                    {
                        lstda = _db.Actas.Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoComplemento == true && x.LActaDetalle.LCasilla.LSeccion.MunicipioId == Mun && x.LActaDetalle.IdEleccion == Ele && x.LActaDetalle.LCasilla.LSeccion.DemarcacionId == DD).Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LtipoEleccion => LtipoEleccion.LTipoEleccion).Where(x => x.Solicitud == 0).ToList();
                    }
                    
                }
                
            }
            else
            {
                if(Mun == 0)
                {
                    lstda = _db.Actas.Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoComplemento == true && x.LActaDetalle.IdEleccion == Ele).Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LtipoEleccion => LtipoEleccion.LTipoEleccion).Where(x => x.Solicitud == 0).ToList();
                }
                else
                {
                    lstda = _db.Actas.Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoComplemento == true && x.LActaDetalle.LCasilla.LSeccion.MunicipioId == Mun && x.LActaDetalle.IdEleccion == Ele).Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LtipoEleccion => LtipoEleccion.LTipoEleccion).Where(x => x.Solicitud == 0).ToList();
                }
            }
            


            return lstda;
        }

        public IEnumerable<DocumentosEntregados> ListaDocumentosEntregados(int id)
        {
            List<DocumentosEntregados> lstdoc = new List<DocumentosEntregados>();
            List<T_Recepcion_Paquete> lstpaq = new List<T_Recepcion_Paquete>();
            var CasillaDetalle = _db.Casillas.Include(LSeccion => LSeccion.LSeccion).Where(x => x.MunicipioId == id).ToList();
            var Test = _db.Recepcion_Paquete.Include(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.LCasilla.MunicipioId == id).ToList();
            var Deta = _db.Actas_Detalle.Include(LCasillaDet => LCasillaDet.LCasilla).Where(x => x.LCasilla.MunicipioId == id && x.CapturadoComplemento == true && x.CapturadoVotos == true).ToList();


            foreach (var item in CasillaDetalle)
            {
                DocumentosEntregados lst = new DocumentosEntregados();
                lst.Seccion = item.LSeccion.Seccion;
                lst.Casilla = item.Nombre;
                if (Test.Where(x => x.IdCasilla == item.Id).Count() != 0)

                {
                    lst.Paquetes = "Si";
                }
                else
                {
                    lst.Paquetes = "No";
                }
                for (int i = 1; i <= 4; i++)
                {
                    if (i == 1)
                    {
                        if (Deta.Where(x => x.IdEleccion == i && x.IdCasilla == item.Id).Count() != 0)
                        {
                            lst.Gobernador = "Si";
                        }
                        else
                        {
                            lst.Gobernador = "No";
                        }
                    }
                    else if (i == 2)
                    {
                        if (Deta.Where(x => x.IdEleccion == i && x.IdCasilla == item.Id).Count() != 0)
                        {
                            lst.Pys = "Si";
                        }
                        else
                        {
                            lst.Pys = "No";
                        }
                    }
                    else if (i == 3)
                    {
                        if (Deta.Where(x => x.IdEleccion == i && x.IdCasilla == item.Id).Count() != 0)
                        {
                            lst.Diputado = "Si";
                        }
                        else
                        {
                            lst.Diputado = "No";
                        }
                    }
                    else if (i == 4)
                    {
                        if (Deta.Where(x => x.IdEleccion == i && x.IdCasilla == item.Id).Count() != 0)
                        {
                            lst.Regidor = "Si";
                        }
                        else
                        {
                            lst.Regidor = "No";
                        }
                    }
                }
                lstdoc.Add(lst);
            }
            return lstdoc;
        }

        public IEnumerable<SelectListItem> ListaSeccion(int Municipio, int Eleccion, int DR)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            if (Eleccion == 3)
            {
                if(DR != 0)
                {
                    lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.CapturadoVotos == false && x.LCasilla.LSeccion.MunicipioId == Municipio && x.IdEleccion == Eleccion && x.LCasilla.LSeccion.DistritoId == DR).Select(i => new SelectListItem()
                    {
                        Text = i.LCasilla.LSeccion.Seccion,
                        Value = i.LCasilla.LSeccion.Id.ToString()
                    }).Distinct().OrderBy(x => x.Text).ToList();
                }
                else
                {
                    lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.CapturadoVotos == false && x.LCasilla.LSeccion.MunicipioId == Municipio && x.IdEleccion == Eleccion).Select(i => new SelectListItem()
                    {
                        Text = i.LCasilla.LSeccion.Seccion,
                        Value = i.LCasilla.LSeccion.Id.ToString()
                    }).Distinct().OrderBy(x => x.Text).ToList();
                }
                
            }
            else if (Eleccion == 4)
            {
                if(DR != 0)
                {
                    lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.CapturadoVotos == false && x.LCasilla.LSeccion.MunicipioId == Municipio && x.IdEleccion == Eleccion && x.LCasilla.LSeccion.DemarcacionId == DR).Select(i => new SelectListItem()
                    {
                        Text = i.LCasilla.LSeccion.Seccion,
                        Value = i.LCasilla.LSeccion.Id.ToString()
                    }).Distinct().OrderBy(x => x.Text).ToList();
                }
                else
                {
                    lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.CapturadoVotos == false && x.LCasilla.LSeccion.MunicipioId == Municipio && x.IdEleccion == Eleccion).Select(i => new SelectListItem()
                    {
                        Text = i.LCasilla.LSeccion.Seccion,
                        Value = i.LCasilla.LSeccion.Id.ToString()
                    }).Distinct().OrderBy(x => x.Text).ToList();
                }
                

            }
            else
            {
                lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.CapturadoVotos == false && x.LCasilla.LSeccion.MunicipioId == Municipio && x.IdEleccion == Eleccion).Select(i => new SelectListItem()
                {
                    Text = i.LCasilla.LSeccion.Seccion,
                    Value = i.LCasilla.LSeccion.Id.ToString()
                }).Distinct().OrderBy(x=> x.Text).ToList();

            }


            return lst;
        }

        public IEnumerable<SelectListItem> ListaSeccionRP(int Municipio, int Eleccion)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            if (Eleccion == 3)
            {
                lst = _db.Acta_Detalle_RP.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.CapturadoVotos == false && x.LCasilla.LSeccion.MunicipioId == Municipio && x.IdEleccion == Eleccion ).Select(i => new SelectListItem()
                {
                    Text = i.LCasilla.LSeccion.Seccion,
                    Value = i.LCasilla.LSeccion.Id.ToString()
                }).Distinct().ToList();
            }
            else if (Eleccion == 4)
            {
                lst = _db.Acta_Detalle_RP.Include(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.CapturadoVotos == false && x.LCasilla.LSeccion.MunicipioId == Municipio && x.IdEleccion == Eleccion ).Select(i => new SelectListItem()
                {
                    Text = i.LCasilla.LSeccion.Seccion,
                    Value = i.LCasilla.LSeccion.Id.ToString()
                }).Distinct().ToList();

            }
            
            return lst;
        }

        public IEnumerable<SelectListItem> ListaCasilla(int Seccion, int Eleccion)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            lst = _db.Actas_Detalle.Include(LCasilla => LCasilla.LCasilla).Where(x => x.CapturadoVotos == false && x.IdEleccion == Eleccion && x.LCasilla.SeccionId == Seccion).Select(i => new SelectListItem()
            {
                Text = i.LCasilla.Nombre,
                Value = i.IdActaDetalle.ToString()
            }).ToList();
            return lst;
        }

        public IEnumerable<SelectListItem> ListaCasillaRP(int Seccion, int Eleccion)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            lst = _db.Acta_Detalle_RP.Include(LCasilla => LCasilla.LCasilla).Where(x => x.CapturadoVotos == false && x.IdEleccion == Eleccion && x.LCasilla.SeccionId == Seccion).Select(i => new SelectListItem()
            {
                Text = i.LCasilla.Nombre,
                Value = i.IdActaDetalle.ToString()
            }).ToList();
            return lst;
        }

        public IEnumerable<ElementosListas> CargarTablasElecciones(int Municipio, int Eleccion, int DR)
        {
            List<ElementosListas> lst = new List<ElementosListas>();
            var tablas = new List<T_Votos_Acta>();
            if (Municipio == 0)
            {
                tablas = _db.Votos_Actas.Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x=>  x.LActaDetalle.CapturadoVotos == true && x.Solicitud == 0).ToList();
            } 
            else
            {
                tablas = _db.Votos_Actas.Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio && x.LActaDetalle.CapturadoVotos == true && x.Solicitud == 0).ToList();
            }
            

            if (Eleccion == 3)
            {
                if(DR != 0)
                {
                    lst = tablas.Where(x => x.LActaDetalle.IdEleccion == Eleccion && x.LActaDetalle.LCasilla.LSeccion.DistritoId == DR).Select(i => new ElementosListas()
                    {
                        seccion = i.LActaDetalle.LCasilla.LSeccion.Seccion,
                        casilla = i.LActaDetalle.LCasilla.Nombre,
                        idreg = i.IdRegistroVotos
                    }).ToList();
                }
                else
                {
                    lst = tablas.Where(x => x.LActaDetalle.IdEleccion == Eleccion).Select(i => new ElementosListas()
                    {
                        seccion = i.LActaDetalle.LCasilla.LSeccion.Seccion,
                        casilla = i.LActaDetalle.LCasilla.Nombre,
                        idreg = i.IdRegistroVotos
                    }).ToList();
                }
                
            }
            else if (Eleccion == 4)
            {
                if (DR != 0)
                {
                    lst = tablas.Where(x => x.LActaDetalle.IdEleccion == Eleccion && x.LActaDetalle.LCasilla.LSeccion.DemarcacionId == DR).Select(i => new ElementosListas()
                    {
                        seccion = i.LActaDetalle.LCasilla.LSeccion.Seccion,
                        casilla = i.LActaDetalle.LCasilla.Nombre,
                        idreg = i.IdRegistroVotos
                    }).ToList();
                }
                else
                {
                    lst = tablas.Where(x => x.LActaDetalle.IdEleccion == Eleccion).Select(i => new ElementosListas()
                    {
                        seccion = i.LActaDetalle.LCasilla.LSeccion.Seccion,
                        casilla = i.LActaDetalle.LCasilla.Nombre,
                        idreg = i.IdRegistroVotos
                    }).ToList();
                }
                
            }
            else
            {
                lst = tablas.Where(x => x.LActaDetalle.IdEleccion == Eleccion).Select(i => new ElementosListas()
                {
                    seccion = i.LActaDetalle.LCasilla.LSeccion.Seccion,
                    casilla = i.LActaDetalle.LCasilla.Nombre,
                    idreg = i.IdRegistroVotos
                }).ToList();
            }


            return lst;
        }

        public IEnumerable<ElementosListas> CargarTablasEleccionesRP(int Municipio, int Eleccion)
        {
            List<ElementosListas> lst = new List<ElementosListas>();
            var tablas = _db.Votos_Acta_RP.Include(LActaDetalle => LActaDetalle.LActaDetalle).ThenInclude(LCasilla => LCasilla.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.LCasilla.LSeccion.MunicipioId == Municipio && x.LActaDetalle.CapturadoVotos == true).ToList();

            if (Eleccion == 3)
            {
                lst = tablas.Where(x => x.LActaDetalle.IdEleccion == Eleccion ).Select(i => new ElementosListas()
                {
                    seccion = i.LActaDetalle.LCasilla.LSeccion.Seccion,
                    casilla = i.LActaDetalle.LCasilla.Nombre,
                    idreg = i.IdRegistroVotosRP
                }).ToList();
            }
            else if (Eleccion == 4)
            {
                lst = tablas.Where(x => x.LActaDetalle.IdEleccion == Eleccion ).Select(i => new ElementosListas()
                {
                    seccion = i.LActaDetalle.LCasilla.LSeccion.Seccion,
                    casilla = i.LActaDetalle.LCasilla.Nombre,
                    idreg = i.IdRegistroVotosRP
                }).ToList();
            }            
            return lst;
        }

        public void EliminarComplementaria(int CasillaDetalle ,int Eleccion)
        {
            var casilla = _db.Actas_Detalle.FirstOrDefault(x => x.IdActaDetalle == CasillaDetalle);
            var causal = _db.Causales_recuento.Where(x => x.CasillaId == casilla.IdCasilla && x.TipoEleccionId == Eleccion).FirstOrDefault();
            casilla.CapturadoComplemento = false;
            if (causal.Causal1 == true)
            {
                causal.Causal1 = false;
                causal.Total_Causales = causal.Total_Causales - 1;
            }
            if (causal.Causal6 == true)
            {
                causal.Causal6 = false;
                causal.Total_Causales = causal.Total_Causales - 1;
            }
            if (causal.Causal7 == true)
            {
                causal.Causal7 = false;
                causal.Total_Causales = causal.Total_Causales - 1;
            }
            if (causal.Causal9 == true)
            {
                causal.Causal9 = false;
                causal.Total_Causales = causal.Total_Causales - 1;
            }
            if (causal.Causal10 == true)
            {
                causal.Causal10 = false;
                causal.Total_Causales = causal.Total_Causales - 1;
            }
            if (causal.Causal11 == true)
            {
                causal.Causal11 = false;
                causal.Total_Causales = causal.Total_Causales - 1;
            }
            _db.SaveChanges();

        }

        public IEnumerable<T_Acta> CargarTablaComplementaria(int Ele)
        {
           var lstda = _db.Actas.Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).Where(x => x.LActaDetalle.CapturadoComplemento == true && x.LActaDetalle.IdEleccion == Ele).Include(LDetalleActas => LDetalleActas.LActaDetalle).ThenInclude(LtipoEleccion => LtipoEleccion.LTipoEleccion).ToList();

            return lstda;
        }

        public IEnumerable<T_HistorialModificaciones> GetListaComplementariaModificacion()
        {
            var res = _db.HistorialModificaciones.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LMunicipio => LMunicipio.LMunicipio).Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(Ltipo => Ltipo.LTipoCasilla).Where(x => x.Concepto == 1 && x.Estatus == 0 && x.Complementaria != 0).Include(Lusuario => Lusuario.LUsuario).ToList();
            return res;
        }

        public IEnumerable<T_HistorialModificaciones> GetListaComplementariaHistorial()
        {
            var res = _db.HistorialModificaciones.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LMunicipio => LMunicipio.LMunicipio).Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(Ltipo => Ltipo.LTipoCasilla).Where(x => x.Concepto == 1 && x.Estatus != 0 && x.Complementaria != 0).Include(Lusuario => Lusuario.LUsuario).ToList();
            return res;
        }

        public IEnumerable<T_HistorialModificaciones> GetListaVotosModificacion()
        {
            var res = _db.HistorialModificaciones.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LMunicipio => LMunicipio.LMunicipio).Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(Ltipo => Ltipo.LTipoCasilla).Where(x => x.Concepto == 2 && x.Estatus == 0 && x.Votos != 0).Include(Lusuario => Lusuario.LUsuario).ToList();
            return res;
        }

        public IEnumerable<T_HistorialModificaciones> GetListaVotosHistorial()
        {
            var res = _db.HistorialModificaciones.Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(LSeccion => LSeccion.LSeccion).ThenInclude(LMunicipio => LMunicipio.LMunicipio).Include(LCasillaDet => LCasillaDet.LCasilla).ThenInclude(Ltipo => Ltipo.LTipoCasilla).Where(x => x.Concepto == 2 && x.Estatus != 0 && x.Votos != 0).Include(Lusuario => Lusuario.LUsuario).ToList();
            return res;
        }
    }


}
