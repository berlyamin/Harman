using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class Pais
    {
        public int PaisId { get; set; }

        [Display(Name = "Pais")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }


        //public ICollection<Provincia> Provincias { get; set; }
        public ICollection<Suplidor> Suplidores { get; set; }

        //public ICollection<Municipio> Municipios { get; set; }
    }
}
