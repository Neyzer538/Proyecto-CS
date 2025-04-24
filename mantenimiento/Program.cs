using mantenimiento.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agrega DbContext con MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

// Agrega servicios de Razor Pages y Controladores
builder.Services.AddRazorPages();
builder.Services.AddControllers(); // ?? Importante para APIs

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mapea rutas de Razor Pages y APIs
app.MapRazorPages();
app.MapControllers(); // ?? Esto activa tus rutas de API (como /api/servicios)

app.Run();
