using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class T_Votos_Acta_Ext
    {
        [Key]
        public int Id { get; set; }
        public int NoRegistrados { get; set; }
        public int Nulos { get; set; }
        public int Total { get; set; }
        public int TotalSistema { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public int Solicitud { get; set; }

    }
}
