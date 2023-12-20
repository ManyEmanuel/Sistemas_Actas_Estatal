using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class T_Usuario : IdentityUser
    {
        [Required(ErrorMessage = "El nombre del usuario es requerido")]
        [Display(Name = "Nombres:")]
        [MaxLength(50, ErrorMessage = "El tamaño del nombre excede el limite permitido")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El apellido paterno es requerido")]
        [Display(Name = "Apellido paterno:")]
        [MaxLength(50, ErrorMessage = "El tamaño del apellido paterno excede el limite permitido")]
        public string Apellido_Paterno { get; set; }

        [Display(Name = "Apellido materno:")]
        [MaxLength(50, ErrorMessage = "El tamaño del apellido paterno excede el limite permitido")]
        public string Apellido_Materno { get; set; }

        [Display(Name = "Oficina")]
        [Required(ErrorMessage = "La oficina es requerida")]
        public int OficinaId { get; set; }

        [Display(Name = "Puesto del usuario")]
        [MaxLength(50, ErrorMessage = "El tamaño del puesto excede el limite permitido")]
        public string Puesto { get; set; }

        [Phone(ErrorMessage = "El telefono tiene formato incorrecto")]
        [Required(ErrorMessage = "El telefono es requerido")]
        public string Telefono { get; set; }
        public string Foto_Url { get; set; }
        public string Acceso { get; set; }
        public string TipoUsuario { get; set; }

        [ForeignKey("OficinaId")]
        public T_Oficina Oficina { get; set; }

    }
}
