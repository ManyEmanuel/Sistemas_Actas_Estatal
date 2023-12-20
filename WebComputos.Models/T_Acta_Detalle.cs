using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebComputos.Models
{
   public class T_Acta_Detalle
    {
        [Key]
        public int IdActaDetalle { get; set; }
        public int IdCasilla { get; set; }
        public int IdEleccion { get; set; }
        public bool CapturadoVotos { get; set; }
        public bool CapturadoComplemento { get; set; }
        public bool Eliminado { get; set; }
        [ForeignKey("IdCasilla")]
        public T_Casilla LCasilla { get; set; }

        [ForeignKey("IdEleccion")]
        public T_Tipo_Eleccion LTipoEleccion { get; set; }

    }
}

