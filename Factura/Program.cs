using Aforo255.Cross.Event.Src.Bus;
using Aforo255.Cross.Event.Src;
using Factura.Datos;
using Factura.Mensajes.Eventos;
using Factura.Persistencia;
using Factura.Servicios;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Factura.Mensajes.ManejadoresEventos;
using Aforo255.Cross.Discovery.Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<BaseDatosContexto>(
    opt =>
    {
        opt.UseNpgsql(builder.Configuration["postgres:cn"]);
    }
);
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddRabbitMQ();
builder.Services.AddTransient<PagoCreadoEventHandler>();
builder.Services.AddTransient<IEventHandler<PagoCreadoEvent>, PagoCreadoEventHandler>();
builder.Services.AddConsul();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.UseConsul();

BaseDatosInicializada.CrearBaseDatosSinoExiste(app);

ConfigurarEventBus(app);

app.Run();

void ConfigurarEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

    eventBus.Subscribe<PagoCreadoEvent, PagoCreadoEventHandler>();
}