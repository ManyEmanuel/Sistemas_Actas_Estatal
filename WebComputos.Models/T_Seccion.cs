using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class T_Seccion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El distrito es requerido")]
        [Display(Name = "Distrito:")]
        public int? DistritoId { get; set; }

        [Required(ErrorMessage = "La sección es requerida")]
        [Range(1, 9999, ErrorMessage = "La seccion debe estar entre {1} y {2}")]
        public string Seccion { get; set; }

        [Required(ErrorMessage = "La demarcación es requerida")]
        [Display(Name = "Demarcación:")]
        public int? DemarcacionId { get; set; }

        [Required(ErrorMessage = "El municipio es requerido")]
        [Display(Name = "Municipio:")]
        public int? MunicipioId { get; set; }

        [Required(ErrorMessage = "La cabecera de la localidad es requerida")]
        [Display(Name = "Cabecera localidad:")]
        [MaxLength(100, ErrorMessage = "La cabecera de la localidad excede el tamaño permitido")]
        public string Cabecera_Localidad { get; set; }

        [Required(ErrorMessage = "El listado nominal es requerido")]
        [Display(Name = "Listado nominal:")]
        [Range(0, 1000000, ErrorMessage = "El listado nominal excede el limite permitido")]
        public int? Listado_Nominal { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; }

        [Required(ErrorMessage = "El padrón electoral es requerido")]
        [Display(Name = "Padrón electoral:")]
        [Range(1, 1000000, ErrorMessage = "El padrón electoral excede el tamaño permitido")]
        public int? Padron_Electoral { get; set; }

        public bool Eliminado { get; set; }

        [Display(Name = "Tipo de sección:")]
        [MaxLength(50, ErrorMessage = "El tipo de sección excede el tamaño permitido")]
        public string TipoSeccion { get; set; }

        [ForeignKey("DistritoId")]
        public T_Distrito LDistrito { get; set; }
        [ForeignKey("DemarcacionId")]
        public T_Demarcacion LDemarcacion { get; set; }

        [ForeignKey("MunicipioId")]
        public T_Municipio LMunicipio { get; set; }

    }
}
