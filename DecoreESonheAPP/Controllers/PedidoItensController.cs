using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DecoreESonheAPP.Data;
using DecoreESonheAPP.Models;

namespace DecoreESonheAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoItensController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PedidoItensController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PedidoItens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoItem>>> GetPedidoItens()
        {
            return await _context.PedidoItens.ToListAsync();
        }

        // GET: api/PedidoItens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoItem>> GetPedidoItem(int id)
        {
            var pedidoItem = await _context.PedidoItens.FindAsync(id);

            if (pedidoItem == null)
            {
                return NotFound();
            }

            return pedidoItem;
        }

        // PUT: api/PedidoItens/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoItem(int id, PedidoItem pedidoItem)
        {
            if (id != pedidoItem.Identificador)
            {
                return BadRequest();
            }

            _context.Entry(pedidoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PedidoItens
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PedidoItem>> PostPedidoItem(PedidoItem pedidoItem)
        {
            _context.PedidoItens.Add(pedidoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidoItem", new { id = pedidoItem.Identificador }, pedidoItem);
        }

        // DELETE: api/PedidoItens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PedidoItem>> DeletePedidoItem(int id)
        {
            var pedidoItem = await _context.PedidoItens.FindAsync(id);
            if (pedidoItem == null)
            {
                return NotFound();
            }

            _context.PedidoItens.Remove(pedidoItem);
            await _context.SaveChangesAsync();

            return pedidoItem;
        }

        private bool PedidoItemExists(int id)
        {
            return _context.PedidoItens.Any(e => e.Identificador == id);
        }
    }
}
