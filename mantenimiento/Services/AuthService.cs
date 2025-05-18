using mantenimiento.Data;
using mantenimiento.Models;
using Microsoft.EntityFrameworkCore;

namespace mantenimiento.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Empleado?> ValidarCredencialesAsync(string correo, string contrasenia)
        {
            var empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.Correo == correo);

            if (empleado == null)
                return null;

            bool isValid = BCrypt.Net.BCrypt.Verify(contrasenia, empleado.Contrasenia);

            return isValid ? empleado : null;
        }
    }
}
