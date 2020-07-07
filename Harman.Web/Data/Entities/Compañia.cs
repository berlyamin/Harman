using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class Compañia
    {
        [Key]
        public int CompañiaID { get; set; }


        [DisplayName("Nombre Empresa")]
        [StringLength(50, ErrorMessage = "Debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public string NombreCompañia { get; set; }


        [DisplayName("Descripción")]
        [StringLength(50, ErrorMessage = "Debe tener entre {2} y {1} caracteres", MinimumLength = 10)]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public string DescripcionCompañia { get; set; }


        [DisplayName("Dirección")]
        [StringLength(50, ErrorMessage = "Debe tener entre {2} y {1} caracteres", MinimumLength = 10)]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public string DireccionCompañia { get; set; }


        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Campo Requerido {0}")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 10)]
        public string TelefonoCompañia { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo Requerido {0}")]
        [DataType(DataType.EmailAddress)]
        public string CompanyEmail { get; set; }


        [Display(Name = "Fecha Creado")]
        [DataType(DataType.Date)]
        public DateTime CompanyCreateDate { get; set; }


        public virtual ICollection<Empleado> Empleado { get; set; }
        //public string Manager { get; set; }
        //public string ManagerPhone { get; set; }
        //public string ManagerMail { get; set; }

        public int CiudadID { get; set; }
        public virtual Ciudad Ciudad { get; set; }

    }
}
