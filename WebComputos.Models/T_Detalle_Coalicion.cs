using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class T_Detalle_Coalicion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Seleccione el partido a agregar a la coalición")]
        [Display(Name = "Partido:")]
        public int? PartidoId { get; set; }

        [Display(Name = "Coalición:")]
        [Required(ErrorMessage = "La coalición es obligatoria")]
        public int? CoalicionId { get; set; }

        public bool Activo { get; set; }
        public bool Eliminado { get; set; }

        [ForeignKey("PartidoId")]
        public T_Partido Partido { get; set; }

        [ForeignKey("CoalicionId")]
        public T_Coalicion Coalicion { get; set; }

    }
}
