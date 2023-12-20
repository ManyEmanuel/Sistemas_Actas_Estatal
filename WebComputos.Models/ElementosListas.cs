using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models
{
    public class ElementosListas
    {
        public int value { get; set; }
        public int idreg { get; set; }
        public string text { get; set; }
        public int value1 { get; set; }
        public string text1 { get; set; }
        public string seccion { get; set; }
        public string casilla { get; set; }
        public int? Distrito { get; set; }
        public int? Demarcacion { get; set; }
        public int? Votos { get; set; }
        public int? Partido { get; set; }
        public int? Coalicion { get; set; }
        public int? Independiente { get; set; }
        public int? Combinacion { get; set; }
        public int Nulos { get; set; }
        public int NoRegistrados { get; set; }
        public int Total { get; set; }


        public bool cau1 { get; set; }
        public bool cau2 { get; set; }
        public bool cau3 { get; set; }
        public bool cau4 { get; set; }
        public bool cau5 { get; set; }
        public bool cau6 { get; set; }
        public bool cau7 { get; set; }
        public bool cau8 { get; set; }
        public bool cau9 { get; set; }
        public bool cau10 { get; set; }
        public bool cau11 { get; set; }
        public int numcau { get; set; }
        public int idcau { get; set; }
        public DateTime recep { get; set; }

        public int cont { get; set; }
        public int idr { get; set; }

    }
    public class AvancePaquetes
    {
        public string Municipio { get; set; }
        public double Total { get; set; }
        public double Recibidos { get; set; }
        public double Faltantes { get; set; }
        public double Porcentaje { get; set; }
        public int IdMunicipio { get; set; }
    }

    public class DetallePaquete
    {
        public string Casilla { get; set; }
        public string Seccion { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Estatus { get; set; }

    }

    public class DocumentosEntregados
    {
        public string Seccion { get; set; }
        public string Casilla { get; set; }
        public string Paquetes { get; set; }
        public string Gobernador { get; set; }
        public string Pys { get; set; }
        public string Diputado { get; set; }
        public string Regidor { get; set; }


    }

    public class AvanceEstatal
    {
        public string Municipio { get; set; }
        public string Tpaquete { get; set; }
        public double Gpaquete { get; set; }
        public string Tgobernador { get; set; }
        public double Ggobernador { get; set; }
        public string Tpys { get; set; }
        public double Gpys { get; set; }
        public string Tdiputado { get; set; }
        public double Gdiputado { get; set; }
        public string Tregidor { get; set; }
        public double Gregidor { get; set; }
        public int idMunicipio { get; set; }
    }

    public class PuntosRec {
        public int? Elecciones { get; set; }
        public int? NoGrupos { get; set; }
        public int? PuntosRecuento { get; set; }
        public int? NoEjercicio { get; set; }
        public int? TotalCasillas { get; set; }
        public int? Tipo { get; set; }

    }

    public class ElementosCartel
    {
        public int? Partido { get; set; }
        public int? Coalicion { get; set; }
        public int? Combinacion { get; set; }
        public int? Independiente { get; set; }
        public int? Votos { get; set; }
        public int? Distrito { get; set; }
        public int? Demarcacion { get; set; }
    }
}
