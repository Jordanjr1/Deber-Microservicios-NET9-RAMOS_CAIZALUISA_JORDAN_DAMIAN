using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Api.Models
{
    [Table("Existencias")]
    public class Existencia
    {
        [Key]
        public int IdExistencias { get; set; }

        // Relación lógica hacia CatalogoDB
        public int IdProducto { get; set; }

        public int TotalGeneral { get; set; }
    }
}