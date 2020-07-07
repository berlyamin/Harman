using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class Empleado
    {
        [Key]
        public int EmpleadoID { get; set; }


        [Display(Name = "Fecha Creado")]
        [DataType(DataType.Date)]
        public DateTime EmployeeDateAdd { get; set; }


        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo Requerido {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string EmployeeCode { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo Requerido {0}")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string EmployeeName { get; set; }


        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Campo Requerido {0}")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string EmployeeLastName { get; set; }


        //[Display(Name = "Tipo Documento")]
        //[Required(ErrorMessage = "Campo Requerido {0}")]
        public int TipoDocumentoID { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }


        [Required(ErrorMessage = "Campo Requerido {0}")]
        [Display(Name = "Cédula/Pasaporte")]
        [StringLength(15, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 10)]
        public string EmployeeIDNumber { get; set; }


        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Campo Requerido {0}")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 10)]
        public string EmployeePhone { get; set; }


        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Campo Requerido {0}")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 10)]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Sólo debe Colocar Números")]
        public string EmployeeCellPhone { get; set; }


        [Display(Name = "Extensión")]
        [Required(ErrorMessage = "Campo Requerido {0}")]
        [Range(0, Int16.MaxValue, ErrorMessage = "Debe de insertar números")]
        public int EmployeePhoneExtension { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo Requerido {0}")]
        [DataType(DataType.EmailAddress)]
        public string EmployeeEmail { get; set; }


        //[Display(Name = "Estado")]
        //[Required(ErrorMessage = "Campo Requerido {0}")]
        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }


        //[Display(Name = "Puesto de Trabajo")]
        //[Required(ErrorMessage = "Campo Requerido {0}")]
        public int CargoID { get; set; }
        public virtual Cargo Cargo { get; set; }


        public int VendedorID { get; set; }
        public virtual Vendedor Vendedor { get; set; }


        public int CompañiaID { get; set; }
        public virtual Compañia Compañia { get; set; }


        //public virtual ICollection<tUsers> tUsers { get; set; }
    }
}
