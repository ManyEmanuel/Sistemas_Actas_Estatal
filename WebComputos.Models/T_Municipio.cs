using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebComputos.Models
{
    public class T_Municipio
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Municipio:")]
        public string Municipio { get; set; }

        [Display(Name = "Cabecera municipal:")]
        public string Cabecera_Municipal { get; set; }

        [Display(Name = "No Estado")]
        public int NoEstado { get; set; }

        public string Estado { get; set; }
        public bool Eliminado { get; set; }
    }
}
