using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    
     public class Marca
    {
        [Key]
        public int MarcaID { get; set; }

        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Solo debe Colocar Numeros")]

        public int CodigoMArca { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [StringLength(100, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 3)]
        public string NombreMarca { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }

    }
}
