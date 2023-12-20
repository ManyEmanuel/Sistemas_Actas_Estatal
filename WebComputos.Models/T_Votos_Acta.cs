using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebComputos.Models
{
    public class T_Votos_Acta
    {
        [Key]
        public int IdRegistroVotos { get; set; }
        public int IdActaDetalle { get; set; }
        public int NoRegistrados { get; set; }
        public int Nulos { get; set; }
        public int Total { get; set; }
        public int TotalSistema { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Eliminado { get; set; }

        [ForeignKey("IdActaDetalle")]

        public T_Acta_Detalle LActaDetalle { get; set; }
        public string UsuarioRegistro { get; set; }
        public int Solicitud { get; set; }


        [ForeignKey("UsuarioRegistro")]
        public T_Usuario LUsuario { get; set; }

    }
}
