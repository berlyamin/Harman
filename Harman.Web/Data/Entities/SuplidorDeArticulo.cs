using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class SuplidorDeArticulo
    {
        [Key]
        public int SuplidorDeArticuloID { get; set; }

        public int SuplidorID { get; set; }

        public int ProductoID { get; set; }

        public virtual Suplidor Suplidor { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
