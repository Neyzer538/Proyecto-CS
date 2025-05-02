using mantenimiento.Data;
using mantenimiento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mantenimiento.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParteController : Controller
    {
        private readonly AppDbContext _context;

        public ParteController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/parte
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parte>>> GetParte()
        {
            return await _context.Partes.ToListAsync();
        }

        //GET: api/parte/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parte>> GetParte(int id)
        {
            var parte = await _context.Partes.FindAsync(id);
            if (parte == null)

                return NotFound();

            return parte;
        }

        //POST: api/parte
        [HttpPost]
        public async Task<ActionResult<Parte>> PostEmpleado(Parte parte)
        {
            _context.Partes.Add(parte);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetParte), new { id = parte.Id }, parte);
        }

        //PUT: api/parte/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParte(int id, Parte parte)
        {
            if (id != parte.Id)

                return BadRequest();

            _context.Entry(parte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Partes.Any(e => e.Id == id))

                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        //DELETE: api/parte/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParte(int id)
        {
            var parte = await _context.Partes.FindAsync(id);
            if (parte == null)

                return NotFound();

            _context.Partes.Remove(parte);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
