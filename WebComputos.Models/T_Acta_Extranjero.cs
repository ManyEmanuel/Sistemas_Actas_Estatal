using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebComputos.Models
{
    public class T_Acta_Extranjero
    {
        [Key]
        public int Id { get; set; }
        public int NumMesa { get; set; }
        public DateTime Instalacion { get; set; }
        public bool UrnaVacia { get; set; }
        public bool UrnaVista { get; set; }
        public int PersonasVotaron { get; set; }
        public int SobreVotos { get; set; }
        public DateTime Deposito { get; set; }
        public int VotosUrnas { get; set; }
        public bool Incidentes { get; set; }
        public string DesIncidentes { get; set; }
    }
}
