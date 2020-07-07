using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data.Entities
{
    public class Producto
    {
        [Key]
        public int ProductoID { get; set; }


        [DisplayName("Código")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public string ArticleCode { get; set; }


        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public string ArticleDescription { get; set; }


        [DisplayName("Modelo")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public string ArticleModel { get; set; }


        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public DateTime ArticleEntryDate { get; set; }


        [DataType(DataType.Currency)]
        [DisplayName("Precio")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public decimal ArticlePrice { get; set; }


        [DisplayName("Costo")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public decimal ArticleCost { get; set; }


        [DisplayName("Mínimo")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public int ArticleMinimumAmount { get; set; }


        [DisplayName("Existencia")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public float ArticleQuantity { get; set; }


        [DataType(DataType.MultilineText)]
        [DisplayName("Comentario")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public string ArticleRemarks { get; set; }


        //[DisplayName("ITBIS")]
        //[Required(ErrorMessage = "Completar el campo {0}")]
        //public int ItbisID { get; set; }


        [DisplayName("Grupo")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public int ArticleClassificationID { get; set; }
        public virtual ClasificacionDeProducto ClasificacionDeProducto { get; set; }


        [DisplayName("Marca")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public int MarcaID { get; set; }
        public virtual Marca Marca { get; set; }


        [DisplayName("Unidad de Medida")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public int UnidadID { get; set; }
        public virtual Unidad Unidad { get; set; }


        [DisplayName("Ubicación")]
        [Required(ErrorMessage = "Completar el campo {0}")]
        public int UbicacionID { get; set; }
        public virtual Ubicacion Ubicacion { get; set; }


        public virtual ICollection<SuplidorDeArticulo> SuplidorDeArticulos { get; set; }

        public virtual ICollection<DetallesDeVenta> DetallesDeVentas { get; set; }

        public virtual ICollection<DetallesOrdenDeCompra> DetallesOrdenDeCompras { get; set; }


    }
}
