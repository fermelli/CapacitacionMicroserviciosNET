using Microsoft.EntityFrameworkCore;
using Pago.Datos;
using Pago.Persistencia;
using Pago.Servicios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<BaseDatosContexto>(
    opt =>
    {
        opt.UseMySQL(builder.Configuration["mysql:cn"]);
    }
);
builder.Services.AddScoped<IPagoService, PagoService>();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

BaseDatosCreada.CrearBaseDatosSinoExiste(app);

app.Run();
