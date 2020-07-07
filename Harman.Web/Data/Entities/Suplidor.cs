using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class Suplidor
    {
        [Key]
        public int SupplidorID { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [Range(0, Int64.MaxValue, ErrorMessage = "debe de insertar números")]
        public int SupplierCode { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 3)]
        public string SupplierFirstName { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 3)]
        public string SupplierLastName { get; set; }

        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [StringLength(15, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 10)]
        public string SupplierDocumentNumber { get; set; }


        [Display(Name = "Teléfono")]
        [StringLength(15, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Sólo debe Colocar Números")]
        public string SupplierPhone { get; set; }

        [Display(Name = "Celular")]
        [StringLength(15, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Sólo debe Colocar Números")]
        public string SupplierCellPhone { get; set; }


        [Display(Name = "Fecha Inicio")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime SupplierStartDate { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [StringLength(250, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 3)]
        [DataType(DataType.MultilineText)]
        public string SupplierAddress { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public string SupplierEmail { get; set; }

        [Display(Name = "Notas")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [StringLength(250, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 10)]
        public string SupplierRemarks { get; set; }

        [NotMapped]
        public string SupplierFullName { get { return string.Format("{0} {1}", SupplierFirstName, SupplierLastName); } }

        public int ClasificacionSuplidorID { get; set; }
        public virtual ClasificacionSuplidor ClasificacionSuplidor { get; set; }

        public int TipoDocumentoID { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }

        public int CiudadID { get; set; }
        public virtual Ciudad Ciudad { get; set; }


        public Pais Paises { get; set; }


        public Tipo_De_Suplidor Tipo_De_Suplidores { get; set; }
    }
}
