using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class Cliente
    {
        [Key]
        public int Customerid { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 3)]
        public string CustomerName { get; set; }



        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 3)]
        public string Customerlastname { get; set; }


        [Display(Name = "Cédula ")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [StringLength(15, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 10)]
        public string Customeridentification { get; set; }



        [Display(Name = "Teléfono")]
        [StringLength(15, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 15)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Sólo debe Colocar Números")]
        public string CustomerPhone { get; set; }


        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Campo Requerido {0}")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 15)]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Sólo debe Colocar Números")]
        public string CustomerCellPhone { get; set; }


        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public string CustomerEmail { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [StringLength(250, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 3)]
        [DataType(DataType.MultilineText)]
        public string CustomerAddress { get; set; }

        public Suplidor Suplidor { get; set; }



        [DisplayName("Aplicar ITBIS")]
        public int ItbisID { get; set; }
        public virtual Itbis Itbis { get; set; }

        [DisplayName("Tipo de cliente")]
        public int PrefijoNCFID { get; set; }
        public virtual PrefijoNCF PrefijoNCF { get; set; }

        public virtual ICollection<Venta> Ventas { get; set; }







    }
}
