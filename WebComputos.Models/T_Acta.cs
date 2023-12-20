using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebComputos.Models
{
    public class T_Acta
    {
        [Key]
        public int IdActa { get; set; }


        [Display(Name = "[1] Boletas sobrantes de la elección:")]
        public int Sobrantes { get; set; }

        [Display(Name = "[2] Personas que votaron:")]
        public int VotosCiudadanos { get; set; }

        [Display(Name = "[3] Representantes de partidos políticos y de candidatos/as independientes que votaron en la casilla no incluidos/as en la lista nominal:")]
        public int VotosRepresentantes { get; set; }

        [Display(Name = "[4] Suma de las cantidades de los apartados [2] y [3]:")]
        public int TotalVotos { get; set; }

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
        public T_Acta_Detalle LActaDetalle { get; set; }
        public string UsuarioRegistro { get; set; }
        public int Solicitud { get; set; }

        [ForeignKey("UsuarioRegistro")]
        public T_Usuario LUsuario { get; set; }

    }










}
