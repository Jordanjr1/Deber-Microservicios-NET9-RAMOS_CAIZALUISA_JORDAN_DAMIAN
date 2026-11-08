using Inventario.Api.Data;
using Inventario.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public StocksController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()
        {
            return await _context.Stocks.Include(s => s.Bodega).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetStock(int id)
        {
            var stock = await _context.Stocks.Include(s => s.Bodega)
                                             .FirstOrDefaultAsync(s => s.IdStock == id);
            if (stock == null) return NotFound();
            return stock;
        }

        [HttpPost]
        public async Task<ActionResult<Stock>> PostStock(Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStock), new { id = stock.IdStock }, stock);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock(int id, Stock stock)
        {
            if (id != stock.IdStock) return BadRequest();
            _context.Entry(stock).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}