using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class DetallesDeVenta
    {
        [Key]
        public int DetallesDeVentaID { get; set; }


        public int VentaID { get; set; }
        public virtual Venta Venta { get; set; }


        public int ProductoID { get; set; }
        public virtual Producto Producto { get; set; }


        [Required(ErrorMessage = "Campo Requerido {0}")]
        [StringLength(250, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "Campo Requerido {0}")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal price { get; set; }


        [Required(ErrorMessage = "Campo Requerido {0}")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public float Quantity { get; set; }

        public decimal discountamount { get; set; }

    }
}
