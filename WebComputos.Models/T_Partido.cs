using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebComputos.Models
{
    public class T_Partido
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "El nombre del partido es obligatorio")]
        [MaxLength(300, ErrorMessage = "El nombre excede el tamaño permitido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Las siglas son requeridas")]
        [Display(Name = "Siglas:")]
        [MaxLength(20, ErrorMessage = "Las siglas exceden el tamaño permitido")]
        public string Siglas { get; set; }

        [Display(Name = "Logotipo:")]
        public string LogoURL { get; set; }

        [Display(Name = "Independiente:")]
        public bool Independiente { get; set; }

        [Display(Name = "Prioridad:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La prioridad es requerida")]
        public int? Prioridad { get; set; }

        [Display(Name = "Pantone Fondo:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El pantone de fondo es requerido")]
        [MaxLength(100, ErrorMessage = "El tamaño del pantone de fondo excede el tamaño permitido")]
        public string PantoneFondo { get; set; }

        [Display(Name = "Pantone Letra:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El pantone de la letra es requerido")]
        [MaxLength(100, ErrorMessage = "El tamaño del pantone de la letra excede el tamaño permitido")]
        public string PantoneLetra { get; set; }

        public bool Eliminado { get; set; }

    }
}
