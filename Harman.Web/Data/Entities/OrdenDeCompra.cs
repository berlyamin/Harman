using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class OrdenDeCompra
    {
        [Key]
        public int OrdenDeCompraID { get; set; }

        public int SuplidorID { get; set; }

        public int PaymentTermsID { get; set; }

        public int ShipmentTermsID { get; set; }

        public DateTime PurchaseOrderDate { get; set; }

        public EstadoOrdenDeCompra EstadoOrdenDeCompra { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public virtual Suplidor Suplidor { get; set; }

        public virtual ModoDePago ModoDePago { get; set; }

        public virtual ModoEnvio ModoEnvio { get; set; }

        public virtual ICollection<DetallesOrdenDeCompra> DetallesOrdenDeCompras { get; set; }

    }
}
