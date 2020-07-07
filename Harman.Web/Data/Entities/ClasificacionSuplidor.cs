using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class ClasificacionSuplidor
    {
        [Key]
        public int ClasificacionSuplidorID { get; set; }

        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [Range(0, int.MaxValue, ErrorMessage = "Por favor digite un número entero válido")]
        public int Code { get; set; }

        [Display(Name = "Clasificación")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [StringLength(100, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 3)]
        public string Name { get; set; }

        public virtual ICollection<Suplidor> Suplidor { get; set; }

    }
}
