using Microsoft.AspNetCore.Mvc;
using mantenimiento.Models;
using mantenimiento.Data;
using Microsoft.EntityFrameworkCore;

namespace mantenimiento.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleOrdenController : Controller
    {
        private readonly AppDbContext _context;

        public DetalleOrdenController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/detalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleOrden>>> GetDetalleOrden()
        {
            return await _context.DetallesOrdenes.ToListAsync();
        }

        //GET: api/detalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleOrden>> GetDetalleOrden(int id)
        {
            var detalle = await _context.DetallesOrdenes.FindAsync(id);
            if (detalle == null)
            
                return NotFound();
            
            return detalle;
        }

        //POST: api/detalle
        [HttpPost]
        public async Task<ActionResult<DetalleOrden>> PostDetalleOrden(DetalleOrden detalleOrden)
        {
            _context.DetallesOrdenes.Add(detalleOrden);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDetalleOrden), new { IdDetalleOrden = detalleOrden.IdDetalleOrden}, detalleOrden);
        }

        //PUT: api/detalle/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleOrden(int id, DetalleOrden detalleOrden)
        {

            detalleOrden.IdDetalleOrden = id;
            
            _context.Entry(detalleOrden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.DetallesOrdenes.Any(e => e.IdDetalleOrden == id))

                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        //DELETE: api/detalle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleOrden(int id)
        {
            var detalle = await _context.DetallesOrdenes.FindAsync(id);
            if (detalle == null)

                return NotFound();
            
            _context.DetallesOrdenes.Remove(detalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
