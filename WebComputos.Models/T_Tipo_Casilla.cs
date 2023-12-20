using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebComputos.Models
{
    public class T_Tipo_Casilla
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del tipo casilla es obligatorio")]
        [Display(Name = "Nombre:")]
        [MaxLength(50, ErrorMessage = "El tipo casilla excede el tamaño permitido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Las siglas son obligatorios")]
        [Display(Name = "Siglas:")]
        [MaxLength(5, ErrorMessage = "Las siglas exceden el tamaño permitido")]
        public string Siglas { get; set; }

        public bool Eliminado { get; set; }
    }
}
