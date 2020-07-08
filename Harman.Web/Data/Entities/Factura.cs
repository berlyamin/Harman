using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class Factura
    {
        public int FacturaID { get; set; }

        public DateTime Fecha { get; set; }

        public Estado Estado { get; set; }

        public int NumeroPago { get; set; }

        public int ItbisID { get; set; }

       
        public virtual Itbis Itbis { get; set; }






    }
}
