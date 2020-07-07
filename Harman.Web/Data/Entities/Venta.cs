using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class Venta
    {
        [Key]
        public int VentaID { get; set; }

        public DateTime FechaDeVenta { get; set; }


        public EstadoDeVenta EstadoDeVenta { get; set; }


        // NO TIENE RELACION EN EL MODELO DE YAN
        // 1 CLIENTE MUCHAS VENTAS
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }


        public int VendedorID { get; set; }
        public virtual Vendedor Vendedor { get; set; }


        public int ModoDePagoID { get; set; }
        public virtual ModoDePago ModoDePago { get; set; }


        public int TipoDeTransaccionID { get; set; }
        public virtual TipoDeTransaccion TipoDeTransaccion { get; set; }

        public int NcfId { get; set; }

        public virtual ICollection<DetallesDeVenta> DetallesDeVentas { get; set; }
    }
}
