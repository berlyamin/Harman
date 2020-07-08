using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class Itbis
    {
        [Key]
        public int ItbisID { get; set; }

        [DisplayName("Porcentaje")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public decimal PorcientoItbis { get; set; }

        [DisplayName("Descripcion")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public string DescripcionItbis { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; } 
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
