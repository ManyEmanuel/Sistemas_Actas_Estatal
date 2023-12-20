using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebComputos.Models
{
    public class T_Tipo_Eleccion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del tipo elección es obligatorio", AllowEmptyStrings = false)]
        [Display(Name = "Nombre:")]
        [MaxLength(50, ErrorMessage = "El tipo elección excede el tamaño permitido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Las siglas del tipo elección son obligatorias", AllowEmptyStrings = false)]
        [MaxLength(3, ErrorMessage = "Las siglas exceden el tamaño permitido")]
        [Display(Name = "Siglas:")]
        public string Siglas { get; set; }

        public bool Eliminado { get; set; }
    }
}
