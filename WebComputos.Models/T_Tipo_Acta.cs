using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class T_Tipo_Acta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del tipo de acta es obligatorio")]
        [Display(Name = "Nombre:")]
        [MaxLength(50, ErrorMessage = "El nombre excede el tamaño permitido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El tipo de elección es obligatorio")]
        [Display(Name = "Tipo de elección:")]
        public int? TipoEleccionId { get; set; }

        [ForeignKey("TipoEleccionId")]
        public T_Tipo_Eleccion TipoEleccion { get; set; }

        public bool Eliminado { get; set; }

    }
}
