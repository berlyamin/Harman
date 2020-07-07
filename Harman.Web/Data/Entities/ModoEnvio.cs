using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class ModoEnvio
    {
        [Key]
        public int ModoEnvioID { get; set; }

        [Display(Name = "Tipo de Envio")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [StringLength(100, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 3)]
        public string DescripcionModoEnvio { get; set; }

        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }

        public virtual ICollection<OrdenDeCompra> OrdenDeCompras { get; set; }
    }
}
