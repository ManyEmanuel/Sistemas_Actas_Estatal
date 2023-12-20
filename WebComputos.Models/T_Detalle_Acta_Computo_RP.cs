using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class T_Detalle_Acta_Computo_RP
    {
        [Key]
        public int? Id { get; set; }
        public int CasillaId { get; set; }
        public int TipoEleccionId { get; set; }
        public bool Computado { get; set; }
        public bool Reservado { get; set; }
        public bool Recuento_Total { get; set; }

        //1=Cotejo 2=Recuento Parcial 3=Recuento Total
        public int TipoComputo { get; set; }

        [ForeignKey("CasillaId")]
        public T_Casilla Casilla { get; set; }

        [ForeignKey("TipoEleccionId")]
        public T_Tipo_Eleccion TipoEleccion { get; set; }
        public IEnumerable<T_Causal_Recuento> Causales { get; set; }
    }
}
