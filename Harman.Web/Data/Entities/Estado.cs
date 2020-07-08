using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class Estado
    {
        [Key]
        public int EstadoID { get; set; }


        [Display(Name = "Código Estatus")]
        [Required(ErrorMessage = "Campo Requerido {0}")]
        [StringLength(1, ErrorMessage = "El campo {0} debe ser de un caracter", MinimumLength = 1)]
        public string StatusCode { get; set; }


        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Campo Requerido {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string StatusName { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }

        public virtual ICollection<Empleado> Empleado { get; set; }

        public virtual ICollection<ModoEnvio> ModoEnvio{ get; set; }

        public virtual ICollection<ModoDePago> ModoDePago { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }

    } 
}
