using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class ReporteCausalesVM
    {
        public List<ConCausal> CCausal { get; set; }
        public List <SinCausal> SCausal { get; set; }
        public List <T_Puntos_Recuento> PuntosRecuento { get; set; }
        public List<PuntosRec> ListadoCausales { get; set; }
        public string Municipio { get; set; }
        public string Distrito { get; set; }
        public string Demarcacion { get; set; }
        public string Eleccion { get; set; }
        

        

    }
    public class ConCausal
    {
        public int ID { get; set; }
        public string NoSeccionCC { get; set; }
        public string CasillaCC { get; set; }
        public string NoCausales { get; set; }
    }
    public class SinCausal
    {
        public int ID {get;set;}
        public string NoSeccionSC { get; set; }
        public string CasillaSC { get; set; }
    }
}
