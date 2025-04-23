using Mantenimiento_Vehiculos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mantenimiento_Vehiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomovilesController : ControllerBase
    {
        private readonly AutomovilesContext _automovilesContext;

        public AutomovilesController(AutomovilesContext automovilesContext)
        {
            _automovilesContext = automovilesContext;
        }

        // Get : api/Automoviles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Automoviles>>> GetAutomoviles()
        {
            if (_automovilesContext.Automoviles == null)
            {
                return NotFound();
            }
            return await _automovilesContext.Automoviles.ToListAsync();
        }

        // Get : api/Automoviles/2
        [HttpGet("{id}")] 
        public async Task<ActionResult<Automoviles>> GetAutomoviles(int id)
        {
            if (_automovilesContext.Automoviles is null)
            {
                return BadRequest();
            }
            var automovil = await _automovilesContext.Automoviles.FindAsync(id);
            if (automovil is null)
            {
                return NotFound();
            }
            return automovil;
        }
    }
}
