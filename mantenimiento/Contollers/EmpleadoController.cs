using Microsoft.AspNetCore.Mvc;
using mantenimiento.Models;
using mantenimiento.Data;
using mantenimiento.Services;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net; 

namespace mantenimiento.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly AuthService _authService;

        public EmpleadoController(AppDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        // GET: api/Empleado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleado()
        {
            return await _context.Empleados.ToListAsync();
        }

        // GET: api/Empleado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var detalle = await _context.Empleados.FindAsync(id);
            if (detalle == null)
                return NotFound();

            return detalle;
        }

        // POST: api/Empleado 
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado([FromBody]  Empleado empleado)
        {
            empleado.Contrasenia = BCrypt.Net.BCrypt.HashPassword(empleado.Contrasenia);
            empleado.RolIdRol = empleado.IdRol;
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.IdEmpleado }, empleado);
        }

        // PUT: api/Empleado/5 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            var empleadoExistente = await _context.Empleados.AsNoTracking().FirstOrDefaultAsync(e => e.IdEmpleado == id);
            if (empleadoExistente == null)
                return NotFound();

            if (!BCrypt.Net.BCrypt.Verify(empleadoExistente.Contrasenia, empleadoExistente.Contrasenia) &&
                !BCrypt.Net.BCrypt.Verify(empleado.Contrasenia, empleadoExistente.Contrasenia))
            {
                empleado.Contrasenia = BCrypt.Net.BCrypt.HashPassword(empleado.Contrasenia);
            }
            else
            {
                empleado.Contrasenia = empleadoExistente.Contrasenia;
            }

            empleado.IdEmpleado = id;
            empleado.RolIdRol = empleado.IdRol;

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Empleados.Any(e => e.IdEmpleado == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Empleado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleados(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
                return NotFound();

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var empleado = await _authService.ValidarCredencialesAsync(request.Correo, request.Contrasenia);

            if (empleado == null)
                return Unauthorized(new { mensaje = "Correo o contraseña incorrectos" });

            return Ok(new
            {
                mensaje = "Login exitoso",
                empleado.IdEmpleado,
                empleado.Nombre,
                empleado.Correo,
                empleado.IdRol
            });
        }
    }
}
