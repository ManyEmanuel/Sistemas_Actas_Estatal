using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class T_Detalle_Votos_Ext
    {
        [Key]

        public int Id { get; set; }
        public int IdVotosActa { get; set; }
        public int IdPartido { get; set; }
        public int IdCoalicion { get; set; }
        public int IdCombinacion { get; set; }
        public int Votos { get; set; }
        public bool Eliminado { get; set; }


        [ForeignKey("IdVotosActa")]
        public T_Votos_Acta_Ext LVotosActa { get; set; }
    }
}
