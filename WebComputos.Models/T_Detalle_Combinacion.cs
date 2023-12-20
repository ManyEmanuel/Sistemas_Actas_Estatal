using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class T_Detalle_Combinacion
    {
        [Key]
        public int Id { get; set; }

        public int CombinacionId { get; set; }
        public int PartidoId { get; set; }

        [ForeignKey("CombinacionId")]
        public T_Combinacion Combinacion { get; set; }

        [ForeignKey("PartidoId")]
        public T_Partido Partido { get; set; }
    }
}
