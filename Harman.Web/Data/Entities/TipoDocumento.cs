using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class TipoDocumento
    {
        [Key]
        public int TipoDocumentoID { get; set; }

        [Display(Name = "Tipo Documento")]
        [Required(ErrorMessage = "Campo Requerido {0}")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string DescripcionTipoDocumento { get; set; }

        public virtual ICollection<Empleado> Empleado { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }

        public virtual ICollection<Suplidor> Suplidores { get; set; }

    }
}
