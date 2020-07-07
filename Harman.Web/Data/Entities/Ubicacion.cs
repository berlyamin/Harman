using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class Ubicacion
    {
        [Key]
        public int UbicacionID { get; set; }
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [Range(0, int.MaxValue, ErrorMessage = "Número incorrecto")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Sólo debe Colocar Números")]

        public int CodigoUbicacion { get; set; }

        [Display(Name = "Ubicación")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [StringLength(100, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 3)]
        public string NombreUbicacion { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
