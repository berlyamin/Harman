using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class TipoDeTransaccion
    {
        [Key]
        public int TipoDeTransaccionID { get; set; }


        [Display(Name = "Código transación")]
        [Required(ErrorMessage = "Campo Requerido {0}")]
        public string TransactionTypecode { get; set; }


        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Campo Requerido {0}")]
        public string DescripcionTipoDeTransaccion { get; set; }


        public virtual ICollection<Venta> Venta { get; set; }
    }
}
