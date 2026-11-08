using Inventario.Api.Models; 
using Microsoft.EntityFrameworkCore;

namespace Inventario.Api.Data
{
    public class InventarioDbContext : DbContext
    {
        public InventarioDbContext(DbContextOptions<InventarioDbContext> options) : base(options)
        {
        }

        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<MovimientoInv> Movimientos { get; set; }
        public DbSet<Existencia> Existencias { get; set; }
    }
}
