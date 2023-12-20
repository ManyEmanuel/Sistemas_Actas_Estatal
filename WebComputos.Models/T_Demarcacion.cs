using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class T_Demarcacion
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El número de la demarcacíon es obligatorio")]
        [Display(Name = "No. demarcación:")]
        [MaxLength(3)]
        public int No_Demarcacion { get; set; }

        [Display(Name = "Es indigena?")]
        public bool Indigena { get; set; }

        [Required(ErrorMessage = "El municipio es obligatorio")]
        [Display(Name = "Municipio:")]
        public int? MunicipioId { get; set; }

        [ForeignKey("MunicipioId")]
        public T_Municipio Municipio { get; set; }
        public bool Eliminado { get; set; }
    }
}
