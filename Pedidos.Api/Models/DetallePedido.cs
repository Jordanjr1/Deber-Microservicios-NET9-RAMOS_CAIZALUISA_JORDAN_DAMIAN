using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Api.Models
{
    [Table("DetallesPedido")]
    public class DetallePedido
    {
        [Key]
        public int IdDetallePedido { get; set; }

        // FK real hacia Pedido
        public int IdPedido { get; set; }
        [ForeignKey("IdPedido")]
        public Pedido? Pedido { get; set; }

        // Relación lógica hacia CatalogoDB (Solo el ID)
        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }
    }
}