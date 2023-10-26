using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;
using Aforo255.Cross.Event.Src;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pago.Datos;
using Pago.Mensajes.Comandos;
using Pago.Mensajes.ManejadoresComandos;
using Pago.Persistencia;
using Pago.Servicios;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<BaseDatosContexto>(
    opt =>
    {
        opt.UseMySQL(builder.Configuration["mysql:cn"]);
    }
);
builder.Services.AddScoped<IPagoService, PagoService>();
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
builder.Services.AddRabbitMQ();
builder.Services.AddTransient<IRequestHandler<CrearPagoCommand, bool>, PagoCommandHandler>();
builder.Services.AddConsul();
builder.Services.AddFabio();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.UseConsul();

BaseDatosCreada.CrearBaseDatosSinoExiste(app);

app.Run();
