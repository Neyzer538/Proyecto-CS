using mantenimiento.Data;
using mantenimiento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mantenimiento.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenParteController : Controller
    {
        private readonly AppDbContext _context;

        public OrdenParteController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/ordenparte
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenParte>>> GetOrdenParte()
        {
            return await _context.OrdenesPartes.ToListAsync();
        }

        //GET: api/ordenparte/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenParte>> GetOrdenParte(int id)
        {
            var ordenParte = await _context.OrdenesPartes.FindAsync(id);
            if (ordenParte == null)

                return NotFound();

            return ordenParte;
        }

        //POST: api/ordenparte
        [HttpPost]
        public async Task<ActionResult<OrdenParte>> PostEmpleado(OrdenParte ordenParte)
        {
            _context.OrdenesPartes.Add(ordenParte);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrdenParte), new { IdOrdenParte = ordenParte.IdOrdenParte }, ordenParte);
        }

        //PUT: api/ordenparte/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenParte(int id, OrdenParte ordenParte)
        {
            if (id != ordenParte.IdOrdenParte)

                return BadRequest();

            _context.Entry(ordenParte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.OrdenesPartes.Any(e => e.IdOrdenParte == id))

                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        //DELETE: api/ordenparte/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenParte(int id)
        {
            var ordenParte = await _context.OrdenesPartes.FindAsync(id);
            if (ordenParte == null)

                return NotFound();

            _context.OrdenesPartes.Remove(ordenParte);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
