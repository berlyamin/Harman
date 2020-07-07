using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class ModoDePago
    {
        [Key]
        public int PaymentTermsID { get; set; }


        [Display(Name = "Tipo de Pago")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [StringLength(100, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 3)]
        public string DescripcionModoDePago { get; set; }


        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }


        public virtual ICollection<Venta> Venta { get; set; }

        public virtual ICollection<OrdenDeCompra> OrdenDeCompras { get; set; }

    }
}
