using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class Moneda
    {
        [Key]
        public int MonedaID { get; set; }


        [DisplayName("Código Moneda")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [StringLength(3, ErrorMessage = "Debe tener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string CodigoMoneda { get; set; }


        [DisplayName("Descripción")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [StringLength(50, ErrorMessage = "Debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string NombreMoneda { get; set; }


        [DisplayName("Símbolo")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [StringLength(5, ErrorMessage = "Debe tener {1} caracter", MinimumLength = 1)]
        public string SimboloDeMoneda { get; set; }


        public int PaisID { get; set; }
        public virtual Pais Pais { get; set; }


        public virtual ICollection<TasaDeCambio> TasaDeCambio { get; set; }
        

        public virtual ICollection<OrdenDeCompra> OrdenDeCompra { get; set; }

    }
}
