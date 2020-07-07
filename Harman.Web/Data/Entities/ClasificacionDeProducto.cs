using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class ClasificacionDeProducto
    {
        
        [Key]
        public int ClasificacionDeProductoID { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [Range(0, int.MaxValue, ErrorMessage = "Por favor digite un número entero válido")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Sólo debe colocar Números")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 3)]
        public string CodigoClasificacionDeProducto { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 3)]
        public string NombreClasificacionDeProducto { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }

}
