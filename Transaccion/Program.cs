using Carter;
using Transaccion.Persistencia;
using Transaccion.Persistencia.Configuraciones;
using Transaccion.Servicios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.Configure<BaseDatosMongoConfiguraciones>(opt =>
{
    opt.Conexion = builder.Configuration.GetSection("mongo:cn").Value;
    opt.NombreBaseDatos = builder.Configuration.GetSection("mongo:database").Value;
});
builder.Services.AddScoped<ITransaccionService, TransaccionService>();
builder.Services.AddScoped<IBaseDatosMongoContexto, BaseDatosMongoContexto>();

var app = builder.Build();

app.MapCarter();
app.Run();
