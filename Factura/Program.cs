using Factura.Datos;
using Factura.Persistencia;
using Factura.Servicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<BaseDatosContexto>(
    opt =>
    {
        opt.UseNpgsql(builder.Configuration["postgres:cn"]);
    }
);
builder.Services.AddScoped<IFacturaService, FacturaService>();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

BaseDatosInicializada.CrearBaseDatosSinoExiste(app);

app.Run();