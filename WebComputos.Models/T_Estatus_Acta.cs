using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebComputos.Models
{
    public class T_Estatus_Acta
    {
        [Key]
        public int IdEstatus { get; set; }
        public string Descripcion { get; set; }
        public bool Eliminado { get; set; }
    }
}
