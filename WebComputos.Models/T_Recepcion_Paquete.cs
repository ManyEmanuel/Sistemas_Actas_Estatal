using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebComputos.Models
{
    public class T_Recepcion_Paquete
    {
        [Key]
        public int IdRecepcion { get; set; }

        [Required(ErrorMessage = "Hora de recepción requerida")]
        [Display(Name = "Hora de recepción:")]
        public DateTime HoraRecepcion { get; set; }

        [Required(ErrorMessage = "Fecha de recepción requerida")]
        [Display(Name = "Fecha de recepción:")]
        public DateTime FechaRecepcion { get; set; }
        public DateTime HoraRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }

        [Required(ErrorMessage = "Persona que entrega el paquete electoral, obligatorio")]
        [Display(Name = "Persona que hace entrega del paquete electoral:")]
        public string Nombre_Entrega { get; set; }

        [Required(ErrorMessage = "Cargo de la persona que entrega el paquete, obligatorio")]
        [Display(Name = "Cargo/Puesto de quien entrega:")]
        public int Cargo_Entrega { get; set; }

        public int Lugar_Entrega { get; set; }        
        public int Cargo_Recibe { get; set; }
        public int Medio_Entrega { get; set; }
        public bool Firma { get; set; }
        public bool Alteracion { get; set; }
        public bool Cinta { get; set; }
        [Required(ErrorMessage = "Se requiere información del sobre PREP")]
        public bool SobrePrep { get; set; }
        [Required(ErrorMessage = "Se requiere información del Paquete Electoral")]
        public bool PaqueteElec { get; set; }
        [Required(ErrorMessage = "CSe requiere registrar una casilla")]
        public int IdCasilla { get; set; }
        public bool Eliminado { get; set; }

        [ForeignKey("IdCasilla")]
        public T_Casilla LCasilla { get; set; }
        public string UsuarioRegistro { get; set; }

        [ForeignKey("UsuarioRegistro")]
        public T_Usuario LUsuario { get; set; }
        public int Solicitud { get; set; }



    }
}
