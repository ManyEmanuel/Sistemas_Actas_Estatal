using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace WebComputos.Models
{
    public class T_Candidato
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El tipo de elección es requerido")]
        [Display(Name = "Tipo de elección:")]
        public int? TipoEleccionId { get; set; }

        [Display(Name = "Municipio:")]
        public int? MunicipioId { get; set; }

        [Display(Name = "Distrito:")]
        public int? DistritoId { get; set; }

        [Display(Name = "Demarcación:")]
        public int? DemarcacionId { get; set; }

        [Display(Name = "Estado:")]
        public int? Estado { get; set; }

        [Display(Name = "Coalición:")]
        public int? CoalicionId { get; set; }

        [Display(Name = "Partido/Asociación:")]
        [Required(ErrorMessage = "El partido/asociación es requerido")]
        public int? PartidoId { get; set; }

        [Display(Name = "¿Coalición?")]
        public bool IsCoalicion { get; set; }

        [Display(Name = "Activo:")]
        public bool Activo { get; set; }

        [Display(Name = "Tipo candidato:")]
        public string? MR_RP { get; set; }

        [Display(Name = "Orden:")]
        public int?  Orden { get; set; }

        public bool Eliminado { get; set; }

        //Propietario 1

        [Display(Name = "Nombres:")]
        [MaxLength(50, ErrorMessage = "EL nombre excede el limite permitido")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombres_Propietario { get; set; }

        [Display(Name = "Apellido paterno:")]
        [MaxLength(50, ErrorMessage = "EL apellido paterno excede el limite permitido")]
        [Required(ErrorMessage = "El apellido paterno es requerido")]
        public string Apellido_Paterno_Propietario { get; set; }

        [Display(Name = "Apellido materno:")]
        [MaxLength(50, ErrorMessage = "EL apellido materno excede el limite permitido")]
        public string Apellido_Materno_Propietario { get; set; }

        [Display(Name = "Mote:")]
        [MaxLength(50, ErrorMessage = "El mote excede el limite permitido")]
        public string Mote_Propietario { get; set; }

        [Display(Name = "Sexo:")]
        [Required(ErrorMessage = "El apellido paterno es requerido", AllowEmptyStrings = false)]
        public string Sexo_Propietario { get; set; }

        public string Foto_Propietario { get; set; }

        //Propietario 2
        [Display(Name = "Nombres:")]
        [MaxLength(50, ErrorMessage = "EL nombre excede el limite permitido")]
        public string? Nombres_Propietario1 { get; set; }

        [Display(Name = "Apellido paterno:")]
        [MaxLength(50, ErrorMessage = "EL apellido paterno excede el limite permitido")]
        public string? Apellido_Paterno_Propietario1 { get; set; }

        [Display(Name = "Apellido materno:")]
        [MaxLength(50, ErrorMessage = "EL apellido materno excede el limite permitido")]
        public string? Apellido_Materno_Propietario1 { get; set; }

        [Display(Name = "Mote:")]
        [MaxLength(50, ErrorMessage = "El mote excede el limite permitido")]
        public string? Mote_Propietario1 { get; set; }

        [Display(Name = "Sexo:")]
        public string? Sexo_Propietario1 { get; set; }

        public string? Foto_Propietario1 { get; set; }

        //Sumplente 1
        [Display(Name = "Nombres:")]
        [MaxLength(50, ErrorMessage = "EL nombre excede el limite permitido")]
        public string? Nombres_Suplente { get; set; }

        [Display(Name = "Apellido paterno:")]
        [MaxLength(50, ErrorMessage = "EL apellido paterno excede el limite permitido")]
        public string? Apellido_Paterno_Suplente { get; set; }

        [Display(Name = "Apellido materno:")]
        [MaxLength(50, ErrorMessage = "EL apellido materno excede el limite permitido")]
        public string? Apellido_Materno_Suplente { get; set; }

        [Display(Name = "Mote:")]
        [MaxLength(50, ErrorMessage = "El mote excede el limite permitido")]
        public string? Mote_Suplente { get; set; }

        [Display(Name = "Sexo:")]
        public string? Sexo_Suplente { get; set; }

        public string? Foto_Suplente { get; set; }

        //Sumplente 2
        [Display(Name = "Nombres:")]
        [MaxLength(50, ErrorMessage = "EL nombre excede el limite permitido")]
        public string? Nombres_Suplente1 { get; set; }

        [Display(Name = "Apellido paterno:")]
        [MaxLength(50, ErrorMessage = "EL apellido paterno excede el limite permitido")]
        public string? Apellido_Paterno_Suplente1 { get; set; }

        [Display(Name = "Apellido materno:")]
        [MaxLength(50, ErrorMessage = "EL apellido materno excede el limite permitido")]
        public string? Apellido_Materno_Suplente1 { get; set; }

        [Display(Name = "Mote:")]
        [MaxLength(50, ErrorMessage = "El mote excede el limite permitido")]
        public string? Mote_Suplente1 { get; set; }

        [Display(Name = "Sexo:")]
        public string? Sexo_Suplente1 { get; set; }

        public string? Foto_Suplente1 { get; set; }


        [ForeignKey("CoalicionId")]
        public T_Coalicion Coalicion { get; set; }

        [ForeignKey("MunicipioId")]
        public T_Municipio Municipio { get; set; }

        [ForeignKey("PartidoId")]
        public T_Partido Partido { get; set; }

        [ForeignKey("TipoEleccionId")]
        public T_Tipo_Eleccion Tipo_Eleccion { get; set; }

        [ForeignKey("DemarcacionId")]
        public T_Demarcacion Demarcacion { get; set; }

        [ForeignKey("DistritoId")]
        public T_Distrito Distrito { get; set; }
    }
}
