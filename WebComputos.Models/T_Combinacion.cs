using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class T_Combinacion
    {
        [Key]
        public int Id { get; set; }
        public int CoalicionId { get; set; }
        public string Combinacion { get; set; }
        public int Tamaño { get; set; }
        public string LogoURL { get; set; }

        [ForeignKey("CoalicionId")]
        public T_Coalicion Coalicion { get; set; }


    }
}
