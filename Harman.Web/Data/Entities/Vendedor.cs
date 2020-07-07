using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class Vendedor
    {
        /*Tabla original en cirica [sdcven]*/
        [Key]
        public int VendedorID { get; set; }


        [Display(Name = "Código")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe de insertar números")]
        public int CodigoVendedor { get; set; }


        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Campo Requerido {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string DescripcionVendedor { get; set; }


        [Display(Name = "Porciento Comisión")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public int SellerCommissionPercent { get; set; }


        [Display(Name = "Valor descontado")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public int SellerDiscountValue { get; set; }


        public virtual ICollection<Empleado> Empleado { get; set; }


        public virtual ICollection<Venta> Venta { get; set; }
    }
}
