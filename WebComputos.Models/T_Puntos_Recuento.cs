using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebComputos.Models
{
    public class T_Puntos_Recuento
    {
        [Key]
        public int IdPuntosRecuento { get; set; }
        public int GrupoTrabajo { get; set; }
        public int PuntoRecu { get; set; }
        public int CasillasTot { get; set; }
        public int Tipo { get; set; }
        public int Municipio { get; set; }
        public int Eleccion { get; set; }
        public bool Eliminado { get; set; }
        public int Demarcacion { get; set; }
        public int Distrito { get; set; }
        public int NumEjercicio { get; set; }

        [ForeignKey("Municipio")]
        public T_Municipio LMunicipio { get; set; }

        [ForeignKey("Eleccion")]
        public T_Tipo_Eleccion LEleccion { get; set; }

    }
}
