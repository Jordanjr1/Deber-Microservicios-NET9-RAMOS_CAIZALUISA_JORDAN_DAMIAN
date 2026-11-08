using Inventario.Api.Data;
using Inventario.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosInvController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public MovimientosInvController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimientoInv>>> GetMovimientos()
        {
            return await _context.Movimientos.Include(m => m.Bodega).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<MovimientoInv>> PostMovimiento(MovimientoInv movimiento)
        {
            // Al crear un movimiento, la fecha se asigna automáticamente al día de hoy
            movimiento.FechaMovimiento = DateTime.Now;
            _context.Movimientos.Add(movimiento);
            await _context.SaveChangesAsync();
            return Ok(movimiento);
        }
    }
}