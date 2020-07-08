using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class NCF
    {
        [Key]
        public int NcfId { get; set; }
        public int PrefijoNCFID { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string NoNCF { get; set; }
        public string Users { get; set; }
        public bool Status { get; set; }

       // [ForeignKey("PrefijoNCF")]
        public virtual PrefijoNCF PrefijoNCF { get; set; }
    }
}
