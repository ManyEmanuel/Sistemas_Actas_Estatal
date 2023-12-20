using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class T_HistorialSubsanar
    {
        [Key]
        public int Id { get; set; }
        public int IdCausal { get; set; }
        public int CasillaId { get; set; }

        public int TipoEleccionId { get; set; }

        //El Paquete Electoral fue entregado sin el AECC
        public bool Causal1 { get; set; }

        //Votos Nulos mayor a la diferencia entre el 1er y 2do lugar
        public bool Causal2 { get; set; }

        //Total de votos del sistema mayor a boletas entregadas
        public bool Causal3 { get; set; }

        //Total de votos del sistema diferente al total de votos del AECC
        public bool Causal4 { get; set; }

        //Votos para un solo Partido Político, Coalición o Candidato Independiente
        public bool Causal5 { get; set; }

        //Acta ilegible
        public bool Causal6 { get; set; }

        //Acta con alteraciones
        public bool Causal7 { get; set; }

        //Paquete con muestras de alteraciones
        public bool Causal8 { get; set; }

        //Ciudadanos que votaron diferente al total de votos del sistema
        public bool Causal9 { get; set; }

        //Boletas sobrantes más ciudadanos que votaron mayor a boletas entregadas
        public bool Causal10 { get; set; }

        //Boletas sobrantes más total de votos del sistema mayor a boletas entregadas
        public bool Causal11 { get; set; }

        public int Total_Causales { get; set; }

        public bool Recuento_Total { get; set; }

        public bool RP { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaHora { get; set; }

        public bool Eliminar { get; set; }
        public int Solicitud { get; set; }
        public DateTime FechaHora_Solicitud { get; set; }

        [ForeignKey("IdCausal")]
        public T_Causal_Recuento LCausal { get; set; }

        [ForeignKey("CasillaId")]
        public T_Casilla LCasilla { get; set; }

        [ForeignKey("TipoEleccionId")]
        public T_Tipo_Eleccion LTipo_Eleccion { get; set; }

        [ForeignKey("UsuarioRegistro")]
        public T_Usuario LUsuario { get; set; }
    }
}
