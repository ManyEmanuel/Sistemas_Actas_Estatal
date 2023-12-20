using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebComputos.Models
{
    public class T_Detalle_Votos_Acta_Actor
    {
        [Key]

        public int IdDetalleVotosActor { get; set; }
        public int IdVotosActas { get; set; }
        public int IdPartido { get; set; }
        public int IdCoalicion { get; set; }
        public int IdIndependiente { get; set; }
        public int Votos { get; set; }
        public bool Eliminado { get; set; }

        [ForeignKey("IdVotosActas")]
        public T_Votos_Acta LVotosActa { get; set; }

    }
}
