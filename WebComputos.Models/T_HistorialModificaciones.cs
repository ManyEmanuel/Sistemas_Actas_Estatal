using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class T_HistorialModificaciones
    {
        [Key]

        public int Id { get; set; }
        public int IdCasilla { get; set; }  
        public int Concepto { get; set; }
        public int TipoEleccion { get; set; }
        public int Estatus { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public string UsuarioRegistro { get; set; }
        public int Paquetes { get; set; }
        public int Complementaria { get; set; }
        public int Votos { get; set; }

        [ForeignKey("UsuarioRegistro")]
        public T_Usuario LUsuario { get; set; }

        [ForeignKey("IdCasilla")]
        public T_Casilla LCasilla { get; set; }

    }
}
