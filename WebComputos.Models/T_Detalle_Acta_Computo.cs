using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class T_Detalle_Acta_Computo
    {
        [Key]
        public int Id { get; set; }
        public int CasillaId { get; set; }
        public int TipoEleccionId { get; set; }
        public bool Computado { get; set; }
        public int TipoComputo { get; set; }

        [ForeignKey("CasillaId")]
        public T_Casilla Casilla { get; set; }

        [ForeignKey("TipoEleccionId")]
        public T_Tipo_Eleccion TipoEleccion { get; set; }
        public IEnumerable<T_Causal_Recuento> Causales { get; set; }

    }
}
