using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class TasaDeCambio
    {
        [Key]
        public int TasaDeCambioID { get; set; }

        [Display(Name = "Fecha Creado")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaCreacionTasaDeCambio { get; set; }

        [Display(Name = "Valor de Cambio")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public decimal ExchangeValue { get; set; }

        public int MonedaID { get; set; }
        public virtual Moneda Moneda { get; set; }

        //public virtual ICollection<Currency> Currencies { get; set; }


    }
}
