using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebComputos.Models
{
    public class T_Causal_Recuento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La casilla es requerida")]
        public int CasillaId { get; set; }

        [Required(ErrorMessage = "El tipo de elección es requerido")]
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

        [ForeignKey("CasillaId")]
        public T_Casilla LCasilla { get; set; }

        [ForeignKey("TipoEleccionId")]
        public T_Tipo_Eleccion LTipo_Eleccion { get; set; }
        public int? DetalleActaComputoId { get; set; }

        public int? DetalleActaComputoRPId { get; set; }
        [ForeignKey("DetalleActaComputoRPId")]
        public T_Detalle_Acta_Computo_RP LDetalle_Acta_Computo_RP { get; set; }

        [ForeignKey("DetalleActaComputoId")]
        public T_Detalle_Acta_Computo LDetalle_Acta_Computo { get; set; }


    }
}
