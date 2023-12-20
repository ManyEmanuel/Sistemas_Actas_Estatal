using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class T_Acta_RP
    {
        [Key]
        public int IdActa { get; set; }


        [Display(Name = "[1] Boletas sobrantes de la elección:")]
        public int Sobrantes { get; set; }

        [Display(Name = "[2] Personas que votaron:")]
        public int VotosCiudadanos { get; set; }

        [Display(Name = "[5] Votos de la elección sacados de la urna:")]
        public int VotosUrnas { get; set; }

        public Boolean Incidentes { get; set; }
        public string DesIncidentes { get; set; }
        public DateTime FechaRegistro { get; set; }

        [Required(ErrorMessage = "Se requiere conocer el estatus del acta")]
        [Display(Name = "Estatus en la que se recibió el acta:")]
        public int Estatus { get; set; }
        public bool Eliminado { get; set; }

        [ForeignKey("Estatus")]
        public T_Estatus_Acta LEstatus { get; set; }
        public int IdActaDetalle { get; set; }

        [ForeignKey("IdActaDetalle")]
        public T_Acta_Detalle_RP LActaDetalle { get; set; }
        public string UsuarioRegistro { get; set; }
        public int Solicitud { get; set; }

        [ForeignKey("UsuarioRegistro")]
        public T_Usuario LUsuario { get; set; }
    }
}
