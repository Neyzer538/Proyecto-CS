using mantenimiento.Data;
using mantenimiento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mantenimiento.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : Controller
    {
        private readonly AppDbContext _context;

        public OrdenController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/orden
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orden>>> GetOrden()
        {
            var ordenes = await _context.Ordenes
                .Include(o => o.Vehiculo)
                .Include(o => o.Empleado)
                .Include(o => o.Pago)
                .Include(o => o.Detalles)
                .Include(o => o.Partes)
                .ToListAsync();

            return ordenes;
        }

        //GET: api/orden/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orden>> GetOrden(int id)
        {
            var orden = await _context.Ordenes
                .Include(o => o.Vehiculo)
                .Include(o => o.Empleado)
                .Include(o => o.Pago)
                .Include(o => o.Detalles)
                .Include(o => o.Partes)
                .FirstOrDefaultAsync(o => o.IdOrden == id);

            if (orden == null)
                return NotFound();

            return orden;
        }

        //POST: api/orden
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostOrden(Orden orden)
        {
            _context.Ordenes.Add(orden);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrden), new { IdOrden = orden.IdOrden }, orden);
        }

        //PUT: api/orden/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Orden orden)
        {
           
            orden.IdOrden = id;

            _context.Entry(orden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Ordenes.Any(e => e.IdOrden == id))

                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        //DELETE: api/orden/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrden(int id)
        {
            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null)

                return NotFound();

            _context.Ordenes.Remove(orden);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
