using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class Transportista
    {
        [Key]
        public int CourierID { get; set; }

        [DisplayName("Código")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public int CourierCode { get; set; }


        [DisplayName("Nombre(s)")]
        [StringLength(50, ErrorMessage = "Debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public string CourierName { get; set; }

        [DisplayName("Cuenta")]
        [StringLength(50, ErrorMessage = "Debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public string CourierAccount { get; set; }

        [DisplayName("Dirección")]
        [StringLength(100, ErrorMessage = "Debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [DataType(DataType.MultilineText)]
        public string CourierAddress { get; set; }

        [DisplayName("Nombre del Contacto")]
        [StringLength(50, ErrorMessage = "Debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public string CourierContactName { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(15, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Sólo debe Colocar Números")]
        public string CourierPhone { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Campo Requerido {0}")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 10)]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Sólo debe Colocar Números")]
        public string CourierCellPhone { get; set; }


        [DisplayName("Fecha Inicio")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CourierStartDate { get; set; }


        [DisplayName("Comentario")]
        [StringLength(250, ErrorMessage = "Debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [DataType(DataType.MultilineText)]
        public string CourierRemarks { get; set; }


        [DisplayName("Ciudad")]
        public int CiudadID { get; set; }
        public virtual Ciudad Ciudad { get; set; }


    }
}
