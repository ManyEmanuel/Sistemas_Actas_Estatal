using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebComputos.Models
{
    public class T_Detalle_Votos_Acta_Partido
    {
        [Key]
        public int IdDetalleVotosPartidos { get; set; }
        public int IdEleccion { get; set; }
        public int Municipio { get; set; }
        public int Distrito { get; set; }
        public int Demarcacion { get; set; }
        public int IdPartido { get; set; }
        public int IdIndependiente { get; set; }
        public int Votos { get; set; }
        public bool Eliminado { get; set; }

        [ForeignKey("IdEleccion")]
        public T_Tipo_Eleccion LEleccion { get; set; }
    }
}
