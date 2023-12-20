using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebComputos.Models
{
    public class T_Distrito
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del distrito es obligatorio")]
        [Display(Name = "No distrito:")]
        public int NoDistrito { get; set; }

        [Display(Name = "Cabecera distrital:")]
        [MaxLength(50, ErrorMessage = "El nombre de distrito excede el tamaño permitido")]
        public string Nombre { get; set; }

        [MaxLength(300, ErrorMessage = "La integración del distrito excede el tamaño permitido")]
        public string Integracion { get; set; }
        public bool Eliminado { get; set; }

    }
}
