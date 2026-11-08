using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Libro.Api.Models
{
    [Table("Libros")]
    public class Libros
    {
        [Key]
        [Column("IdLibro")]
        public int IdLibro { get; set; }

        [StringLength(100)]
        [Column("Titulo")]
        public String Titulo { get; set; } = string.Empty;

        [StringLength(100)]
        [Column("Autor")]
        public string Autor { get; set; } = string.Empty;

        [StringLength(13)]
        [Column("Isbn")]
        public string Isbn { get; set; } = string.Empty;

        
        [Column("Precio", TypeName="decimal(18,2)")]
        public decimal Precio { get; set; }

        [Column("Estado")]
        public bool Estado { get; set; }

    }
}
