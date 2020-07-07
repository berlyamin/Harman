using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class DetallesOrdenDeCompra
    {
        [Key]
        public int DetallesOrdenDeCompraID { get; set; }

        public int PurchaseOrderID { get; set; }

        public int ProductoID { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Costo")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public decimal Cost { get; set; }

        [DisplayName("Cantidad")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Digite la cantidad")]
        public float Quantity { get; set; }


        [NotMapped]
        public string Value { get; set; }

        public virtual OrdenDeCompra OrdenDeCompra { get; set; }

        public virtual Producto Producto { get; set; }

    }
}
