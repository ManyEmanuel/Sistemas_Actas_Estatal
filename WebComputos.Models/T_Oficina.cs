using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class T_Oficina
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Las siglas son requeridas")]
        [Display(Name = "Siglas:")]
        public string Siglas { get; set; }

        [Required(ErrorMessage = "La calle es requerida")]
        [Display(Name = "Calle:")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "El no.exterior es requerido")]
        [Display(Name = "No. Exterior:")]
        public string NoExterior { get; set; }

        [Display(Name = "No. Interior:")]
        public string NoInterior { get; set; }

        [Required(ErrorMessage = "La colonia es requerida")]
        [Display(Name = "Colonia:")]
        public string Colonia { get; set; }

        [Required(ErrorMessage = "El municipio es requerido")]
        [Display(Name = "Municipio:")]
        public int MunicipioId { get; set; }

        [Required(ErrorMessage = "El codigo postal es requerido")]
        [Display(Name = "C.P.:")]
        public int CodigoPostal { get; set; }

        [Display(Name = "Teléfono oficina:")]
        public string Telefono1 { get; set; }

        [Display(Name = "Teléfono particular:")]
        public string Telefono2 { get; set; }

        [Display(Name = "Responsable:")]
        public string Responsable { get; set; }

        [ForeignKey("MunicipioId")]
        public T_Municipio Municipio { get; set; }

        public bool Eliminado { get; set; }


    }
}
