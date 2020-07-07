using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class PrefijoNCF
    {
        [Key]
        public int PrefijoNCFID { get; set; }
        public string Prefijo { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<NCF> NCF { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
