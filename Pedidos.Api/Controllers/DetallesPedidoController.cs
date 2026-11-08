using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.Api.Data;
using Pedidos.Api.Models;

namespace Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesPedidoController : ControllerBase
    {
        private readonly PedidosDbContext _context;

        public DetallesPedidoController(PedidosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetDetalles()
        {
            return await _context.Detalles.Include(d => d.Pedido).ToListAsync();
        }

        [HttpGet("PorPedido/{idPedido}")]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetDetallesPorPedido(int idPedido)
        {
            // Busca todos los detalles que pertenezcan a un número de pedido específico
            return await _context.Detalles.Include(d => d.Pedido)
                                          .Where(d => d.IdPedido == idPedido)
                                          .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<DetallePedido>> PostDetallePedido(DetallePedido detallePedido)
        {
            _context.Detalles.Add(detallePedido);
            await _context.SaveChangesAsync();
            return Ok(detallePedido);
        }
    }
}