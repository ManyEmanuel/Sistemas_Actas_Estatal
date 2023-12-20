using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebComputos.Models
{
    public class T_Coalicion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la coalición es obligatorio")]
        [Display(Name = "Nombre:")]
        [MaxLength(300, ErrorMessage = "El nombre de la coalición excede el limite permitido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Las siglas de la coalición son obligatorias", AllowEmptyStrings = false)]
        [Display(Name = "Siglas:")]
        [MaxLength(10, ErrorMessage = "Las siglas exceden el tamaño permitido")]
        public string Siglas { get; set; }

        [Display(Name = "Logotipo:")]
        public string LogoURL { get; set; }

        [Display(Name = "Activo?")]
        public bool Activo { get; set; }

        public bool Eliminado { get; set; }

    }
}
