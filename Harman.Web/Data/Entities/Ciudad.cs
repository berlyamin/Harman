using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    
        public class Ciudad
        {
            [Key]
            public int CiudadID { get; set; }

            [DisplayName("Código Ciudad")]
            [Range(0, int.MaxValue, ErrorMessage = "Por favor digite un número entero válido")]
            public int CityCode { get; set; }


            [DisplayName("Nombre Ciudad")]
            [StringLength(50, ErrorMessage = "Debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
            [Required(ErrorMessage = "El campo {0} es Requerido")]
            public string CityName { get; set; }


            public int PaisID { get; set; }
            public virtual Pais Pais { get; set; }


            public virtual ICollection<Compañia> Compañias { get; set; }

            public virtual ICollection<Cliente> Clientes { get; set; }

            public virtual ICollection<Transportista> Transportistas { get; set; }

            public virtual ICollection<Suplidor> Supplidores { get; set; }
        }
}
