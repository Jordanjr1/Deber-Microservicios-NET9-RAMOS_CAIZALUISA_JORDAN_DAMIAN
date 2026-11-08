using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Api.Models
{
    [Table("Stock")]
    public class Stock
    {
        [Key]
        public int IdStock { get; set; }

        // FK real hacia Bodega dentro de esta misma BD
        public int IdBodega { get; set; }
        [ForeignKey("IdBodega")]
        public Bodega? Bodega { get; set; }

        // Relación lógica hacia CatalogoDB (No lleva "public Producto Producto {get;set;}")
        public int IdProducto { get; set; }

        public int Cantidad { get; set; }
    }
}