using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Api.Models
{
    [Table("MovimientosInv")]
    public class MovimientoInv
    {
        [Key]
        public int IdMovimiento { get; set; }

        // FK real hacia Bodega
        public int IdBodega { get; set; }
        [ForeignKey("IdBodega")]
        public Bodega? Bodega { get; set; }

        // Relación lógica hacia CatalogoDB
        public int IdProducto { get; set; }

        public string TipoMovimiento { get; set; } = string.Empty; // Ejemplo: "Entrada" o "Salida"

        public int Cantidad { get; set; }

        public DateTime FechaMovimiento { get; set; } = DateTime.Now;
    }
}