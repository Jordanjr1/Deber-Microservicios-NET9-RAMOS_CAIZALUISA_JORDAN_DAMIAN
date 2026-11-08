using Inventario.Api.Data;
using Inventario.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExistenciasController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public ExistenciasController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Existencia>>> GetExistencias()
        {
            return await _context.Existencias.ToListAsync();
        }

        [HttpGet("{idProducto}")]
        public async Task<ActionResult<Existencia>> GetExistenciaPorProducto(int idProducto)
        {
            // Este endpoint es clave: buscará cuánta existencia hay de un Producto específico
            var existencia = await _context.Existencias
                                           .FirstOrDefaultAsync(e => e.IdProducto == idProducto);
            if (existencia == null) return NotFound();
            return existencia;
        }

        [HttpPost]
        public async Task<ActionResult<Existencia>> PostExistencia(Existencia existencia)
        {
            _context.Existencias.Add(existencia);
            await _context.SaveChangesAsync();
            return Ok(existencia);
        }
    }
}