using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Token.Src;
using Microsoft.EntityFrameworkCore;
using Seguridad.Datos;
using Seguridad.Persistencia;
using Seguridad.Servicios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<BaseDatosContexto>(
    opt =>
    {
        opt.UseSqlServer(builder.Configuration["sql:cn"]);
    }
);
builder.Services.AddScoped<IAutenticacionService, AutenticacionService>();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("jwt"));
builder.Services.AddConsul();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.UseConsul();

BaseDatosCreada.CrearBaseDatosSiNoExiste(app);

app.Run();
