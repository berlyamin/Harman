using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class Cargo
    {
        [Key]
        public int CargoID { get; set; }


        [Display(Name = "Código Cargo")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Solo debe Colocar Numeros")]
        public int CodigoCargo { get; set; }


        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        [StringLength(100, ErrorMessage = "El campo {0} debe estar {2} y {1} caracteres", MinimumLength = 3)]
        public string NombreCargo { get; set; }


        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
