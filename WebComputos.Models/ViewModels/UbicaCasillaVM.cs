using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class UbicaCasillaVM
    {
        public T_Seccion TSeccion { get; set; }
        public int TipoBusqueda { get; set; }
        public int PrimerNum { get; set; }
        public int SegundoNum { get; set; }
        public string Secc { get; set; }
        public string Dem { get; set; }
        public string Dis { get; set; }
        public string Mun { get; set; }
        public int Basica { get; set; }
        public int Contigua { get; set; }
        public int Extra { get; set; }
        public int ExtraCon { get; set; }
        public int Especial { get; set; }
        public int Total { get; set; }
        public IEnumerable<SelectListItem> Municipio { get; set; }
        public IEnumerable<SelectListItem> Distrito { get; set; }
        public IEnumerable<SelectListItem> Demarcacion { get; set; }
        public IEnumerable<SelectListItem> Seccion { get; set; }
        public List<T_Municipio> NombreMun { get; set; }
        public List<ReporteUbica> ReporteCasilla { get; set; }

    }

    public class ReporteUbica
    {
        public string NoSeccion { get; set; }
        public string TipoSeccion { get; set; }
        public int Padron { get; set; }
        public int Lista { get; set; }
        public int? NumMunicipio { get; set; }
        public string TipoCasilla { get; set; }
        public string Domicilio { get; set; }
        public string Ubicacion { get; set; }
        public string Referencia { get; set; }
        public string Lugar { get; set; }
        public int NoCas { get; set; }


    }
}
