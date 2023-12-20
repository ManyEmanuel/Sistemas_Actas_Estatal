using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class T_Casilla
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Sección:")]
        public int SeccionId { get; set; }

        [Display(Name = "Tipo casilla:")]
        [Required(ErrorMessage = "El tipo casilla es requerida")]
        public int TipoCasillaId { get; set; }

        [Display(Name = "No. casilla:")]
        [Required(ErrorMessage = "El numero de casilla es requerido")]
        [Range(1, 99, ErrorMessage = "El numero de casilla excede el limite permitido")]
        public int NoCasilla { get; set; } = 1;

        [Display(Name = "Ext. Contigua:")]
        [Range(0, 99, ErrorMessage = "La estension contigua")]
        public int ExtContigua { get; set; }

        [Display(Name = "Lista Nominal:")]
        [Required(ErrorMessage = "El listado nominal es requerido")]
        [MaxLength(6, ErrorMessage = "El listado nominal excede el tamaño permitido")]
        public int ListadoNominal { get; set; }

        [Display(Name = "Padrón Electoral:")]
        [Required(ErrorMessage = "El padrón electoral es requerido")]
        [MaxLength(6, ErrorMessage = "El padrón electoral excede el tamaño requerido")]
        public int PadronElec { get; set; }

        [Display(Name = "Boletas Entregadas:")]
        [MaxLength(6, ErrorMessage = "El número de boletas entregadas excede el limite permitido")]
        public int Boletas_Entregadas { get; set; } = 0;

        [Display(Name = "Activo:")]
        public bool Activo { get; set; }

        [Display(Name = "Nombre:")]
        [MaxLength(100, ErrorMessage = "El nombre de la casilla excede el limite permitido")]
        public string Nombre { get; set; }

        [Display(Name = "Municipio:")]
        [Required(ErrorMessage = "El municipio es requerido")]
        public int MunicipioId { get; set; }

        [ForeignKey("MunicipioId")]
        public T_Municipio LMunicipio { get; set; }

        [ForeignKey("SeccionId")]
        public T_Seccion LSeccion { get; set; }

        [ForeignKey("TipoCasillaId")]
        public T_Tipo_Casilla LTipoCasilla { get; set; }
        [Display(Name = "Domicilio:")]
        [MaxLength(200, ErrorMessage = "El domicilio excede el limite permitido")]
        [Required(ErrorMessage = "El domicilio es requerido", AllowEmptyStrings = true)]
        public string Domicilio { get; set; }

        [Display(Name = "Referencia:")]
        [MaxLength(200, ErrorMessage = "La referencia excede el limite permitido")]
        [Required(ErrorMessage = "La referencia es requerida", AllowEmptyStrings = true)]
        public string Referencia { get; set; }

        [Display(Name = "Tipo de lugar:")]
        [Required(ErrorMessage = "El tipo de lugar es requerido")]
        //1 Edificio 2 Oficina pública 3 Lugar público 4 Particular
        public int? TipoLugar { get; set; }

        [Display(Name = "Ubicación")]
        [Required(ErrorMessage = "La ubicación es requerida", AllowEmptyStrings = true)]
        [MaxLength(100, ErrorMessage = "La ubicacíon excede el limite permitido")]
        public string Ubicacion { get; set; }

        public bool Computado { get; set; }


        public bool Eliminado { get; set; }

        public bool Recibido { get; set; }

    }
}
